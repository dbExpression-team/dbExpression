using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalIsNullFunctionExpression :
        IsNullFunctionExpression<decimal>,
        DecimalElement,
        AnyDecimalElement,
        IEquatable<DecimalIsNullFunctionExpression>
    {
        #region constructors
        public DecimalIsNullFunctionExpression(AnyDecimalElement expression, DecimalElement value) : base(expression, value)
        {

        }
        #endregion

        #region as
        public DecimalElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DecimalIsNullFunctionExpression obj)
            => obj is DecimalIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DecimalIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
