using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetExpressionMediator :
        ExpressionMediator<DateTimeOffset>,
        DateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<DateTimeOffsetExpressionMediator>
    {
        #region constructors
        private DateTimeOffsetExpressionMediator()
        {
        }

        public DateTimeOffsetExpressionMediator(IExpressionElement expression) : base(expression)
        {
        }

        protected DateTimeOffsetExpressionMediator(IExpressionElement expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public DateTimeOffsetElement As(string alias)
            => new DateTimeOffsetExpressionMediator(base.Expression, alias);
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
