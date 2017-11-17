using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Post { get; set; }


        public BlogContext() : base("name = blog") { }


    }
}