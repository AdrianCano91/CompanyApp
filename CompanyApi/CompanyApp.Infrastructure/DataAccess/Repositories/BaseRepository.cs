using CompanyApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CompanyApp.Infrastructure.DataAccess.Repositories
{
  public class BaseRepository<T> : BaseRepository<T, Guid> where T : class, IBaseEntity { public BaseRepository(ApplicationDbContext dbContext) : base(dbContext) { } }

  public class BaseRepository<T, IdType> : IBaseRepository where T : class, IBaseEntity<IdType>
  {
    private readonly ApplicationDbContext _db;

    protected DbSet<T> dbSet => _db.Set<T>();

    public BaseRepository(ApplicationDbContext dbContext)
    {
      _db = dbContext;
    }
    public IQueryable<T> GetById(IdType id) => GetAll().Where(x => x.Id.Equals(id));

    public async Task<T> AddAsync(T entity)
    {
      await dbSet.AddAsync(entity);
      await SaveChangesAsync();

      return entity;
    }

    public async Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities)
    {
      await dbSet.AddRangeAsync(entities);
      await SaveChangesAsync();
      return entities;
    }

    public async Task DeleteAsync(T entity)
    {
      dbSet.Remove(entity);
      await SaveChangesAsync();
    }

    public async Task DeleteAsync(IEnumerable<T> entities)
    {
      foreach (var entity in entities)
      {
        dbSet.Attach(entity);
      }

      await SaveChangesAsync();
    }

    public IQueryable<T> FindAsync(Expression<Func<T, bool>> predicate) =>
        dbSet.Where(predicate);

    public async Task<T> UpdateAsync(T entity)
    {
      dbSet.Update(entity);
      await SaveChangesAsync();
      return await Task.FromResult(entity);
    }

    public async Task<T> ForceUpdateAsync(T entity)
    {
      dbSet.Update(entity);
      await SaveChangesAsync();
      return await Task.FromResult(entity);
    }

    public async Task<IEnumerable<T>> ForceUpdateAsync(IEnumerable<T> entities)
    {
      foreach (T entity in entities) _db.Entry(entity).State = EntityState.Modified;
      await SaveChangesAsync();
      return await Task.FromResult(entities);
    }

    public IQueryable<T> GetAll()
    {
      try
      {
        var query = dbSet.AsQueryable();
        return query;
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public async Task SaveChangesAsync()
    {
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateException ex)
      {
        throw ex;
      }
    }
  }
}
