using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Usuario : IdentityUser
    {        
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime UltimoLogin { get; internal set; }
    }
}