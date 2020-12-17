using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64ExpressionMediator :
        ExpressionMediator<long>,
        Int64Element,
        AnyInt64Element,
        IEquatable<Int64ExpressionMediator>
    {
        #region constructors
        private Int64ExpressionMediator()
        {
        }

        public Int64ExpressionMediator(IExpressionElement expression) : base(expression)
        {
        }

        protected Int64ExpressionMediator(IExpressionElement expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public Int64Element As(string alias)
            => new Int64SelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(Int64ExpressionMediator obj)
            => obj is Int64ExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int64ExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
