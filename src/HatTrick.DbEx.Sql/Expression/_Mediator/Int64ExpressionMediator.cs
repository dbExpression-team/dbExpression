using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64ExpressionMediator :
        ExpressionMediator<long>,
        IEquatable<Int64ExpressionMediator>
    {
        #region constructors
        private Int64ExpressionMediator()
        {
        }

        public Int64ExpressionMediator(IDbExpression expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new Int64ExpressionMediator As(string alias)
        {
            base.As(alias);
            return this;
        }
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
