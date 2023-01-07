namespace Identity.Infrastructure.Repository.User;

public class WriteUserRepository : WriteRepository<ApplicationUser>, IWriteUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public WriteUserRepository(AppIdentityDbContext appIdentity, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) : base(appIdentity)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<ServiceResponse> AddUserAsync(ApplicationUser user, string password)
    {
        var responseViewModel = new ServiceResponse();
        var existsUser = await _userManager.FindByNameAsync(user.Email);
        if (existsUser == null)
        {
            var result = await _userManager.CreateAsync(user, password.Trim());
            if (result.Succeeded)
            {
                bool roleExists = await _roleManager.RoleExistsAsync(RoleEnum.Member.Name);

                if (!roleExists)
                {
                    IdentityRole role = new IdentityRole(RoleEnum.Member.Name);
                    role.NormalizedName = RoleEnum.Member.Name;

                    _roleManager.CreateAsync(role).Wait();
                }

                //Kullanıcıya ilgili rol ataması yapılır.
                _userManager.AddToRoleAsync(user, RoleEnum.Member.Name).Wait();

                responseViewModel.IsSuccess = true;
                responseViewModel.Message = "Kullanıcı başarılı şekilde oluşturuldu.";
            }
            else
            {
                responseViewModel.IsSuccess = false;
                responseViewModel.Message = string.Format("Kullanıcı oluşturulurken bir hata oluştu: {0}", string.Join(", ", result.Errors.Select(x => x.Description)));
            }
        }

        return responseViewModel;
    }

}

