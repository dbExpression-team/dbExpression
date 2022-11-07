using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql
{
    public static class TupleExtensions
    {
        public static OrderByExpression Asc(this (string TableName, string FieldName) alias)
            => new(new AliasExpression<object?>(alias), OrderExpressionDirection.ASC);

        public static OrderByExpression Desc(this (string TableName, string FieldName) alias)
            => new(new AliasExpression<object?>(alias), OrderExpressionDirection.DESC);
    }
}
