using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSinglePopulationVarianceFunctionExpression :
        NullablePopulationVarianceFunctionExpression<float,float?>,
        NullableSingleElement,
        AnySingleElement,
        IEquatable<NullableSinglePopulationVarianceFunctionExpression>
    {
        #region constructors
        public NullableSinglePopulationVarianceFunctionExpression(NullableByteElement expression) : base(expression)
        {

        }

        public NullableSinglePopulationVarianceFunctionExpression(NullableInt16Element expression) : base(expression)
        {

        }

        public NullableSinglePopulationVarianceFunctionExpression(NullableInt32Element expression) : base(expression)
        {

        }

        public NullableSinglePopulationVarianceFunctionExpression(NullableInt64Element expression) : base(expression)
        {

        }

        public NullableSinglePopulationVarianceFunctionExpression(NullableDoubleElement expression) : base(expression)
        {

        }

        public NullableSinglePopulationVarianceFunctionExpression(NullableDecimalElement expression) : base(expression)
        {

        }

        public NullableSinglePopulationVarianceFunctionExpression(NullableSingleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public NullableSingleElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public NullableSinglePopulationVarianceFunctionExpression Distinct()
        {
            IsDistinct = true;
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
