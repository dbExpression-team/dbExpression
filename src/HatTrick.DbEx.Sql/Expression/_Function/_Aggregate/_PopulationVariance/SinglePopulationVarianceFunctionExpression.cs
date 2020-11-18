using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SinglePopulationVarianceFunctionExpression :
        PopulationVarianceFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SinglePopulationVarianceFunctionExpression>
    {
        #region constructors
        public SinglePopulationVarianceFunctionExpression(ByteElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SinglePopulationVarianceFunctionExpression(Int16Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SinglePopulationVarianceFunctionExpression(Int32Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SinglePopulationVarianceFunctionExpression(Int64Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SinglePopulationVarianceFunctionExpression(DoubleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SinglePopulationVarianceFunctionExpression(DecimalElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SinglePopulationVarianceFunctionExpression(SingleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected SinglePopulationVarianceFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SinglePopulationVarianceFunctionExpression(base.Expression, base.IsDistinct, alias);
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
