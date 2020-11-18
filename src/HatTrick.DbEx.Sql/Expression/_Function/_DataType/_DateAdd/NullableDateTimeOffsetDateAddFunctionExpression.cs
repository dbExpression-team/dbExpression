using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetDateAddFunctionExpression :
        NullableDateAddFunctionExpression<DateTimeOffset,DateTimeOffset?>,
        NullDateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<NullableDateTimeOffsetDateAddFunctionExpression>
    {
        #region constructors
        public NullableDateTimeOffsetDateAddFunctionExpression(DatePartsExpression datePart, AnyInt32Element value, NullDateTimeOffsetElement expression)
            : base(datePart, value, expression)
        {

        }

        public NullableDateTimeOffsetDateAddFunctionExpression(DatePartsExpression datePart, AnyInt32Element value, DateTimeOffsetElement expression)
            : base(datePart, value, expression)
        {

        }

        protected NullableDateTimeOffsetDateAddFunctionExpression(DatePartsExpression datePart, IExpressionElement value, IExpressionElement expression, string alias)
            : base(datePart, value, expression, alias)
        {

        }
        #endregion

        #region as
        public NullDateTimeOffsetElement As(string alias)
            => new NullableDateTimeOffsetDateAddFunctionExpression(base.DatePart, base.Value, base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetDateAddFunctionExpression obj)
            => obj is NullableDateTimeOffsetDateAddFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetDateAddFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
