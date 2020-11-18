using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16MaximumFunctionExpression :
        MaximumFunctionExpression<short>,
        Int16Element,
        AnyInt16Element,
        IEquatable<Int16MaximumFunctionExpression>
    {
        #region constructors
        public Int16MaximumFunctionExpression(Int16Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected Int16MaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public Int16Element As(string alias)
            => new Int16MaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(Int16MaximumFunctionExpression obj)
            => obj is Int16MaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16MaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
