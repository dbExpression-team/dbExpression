using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleIsNullFunctionExpression :
        NullableIsNullFunctionExpression<double>,
        IEquatable<NullableDoubleIsNullFunctionExpression>
    {
        #region constructors
        public NullableDoubleIsNullFunctionExpression(ExpressionMediator<double> expression, ExpressionMediator<double> value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new NullableDoubleIsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDoubleIsNullFunctionExpression obj)
            => obj is NullableDoubleIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
