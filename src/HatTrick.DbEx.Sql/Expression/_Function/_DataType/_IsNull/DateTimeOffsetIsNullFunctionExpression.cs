using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetIsNullFunctionExpression :
        IsNullFunctionExpression<DateTimeOffset>,
        IEquatable<DateTimeOffsetIsNullFunctionExpression>
    {
        #region constructors
        public DateTimeOffsetIsNullFunctionExpression(ExpressionMediator<DateTimeOffset> expression, ExpressionMediator<DateTimeOffset> value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new DateTimeOffsetIsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DateTimeOffsetIsNullFunctionExpression obj)
            => obj is DateTimeOffsetIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeOffsetIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
