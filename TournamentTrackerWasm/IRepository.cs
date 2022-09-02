using System.Linq.Expressions;

namespace TournamentTrackerWasm;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAll();

    Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includeProperties = "");

    Task<TEntity> Insert(TEntity entity);
    
    Task<TEntity> Update(TEntity entityToUpdate);
    
    Task<bool> Delete(TEntity entityToDelete);
}