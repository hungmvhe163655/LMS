using AutoMapper;
using Contracts.Interfaces;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared;
using Shared.DataTransferObjects.RequestDTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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


        private Account? _account;
        public AuthenticationService(ILoggerManager logger, IMapper mapper, UserManager<Account> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _jwtConfiguration = new JwtConfiguration();
            _configuration.Bind(_jwtConfiguration.Section, _jwtConfiguration);
        }
        public async Task<IdentityResult> RegisterLabLead(RegisterRequestModel model)
        {
            try
            {
                var user = _mapper.Map<Account>(model);

                if (string.IsNullOrEmpty(model.VerifiedByUserName))
                {
                    return IdentityResult.Failed();
                }
               // var verifier = _userManager.FindByNameAsync(model.VerifiedByUserName);

               // if (verifier == null || verifier.Result == null) { return IdentityResult.Failed(); }

               // var verifierRole = _userManager.GetRolesAsync(verifier.Result).Result.FirstOrDefault();

               // if (verifierRole == null || !verifierRole.Equals("Teacher")) { return IdentityResult.Failed(); }

                if (string.IsNullOrEmpty(model.Password)) { return IdentityResult.Failed(); }

                var rolesToAdd = model.Roles != null ? model.Roles : null;

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

                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Errors.Any()) return result;
                    await _userManager.AddToRolesAsync(user, validRoles);

                    return result;
                }
                return IdentityResult.Failed();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(RegisterLabLead)}Error During Authentication Process has Occur for LabLead");

                _logger.LogError(ex.Message);
                
                return IdentityResult.Failed();
            }
        }
        public async Task<IdentityResult> RegisterSupervisor(RegisterRequestModel model)
        {
            try
            {
                var user = _mapper.Map<Account>(model);

                if (string.IsNullOrEmpty(model.VerifiedByUserName))
                {
                    return IdentityResult.Failed();
                }
                var verifier = _userManager.FindByNameAsync(model.VerifiedByUserName);

                if (verifier == null || verifier.Result == null) { return IdentityResult.Failed(); }

                var verifierRole = _userManager.GetRolesAsync(verifier.Result).Result.FirstOrDefault();

                if (verifierRole == null || !(verifierRole.Equals("LabLead")||verifierRole.Equals("Teacher"))) { return IdentityResult.Failed(); }// sua pham vi role o day

                if (string.IsNullOrEmpty(model.Password)) { return IdentityResult.Failed(); }

                var rolesToAdd = model.Roles != null ? model.Roles : null;

                var validRoles = new List<string>();

                if (rolesToAdd != null && rolesToAdd.Any()) foreach (var role in rolesToAdd)
                    {
                        if (await _roleManager.RoleExistsAsync(role))
                        {
                            validRoles.Add(role);
                        }
                        else
                        {
                            _logger.LogWarning($"{nameof(RegisterSupervisor)}Role '{role}' does not exist.");
                        }
                    }
                if (validRoles.Any())
                {
                    user.VerifiedBy = verifier.Result.Id;

                    var result = await _userManager.CreateAsync(user, model.Password);

                    await _userManager.AddToRolesAsync(user, validRoles);

                    return result;
                }
                return IdentityResult.Failed();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(RegisterSupervisor)}Error During Authentication Process has Occur for Teacher");
                _logger.LogError(ex.Message);
                return IdentityResult.Failed();
            }
        }
        public async Task<IdentityResult> RegisterStudent(RegisterRequestModel model)
        {
            try
            {
                var user = _mapper.Map<Account>(model);

                if (string.IsNullOrEmpty(model.VerifiedByUserName))
                {
                    return IdentityResult.Failed();
                }
                var verifier = _userManager.FindByNameAsync(model.VerifiedByUserName);

                if (verifier == null || verifier.Result == null) { return IdentityResult.Failed(); }

                var verifierRole = _userManager.GetRolesAsync(verifier.Result).Result.FirstOrDefault();

                if (verifierRole == null || !(verifierRole.Equals("LabLead") || verifierRole.Equals("Teacher"))) { return IdentityResult.Failed(); }

                if (string.IsNullOrEmpty(model.Password)) { return IdentityResult.Failed(); }

                var rolesToAdd = model.Roles != null ? model.Roles : null;

                var validRoles = new List<string>();

                if (rolesToAdd != null && rolesToAdd.Any()) foreach (var role in rolesToAdd)
                    {
                        if (await _roleManager.RoleExistsAsync(role))
                        {
                            validRoles.Add(role);
                        }
                        else
                        {
                            _logger.LogWarning($"{nameof(RegisterStudent)}Role '{role}' does not exist.");
                        }
                    }
                if (validRoles.Any())
                {
                    user.VerifiedBy = verifier.Result.Id;

                    var result = await _userManager.CreateAsync(user, model.Password);

                    await _userManager.AddToRolesAsync(user, validRoles);

                    return result;
                }
                return IdentityResult.Failed();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(RegisterStudent)}Error During Authentication Process has Occur for Student");
                _logger.LogError(ex.Message);
                return IdentityResult.Failed();
            }
        }
        //////////////////////////////////////// TOKEN AREA  -  DO NOT TOUCH  ///////////////////////////////////////////////////
        public async Task<bool> ValidateUser(LoginRequestModel userForAuth)
        {
            /// Tim nguoi dung trong he thong khong nhap ten thi authen loi log vao 
            if (string.IsNullOrEmpty(userForAuth.UserName) || string.IsNullOrEmpty(userForAuth.PassWord))
            {
                _logger.LogWarning($"{nameof(ValidateUser)}: Authentication failed. Empty user name or password");
                return false;
            }
            _account = await _userManager.FindByNameAsync(userForAuth.UserName);
            var result = (_account != null && await _userManager.CheckPasswordAsync(_account, userForAuth.PassWord));
            if (!result)
                _logger.LogWarning($"{nameof(ValidateUser)}: Authentication failed. Wrong user name or password.");
            return result;
        }
        public async Task<string> CreateToken()//onetime short token (khong gui ve refresh token)
        {
            /// phai setup secret truoc khi thuc hien Open CMD (as admin) => setx SECRET "MinhTC" /M
            var signingCredentials = GetSigningCredentials();
            if (signingCredentials.Key == null)
            {
                _logger.LogError($"{nameof(CreateToken)} Failed to find any valid Credential");
                return "NOT FOUND CREDENTIALS";
            }
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
        private SigningCredentials GetSigningCredentials()
        {
            /// phai setup secret truoc khi thuc hien Open CMD (as admin) => setx SECRET "MinhTC" /M
            var hold = Environment.GetEnvironmentVariable("SECRET");
            if (hold != null)
            {
                var key = Encoding.UTF8.GetBytes(hold);
                var secret = new SymmetricSecurityKey(key);
                return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
            }
            return new SigningCredentials(null, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims()
        {
            if (_account != null && string.IsNullOrEmpty(_account.UserName))
            {
                return null;
            }
            /// Tao claims khong co gi dac biet
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
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"))),
                ValidateLifetime = true,
                ValidIssuer = _jwtConfiguration.ValidIssuer,
                ValidAudience = _jwtConfiguration.ValidAudience
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out
           securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null ||
           !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
            StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }
        public async Task<TokenDTO> CreateToken(bool populateExp)//gui ve request token de duy tri dang nhap
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            var refreshToken = GenerateRefreshToken();
            _account.UserRefreshToken = refreshToken;
            if (populateExp)
                _account.UserRefreshTokenExpiryTime = DateTime.Now.AddDays(7);// them thoi gian cho refreshToken neu muon tuy
            await _userManager.UpdateAsync(_account);
            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new TokenDTO(accessToken, refreshToken);
        }
        public async Task<TokenDTO> RefreshToken(TokenDTO tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
            var user = await _userManager.FindByNameAsync(principal.Identity.Name);
            if (user == null || user.UserRefreshToken != tokenDto.RefreshToken ||
            user.UserRefreshTokenExpiryTime <= DateTime.Now)
                return null;
            _account = user;
            return await CreateToken(false);
        }
        public async Task<bool> InvalidateToken(TokenDTO tokenDTO)
        {
            try
            {
                var principal = GetPrincipalFromExpiredToken(tokenDTO.AccessToken);
                var user = await _userManager.FindByNameAsync(principal.Identity.Name);
                if(user==null) { return false; }
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
