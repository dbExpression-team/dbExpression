using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleSumFunctionExpression :
        NullableSumFunctionExpression<float>,
        IEquatable<NullableSingleSumFunctionExpression>
    {
        #region constructors
        public NullableSingleSumFunctionExpression(NullableExpressionMediator<float> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableSingleSumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableSingleSumFunctionExpression obj)
            => obj is NullableSingleSumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleSumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
