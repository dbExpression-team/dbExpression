using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16ExpressionMediator :
        ExpressionMediator<short>,
        Int16Element,
        AnyInt16Element,
        IEquatable<Int16ExpressionMediator>
    {
        #region constructors
        private Int16ExpressionMediator()
        {
        }

        public Int16ExpressionMediator(IExpressionElement expression) : base(expression)
        {
        }

        protected Int16ExpressionMediator(IExpressionElement expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public Int16Element As(string alias)
            => new Int16ExpressionMediator(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(Int16ExpressionMediator obj)
            => obj is Int16ExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16ExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
