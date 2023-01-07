namespace Identity.Application.ModelView.RoleController;

public class CreateRoleRequestViewModel
{
    [Required]
    public string Role { get; set; } = string.Empty;
}
