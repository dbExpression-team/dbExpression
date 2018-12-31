using System.Collections.Generic;

namespace HatTrick.DbEx.Sql
{
    public abstract class SqlDatabaseMetadata : ISqlDatabaseMetadata
    {
        public string Name { get; set; }
        public string ConnectionName { get; private set; }
        public IDictionary<string, ISqlSchemaMetadata> Schemas { get; } = new Dictionary<string, ISqlSchemaMetadata>();

        protected SqlDatabaseMetadata(string name, string connectionName)
        {
            Name = name;
            ConnectionName = connectionName;
        }
    }
}
