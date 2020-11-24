using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalFloorFunctionExpression :
        FloorFunctionExpression<decimal>,
        DecimalElement,
        AnyDecimalElement,
        IEquatable<DecimalFloorFunctionExpression>
    {
        #region constructors
        public DecimalFloorFunctionExpression(DecimalElement expression) : base(expression)
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
        public bool Equals(DecimalFloorFunctionExpression obj)
            => obj is DecimalFloorFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DecimalFloorFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
