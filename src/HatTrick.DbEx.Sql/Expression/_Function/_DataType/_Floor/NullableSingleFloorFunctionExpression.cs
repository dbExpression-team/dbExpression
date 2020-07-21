using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleFloorFunctionExpression :
        NullableFloorFunctionExpression<float>,
        IEquatable<NullableSingleFloorFunctionExpression>
    {
        #region constructors
        public NullableSingleFloorFunctionExpression(NullableExpressionMediator<float> expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableSingleFloorFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableSingleFloorFunctionExpression obj)
            => obj is NullableSingleFloorFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleFloorFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
