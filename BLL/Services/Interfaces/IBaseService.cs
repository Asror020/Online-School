using Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IBaseService<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T?> CreateAsync(T entity);
        Task<bool> UpdateAsync(int id ,T entity);
        Task<bool> DeleteByIdAsync(int id);
        
    }
}
