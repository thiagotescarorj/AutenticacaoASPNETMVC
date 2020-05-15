using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutenticacaoAspNet.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="Nome")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
    }
}