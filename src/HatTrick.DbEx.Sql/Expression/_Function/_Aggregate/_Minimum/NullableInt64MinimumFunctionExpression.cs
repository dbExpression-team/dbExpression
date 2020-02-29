using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64MinimumFunctionExpression :
        NullableMinimumFunctionExpression<long>,
        IEquatable<NullableInt64MinimumFunctionExpression>
    {
        #region constructors
        public NullableInt64MinimumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableInt64MinimumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt64MinimumFunctionExpression obj)
            => obj is NullableInt64MinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64MinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
