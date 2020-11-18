using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32MinimumFunctionExpression :
        MinimumFunctionExpression<int>,
        Int32Element,
        AnyInt32Element,
        IEquatable<Int32MinimumFunctionExpression>
    {
        #region constructors
        public Int32MinimumFunctionExpression(Int32Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected Int32MinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public Int32Element As(string alias)
            => new Int32MinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
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
