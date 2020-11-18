using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleFloorFunctionExpression :
        NullableFloorFunctionExpression<float,float?>,
        NullSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleFloorFunctionExpression>
    {
        #region constructors
        public NullableSingleFloorFunctionExpression(NullSingleElement expression) : base(expression)
        {

        }

        public NullableSingleFloorFunctionExpression(IExpressionElement expression, string alias) : base(expression, alias)
        {

        }
        #endregion

        #region as
        public NullSingleElement As(string alias)
            => new NullableSingleFloorFunctionExpression(base.Expression, alias);
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
