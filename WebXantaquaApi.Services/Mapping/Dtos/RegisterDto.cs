using System.ComponentModel.DataAnnotations;

namespace WebXantaquaApi.Services.Mapping.Dtos
{
    public class RegisterDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Phone(ErrorMessage = "Formato de telefone inválido.")]
        public string Phone { get; set; }

        [Required]
        public bool AgreedToTermsAndConditions { get; set; }

        public bool ConsentForAdvertising { get; set; }
    }
}
