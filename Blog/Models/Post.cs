using Blog.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        [Display(Name="Titulo")]        
        [Required(ErrorMessage ="Deu Ruim") ]
        public string Titulo { get; set;}
        [Required]
        public string Resumo { get; set; }
        public string Categoria { get; set; }
        public DateTime? Timestamp { get; set; }
        public bool Publicado { get; set; }
    }
}
