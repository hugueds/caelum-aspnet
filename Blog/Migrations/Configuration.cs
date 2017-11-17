namespace Blog.Migrations
{
    using Blog.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.Models.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Blog.Models.BlogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("admin");
            Usuario usuarioAdmin = new Usuario()
            {
                UserName = "admin",
                PasswordHash = password,
                UltimoLogin = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            context.Users.AddOrUpdate(u => u.UserName, usuarioAdmin);
        }
    }

    //protected override void Seed(BlogContext context)
    //{
    
    //}
}
