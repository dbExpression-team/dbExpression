using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetDateAddFunctionExpression :
        DateAddFunctionExpression<DateTimeOffset>,
        IEquatable<DateTimeOffsetDateAddFunctionExpression>
    {
        #region constructors
        public DateTimeOffsetDateAddFunctionExpression(DatePartsExpression datePart, ExpressionMediator<int> value, ExpressionMediator<DateTimeOffset> expression) : base(datePart, value, expression)
        {
        }
        #endregion

        #region as
        public new DateTimeOffsetDateAddFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DateTimeOffsetDateAddFunctionExpression obj)
            => obj is DateTimeOffsetDateAddFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeOffsetDateAddFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
