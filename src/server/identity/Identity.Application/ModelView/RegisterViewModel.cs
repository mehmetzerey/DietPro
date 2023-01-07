using System.ComponentModel;

namespace Identity.Application.ModelView;
public class RegisterViewModel 
{
    [Required(ErrorMessage = "Ad zorunlu")]
    [DisplayName("Ad")]
    [StringLength(30)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Soyad zorunlu")]
    [DisplayName("Soyad")]
    [StringLength(30)]
    public string Surname { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email adresi zorunlu")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Şifre zorunlu")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Girmiş olduğunuz parola birbiri ile eşleşmiyor.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
