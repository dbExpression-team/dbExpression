using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalAverageFunctionExpression :
        AverageFunctionExpression<decimal>,
        DecimalElement,
        AnyDecimalElement,
        IEquatable<DecimalAverageFunctionExpression>
    {
        #region constructors
        public DecimalAverageFunctionExpression(DecimalElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public DecimalElement As(string alias)
            => new DecimalSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public DecimalAverageFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DecimalAverageFunctionExpression obj)
            => obj is DecimalAverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DecimalAverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
