using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalIsNullFunctionExpression :
        NullableIsNullFunctionExpression<decimal,decimal?>,
        NullableDecimalElement,
        AnyDecimalElement,
        IEquatable<NullableDecimalIsNullFunctionExpression>
    {
        #region constructors
        public NullableDecimalIsNullFunctionExpression(AnyDecimalElement expression, NullableDecimalElement value)
            : base(expression, value)
        {

        }
        #endregion

        #region as
        public NullableDecimalElement As(string alias)
        {
            Alias = alias;
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
