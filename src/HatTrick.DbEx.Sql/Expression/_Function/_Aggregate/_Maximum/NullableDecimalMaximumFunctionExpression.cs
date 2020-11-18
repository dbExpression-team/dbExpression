using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalMaximumFunctionExpression :
        NullableMaximumFunctionExpression<decimal,decimal?>,
        NullDecimalElement,
        AnyDecimalElement,
        IEquatable<NullableDecimalMaximumFunctionExpression>
    {
        #region constructors
        public NullableDecimalMaximumFunctionExpression(NullDecimalElement expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        protected NullableDecimalMaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias)
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullDecimalElement As(string alias)
            => new NullableDecimalMaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableDecimalMaximumFunctionExpression obj)
            => obj is NullableDecimalMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
