using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSinglePopulationStandardDeviationFunctionExpression :
        NullablePopulationStandardDeviationFunctionExpression<float>,
        IEquatable<NullableSinglePopulationStandardDeviationFunctionExpression>
    {
        #region constructors
        public NullableSinglePopulationStandardDeviationFunctionExpression(NullableExpressionMediator<byte> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public NullableSinglePopulationStandardDeviationFunctionExpression(NullableExpressionMediator<short> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public NullableSinglePopulationStandardDeviationFunctionExpression(NullableExpressionMediator<int> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public NullableSinglePopulationStandardDeviationFunctionExpression(NullableExpressionMediator<long> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public NullableSinglePopulationStandardDeviationFunctionExpression(NullableExpressionMediator<double> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public NullableSinglePopulationStandardDeviationFunctionExpression(NullableExpressionMediator<decimal> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public NullableSinglePopulationStandardDeviationFunctionExpression(NullableExpressionMediator<float> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableSinglePopulationStandardDeviationFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableSinglePopulationStandardDeviationFunctionExpression obj)
            => obj is NullableSinglePopulationStandardDeviationFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSinglePopulationStandardDeviationFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
