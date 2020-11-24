using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalCeilingFunctionExpression :
        CeilFunctionExpression<decimal>,
        DecimalElement,
        AnyDecimalElement,
        IEquatable<DecimalCeilingFunctionExpression>
    {
        #region constructors
        public DecimalCeilingFunctionExpression(DecimalElement expression) : base(expression)
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
        public bool Equals(DecimalCeilingFunctionExpression obj)
            => obj is DecimalCeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DecimalCeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
