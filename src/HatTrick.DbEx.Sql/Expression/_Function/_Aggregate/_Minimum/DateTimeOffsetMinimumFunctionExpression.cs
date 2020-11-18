using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetMinimumFunctionExpression :
        MinimumFunctionExpression<DateTimeOffset>,
        DateTimeOffsetElement,
        AnyDateTimeOffsetElement, 
        IEquatable<DateTimeOffsetMinimumFunctionExpression>
    {
        #region constructors
        public DateTimeOffsetMinimumFunctionExpression(DateTimeOffsetElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected DateTimeOffsetMinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public DateTimeOffsetElement As(string alias)
            => new DateTimeOffsetMinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(DateTimeOffsetMinimumFunctionExpression obj)
            => obj is DateTimeOffsetMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeOffsetMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
