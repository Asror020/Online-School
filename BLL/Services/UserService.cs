using BLL.Services.Interfaces;
using Core.Entities;
using Core.Entities.Common;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : BaseService<User, IRepositoryBase<User>>, IUserService
    {
        public UserService(IRepositoryBase<User> entityRepository) : base(entityRepository)
        {
        }

        public override async Task<bool> UpdateAsync(int id, User entity)
        {
            if (id <= 0 || entity == null)
                throw new ArgumentException();

            return await Task.Run(async () =>
            {
                var foundEntity = await GetByIdAsync(id) ?? throw new EntryPointNotFoundException(typeof(User).FullName);

                foundEntity.FirstName = entity.FirstName;
                foundEntity.LastName = entity.LastName;
                foundEntity.Email = entity.Email;
                foundEntity.Password = entity.Password;
                foundEntity.PhoneNumber = entity.PhoneNumber;
                foundEntity.DateOfBirth = entity.DateOfBirth;

                EntityRepository.Update(foundEntity);
                return await EntityRepository.SaveChangesAsync();
            });
        }
    }
}
