using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64MinimumFunctionExpression :
        MinimumFunctionExpression<long>,
        Int64Element,
        AnyInt64Element,
        IEquatable<Int64MinimumFunctionExpression>
    {
        #region constructors
        public Int64MinimumFunctionExpression(Int64Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected Int64MinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public Int64Element As(string alias)
            => new Int64MinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(Int64MinimumFunctionExpression obj)
            => obj is Int64MinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int64MinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
