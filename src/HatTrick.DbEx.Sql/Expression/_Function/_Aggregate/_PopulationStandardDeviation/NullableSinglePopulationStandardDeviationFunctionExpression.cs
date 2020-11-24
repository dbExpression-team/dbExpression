using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSinglePopulationStandardDeviationFunctionExpression :
        NullablePopulationStandardDeviationFunctionExpression<float,float?>,
        NullableSingleElement,
        AnySingleElement,
        IEquatable<NullableSinglePopulationStandardDeviationFunctionExpression>
    {
        #region constructors
        public NullableSinglePopulationStandardDeviationFunctionExpression(NullableByteElement expression) : base(expression)
        {

        }

        public NullableSinglePopulationStandardDeviationFunctionExpression(NullableInt16Element expression) : base(expression)
        {

        }
        public NullableSinglePopulationStandardDeviationFunctionExpression(NullableInt32Element expression) : base(expression)
        {
        }

        public NullableSinglePopulationStandardDeviationFunctionExpression(NullableInt64Element expression) : base(expression)
        {

        }

        public NullableSinglePopulationStandardDeviationFunctionExpression(NullableDoubleElement expression) : base(expression)
        {

        }

        public NullableSinglePopulationStandardDeviationFunctionExpression(NullableDecimalElement expression) : base(expression)
        {

        }

        public NullableSinglePopulationStandardDeviationFunctionExpression(NullableSingleElement expression) : base(expression)
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
        public NullableSinglePopulationStandardDeviationFunctionExpression Distinct()
        {
            IsDistinct = true;
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
