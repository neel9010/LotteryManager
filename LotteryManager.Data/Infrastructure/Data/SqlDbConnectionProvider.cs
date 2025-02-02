using LotteryManager.Data.Infrastructure.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace LotteryManager.Data.Infrastructure.Data
{
    public class SqlDbConnectionProvider(IOptionsSnapshot<DatabaseConnectionConfiguration> databaseConnectionConfiguration) : IDbConnectionProvider
    {
        private readonly IOptionsSnapshot<DatabaseConnectionConfiguration> _databaseConnectionConfiguration = databaseConnectionConfiguration ?? throw new ArgumentNullException(nameof(databaseConnectionConfiguration));

        public ISqlConnection GetLotteryManagerConnection(int? connectionTimeout = null)
        {
            SqlConnectionStringBuilder sqlConn = CreateDefaultConnectionBuilder(connectionTimeout);

            var appDatabaseConnection = _databaseConnectionConfiguration.Value.LotteryManger;

            sqlConn.DataSource = appDatabaseConnection.SqlServer;
            sqlConn.InitialCatalog = appDatabaseConnection.DatabaseName;
            sqlConn.IntegratedSecurity = true;
            sqlConn.PersistSecurityInfo = false;
            sqlConn.Pooling = false;
            sqlConn.MultipleActiveResultSets = false;
            sqlConn.ConnectTimeout = 60;
            sqlConn.Encrypt = false;
            sqlConn.TrustServerCertificate = false;
            sqlConn.CommandTimeout = 0;

            return GetConnection(sqlConn.ToString());
        }

        private static ISqlConnection GetConnection(string connectionString) => new SqlConnectionWrapper(new SqlConnection(connectionString));

        private static SqlConnectionStringBuilder CreateDefaultConnectionBuilder(int? connectionTimeout)
        {
            SqlConnectionStringBuilder sqlConn = new()
            {
                IntegratedSecurity = true,
                MaxPoolSize = 1000,
                ConnectRetryCount = 1,
                ConnectRetryInterval = 1,
                TrustServerCertificate = false,
            };

            if (connectionTimeout.HasValue)
            {
                sqlConn.ConnectTimeout = connectionTimeout.Value;
            }

            return sqlConn;
        }
    }
}