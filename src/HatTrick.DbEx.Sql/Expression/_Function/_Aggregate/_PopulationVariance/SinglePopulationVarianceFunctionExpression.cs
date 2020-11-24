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
        public SinglePopulationVarianceFunctionExpression(ByteElement expression) : base(expression)
        {

        }

        public SinglePopulationVarianceFunctionExpression(Int16Element expression) : base(expression)
        {

        }

        public SinglePopulationVarianceFunctionExpression(Int32Element expression) : base(expression)
        {

        }

        public SinglePopulationVarianceFunctionExpression(Int64Element expression) : base(expression)
        {

        }

        public SinglePopulationVarianceFunctionExpression(DoubleElement expression) : base(expression)
        {

        }

        public SinglePopulationVarianceFunctionExpression(DecimalElement expression) : base(expression)
        {

        }

        public SinglePopulationVarianceFunctionExpression(SingleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public SinglePopulationVarianceFunctionExpression Distinct()
        {
            IsDistinct = true;
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
