using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32ExpressionMediator :
        ExpressionMediator<int>,
        IEquatable<Int32ExpressionMediator>
    {
        #region constructors
        private Int32ExpressionMediator()
        {
        }

        public Int32ExpressionMediator(IDbExpression expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new Int32ExpressionMediator As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int32ExpressionMediator obj)
            => obj is Int32ExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32ExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
