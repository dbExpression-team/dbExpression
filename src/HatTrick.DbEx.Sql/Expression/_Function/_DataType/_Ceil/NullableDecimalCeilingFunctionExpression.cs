using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalCeilingFunctionExpression :
        NullableCeilFunctionExpression<decimal>,
        IEquatable<NullableDecimalCeilingFunctionExpression>
    {
        #region constructors
        public NullableDecimalCeilingFunctionExpression(NullableExpressionMediator<decimal> expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableDecimalCeilingFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDecimalCeilingFunctionExpression obj)
            => obj is NullableDecimalCeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalCeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
