using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalMinimumFunctionExpression :
        NullableMinimumFunctionExpression<decimal>,
        IEquatable<NullableDecimalMinimumFunctionExpression>
    {
        #region constructors
        public NullableDecimalMinimumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableDecimalMinimumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDecimalMinimumFunctionExpression obj)
            => obj is NullableDecimalMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
