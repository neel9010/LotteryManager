using Dapper;
using System.Data;

namespace LotteryManager.Data.Infrastructure.Data
{
    public interface ISqlConnection : IDisposable
    {
        Task<int> ExecuteAsync(string sql, DynamicParameters? parameters = null, IDbTransaction? transaction = null);

        Task<T?> ExecuteScalarAsync<T>(string sql, DynamicParameters? parameters = null, IDbTransaction? transaction = null);

        Task<IEnumerable<T>> QueryAsync<T>(string sql, DynamicParameters? parameters = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<IEnumerable<TReturn>> QueryAsync<TInput1, TInput2, TReturn>(string sql, Func<TInput1, TInput2, TReturn> map, DynamicParameters? parameters = null, IDbTransaction? transaction = null,
          bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

        Task<IEnumerable<TReturn>> QueryAsync<TInput1, TInput2, TInput3, TReturn>(string sql, Func<TInput1, TInput2, TInput3, TReturn> map, DynamicParameters? parameters = null, IDbTransaction? transaction = null,
          bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

        Task<T> QueryFirstAsync<T>(string sql, DynamicParameters? parameters = null);

        Task<T?> QueryFirstOrDefaultAsync<T>(string sql, DynamicParameters? parameters = null);

        Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, DynamicParameters? parameters = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);
    }
}