using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalIsNullFunctionExpression :
        NullableIsNullFunctionExpression<decimal>,
        IEquatable<NullableDecimalIsNullFunctionExpression>
    {
        #region constructors
        public NullableDecimalIsNullFunctionExpression(NullableExpressionMediator<decimal> expression, ExpressionMediator<decimal> value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new NullableDecimalIsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDecimalIsNullFunctionExpression obj)
            => obj is NullableDecimalIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
