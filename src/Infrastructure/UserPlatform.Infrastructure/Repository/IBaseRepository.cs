using System.Linq.Expressions;

namespace UserPlatform.Infrastructure.Repository;

public interface IBaseRepository<TEntity> where TEntity : class
{
    public bool Add(TEntity entity);

    public ICollection<TEntity> AddRange(ICollection<TEntity> entities);

    public bool Any(Expression<Func<TEntity, bool>>? predicate = null, bool withDeleted = false, bool enableTracking = true);

    public TEntity Delete(TEntity entity);

    public ICollection<TEntity> DeleteRange(ICollection<TEntity> entities);

    public TEntity? Get(Expression<Func<TEntity, bool>> predicate, bool withDeleted = false, bool enableTracking = true);

    public ICollection<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null, bool withDeleted = false, bool enableTracking = true);

    public IQueryable<TEntity> Query();

    public bool Update(TEntity entity);

    public ICollection<TEntity> UpdateRange(ICollection<TEntity> entities);
}
