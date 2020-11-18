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

        protected DecimalIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias) : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public DecimalElement As(string alias)
            => new DecimalIsNullFunctionExpression(base.Expression, base.Value, alias);
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
