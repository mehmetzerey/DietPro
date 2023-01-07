namespace Identity.Application.Repository.User;

public interface IReadUserRepository : IReadRepository<ApplicationUser>
{
    Task<ApplicationUser> FindByNameAsync(string userName);
    Task<ApplicationUser> FindByIdAsync(string userId);
    Task<ApplicationUser> FindByEmail(string email);
}
