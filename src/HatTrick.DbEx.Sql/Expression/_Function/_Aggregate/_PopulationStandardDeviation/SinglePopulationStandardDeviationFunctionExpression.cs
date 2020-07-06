using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SinglePopulationStandardDeviationFunctionExpression :
        PopulationStandardDeviationFunctionExpression<float>,
        IEquatable<SinglePopulationStandardDeviationFunctionExpression>
    {
        #region constructors
        public SinglePopulationStandardDeviationFunctionExpression(ExpressionMediator<byte> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public SinglePopulationStandardDeviationFunctionExpression(ExpressionMediator<short> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public SinglePopulationStandardDeviationFunctionExpression(ExpressionMediator<int> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public SinglePopulationStandardDeviationFunctionExpression(ExpressionMediator<long> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public SinglePopulationStandardDeviationFunctionExpression(ExpressionMediator<double> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public SinglePopulationStandardDeviationFunctionExpression(ExpressionMediator<decimal> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public SinglePopulationStandardDeviationFunctionExpression(ExpressionMediator<float> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new SinglePopulationStandardDeviationFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SinglePopulationStandardDeviationFunctionExpression obj)
            => obj is SinglePopulationStandardDeviationFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SinglePopulationStandardDeviationFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
