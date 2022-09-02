using System.Data;
using System.Linq.Expressions;
using Dapper;
using Microsoft.Data.SqlClient;

namespace TournamentTrackerWasm.Data;

public class DapperRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private string _sqlConnectionString;
    private string _entityName;
    private Type _entityType;

    public DapperRepository(string sqlConnectionString)
    {
        _sqlConnectionString = sqlConnectionString;
        _entityType = typeof(TEntity);
        _entityName = _entityType.Name;
    }
    
    public async Task<IEnumerable<TEntity>> GetAll()
    {
        using (IDbConnection db = new SqlConnection(_sqlConnectionString))
        {
            db.Open();
            string sql = $"select * from {_entityName}";
            IEnumerable<TEntity> result = await db.QueryAsync<TEntity>(sql);
            return result;
        }
    }

    public Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includeProperties = "")
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> Insert(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> Update(TEntity entityToUpdate)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(TEntity entityToDelete)
    {
        throw new NotImplementedException();
    }
}
