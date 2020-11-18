using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16MinimumFunctionExpression :
        MinimumFunctionExpression<short>,
        Int16Element,
        AnyInt16Element,
        IEquatable<Int16MinimumFunctionExpression>
    {
        #region constructors
        public Int16MinimumFunctionExpression(Int16Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected Int16MinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public Int16Element As(string alias)
            => new Int16MinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(Int16MinimumFunctionExpression obj)
            => obj is Int16MinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16MinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
