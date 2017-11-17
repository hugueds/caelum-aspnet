using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string LoginName { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password, ErrorMessage = "Senha Inválida!")]
        public string Senha { get; set; }
    }
}