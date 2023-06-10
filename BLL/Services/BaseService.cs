using BLL.Services.Interfaces;
using Core.Entities.Common;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BaseService<T, TRepository> : IBaseService<T> where T : class, IEntity where TRepository : IRepositoryBase<T>
    {
        protected readonly TRepository EntityRepository;

        public BaseService(TRepository entityRepository)
        {
            EntityRepository = entityRepository;
        }

        public virtual async Task<bool> CheckExistenceAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException();

            return await Task.Run(() => EntityRepository.Get(x => x.Id == id).Any());
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run(EntityRepository.Context.Set<T>);
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException();

            return await Task.Run(() => EntityRepository.Get(x => x.Id == id).FirstOrDefault());
        }

        public virtual async Task<IEnumerable<T>> GetByIdsAsync(ICollection<int> ids)
        {
            if (ids.Any())
                throw new ArgumentException();

            return await Task.Run(() => EntityRepository.Get(x => ids.Contains(x.Id)).ToList());
        }

        public virtual async Task<T?> CreateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentException();

            return await Task.Run(async () =>
            {
                entity.Id = 0;
                EntityRepository.Create(entity);
                return await EntityRepository.SaveChangesAsync() ? entity : throw new InvalidOperationException();
            });
        }

        public virtual async Task<bool> UpdateAsync(int id, T entity)
        {
            if (id <= 0 || entity == null)
                throw new ArgumentException();

            return await Task.Run(async () =>
            {
                var foundEntity = await GetByIdAsync(id) ?? throw new EntryPointNotFoundException(typeof(T).FullName);
                EntityRepository.Update(entity);
                return await EntityRepository.SaveChangesAsync();
            });
        }

        public virtual async Task<bool> DeleteByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException($"Couldn't delete {nameof(T)} due to invalid id");

            return await Task.Run(async () =>
            {
                var entity = EntityRepository.Get(x => x.Id == id).FirstOrDefault() ?? throw new EntryPointNotFoundException(typeof(T).FullName);
                return await DeleteAsync(entity);
            });
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentException($"Couldn't delete {nameof(T)} due to invalid model");

            return await Task.Run(async () =>
            {
                EntityRepository.Delete(entity);
                return await EntityRepository.SaveChangesAsync();
            });
        }
    }
}
