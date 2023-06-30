using Dapper;
using LotteryManager.DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LotteryManager.DataAccess.Implementations
{
    public class SqlDataAccess : IDBAccess
    {
        private readonly IConfiguration _config;
        private IDbConnection? _dbConnection;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public void CreateConnection(string connectionId)
        {
            _dbConnection = new SqlConnection(_config.GetConnectionString(connectionId));
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default")
        {
            CreateConnection(connectionId);
            using (_dbConnection)
            {
                return await _dbConnection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.Text);
            }
        }

        public async Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default")
        {
            CreateConnection(connectionId);
            using (_dbConnection)
            {
                await _dbConnection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}