using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SinglePopulationVarianceFunctionExpression :
        PopulationVarianceFunctionExpression<float>,
        IEquatable<SinglePopulationVarianceFunctionExpression>
    {
        #region constructors
        public SinglePopulationVarianceFunctionExpression(ExpressionMediator<byte> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public SinglePopulationVarianceFunctionExpression(ExpressionMediator<short> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public SinglePopulationVarianceFunctionExpression(ExpressionMediator<int> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public SinglePopulationVarianceFunctionExpression(ExpressionMediator<long> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public SinglePopulationVarianceFunctionExpression(ExpressionMediator<double> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public SinglePopulationVarianceFunctionExpression(ExpressionMediator<decimal> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public SinglePopulationVarianceFunctionExpression(ExpressionMediator<float> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new SinglePopulationVarianceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SinglePopulationVarianceFunctionExpression obj)
            => obj is SinglePopulationVarianceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SinglePopulationVarianceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
