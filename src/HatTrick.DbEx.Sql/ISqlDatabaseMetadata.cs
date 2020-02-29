using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql
{
    public interface ISqlDatabaseMetadata : IDbExpressionMetadata
    {
        new string Name { get; set; }
        IDictionary<string, ISqlSchemaMetadata> Schemas { get; }
    }
}
