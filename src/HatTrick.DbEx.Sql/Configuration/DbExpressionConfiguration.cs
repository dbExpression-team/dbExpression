using System.Collections.Generic;
using System.Configuration;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class DbExpressionConfiguration
    {
        public IDictionary<string, ConnectionStringSettings> ConnectionStringSettings { get; set; } = new Dictionary<string,ConnectionStringSettings>();
        public IDictionary<string, DatabaseConfiguration> Databases { get; set; } = new Dictionary<string, DatabaseConfiguration>();
    }
}
