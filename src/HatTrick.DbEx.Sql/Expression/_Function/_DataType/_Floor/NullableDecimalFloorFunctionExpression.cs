using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalFloorFunctionExpression :
        NullableFloorFunctionExpression<decimal,decimal?>,
        NullableDecimalElement,
        AnyDecimalElement,
        IEquatable<NullableDecimalFloorFunctionExpression>
    {
        #region constructors
        public NullableDecimalFloorFunctionExpression(NullableDecimalElement expression) : base(expression)
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
        public bool Equals(NullableDecimalFloorFunctionExpression obj)
            => obj is NullableDecimalFloorFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalFloorFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
