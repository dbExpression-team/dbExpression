using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetDateAddFunctionExpression :
        NullableDateAddFunctionExpression<DateTimeOffset>,
        IEquatable<NullableDateTimeOffsetDateAddFunctionExpression>
    {
        #region constructors
        public NullableDateTimeOffsetDateAddFunctionExpression(ExpressionContainer datePart, ExpressionContainer value, ExpressionContainer expression) : base(datePart, value, expression)
        {
        }
        #endregion

        #region as
        public new NullableDateTimeOffsetDateAddFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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
