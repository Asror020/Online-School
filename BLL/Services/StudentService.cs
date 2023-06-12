using BLL.Services.Interfaces;
using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService : BaseService<Student, IRepositoryBase<Student>>, IStudentService
    {
        private readonly IRepositoryBase<User> _userRepo;
        public StudentService(IRepositoryBase<Student> entityRepository, IRepositoryBase<User> userRepo) : base(entityRepository)
        {
            _userRepo = userRepo;
        }

        public override async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return EntityRepository.Context.Students.Include(x => x.User).ToList();
            });
        }

        public override async Task<Student?> GetByIdAsync(int id)
        {
            return await Task.Run(() =>
            {
                return EntityRepository.Context.Students.Where(x => x.Id == id).Include(x => x.User).FirstOrDefault();
            });
        }

        public override async Task<bool> UpdateAsync(int id, Student entity)
        {
            if (id <= 0 || entity == null)
                throw new ArgumentException();

            return await Task.Run(async () =>
            {
                var foundEntity = await GetByIdAsync(id) ?? throw new EntryPointNotFoundException(typeof(Student).FullName);

                foundEntity.RegistrationId = entity.RegistrationId;
                foundEntity.User.FirstName = entity.User.FirstName;
                foundEntity.User.LastName = entity.User.LastName;
                foundEntity.User.PhoneNumber = entity.User.PhoneNumber;
                foundEntity.User.Email = entity.User.Email;
                foundEntity.User.DateOfBirth = entity.User.DateOfBirth;
                foundEntity.User.Password = entity.User.Password;

                EntityRepository.Update(foundEntity);
                return await EntityRepository.SaveChangesAsync();
            });
        }

        public override async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id) ?? throw new EntryPointNotFoundException();

            _userRepo.Delete(entity.User);
            
            return await base.DeleteAsync(entity);
        }
    }
}
