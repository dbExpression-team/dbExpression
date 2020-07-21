using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleFloorFunctionExpression :
        NullableFloorFunctionExpression<double>,
        IEquatable<NullableDoubleFloorFunctionExpression>
    {
        #region constructors
        public NullableDoubleFloorFunctionExpression(NullableExpressionMediator<double> expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableDoubleFloorFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDoubleFloorFunctionExpression obj)
            => obj is NullableDoubleFloorFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleFloorFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
