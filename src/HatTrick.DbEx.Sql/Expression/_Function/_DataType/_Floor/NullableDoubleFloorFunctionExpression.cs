using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleFloorFunctionExpression :
        NullableFloorFunctionExpression<double,double?>,
        NullDoubleElement,
        AnyDoubleElement,
        IEquatable<NullableDoubleFloorFunctionExpression>
    {
        #region constructors
        public NullableDoubleFloorFunctionExpression(NullDoubleElement expression) : base(expression)
        {

        }

        public NullableDoubleFloorFunctionExpression(IExpressionElement expression, string alias) : base(expression, alias)
        {

        }
        #endregion

        #region as
        public NullDoubleElement As(string alias)
            => new NullableDoubleFloorFunctionExpression(base.Expression, alias);
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
