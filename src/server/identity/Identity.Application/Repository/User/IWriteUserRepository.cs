namespace Identity.Application.Repository.User;

public interface IWriteUserRepository : IWriteRepository<ApplicationUser>
{
    Task<ServiceResponse> AddUserAsync(ApplicationUser user, string password);
}
