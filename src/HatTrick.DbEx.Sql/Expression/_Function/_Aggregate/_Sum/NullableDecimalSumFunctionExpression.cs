using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalSumFunctionExpression :
        NullableSumFunctionExpression<decimal>,
        IEquatable<NullableDecimalSumFunctionExpression>
    {
        #region constructors
        public NullableDecimalSumFunctionExpression(NullableExpressionMediator<decimal> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableDecimalSumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDecimalSumFunctionExpression obj)
            => obj is NullableDecimalSumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalSumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
