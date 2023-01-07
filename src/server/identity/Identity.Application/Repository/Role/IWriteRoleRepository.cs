namespace Identity.Application.Repository.Role;

public interface IWriteRoleRepository : IWriteRepository<ApplicationRole>
{
    Task<ServiceResponse> AddRoleAsync(string role);
}
