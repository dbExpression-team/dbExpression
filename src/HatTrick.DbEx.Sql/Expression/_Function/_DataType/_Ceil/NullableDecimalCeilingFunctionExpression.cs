using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalCeilingFunctionExpression :
        NullableCeilFunctionExpression<decimal,decimal?>,
        NullableDecimalElement,
        AnyDecimalElement,
        IEquatable<NullableDecimalCeilingFunctionExpression>
    {
        #region constructors
        public NullableDecimalCeilingFunctionExpression(NullableDecimalElement expression) : base(expression)
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
        public bool Equals(NullableDecimalCeilingFunctionExpression obj)
            => obj is NullableDecimalCeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalCeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
