namespace Identity.Infrastructure.Repository.Role;

public class WriteRoleRepository : WriteRepository<ApplicationRole>, IWriteRoleRepository
{
    private readonly RoleManager<IdentityRole> _roleManager;
    public WriteRoleRepository(AppIdentityDbContext appIdentity, RoleManager<IdentityRole> roleManager) : base(appIdentity)
    {
        _roleManager = roleManager;
    }

    public async Task<ServiceResponse> AddRoleAsync(string role)
    {
        role = role.ToLower();
        var response = new ServiceResponse();
        bool roleExists = await _roleManager.RoleExistsAsync(role);

        if (!roleExists)
        {
            var createRole = new IdentityRole(role.ToLower());
            createRole.NormalizedName = role.ToUpper();

            _roleManager.CreateAsync(createRole).Wait();
            response.IsSuccess = true;
            response.Message = $"Rol oluşturuldu {role}";
        }
        else
        {
            response.IsSuccess = false;
            response.Message = $"{role} zaten kayıtlı";
        }
        return response;
    }
}
