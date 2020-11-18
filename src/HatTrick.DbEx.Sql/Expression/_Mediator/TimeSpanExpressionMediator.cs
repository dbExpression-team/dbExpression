using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class TimeSpanExpressionMediator :
        ExpressionMediator<TimeSpan>,
        TimeSpanElement,
        AnyTimeSpanElement,
        IEquatable<TimeSpanExpressionMediator>
    {
        #region constructors
        private TimeSpanExpressionMediator()
        {
        }

        public TimeSpanExpressionMediator(IExpressionElement expression) : base(expression)
        {
        }

        protected TimeSpanExpressionMediator(IExpressionElement expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public TimeSpanElement As(string alias)
            => new TimeSpanExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(TimeSpanExpressionMediator obj)
            => obj is TimeSpanExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is TimeSpanExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
