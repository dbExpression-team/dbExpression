using HTL.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTL.DbEx.Sql.Extensions.Expression
{
    public static class DBExpressionFieldExtensions
    {
        public static bool Contains<T>(this ICollection<DBExpressionField> fields, DBExpressionField<T> field, bool ignoreAlias)
        {
            if (ignoreAlias)
                return fields.Any(f => f.Equals(field));

            //if they are the same, or the parent and original name are the same assume they are the same (ignore aliasing)
            return fields.Any(f => f.Equals(field) || f.ParentEntity.Equals(field.ParentEntity) && string.Compare(f.Name, field.Name) == 0);
        }
    }
}
