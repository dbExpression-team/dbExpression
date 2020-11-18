using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalSumFunctionExpression :
        NullableSumFunctionExpression<decimal,decimal?>,
        NullDecimalElement,
        AnyDecimalElement,
        IEquatable<NullableDecimalSumFunctionExpression>
    {
        #region constructors
        public NullableDecimalSumFunctionExpression(NullDecimalElement expression, bool isDistinct) : base(expression, typeof(decimal?), isDistinct)
        {

        }

        public NullableDecimalSumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, typeof(decimal?), isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullDecimalElement As(string alias)
            => new NullableDecimalSumFunctionExpression(base.Expression, base.IsDistinct, alias);
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
