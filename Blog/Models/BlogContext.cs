using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class BlogContext : IdentityDbContext<Usuario>
    {
        public DbSet<Post> Post { get; set; }


        public BlogContext() : base("name = blog") { }


    }
}