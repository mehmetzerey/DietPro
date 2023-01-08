namespace Identity.Infrastructure.Authentication;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IReadUserRepository _readUserRepository;
    private readonly IConfiguration _configuration;
    public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, IReadUserRepository readUserRepository)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _readUserRepository = readUserRepository;
    }

    public async Task<ServiceResponse> IForgotMyPassword(ResetPasswordRequestModel resetPasswordRequest)
    {
        var response = new ServiceResponse();

        var user = await _userManager.FindByEmailAsync(resetPasswordRequest.Email);
        if (user != null)
        {
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            string confirmationLink = $"/Account/UpdatePassword/userId={user.Id}&token={resetToken}";

            response.IsSuccess = true;
            response.Message = confirmationLink;
        }
        else
        {
            response.IsSuccess = false;
            response.Error = "Kullanıcı bulunamadı";
        }
        return response;
    }

    public async Task<ServiceResponse<AccessToken>> SignInAsync(string email, string password, bool isPersistent, bool lockOutFailure)
    {
        var response = new ServiceResponse<AccessToken>();
        response.Data = new AccessToken();
        var findUser = await _userManager.FindByNameAsync(email);

        if (findUser == null)
        {
            response.Message = "Kullanıcı bulunamadı";
            response.IsSuccess = false;
            return response;
        }

        var userRoles = await _userManager.GetRolesAsync(findUser);
        if (userRoles.Count == 0)
        {
            response.Message = "Kullanıcı rolü bulunamadı";
            response.IsSuccess = false;
            return response;
        }

        var signInResult = await _signInManager.PasswordSignInAsync(findUser, password, isPersistent, lockOutFailure);
        //Kullanıcı adı ve şifre kontrolü
        if (signInResult.Succeeded == false)
        {
            response.Message = "Giriş bilgileri hatalı";
            response.IsSuccess = false;
            return response;
        }
        else
        {

            var authClaims = GetClaimsFromUser(findUser);

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = GetToken(authClaims);
            response.Data.Token = new JwtSecurityTokenHandler().WriteToken(token);
            response.Data.Expiration = token.ValidTo;
            response.IsSuccess = true;
            response.Message = "Oturum açma başarılı";
            return response;
        }


    }

    // todo: mail servisi entegre et ve  şifre sıfırlama maili gönder
    // mailden token ve diğer bilgiler dönecek ona göre aksiyon alınacak
    public async Task<ServiceResponse> UpdatePassword(UpdatePasswordRequestModel updatePasswordRequestModel)
    {
        var response = new ServiceResponse();
        var user = await _userManager.FindByIdAsync(updatePasswordRequestModel.userId);
        var result = await _userManager.ResetPasswordAsync(user, updatePasswordRequestModel.token, updatePasswordRequestModel.Password);
        if (result.Succeeded)
        {
            await _userManager.UpdateSecurityStampAsync(user);
            response.IsSuccess = true;
            response.Message = "Şifre güncellendi.";
        }
        else
        {
            response.Error = "Şifre güncellenirken hata oluştu";
            response.IsSuccess = false;
        }

        return response;
    }


    private List<Claim> GetClaimsFromUser(ApplicationUser user)
    {
        var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Subject, user.Id),
                new Claim(JwtClaimTypes.PreferredUserName, user.UserName),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

        if (!string.IsNullOrWhiteSpace(user.Name))
            claims.Add(new Claim("name", user.Name));

        if (!string.IsNullOrWhiteSpace(user.Surname))
            claims.Add(new Claim("last_name", user.Surname));

        if (_userManager.SupportsUserEmail)
        {
            claims.AddRange(new[]
            {
                    new Claim(JwtClaimTypes.Email, user.Email),
                    new Claim(JwtClaimTypes.EmailVerified, user.EmailConfirmed ? "true" : "false", ClaimValueTypes.Boolean)
                });
        }

        if (_userManager.SupportsUserPhoneNumber && !string.IsNullOrWhiteSpace(user.PhoneNumber))
        {
            claims.AddRange(new[]
                {
                    new Claim(JwtClaimTypes.PhoneNumber, user.PhoneNumber),
                    new Claim(JwtClaimTypes.PhoneNumberVerified, user.PhoneNumberConfirmed ? "true" : "false", ClaimValueTypes.Boolean)
                });
        }

        return claims;
    }

    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Application:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["Application:ValidIssuer"],
            audience: _configuration["Application:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

        return token;
    }
}

