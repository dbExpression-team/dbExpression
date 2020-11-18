using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetMaximumFunctionExpression :
        NullableMaximumFunctionExpression<DateTimeOffset,DateTimeOffset?>,
        NullDateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<NullableDateTimeOffsetMaximumFunctionExpression>
    {
        #region constructors
        public NullableDateTimeOffsetMaximumFunctionExpression(NullDateTimeOffsetElement expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        protected NullableDateTimeOffsetMaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias)
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullDateTimeOffsetElement As(string alias)
            => new NullableDateTimeOffsetMaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetMaximumFunctionExpression obj)
            => obj is NullableDateTimeOffsetMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
