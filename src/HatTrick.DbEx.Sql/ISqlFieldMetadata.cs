using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql
{
    public interface ISqlFieldMetadata : IDbExpressionMetadata
    {
        ISqlEntityMetadata Entity { get; }
        bool IsIdentity { get; }
        int? Size { get; }
        byte? Precision { get; }
        byte? Scale { get; }
        object DbType { get; }
    }

    public interface ISqlEntityMetadata : IDbExpressionMetadata
    {
        ISqlSchemaMetadata Schema { get; }
        IDictionary<string, ISqlFieldMetadata> Fields { get; }
    }

    public interface ISqlSchemaMetadata : IDbExpressionMetadata
    {
        ISqlDatabaseMetadata Database { get; }
        IDictionary<string, ISqlEntityMetadata> Entities { get; }
    }

    public interface ISqlDatabaseMetadata : IDbExpressionMetadata
    {
        new string Name { get; set; }
        IDictionary<string, ISqlSchemaMetadata> Schemas { get; }
    }
}
