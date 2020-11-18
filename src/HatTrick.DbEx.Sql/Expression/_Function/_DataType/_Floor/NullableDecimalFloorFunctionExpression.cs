using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalFloorFunctionExpression :
        NullableFloorFunctionExpression<decimal,decimal?>,
        NullDecimalElement,
        AnyDecimalElement,
        IEquatable<NullableDecimalFloorFunctionExpression>
    {
        #region constructors
        public NullableDecimalFloorFunctionExpression(NullDecimalElement expression) : base(expression)
        {

        }

        public NullableDecimalFloorFunctionExpression(IExpressionElement expression, string alias) : base(expression, alias)
        {

        }
        #endregion

        #region as
        public NullDecimalElement As(string alias)
            => new NullableDecimalFloorFunctionExpression(base.Expression, alias);
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
