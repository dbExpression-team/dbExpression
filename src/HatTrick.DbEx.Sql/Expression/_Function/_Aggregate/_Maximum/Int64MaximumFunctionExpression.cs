using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64MaximumFunctionExpression :
        MaximumFunctionExpression<long>,
        IEquatable<Int64MaximumFunctionExpression>
    {
        #region constructors
        public Int64MaximumFunctionExpression(ExpressionMediator<long> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new Int64MaximumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int64MaximumFunctionExpression obj)
            => obj is Int64MaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int64MaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
