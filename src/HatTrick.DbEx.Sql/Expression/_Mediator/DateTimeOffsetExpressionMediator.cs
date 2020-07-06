using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetExpressionMediator :
        ExpressionMediator<DateTimeOffset>,
        IEquatable<DateTimeOffsetExpressionMediator>
    {
        #region constructors
        private DateTimeOffsetExpressionMediator()
        {
        }

        public DateTimeOffsetExpressionMediator(IDbExpression expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new DateTimeOffsetExpressionMediator As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DateTimeOffsetExpressionMediator obj)
            => obj is DateTimeOffsetExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeOffsetExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
