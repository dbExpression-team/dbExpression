using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSinglePopulationVarianceFunctionExpression :
        NullablePopulationVarianceFunctionExpression<float>,
        IEquatable<NullableSinglePopulationVarianceFunctionExpression>
    {
        #region constructors
        public NullableSinglePopulationVarianceFunctionExpression(NullableExpressionMediator<byte> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public NullableSinglePopulationVarianceFunctionExpression(NullableExpressionMediator<short> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public NullableSinglePopulationVarianceFunctionExpression(NullableExpressionMediator<int> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public NullableSinglePopulationVarianceFunctionExpression(NullableExpressionMediator<long> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public NullableSinglePopulationVarianceFunctionExpression(NullableExpressionMediator<double> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public NullableSinglePopulationVarianceFunctionExpression(NullableExpressionMediator<decimal> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public NullableSinglePopulationVarianceFunctionExpression(NullableExpressionMediator<float> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableSinglePopulationVarianceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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
