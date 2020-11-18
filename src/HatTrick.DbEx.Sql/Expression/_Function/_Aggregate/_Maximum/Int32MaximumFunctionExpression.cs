using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32MaximumFunctionExpression :
        MaximumFunctionExpression<int>,
        Int32Element,
        AnyInt32Element,
        IEquatable<Int32MaximumFunctionExpression>
    {
        #region constructors
        public Int32MaximumFunctionExpression(Int32Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected Int32MaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public Int32Element As(string alias)
            => new Int32MaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(Int32MaximumFunctionExpression obj)
            => obj is Int32MaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32MaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
