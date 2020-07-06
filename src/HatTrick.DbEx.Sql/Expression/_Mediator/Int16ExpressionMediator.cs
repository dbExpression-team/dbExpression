using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16ExpressionMediator :
        ExpressionMediator<short>,
        IEquatable<Int16ExpressionMediator>
    {
        #region constructors
        private Int16ExpressionMediator()
        {
        }

        public Int16ExpressionMediator(IDbExpression expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new Int16ExpressionMediator As(string alias)
        {
            base.As(alias);
            return this;
        }
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
