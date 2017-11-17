protected override void Seed(Blog.Infras.BlogContext context)
{
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