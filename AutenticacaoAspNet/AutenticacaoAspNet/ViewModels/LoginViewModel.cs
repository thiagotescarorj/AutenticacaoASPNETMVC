using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutenticacaoAspNet.ViewModels
{
    public class LoginViewModel
    {
        public string UrlRetorno { get; set; }

        [Required(ErrorMessage = "Informe seu login")]
        [MaxLength(50, ErrorMessage = "O login deve ter até 50 caracteres")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a sua senha")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
    }
}