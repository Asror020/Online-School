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
            AddSeedSubjects(dbContext);
            AddSeedGrades(dbContext);
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

        private static void AddSeedStudents(ApplicationDbContext dbContext)
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

        private static void AddSeedProfessors(ApplicationDbContext dbContext)
        {
            if (dbContext.Professors.Any()) return;

            dbContext.Professors.AddRange(new[]
            {
                new Professor
                {
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

        public static void AddSeedSubjects(ApplicationDbContext dbContext)
        {
            if(dbContext.Subjects.Any()) return;

            dbContext.Subjects.AddRange(new[]
            {
                new Subject
                {
                    Name = "Math",
                    ProfessorId = 1,
                    ProfessorFullName = "Anora Anora",
                    StudentsList = "1,2,3,4,5,6,7"
                },
                new Subject
                {
                    Name = "English",
                    ProfessorId = 2,
                    ProfessorFullName = "Bobur Bobur",
                    StudentsList = "1,2,3,4,5,6,7"
                }
            });

            dbContext.SaveChanges();
        }

        public static void AddSeedGrades(ApplicationDbContext dbContext)
        {
            if(dbContext.Grades.Any()) return;

            dbContext.Grades.AddRange(new[]
            {
                new Grade
                {
                    SubjectName = "Math",
                    StudentId = 1,
                    StudentFullName = "John Smith",
                    Score = 98,
                },
                new Grade
                {
                    SubjectName = "English",
                    StudentId = 1,
                    StudentFullName = "John Smith",
                    Score = 78
                },
                new Grade
                {
                    SubjectName = "Math",
                    StudentId = 2,
                    StudentFullName = "Bob Bob",
                    Score = 90,
                },
                new Grade
                {
                    SubjectName = "English",
                    StudentId = 2,
                    StudentFullName = "Bob Bob",
                    Score = 87
                }
            });

            dbContext.SaveChanges();
        }
    }
}
