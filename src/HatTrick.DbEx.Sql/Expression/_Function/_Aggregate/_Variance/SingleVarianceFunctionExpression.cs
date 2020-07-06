using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleVarianceFunctionExpression :
        VarianceFunctionExpression<float>,
        IEquatable<SingleVarianceFunctionExpression>
    {
        #region constructors
        public SingleVarianceFunctionExpression(ExpressionMediator<byte> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public SingleVarianceFunctionExpression(ExpressionMediator<short> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public SingleVarianceFunctionExpression(ExpressionMediator<int> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public SingleVarianceFunctionExpression(ExpressionMediator<long> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public SingleVarianceFunctionExpression(ExpressionMediator<double> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public SingleVarianceFunctionExpression(ExpressionMediator<decimal> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public SingleVarianceFunctionExpression(ExpressionMediator<float> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new SingleVarianceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SingleVarianceFunctionExpression obj)
            => obj is SingleVarianceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleVarianceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
