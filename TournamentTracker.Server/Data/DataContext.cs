using Dapper.Contrib.Linq2Dapper;
using Microsoft.Data.SqlClient;

namespace TournamentTracker.Server.Data;

public class DataContext<TEntity> : IDisposable where TEntity: class
{
    private readonly SqlConnection _connection;
    private Linq2Dapper<TEntity> _data;

    public Linq2Dapper<TEntity> Data => _data ?? (_data = CreateObject<TEntity>());

    public DataContext(string sqlConnectionString)
    {
        _connection = new SqlConnection(sqlConnectionString);
    }

    private Linq2Dapper<T> CreateObject<T>()
    {
        return new Linq2Dapper<T>(_connection);
    }
    
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}