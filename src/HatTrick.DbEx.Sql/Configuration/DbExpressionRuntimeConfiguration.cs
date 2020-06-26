using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class DbExpressionRuntimeConfiguration
    {
        public IDictionary<string, DatabaseConfiguration> Databases { get; set; } = new Dictionary<string, DatabaseConfiguration>();
    }
}
