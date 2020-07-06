using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64MaximumFunctionExpression :
        NullableMaximumFunctionExpression<long>,
        IEquatable<NullableInt64MaximumFunctionExpression>
    {
        #region constructors
        public NullableInt64MaximumFunctionExpression(NullableExpressionMediator<long> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableInt64MaximumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt64MaximumFunctionExpression obj)
            => obj is NullableInt64MaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64MaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
