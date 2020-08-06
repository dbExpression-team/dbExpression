using System.Collections.Generic;

namespace HatTrick.DbEx.Sql
{
    public interface ISqlDatabaseMetadata : ISqlMetadata
    {
        IDictionary<string, ISqlSchemaMetadata> Schemas { get; }
    }
}
