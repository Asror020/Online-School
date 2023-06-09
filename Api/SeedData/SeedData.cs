using Core.Entities;
using DAL.Contexts;

namespace Api.SeedData
{
    public static class SeedData
    {
        public static void AddSeedData(this IServiceProvider serviceProvider)
        {
            var hostEnvironment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

            AddSeedUsers(dbContext);
            AddSeedStudents(dbContext);
            AddSeedProfessors(dbContext);
        }

        private static void AddSeedUsers(ApplicationDbContext dbContext)
        {
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

        private static void AddSeedStudents( ApplicationDbContext dbContext)
        {
            if (dbContext.Students.Any()) return;

            dbContext.Students.AddRange(new[]
            {
                new Student
                {
                    RegistrationId = "0001",
                    UserId = 1,
                    User = new User
                    {
                        FirstName = "Bob",
                        LastName = "Bob",
                        PhoneNumber = "+998901110022",
                        DateOfBirth = DateTime.ParseExact("30/12/2011", "dd/MM/yyyy", null),
                        Email = "bob@gmail.com",
                        Password = "Pa$$w0rd"
                    }
                },
                new Student
                {
                    RegistrationId = "0002",
                    UserId = 2,
                    User = new User
                    {
                        FirstName = "Alice",
                        LastName = "Alice",
                        PhoneNumber = "+998910003311",
                        DateOfBirth = DateTime.ParseExact("30/12/2011", "dd/MM/yyyy", null),
                        Email = "alice@gmail.com",
                        Password = "Pa$$w0rd"
                    }
                }
            });

            dbContext.SaveChanges();
        }

        private static void AddSeedProfessors( ApplicationDbContext dbContext)
        {
            if (dbContext.Professors.Any()) return;

            dbContext.Professors.AddRange(new[]
            {
                new Professor
                {
                    UserId = 3,
                    User = new User
                    {
                        FirstName = "Bobur",
                        LastName = "Bobur",
                        PhoneNumber = "+998901110000",
                        DateOfBirth = DateTime.ParseExact("30/12/1995", "dd/MM/yyyy", null),
                        Email = "bobur@gmail.com",
                        Password = "Pa$$w0rd"
                    }
                },
                new Professor
                {
                    UserId = 4,
                    User = new User
                    {
                        FirstName = "Anora",
                        LastName = "Anora",
                        PhoneNumber = "+998910000000",
                        DateOfBirth = DateTime.ParseExact("30/12/1999", "dd/MM/yyyy", null),
                        Email = "anora@gmail.com",
                        Password = "Pa$$w0rd"
                    }
                }
            });

            dbContext.SaveChanges();
        }
    }
}
