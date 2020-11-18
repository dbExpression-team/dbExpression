using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalIsNullFunctionExpression :
        NullableIsNullFunctionExpression<decimal,decimal?>,
        NullDecimalElement,
        AnyDecimalElement,
        IEquatable<NullableDecimalIsNullFunctionExpression>
    {
        #region constructors
        public NullableDecimalIsNullFunctionExpression(AnyDecimalElement expression, NullDecimalElement value)
            : base(expression, value)
        {

        }

        protected NullableDecimalIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias)
            : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public NullDecimalElement As(string alias)
            => new NullableDecimalIsNullFunctionExpression(base.Expression, base.Value, alias);
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
