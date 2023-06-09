using DAL.Contexts;
using System.Linq.Expressions;

namespace DAL.Repositories.Interfaces;

public interface IRepositoryBase<TEntity> 
    where TEntity : class
{
    ApplicationDbContext Context { get; }

    IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);

    void Create(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);

    bool SaveChanges();

    Task<bool> SaveChangesAsync();

    void Detach(TEntity entity);



}
