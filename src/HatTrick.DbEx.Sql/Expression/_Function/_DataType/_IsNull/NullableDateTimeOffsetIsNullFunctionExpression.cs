using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetIsNullFunctionExpression :
        NullableIsNullFunctionExpression<DateTimeOffset,DateTimeOffset?>,
        NullDateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<NullableDateTimeOffsetIsNullFunctionExpression>
    {
        #region constructors
        public NullableDateTimeOffsetIsNullFunctionExpression(AnyDateTimeOffsetElement expression, NullDateTimeOffsetElement value)
            : base(expression, value)
        {

        }

        protected NullableDateTimeOffsetIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias)
            : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public NullDateTimeOffsetElement As(string alias)
            => new NullableDateTimeOffsetIsNullFunctionExpression(base.Expression, base.Value, alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetIsNullFunctionExpression obj)
            => obj is NullableDateTimeOffsetIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
