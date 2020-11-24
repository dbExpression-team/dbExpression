using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleFloorFunctionExpression :
        NullableFloorFunctionExpression<double,double?>,
        NullableDoubleElement,
        AnyDoubleElement,
        IEquatable<NullableDoubleFloorFunctionExpression>
    {
        #region constructors
        public NullableDoubleFloorFunctionExpression(NullableDoubleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public NullableDoubleElement As(string alias)
        {
            Alias = alias;
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
