using AutoMapper;
using Contracts.Interfaces;
using Entities.ConfigurationModels;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared;
using Shared.DataTransferObjects;
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


        private readonly string _Secret;
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
            var hold = Environment.GetEnvironmentVariable("SECRET");
            _Secret = hold ?? "#";

        }

        public async Task<bool> VerifyEmail(string email, string token)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);

                var hold = (user != null && user.EmailVerifyCodeAge > DateTime.Now && !user.EmailConfirmed) ? user.EmailVerifyCode : null;

                if (hold != null)
                {
                    if (hold.Equals(token) && user != null)
                    {
                        user.EmailVerifyCode = null;

                        user.EmailVerifyCodeAge = DateTime.MinValue;

                        user.EmailConfirmed = true;

                       var result = await _userManager.UpdateAsync(user);
                        if (!result.Succeeded) throw new Exception("Internal Error");

                        return true;
                    }
                }
            }
            catch
            {
            }
            return false;
        }
        public async Task<IdentityResult> Register(RegisterRequestModel model)
        {
            {
                try
                {
                    var user = _mapper.Map<Account>(model);

                    if (string.IsNullOrEmpty(model.VerifiedByUserID))
                    {
                        return IdentityResult.Failed();
                    }
                    var verifier = _userManager.FindByIdAsync(model.VerifiedByUserID);

                    if (verifier == null || verifier.Result == null) { return IdentityResult.Failed(); }

                    var verifierRole = _userManager.GetRolesAsync(verifier.Result).Result.FirstOrDefault();

                    if (verifierRole == null || !(verifierRole.ToLower().Equals("labadmin") || verifierRole.ToLower().Equals("supervisor"))) { return IdentityResult.Failed(); }// sua pham vi role o day

                    if (string.IsNullOrEmpty(model.Password)) { return IdentityResult.Failed(); }

                    var rolesToAdd = model.Roles ?? null;

                    var validRoles = new List<string>();

                    if (rolesToAdd != null && rolesToAdd.Any()) foreach (var role in rolesToAdd)
                        {
                            if (await _roleManager.RoleExistsAsync(role))
                            {
                                validRoles.Add(role);
                            }
                            else
                            {
                                _logger.LogWarning($"{nameof(Register)}Role '{role}' does not exist.");
                            }
                        }
                    if (validRoles.Any())
                    {

                        user.VerifiedBy = verifier.Result.Id;

                        user.UserName = user.Id.ToString();

                        var result = await _userManager.CreateAsync(user, model.Password);

                        await _userManager.AddToRolesAsync(user, validRoles);

                        return result;
                    }
                    return IdentityResult.Failed();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{nameof(Register)}Error During Authentication Process has Occured");

                    _logger.LogError(ex.Message);

                    return IdentityResult.Failed();
                }
            }
        }
        public async Task<IdentityResult> RegisterLabLead(RegisterRequestModel model)
        {
            try
            {
                var user = _mapper.Map<Account>(model);

                /*
                if (string.IsNullOrEmpty(model.VerifiedByUserName))
                {
                    return IdentityResult.Failed();
                }
                */
                // var verifier = _userManager.FindByIdAsync(model.VerifiedByUserName);

                // if (verifier == null || verifier.Result == null) { return IdentityResult.Failed(); }

                // var verifierRole = _userManager.GetRolesAsync(verifier.Result).Result.FirstOrDefault();

                // if (verifierRole == null || !verifierRole.Equals("Teacher")) { return IdentityResult.Failed(); }

                if (string.IsNullOrEmpty(model.Password)) { return IdentityResult.Failed(); }

                var rolesToAdd = model.Roles ?? null;

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

                if (string.IsNullOrEmpty(model.VerifiedByUserID))
                {
                    return IdentityResult.Failed();
                }
                var verifier = _userManager.FindByIdAsync(model.VerifiedByUserID);

                if (verifier == null || verifier.Result == null) { return IdentityResult.Failed(); }

                var verifierRole = _userManager.GetRolesAsync(verifier.Result).Result.FirstOrDefault();

                if (verifierRole == null || !(verifierRole.ToLower().Equals("labadmin") || verifierRole.ToLower().Equals("supervisor"))) { return IdentityResult.Failed(); }// sua pham vi role o day

                if (string.IsNullOrEmpty(model.Password)) { return IdentityResult.Failed(); }

                var rolesToAdd = model.Roles ?? null;

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

                    user.UserName = user.Id.ToString();

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

                if (string.IsNullOrEmpty(model.VerifiedByUserID))
                {
                    return IdentityResult.Failed();
                }
                var verifier = _userManager.FindByIdAsync(model.VerifiedByUserID);

                if (verifier == null || verifier.Result == null) { return IdentityResult.Failed(); }

                var verifierRole = _userManager.GetRolesAsync(verifier.Result).Result.FirstOrDefault();

                if (verifierRole == null || !verifierRole.ToLower().Equals("labadmin") || verifierRole.ToLower().Equals("supervisor")) { return IdentityResult.Failed(); }

                if (string.IsNullOrEmpty(model.Password)) { return IdentityResult.Failed(); }

                var rolesToAdd = model.Roles ?? null;

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

                    user.UserName = user.Id.ToString();

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
        public async Task<string> ValidateUser(LoginRequestModel userForAuth)
        {
            /// Tim nguoi dung trong he thong khong nhap ten thi authen loi log vao 
            if (string.IsNullOrEmpty(userForAuth.Email) || string.IsNullOrEmpty(userForAuth.Password))
            {
                _logger.LogWarning($"{nameof(ValidateUser)}: Authentication failed. Empty Email or password");
                return "BADLOGIN|";
            }
            _account = await _userManager.FindByEmailAsync(userForAuth.Email);
            if(_account == null) return "BADLOGIN | INVALID EMAIL";
            var result = (await _userManager.CheckPasswordAsync(_account, userForAuth.Password));
            if (!result)
            {
                _logger.LogWarning($"{nameof(ValidateUser)}: Authentication failed. Wrong user name or password.");
                return "BADLOGIN | INCORRECT PASSWORD";
            }
            if (result && _account != null)
            {
                if (!_account.EmailConfirmed)
                {
                    return "UNVERIFIEDEMAIL|" + _account.UserName;
                }
                if (_account.IsBanned)
                {
                    return "ISBANNED|";
                }
                if (!_account.IsVerified)
                {
                    return "UNVERIFIED|" + _account.UserName;
                }
            }
            return "SUCCESS|";
        }
        public async Task<string> CreateToken()//onetime short token (khong gui ve refresh token)
        {
            /// phai setup secret truoc khi thuc hien Open CMD (as admin) => example setx SECRET "MINTCHE SUPER LONG KEY FOR JWT" /M
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
            var hold = _Secret;
            if (!hold.Equals("#"))
            {
                var key = Encoding.UTF8.GetBytes(hold);

                var secret = new SymmetricSecurityKey(key);

                return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

            }
            return new SigningCredentials(null, SecurityAlgorithms.HmacSha256);
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
                    _account.UserRefreshTokenExpiryTime = DateTime.Now.AddDays(7);// them thoi gian cho refreshToken neu muon tuy

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

                if (user == null || user.UserRefreshToken != tokenDto.RefreshToken ||
                user.UserRefreshTokenExpiryTime <= DateTime.Now)
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
