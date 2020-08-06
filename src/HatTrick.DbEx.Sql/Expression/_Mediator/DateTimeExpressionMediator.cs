using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeExpressionMediator :
        ExpressionMediator<DateTime>,
        IEquatable<DateTimeExpressionMediator>
    {
        #region constructors
        private DateTimeExpressionMediator()
        {
        }

        public DateTimeExpressionMediator(IExpression expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new DateTimeExpressionMediator As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DateTimeExpressionMediator obj)
            => obj is DateTimeExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
