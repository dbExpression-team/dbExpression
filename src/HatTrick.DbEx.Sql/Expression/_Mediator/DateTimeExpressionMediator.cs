using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeExpressionMediator :
        ExpressionMediator<DateTime>,
        DateTimeElement,
        AnyDateTimeElement,
        IEquatable<DateTimeExpressionMediator>
    {
        #region constructors
        private DateTimeExpressionMediator()
        {
        }

        public DateTimeExpressionMediator(IExpressionElement expression) : base(expression)
        {
        }

        protected DateTimeExpressionMediator(IExpressionElement expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public DateTimeElement As(string alias)
            => new DateTimeExpressionMediator(base.Expression, alias);
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
