using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalAverageFunctionExpression :
        NullableAverageFunctionExpression<decimal,decimal?>,
        NullableDecimalElement,
        AnyDecimalElement,
        IEquatable<NullableDecimalAverageFunctionExpression>
    {
        #region constructors
        public NullableDecimalAverageFunctionExpression(NullableDecimalElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public NullableDecimalElement As(string alias)
            => new NullableDecimalSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public NullableDecimalAverageFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDecimalAverageFunctionExpression obj)
            => obj is NullableDecimalAverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalAverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
