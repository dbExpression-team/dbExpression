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

        public DateTimeOffsetExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected DateTimeOffsetExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new DateTimeOffsetExpressionMediator As(string alias)
            => new DateTimeOffsetExpressionMediator(this.Expression, alias);
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
