using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeExpressionMediator :
        NullableExpressionMediator<DateTime,DateTime?>,
        NullableDateTimeElement,
        AnyDateTimeElement,
        IEquatable<NullableDateTimeExpressionMediator>
    {
        #region constructors
        private NullableDateTimeExpressionMediator()
        {
        }

        public NullableDateTimeExpressionMediator(IExpressionElement expression) : base(expression, typeof(DateTime?))
        {
        }

        protected NullableDateTimeExpressionMediator(IExpressionElement expression, string alias) : base(expression, typeof(DateTime?), alias)
        {
        }
        #endregion

        #region as
        public NullableDateTimeElement As(string alias)
            => new NullableDateTimeSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeExpressionMediator obj)
            => obj is NullableDateTimeExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
