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
}
