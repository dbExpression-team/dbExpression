using System.Collections.Generic;

namespace HatTrick.DbEx.Sql
{
    public interface ISqlDatabaseMetadata : IDbExpressionMetadata
    {
        IDictionary<string, ISqlSchemaMetadata> Schemas { get; }
    }
}
