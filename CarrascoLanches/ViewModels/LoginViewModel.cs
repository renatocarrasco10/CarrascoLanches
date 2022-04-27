using System.ComponentModel.DataAnnotations;

namespace CarrascoLanches.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o Nome")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
