using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql
{
    public interface ISqlEntityMetadata : IDbExpressionMetadata
    {
        ISqlSchemaMetadata Schema { get; }
        IDictionary<string, ISqlFieldMetadata> Fields { get; }
    }
}
