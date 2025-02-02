using Dapper;
using System.Data;
using System.Data.Common;

namespace LotteryManager.Data.Infrastructure.Data
{
    public class SqlConnectionWrapper(DbConnection dbConnection) : ISqlConnection
    {
        protected readonly DbConnection _dbConnection = dbConnection;

        public virtual async Task<int> ExecuteAsync(string sql, DynamicParameters? parameters = null, IDbTransaction? transaction = null)
        {
            return await _dbConnection.ExecuteAsync(sql, parameters, transaction);
        }

        public virtual async Task<T?> ExecuteScalarAsync<T>(string sql, DynamicParameters? parameters = null, IDbTransaction? transaction = null)
        {
            return await _dbConnection.ExecuteScalarAsync<T>(sql, parameters, transaction);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, DynamicParameters? parameters = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await _dbConnection.QueryAsync<T>(sql, parameters, transaction, commandTimeout, commandType);
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TInput1, TInput2, TReturn>(string sql, Func<TInput1, TInput2, TReturn> map, DynamicParameters? parameters = null, IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return await _dbConnection.QueryAsync(sql, map, parameters, transaction, buffered, splitOn, commandTimeout, commandType);
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TInput1, TInput2, TInput3, TReturn>(string sql, Func<TInput1, TInput2, TInput3, TReturn> map, DynamicParameters? parameters = null, IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return await _dbConnection.QueryAsync(sql, map, parameters, transaction, buffered, splitOn, commandTimeout, commandType);
        }

        public async Task<T> QueryFirstAsync<T>(string sql, DynamicParameters? parameters = null)
        {
            return await _dbConnection.QueryFirstAsync<T>(sql, parameters);
        }

        public async Task<T?> QueryFirstOrDefaultAsync<T>(string sql, DynamicParameters? parameters = null)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<T>(sql, parameters);
        }

        public async Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, DynamicParameters? parameters = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await _dbConnection.QueryMultipleAsync(sql, parameters, transaction, commandTimeout, commandType);
        }

        public virtual void Dispose()
        {
            _dbConnection?.Dispose();
        }
    }
}