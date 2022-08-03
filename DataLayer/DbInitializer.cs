using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace DataLayer
{
    internal sealed class DbInitializer : IDbInitializer
    {
        private readonly ConnectionHelper _connectionHelper;
        private readonly DbOptions _options;

        public DbInitializer(
            ConnectionHelper connectionHelper,
            IOptions<DbOptions> dbOptions)
        {
            _connectionHelper = connectionHelper;
            _options = dbOptions.Value;
        }

        public async Task Initialize()
        {
            var queries = QueryLoader.Get("Init")
                .Replace("{DB_NAME}", _options.Database)
                .Split("GO");

            var cnn = _connectionHelper.OpenNewConnection(true);
            var cmd = cnn.CreateCommand();

            foreach (var query in queries)
            {
                cmd.CommandText = query;
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}