using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleExpressionMediator :
        ExpressionMediator<double>,
        IEquatable<DoubleExpressionMediator>
    {
        #region constructors
        private DoubleExpressionMediator()
        {
        }

        public DoubleExpressionMediator(ExpressionContainer expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new DoubleExpressionMediator As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DoubleExpressionMediator obj)
            => obj is DoubleExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
