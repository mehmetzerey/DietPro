namespace Identity.Application.ModelView;

public class UpdatePasswordRequestModel
{
    public string Password { get; set; }
    public string userId { get; set; }
    public string token { get; set; }
}
