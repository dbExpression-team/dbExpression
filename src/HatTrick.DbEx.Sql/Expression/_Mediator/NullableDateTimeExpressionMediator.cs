using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeExpressionMediator :
        NullableExpressionMediator<DateTime>,
        IEquatable<NullableDateTimeExpressionMediator>
    {
        #region constructors
        private NullableDateTimeExpressionMediator()
        {
        }

        public NullableDateTimeExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected NullableDateTimeExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new NullableDateTimeExpressionMediator As(string alias)
            => new NullableDateTimeExpressionMediator(this.Expression, alias);
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
