using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSinglePopulationVarianceFunctionExpression :
        NullablePopulationVarianceFunctionExpression<float,float?>,
        NullSingleElement,
        AnySingleElement,
        IEquatable<NullableSinglePopulationVarianceFunctionExpression>
    {
        #region constructors
        public NullableSinglePopulationVarianceFunctionExpression(NullByteElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSinglePopulationVarianceFunctionExpression(NullInt16Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSinglePopulationVarianceFunctionExpression(NullInt32Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSinglePopulationVarianceFunctionExpression(NullInt64Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSinglePopulationVarianceFunctionExpression(NullDoubleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSinglePopulationVarianceFunctionExpression(NullDecimalElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSinglePopulationVarianceFunctionExpression(NullSingleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected NullableSinglePopulationVarianceFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullSingleElement As(string alias)
            => new NullableSinglePopulationVarianceFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableSinglePopulationVarianceFunctionExpression obj)
            => obj is NullableSinglePopulationVarianceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSinglePopulationVarianceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
