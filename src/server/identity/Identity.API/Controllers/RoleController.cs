// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Identity.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IWriteRoleRepository _roleRepository;

    public RoleController(IWriteRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    // POST api/<RoleController>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoleRequestViewModel createRoleRequest)
    {
        if (ModelState.IsValid == false)
        {
            return BadRequest(ModelState);
        }
        return Ok(await _roleRepository.AddRoleAsync(createRoleRequest.Role));
    }
}
