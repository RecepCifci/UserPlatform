using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UserPlatform.Domain.Entities.Base;

namespace UserPlatform.Infrastructure.Repository;

public class BaseRepository<TEntity, TContext>(TContext context) : IBaseRepository<TEntity>
where TEntity : BaseEntity
where TContext : DbContext
{
    public bool Add(TEntity entity)
    {
        context.Add(entity);
        return context.SaveChanges() > default(int);
    }

    public ICollection<TEntity> AddRange(ICollection<TEntity> entities)
    {
        context.AddRangeAsync(entities);
        context.SaveChanges();
        return entities;
    }

    public bool Any(Expression<Func<TEntity, bool>>? predicate = null, bool withDeleted = false, bool enableTracking = true)
    {
        IQueryable<TEntity> queryable = Query();
        if (enableTracking)
            queryable = queryable.AsNoTracking();
        if (withDeleted)
            queryable = queryable.IgnoreQueryFilters();
        if (predicate != null)
            queryable = queryable.Where(predicate);
        return queryable.Any();
    }

    public TEntity Delete(TEntity entity)
    {
        context.Remove(entity);
        context.SaveChanges();
        return entity;
    }

    public ICollection<TEntity> DeleteRange(ICollection<TEntity> entities)
    {
        context.RemoveRange(entities);
        context.SaveChanges();
        return entities;
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> predicate, bool withDeleted = false, bool enableTracking = true)
    {
        IQueryable<TEntity> queryable = Query();
        if (enableTracking)
            queryable = queryable.AsNoTracking();
        if (withDeleted)
            queryable = queryable.IgnoreQueryFilters();
        return queryable.FirstOrDefault(predicate);
    }

    public ICollection<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null, bool withDeleted = false, bool enableTracking = true)
    {
        IQueryable<TEntity> queryable = Query();
        if (enableTracking)
            queryable = queryable.AsNoTracking();
        if (withDeleted)
            queryable = queryable.IgnoreQueryFilters();
        if (predicate != null)
            queryable = queryable.Where(predicate);
        return queryable.ToList();
    }

    public IQueryable<TEntity> Query() => context.Set<TEntity>();

    public bool Update(TEntity entity)
    {
        context.Update(entity);
        return context.SaveChanges() > default(int);
    }

    public ICollection<TEntity> UpdateRange(ICollection<TEntity> entities)
    {
        context.UpdateRange(entities);
        context.SaveChanges();
        return entities;
    }
}
