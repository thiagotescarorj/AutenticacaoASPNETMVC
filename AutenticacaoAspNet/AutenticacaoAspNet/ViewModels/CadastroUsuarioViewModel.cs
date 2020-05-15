using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutenticacaoAspNet.ViewModels
{
    public class CadastroUsuarioViewModel
    {
        [Required(ErrorMessage ="Informe seu nome")]
        [MaxLength(100, ErrorMessage ="O nome deve ter até 100 caracteres")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe seu login")]
        [MaxLength(50,ErrorMessage ="O login deve ter até 50 caracteres")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a sua senha")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirme a sua senha")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        [Compare(nameof(Senha), ErrorMessage ="A senha e a confirmação estão diferentes")]
        [Display(Name = "Confirmar Senha")]
        public string ConfirmacaoSenha { get; set; }
    }
}