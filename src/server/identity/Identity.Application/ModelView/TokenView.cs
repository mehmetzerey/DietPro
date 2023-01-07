namespace Identity.Application.ModelView;

public class TokenView
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpireDate { get; set; }
}
