using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanExpressionMediator :
        NullableExpressionMediator<TimeSpan>,
        IEquatable<NullableTimeSpanExpressionMediator>
    {
        #region constructors
        private NullableTimeSpanExpressionMediator()
        {
        }

        public NullableTimeSpanExpressionMediator(IExpression expression) : base(expression, typeof(TimeSpan?))
        {
        }

        protected NullableTimeSpanExpressionMediator(IExpression expression, string alias) : base(expression, typeof(TimeSpan?), alias)
        {
        }
        #endregion

        #region as
        public new NullableTimeSpanExpressionMediator As(string alias)
            => new NullableTimeSpanExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableTimeSpanExpressionMediator obj)
            => obj is NullableTimeSpanExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableTimeSpanExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
