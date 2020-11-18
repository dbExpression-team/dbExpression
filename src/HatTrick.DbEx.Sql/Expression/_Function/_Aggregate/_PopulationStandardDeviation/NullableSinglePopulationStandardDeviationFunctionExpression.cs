using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSinglePopulationStandardDeviationFunctionExpression :
        NullablePopulationStandardDeviationFunctionExpression<float,float?>,
        NullSingleElement,
        AnySingleElement,
        IEquatable<NullableSinglePopulationStandardDeviationFunctionExpression>
    {
        #region constructors
        public NullableSinglePopulationStandardDeviationFunctionExpression(NullByteElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSinglePopulationStandardDeviationFunctionExpression(NullInt16Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }
        public NullableSinglePopulationStandardDeviationFunctionExpression(NullInt32Element expression, bool isDistinct) : base(expression, isDistinct)
        {
        }

        public NullableSinglePopulationStandardDeviationFunctionExpression(NullInt64Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSinglePopulationStandardDeviationFunctionExpression(NullDoubleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSinglePopulationStandardDeviationFunctionExpression(NullDecimalElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSinglePopulationStandardDeviationFunctionExpression(NullSingleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }
        protected NullableSinglePopulationStandardDeviationFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullSingleElement As(string alias)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(base.Expression, base.IsDistinct, alias);
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
