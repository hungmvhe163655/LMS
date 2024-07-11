using AutoMapper;
using Contracts.Interfaces;
using Entities.ConfigurationModels;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Service
{
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// Validate and Manage user token and user's account
        /// </summary>
        private readonly ILoggerManager _logger;

        private readonly IMapper _mapper;

        private readonly IConfiguration _configuration;

        private readonly JwtConfiguration _jwtConfiguration;

        private readonly UserManager<Account> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IRepositoryManager _repositoryManager;


        private readonly string _Secret;
        private Account? _account;
        public AuthenticationService(ILoggerManager logger, IMapper mapper, UserManager<Account> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager, IRepositoryManager repositoryManager)
        {
            _logger = logger;

            _mapper = mapper;

            _userManager = userManager;

            _configuration = configuration;

            _roleManager = roleManager;

            _jwtConfiguration = new JwtConfiguration();

            _configuration.Bind(_jwtConfiguration.Section, _jwtConfiguration);

            var hold = Environment.GetEnvironmentVariable("SECRET");

            _Secret = hold ?? throw new Exception("Failed to find variable for Secret");

            _repositoryManager = repositoryManager;
        }
        public async Task<AccountReturnModel> Register(RegisterRequestModel model)
        {
            var user = _mapper.Map<Account>(model);

            var verifier = await _userManager.FindByIdAsync(model.VerifiedByUserID);

            if (verifier == null) throw new BadRequestException("Invalid Verifier id");

            var verifierRole = await _userManager.GetRolesAsync(verifier);

            if (verifierRole == null || !(verifierRole.Contains("Supervisor") || (verifierRole.Contains("Labadmin"))))

                throw new BadRequestException("Verifier's not authorized");

            var rolesToAdd = model.Roles;

            var validRoles = new List<string>();

            if (rolesToAdd != null && rolesToAdd.Any())

                foreach (var role in model.Roles)

                    if (await _roleManager.RoleExistsAsync(role)) validRoles.Add(role);

            if (validRoles.Any())
            {
                user.EmailConfirmed = true;

                user.VerifiedBy = verifier.Id;

                user.UserName = model.RollNumber ?? user.Id.ToString();

                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));

                    throw new BadRequestException($"Add user failed: {errors}");
                }

                var result2 = await _userManager.AddToRolesAsync(user, validRoles);

                if (!result2.Succeeded)
                {
                    var errors2 = string.Join(", ", result2.Errors.Select(e => e.Description));

                    throw new BadRequestException($"Add user failed: {errors2}");
                }

                user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null) throw new Exception("Errors occurs during the registing process");

                var hold = model.Roles.Contains("Student") ? new StudentDetail { AccountId = user.Id, RollNumber = model.RollNumber } : null;

                if (hold != null)
                {
                    _repositoryManager.studentDetail.Create(hold);

                    await _repositoryManager.Save();
                }

                return _mapper.Map<AccountReturnModel>(user);
            }
            throw new BadRequestException("Not valid roles");
        }
        public async Task<AccountReturnModel> RegisterLabLead(RegisterRequestModel model)
        {
            var user = _mapper.Map<Account>(model);

            var rolesToAdd = model.Roles;

            var validRoles = new List<string>();

            if (rolesToAdd != null && rolesToAdd.Any()) foreach (var role in rolesToAdd)
                {
                    if (await _roleManager.RoleExistsAsync(role))
                    {
                        validRoles.Add(role);
                    }
                    else
                    {
                        _logger.LogWarning($"{nameof(RegisterLabLead)}Role '{role}' does not exist.");
                    }
                }
            if (validRoles.Any())
            {
                user.VerifiedBy = null;

                user.UserName = model.Email;

                var result = await _userManager.CreateAsync(user, model.Password);

                await _userManager.AddToRolesAsync(user, validRoles);

                user = await _userManager.FindByEmailAsync(model.Email);

                return _mapper.Map<AccountReturnModel>(user);
            }
            throw new BadRequestException("Not valid roles");
        }
        public async Task<string> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) throw new BadRequestException("Invalid Email");

            string password = GeneratePassword(12);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            await _userManager.ResetPasswordAsync(user, token, password);

            return password;
        }
        private string GeneratePassword(int length)
        {
            Random random = new Random();

            const string UpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            const string LowerCase = "abcdefghijklmnopqrstuvwxyz";

            const string Digits = "0123456789";

            const string NonAlphanumeric = "!@#$%^&*()-_=+[]{}|;:'\",.<>?";

            if (length < 12) throw new ArgumentException("Password length must be at least 12 characters.");

            var password = new StringBuilder();

            password.Append(UpperCase[random.Next(UpperCase.Length)]);

            password.Append(LowerCase[random.Next(LowerCase.Length)]);

            password.Append(Digits[random.Next(Digits.Length)]);

            password.Append(NonAlphanumeric[random.Next(NonAlphanumeric.Length)]);

            var allCharacters = UpperCase + LowerCase + Digits + NonAlphanumeric;

            for (int i = 4; i < length; i++) password.Append(allCharacters[random.Next(allCharacters.Length)]);

            return new string(password.ToString().OrderBy(c => random.Next()).ToArray());

        }
        //////////////////////////////////////// TOKEN AREA  -  DO NOT TOUCH  ///////////////////////////////////////////////////
        public async Task<HiddenAccountResponseModel> ValidateUser(LoginRequestModel userForAuth)
        {
            /// Tim nguoi dung trong he thong khong nhap ten thi authen loi log vao 
            if (string.IsNullOrEmpty(userForAuth.Email) || string.IsNullOrEmpty(userForAuth.Password))
            {
                _logger.LogWarning($"{nameof(ValidateUser)}: Authentication failed. Empty Email or password");

                return new HiddenAccountResponseModel { Message = "BADLOGIN|Empty Email or password" };
            }
            _account = await _userManager.FindByEmailAsync(userForAuth.Email);

            if (_account == null) return new HiddenAccountResponseModel { Message = "BADLOGIN|INVALID EMAIL" };

            var result = (await _userManager.CheckPasswordAsync(_account, userForAuth.Password));

            if (!result)
            {
                _logger.LogWarning($"{nameof(ValidateUser)}: Authentication failed. Wrong user name or password.");

                return new HiddenAccountResponseModel { Message = "BADLOGIN|INCORRECT PASSWORD" };
            }
            if (result && _account != null)
            {
                if (_account.IsDeleted)
                {
                    return new HiddenAccountResponseModel { AccountId = _account.Id, VerifierId = _account.VerifiedBy ?? "", Message = $"DELETED|{_account.UserName}" };
                }
                else
                if (!_account.IsVerified)
                {
                    return new HiddenAccountResponseModel { AccountId = _account.Id, VerifierId = _account.VerifiedBy ?? "", Message = $"UNVERIFIED|{_account.UserName}" };
                }
                else
                if (_account.IsBanned)
                {
                    return new HiddenAccountResponseModel { AccountId = _account.Id, VerifierId = _account.VerifiedBy ?? "", Message = $"ISBANNED|{_account.UserName}" };
                }
                return new HiddenAccountResponseModel { AccountId = _account.Id, VerifierId = _account.VerifiedBy ?? "", Message = "SUCCESS|" + (_account != null && _account.TwoFactorEnabled ? "TWOFACTOR" : "ONEFACTOR") };
            }
            throw new BadRequestException("NOT FOUND ACCOUNT OR INCORRECT PASSWORD");
        }
        public async Task<string> CreateToken()//onetime short token (khong gui ve refresh token)
        {
            /// phai setup secret truoc khi thuc hien Open CMD (as admin) => example setx SECRET "MINTCHE SUPER LONG KEY FOR JWT" /M
            var signingCredentials = GetSigningCredentials();

            if (signingCredentials.Key == null)
            {
                _logger.LogError($"{nameof(CreateToken)} Failed to find any valid Credential");

                throw new Exception("Failed to find variables");
            }
            var claims = await GetClaims();

            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
        private SigningCredentials GetSigningCredentials()
        {
            /// phai setup secret truoc khi thuc hien Open CMD (as admin) => setx SECRET "MinhTC" /M
            var hold = _Secret;

            var key = Encoding.UTF8.GetBytes(hold);

            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims()
        {
            try
            {
                /// Tao claims khong co gi dac biet
                if (_account != null && _account.UserName != null)
                {
                    var claims = new List<Claim>
                     {
                     new Claim(ClaimTypes.Name, _account.UserName)
                     };
                    var roles = await _userManager.GetRolesAsync(_account);

                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                    return claims;
                }
            }
            catch
            {
                throw;
            }
            return new List<Claim>();
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            /// Theo config cua appsettings
            var tokenOptions = new JwtSecurityToken
            (
            issuer: _jwtConfiguration.ValidIssuer,
            audience: _jwtConfiguration.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfiguration.Expires)),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_Secret)),
                ValidateLifetime = true,
                ValidIssuer = _jwtConfiguration.ValidIssuer,
                ValidAudience = _jwtConfiguration.ValidAudience
            };
            var tokenHandler = new JwtSecurityTokenHandler();


            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
           !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
            StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }
        public async Task<TokenDTO> CreateToken(bool populateExp)//gui ve request token de duy tri dang nhap
        {
            if (_account != null)
            {
                var signingCredentials = GetSigningCredentials();

                var claims = await GetClaims();

                var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

                var refreshToken = GenerateRefreshToken();

                _account.UserRefreshToken = refreshToken;

                if (populateExp)
                    _account.UserRefreshTokenExpiryTime = DateTime.Now.AddDays(1);// them thoi gian cho refreshToken neu muon tuy

                await _userManager.UpdateAsync(_account);

                var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return new TokenDTO(accessToken, refreshToken);
            }
            else
            {
                return new TokenDTO("Notfound", "NotFound");
            }

        }
        public async Task<TokenDTO> RefreshTokens(TokenDTO tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);

            if (principal.Identity != null && principal.Identity.Name != null)
            {
                var user = await _userManager.FindByNameAsync(principal.Identity.Name);

                if (user == null || user.UserRefreshToken != tokenDto.RefreshToken || user.UserRefreshTokenExpiryTime <= DateTime.Now)
                    return new TokenDTO("Not Found", "Not Found");

                _account = user;

                return await CreateToken(false);
            }
            return new TokenDTO("Not Found", "Not Found");
        }
        public async Task<bool> InvalidateToken(TokenDTO tokenDTO)//logout logic
        {
            try
            {
                var principal = GetPrincipalFromExpiredToken(tokenDTO.AccessToken);

                if (principal.Identity == null || principal.Identity.Name == null) return false;

                var user = await _userManager.FindByNameAsync(principal.Identity.Name);

                if (user == null) { return false; }

                user.UserRefreshToken = null;

                user.UserRefreshTokenExpiryTime = DateTime.MinValue;

                await _userManager.UpdateAsync(user);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal error happened at {nameof(InvalidateToken)}: {ex.Message}");
            }
            return false;
        }
        //////////////////////////////////////// TOKEN AREA  -  END OF AREA  ///////////////////////////////////////////////////

    }
}