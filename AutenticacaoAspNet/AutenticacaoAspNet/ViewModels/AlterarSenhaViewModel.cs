using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutenticacaoAspNet.ViewModels
{
    public class AlterarSenhaViewModel
    {
        [Required(ErrorMessage = "Informa sua senha atual")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        [Display(Name = "Senha atual")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Informa sua nova senha")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        [Display(Name = "Nova Senha")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Confirme sua nova senha")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        [Display(Name = "Confirmar senha")]
        [Compare(nameof(NovaSenha), ErrorMessage = "A senha e a confirmação estão diferentes")]
        public string ConfirmacaoSenha { get; set; }
    }
}
