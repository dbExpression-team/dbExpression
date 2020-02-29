using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalMaximumFunctionExpression :
        NullableMaximumFunctionExpression<decimal>,
        IEquatable<NullableDecimalMaximumFunctionExpression>
    {
        #region constructors
        public NullableDecimalMaximumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableDecimalMaximumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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
