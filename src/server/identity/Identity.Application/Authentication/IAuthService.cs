namespace Identity.Application.Authentication;

public interface IAuthService
{
    Task<ServiceResponse<AccessToken>> SignInAsync(string email, string password, bool isPersistent, bool lockOutFailure);
    Task<ServiceResponse> UpdatePassword(UpdatePasswordRequestModel updatePasswordRequestModel);

    Task<ServiceResponse> IForgotMyPassword(ResetPasswordRequestModel resetPasswordRequest);
}
