using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetIsNullFunctionExpression :
        IsNullFunctionExpression<DateTimeOffset>,
        DateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<DateTimeOffsetIsNullFunctionExpression>
    {
        #region constructors
        public DateTimeOffsetIsNullFunctionExpression(AnyDateTimeOffsetElement expression, DateTimeOffsetElement value) : base(expression, value)
        {

        }

        protected DateTimeOffsetIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias) : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public DateTimeOffsetElement As(string alias)
            => new DateTimeOffsetIsNullFunctionExpression(base.Expression, base.Value, alias);
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
