using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SinglePopulationStandardDeviationFunctionExpression :
        PopulationStandardDeviationFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SinglePopulationStandardDeviationFunctionExpression>
    {
        #region constructors
        public SinglePopulationStandardDeviationFunctionExpression(ByteElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SinglePopulationStandardDeviationFunctionExpression(Int16Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }
        public SinglePopulationStandardDeviationFunctionExpression(Int32Element expression, bool isDistinct) : base(expression, isDistinct)
        {
        }

        public SinglePopulationStandardDeviationFunctionExpression(Int64Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SinglePopulationStandardDeviationFunctionExpression(DoubleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SinglePopulationStandardDeviationFunctionExpression(DecimalElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SinglePopulationStandardDeviationFunctionExpression(SingleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }
        protected SinglePopulationStandardDeviationFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SinglePopulationStandardDeviationFunctionExpression(base.Expression, base.IsDistinct, alias);
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
