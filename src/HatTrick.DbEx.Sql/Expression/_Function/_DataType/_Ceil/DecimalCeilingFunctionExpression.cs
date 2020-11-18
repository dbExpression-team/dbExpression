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

        protected DecimalCeilingFunctionExpression(IExpressionElement expression, string alias) : base(expression, alias)
        {

        }
        #endregion

        #region as
        public DecimalElement As(string alias)
            => new DecimalCeilingFunctionExpression(base.Expression, alias);
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
