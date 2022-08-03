using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace DataLayer
{
    internal sealed class ConnectionHelper
    {
        private readonly DbOptions _options;

        public ConnectionHelper(IOptions<DbOptions> dbOptions)
        {
            _options = dbOptions.Value;
        }

        public DbConnection OpenNewConnection(bool useMaster = false)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = _options.Server,
                InitialCatalog = useMaster ? "master" : _options.Database,
                IntegratedSecurity = true
            };

            var cnn = new SqlConnection(builder.ToString());
            cnn.Open();

            return cnn;
        }
    }
}