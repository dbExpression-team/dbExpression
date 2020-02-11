using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableDateAddFunctionExpression : DateAddFunctionExpression,
        ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>>,
        ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>>
    {
        #region constructors
        protected NullableDateAddFunctionExpression()
        {
        }

        protected NullableDateAddFunctionExpression((Type, object) datePart, (Type, object) value, (Type, object) expression)
            : base(datePart, value, expression)
        {
        }
        #endregion
    }
}
