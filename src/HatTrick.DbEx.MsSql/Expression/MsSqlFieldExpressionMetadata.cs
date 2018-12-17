using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.MsSql.Expression
{
    public class MsSqlFieldExpressionMetadata : FieldExpressionMetadata
    {

        public MsSqlFieldExpressionMetadata(EntityExpression parent, string name, SqlDbType dbType)
            : base(parent, name, dbType)
        {
        }

        public MsSqlFieldExpressionMetadata(EntityExpression parent, string name, SqlDbType dbType, int size)
            : base(parent, name, dbType, size)
        {
        }

        public MsSqlFieldExpressionMetadata(EntityExpression parent, string name, SqlDbType dbType, byte precision, byte scale)
            : base(parent, name, dbType, precision, scale)
        {
        }
    }
}
