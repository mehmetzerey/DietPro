﻿// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IWriteUserRepository _writeUserRepository;
        private readonly IAuthService _authService;

        public AccountController(IWriteUserRepository writeUserRepository, IAuthService authService)
        {
            _writeUserRepository = writeUserRepository;
            _authService = authService;
        }

        // POST: api/<AccountController>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            #region Validate model
            if (!ModelState.IsValid)
            {
                var responseViewModel = new ServiceResponse();
                responseViewModel.IsSuccess = false;
                responseViewModel.Message = "Bilgileriniz eksik, bazı alanlar gönderilmemiş. Lütfen tüm alanları doldurunuz.";

                return BadRequest(responseViewModel);
            }
            #endregion

            var applicationUserModel = new ApplicationUser();
            applicationUserModel.Email = model.Email;
            applicationUserModel.Name = model.Name;
            applicationUserModel.Surname = model.Surname;
            applicationUserModel.UserName = model.Email;
            var result = await _writeUserRepository.AddUserAsync(applicationUserModel, model.Password);
            return Ok(result);

        }

        // POST api/<AccountController>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            #region Validate

            if (ModelState.IsValid == false)
            {
                var responseViewModel = new ServiceResponse();
                responseViewModel.IsSuccess = false;
                responseViewModel.Message = "Bilgileriniz eksik, bazı alanlar gönderilmemiş. Lütfen tüm alanları doldurunuz.";
                return BadRequest(responseViewModel);
            }
            #endregion
            var result = await _authService.SignInAsync(model.Email, model.Password, false, false);
            return Ok(result);
        }
    }
}
