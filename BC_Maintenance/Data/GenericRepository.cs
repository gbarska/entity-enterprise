using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SharedKernel;
using SharedKernel.Data;
using Microsoft.EntityFrameworkCore;

namespace Maintenance.Data
{
  // public class GenericRepository<TEntity> where TEntity : class, IEntity (IEntity contract to determine properties of domain classes)
  public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
  {
    internal DbContext _context;
    internal DbSet<TEntity> _dbSet;

    public GenericRepository(DbContext context) {
      _context = context;
      _dbSet = context.Set<TEntity>();
    }
   
    public IEnumerable<TEntity> All() {
      return _dbSet.AsNoTracking().ToList();
    }

     public IEnumerable<TEntity> AllInclude(params Expression<Func<TEntity, object>>[] includeProperties) {
      return GetAllIncluding(includeProperties).ToList();
    }

    public IEnumerable<TEntity> FindByInclude
      (Expression<Func<TEntity, bool>> predicate,
      params Expression<Func<TEntity, object>>[] includeProperties) {
      var query = GetAllIncluding(includeProperties);
      IEnumerable<TEntity> results = query.Where(predicate).ToList();
      return results;
    }
     IQueryable<TEntity> GetAllIncluding
    (params Expression<Func<TEntity, object>>[] includeProperties) 
    {
      IQueryable<TEntity> queryable = _dbSet.AsNoTracking();

      return includeProperties.Aggregate
        (queryable, (current, includeProperty) => current.Include(includeProperty));
    }
    public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate) {

      IEnumerable<TEntity> results = _dbSet.AsNoTracking()
        .Where(predicate).ToList();
      return results;
    }

    public TEntity FindByKey(int id) {
      //approach to find by properties of base classes define where clause to the generic repository
      //pointing to the interface that has the properties
      // return _dbSet.AsNoTracking().SingleOrDefault(e=>e.Id=id);

      //the second approach when our classes have different properties like customerId, samuraiId and so on..
      //instead of controlling it with an interface we could use a lambda 
      // var item = Expression.Parameter(typeof(TEntity),"entity");
      // var prop = Expression.Property(item, typeof(TEntity).Name + "Id");
      // var value = Expression.Constant(id);
      // var equal = Expression.Equal(prop,value);
      // var lambda= Expression.Lambda<Func<TEntity, bool>>(equal,item);

      Expression<Func<TEntity, bool>> lambda = Utilities.BuildLambdaForFindByKey<TEntity>(id);
      return _dbSet.AsNoTracking().SingleOrDefault(lambda);
    }

    public void Insert(TEntity entity) {
      _dbSet.Add(entity);
    }

    public void Update(TEntity entity) {
      _dbSet.Attach(entity);
      _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(int id) {
      var entity = FindByKey(id);
      _dbSet.Remove(entity);
    }
  }
}