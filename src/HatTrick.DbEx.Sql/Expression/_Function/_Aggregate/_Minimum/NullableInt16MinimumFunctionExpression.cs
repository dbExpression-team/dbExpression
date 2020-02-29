using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16MinimumFunctionExpression :
        NullableMinimumFunctionExpression<short>,
        IEquatable<NullableInt16MinimumFunctionExpression>
    {
        #region constructors
        public NullableInt16MinimumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableInt16MinimumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt16MinimumFunctionExpression obj)
            => obj is NullableInt16MinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16MinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
