using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32MinimumFunctionExpression :
        MinimumFunctionExpression<int>,
        IEquatable<Int32MinimumFunctionExpression>
    {
        #region constructors
        public Int32MinimumFunctionExpression(ExpressionMediator<int> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new Int32MinimumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int32MinimumFunctionExpression obj)
            => obj is Int32MinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32MinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
