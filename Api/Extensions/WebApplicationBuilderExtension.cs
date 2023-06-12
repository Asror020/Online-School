using AutoMapper;
using BLL.Services;
using BLL.Services.Interfaces;
using Core.Entities;
using DAL.Contexts;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Helpers;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions
{
    public static class WebApplicationBuilderExtension
    {
        public static WebApplicationBuilder AddRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRepositoryBase<User>, RepositoryBase<User>>();
            builder.Services.AddScoped<IBaseService<User>, BaseService<User, IRepositoryBase<User>>>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<IRepositoryBase<Student>, RepositoryBase<Student>>();
            builder.Services.AddScoped<IBaseService<Student>, BaseService<Student, IRepositoryBase<Student>>>();
            builder.Services.AddScoped<IStudentService, StudentService>();

            builder.Services.AddScoped<IRepositoryBase<Professor>, RepositoryBase<Professor>>();
            builder.Services.AddScoped<IBaseService<Professor>, BaseService<Professor, IRepositoryBase<Professor>>>();
            builder.Services.AddScoped<IProfessorService, ProfessorService>();

            builder.Services.AddScoped<IRepositoryBase<Subject>, RepositoryBase<Subject>>();
            builder.Services.AddScoped<IBaseService<Subject>, BaseService<Subject, IRepositoryBase<Subject>>>();

            builder.Services.AddScoped<IRepositoryBase<Grade>, RepositoryBase<Grade>>();
            builder.Services.AddScoped<IBaseService<Grade>, BaseService<Grade, IRepositoryBase<Grade>>>();

            return builder;
        }

        public static WebApplicationBuilder AddDbContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")));

            return builder;
        }

        public static WebApplicationBuilder AddMapper(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            }).CreateMapper());

            return builder;
        }

        public static WebApplicationBuilder AddCorsPolicy(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            return builder;
        }
    }
}
