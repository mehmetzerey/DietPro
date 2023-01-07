namespace Identity.Domain.Models;

public class ApplicationUserToken : IdentityUserToken<string>
{
    public DateTime ExpireDate { get; set; }
}
