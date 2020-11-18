using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanExpressionMediator :
        NullableExpressionMediator<TimeSpan,TimeSpan?>,
        NullTimeSpanElement,
        AnyTimeSpanElement,
        IEquatable<NullableTimeSpanExpressionMediator>
    {
        #region constructors
        private NullableTimeSpanExpressionMediator()
        {
        }

        public NullableTimeSpanExpressionMediator(IExpressionElement expression) : base(expression, typeof(TimeSpan?))
        {
        }

        protected NullableTimeSpanExpressionMediator(IExpressionElement expression, string alias) : base(expression, typeof(TimeSpan?), alias)
        {
        }
        #endregion

        #region as
        public NullTimeSpanElement As(string alias)
            => new NullableTimeSpanExpressionMediator(base.Expression, alias);
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
