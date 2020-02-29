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

        public NullableDateTimeExpressionMediator(ExpressionContainer expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableDateTimeExpressionMediator As(string alias)
        {
            base.As(alias);
            return this;
        }
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
