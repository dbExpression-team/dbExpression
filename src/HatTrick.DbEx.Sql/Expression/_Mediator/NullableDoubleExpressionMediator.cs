using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleExpressionMediator :
        NullableExpressionMediator<double>,
        IEquatable<NullableDoubleExpressionMediator>
    {
        #region constructors
        private NullableDoubleExpressionMediator()
        {
        }

        public NullableDoubleExpressionMediator(IExpression expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableDoubleExpressionMediator As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDoubleExpressionMediator obj)
            => obj is NullableDoubleExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
