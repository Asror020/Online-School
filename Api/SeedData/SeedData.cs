using Core.Entities;
using DAL.Contexts;

namespace Api.SeedData
{
    public static class SeedData
    {
        public static void AddSeedUsers(this IServiceProvider serviceProvider)
        {
            var hostEnvironment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (dbContext.Users.Any()) return;

            dbContext.Users.AddRange(new[]
            {
                new User
                {
                    FirstName = "Bob",
                    LastName = "Bob",
                    PhoneNumber = "+998901110022",
                    DateOfBirth = DateTime.ParseExact("30/12/2011", "dd/MM/yyyy", null),
                    Email = "bob@gmail.com",
                    Password = "Pa$$w0rd"
                },
                new User
                {
                    FirstName = "Alice",
                    LastName = "Alice",
                    PhoneNumber = "+998910003311",
                    DateOfBirth = DateTime.ParseExact("30/12/2011", "dd/MM/yyyy", null),
                    Email = "alice@gmail.com",
                    Password = "Pa$$w0rd"
                }
            });
            dbContext.SaveChanges();
        }
    }
}
