using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class DbExpressionRuntimeConfiguration
    {
        public IDictionary<string, RuntimeDatabaseMap> Databases { get; set; } = new Dictionary<string, RuntimeDatabaseMap>();
    }
}
