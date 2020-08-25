using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql
{
    public class SqlDatabaseMetadataProvider : ISqlDatabaseMetadataProvider
    {
        #region internals
        private ConcurrentDictionary<string, ISqlEntityMetadata> _discoveredEntities = new ConcurrentDictionary<string, ISqlEntityMetadata>();
        private ConcurrentDictionary<string, ISqlFieldMetadata> _discoveredFields = new ConcurrentDictionary<string, ISqlFieldMetadata>();
        #endregion

        #region interface
        public ISqlDatabaseMetadata Database { get; private set; }
        #endregion

        #region constructors
        public SqlDatabaseMetadataProvider(ISqlDatabaseMetadata metadata)
        {
            Database = metadata;
        }
        #endregion

        #region methods
        public ISqlSchemaMetadata FindSchemaMetadata(string identifier)
        {
            if (Database.Schemas.TryGetValue(identifier, out var meta))
                return meta;
            return null;
        }

        public ISqlEntityMetadata FindEntityMetadata(string identifier)
        {
            if (_discoveredEntities.TryGetValue(identifier, out var entity))
                return entity;

            foreach (var schema in Database.Schemas)
                if (schema.Value.Entities.TryGetValue(identifier, out var meta))
                {
                    _discoveredEntities.TryAdd(identifier, meta);
                    return meta;
                }

            return null;
        }

        public ISqlFieldMetadata FindFieldMetadata(string identifier)
        {
            if (_discoveredFields.TryGetValue(identifier, out var field))
                return field;

            foreach (var schema in Database.Schemas)
                foreach (var table in schema.Value.Entities)
                    if (table.Value.Fields.TryGetValue(identifier, out var meta))
                    {
                        _discoveredFields.TryAdd(identifier, meta);
                        return meta;
                    }

            return null;
        }
        #endregion
    }
}
