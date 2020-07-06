using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32MinimumFunctionExpression :
        NullableMinimumFunctionExpression<int>,
        IEquatable<NullableInt32MinimumFunctionExpression>
    {
        #region constructors
        public NullableInt32MinimumFunctionExpression(NullableExpressionMediator<int> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableInt32MinimumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt32MinimumFunctionExpression obj)
            => obj is NullableInt32MinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32MinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
