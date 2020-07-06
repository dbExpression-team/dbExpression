using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64MinimumFunctionExpression :
        MinimumFunctionExpression<long>,
        IEquatable<Int64MinimumFunctionExpression>
    {
        #region constructors
        public Int64MinimumFunctionExpression(ExpressionMediator<long> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new Int64MinimumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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
