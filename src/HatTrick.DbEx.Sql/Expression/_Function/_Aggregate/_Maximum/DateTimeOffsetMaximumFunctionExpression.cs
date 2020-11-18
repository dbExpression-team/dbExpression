using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetMaximumFunctionExpression :
        MaximumFunctionExpression<DateTimeOffset>,
        DateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<DateTimeOffsetMaximumFunctionExpression>
    {
        #region constructors
        public DateTimeOffsetMaximumFunctionExpression(DateTimeOffsetElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected DateTimeOffsetMaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public DateTimeOffsetElement As(string alias)
            => new DateTimeOffsetMaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(DateTimeOffsetMaximumFunctionExpression obj)
            => obj is DateTimeOffsetMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeOffsetMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
