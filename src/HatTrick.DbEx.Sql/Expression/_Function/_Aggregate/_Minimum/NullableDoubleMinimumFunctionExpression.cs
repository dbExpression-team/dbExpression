using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleMinimumFunctionExpression :
        NullableMinimumFunctionExpression<double>,
        IEquatable<NullableDoubleMinimumFunctionExpression>
    {
        #region constructors
        public NullableDoubleMinimumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableDoubleMinimumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDoubleMinimumFunctionExpression obj)
            => obj is NullableDoubleMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
