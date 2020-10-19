using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class TimeSpanExpressionMediator :
        ExpressionMediator<TimeSpan>,
        IEquatable<TimeSpanExpressionMediator>
    {
        #region constructors
        private TimeSpanExpressionMediator()
        {
        }

        public TimeSpanExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected TimeSpanExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new TimeSpanExpressionMediator As(string alias)
            => new TimeSpanExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(TimeSpanExpressionMediator obj)
            => obj is DateTimeExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is TimeSpanExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
