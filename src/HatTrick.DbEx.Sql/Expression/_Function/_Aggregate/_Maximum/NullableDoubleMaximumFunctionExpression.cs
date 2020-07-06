using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleMaximumFunctionExpression :
        NullableMaximumFunctionExpression<double>,
        IEquatable<NullableDoubleMaximumFunctionExpression>
    {
        #region constructors
        public NullableDoubleMaximumFunctionExpression(NullableExpressionMediator<double> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableDoubleMaximumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDoubleMaximumFunctionExpression obj)
            => obj is NullableDoubleMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
