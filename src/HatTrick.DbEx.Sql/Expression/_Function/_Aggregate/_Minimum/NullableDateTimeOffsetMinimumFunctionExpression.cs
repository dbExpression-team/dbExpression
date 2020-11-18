using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetMinimumFunctionExpression :
        NullableMinimumFunctionExpression<DateTimeOffset,DateTimeOffset?>,
        NullDateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<NullableDateTimeOffsetMinimumFunctionExpression>
    {
        #region constructors
        public NullableDateTimeOffsetMinimumFunctionExpression(NullDateTimeOffsetElement expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        protected NullableDateTimeOffsetMinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) 
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullDateTimeOffsetElement As(string alias)
            => new NullableDateTimeOffsetMinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetMinimumFunctionExpression obj)
            => obj is NullableDateTimeOffsetMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
