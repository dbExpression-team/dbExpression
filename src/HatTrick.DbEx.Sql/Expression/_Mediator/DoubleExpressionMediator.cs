using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleExpressionMediator :
        ExpressionMediator<double>,
        DoubleElement,
        AnyDoubleElement,
        IEquatable<DoubleExpressionMediator>
    {
        #region constructors
        private DoubleExpressionMediator()
        {
        }

        public DoubleExpressionMediator(IExpressionElement expression) : base(expression)
        {
        }

        protected DoubleExpressionMediator(IExpressionElement expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public DoubleElement As(string alias)
            => new DoubleExpressionMediator(base.Expression, alias);
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
