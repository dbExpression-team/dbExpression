using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleStandardDeviationFunctionExpression :
        NullableStandardDeviationFunctionExpression<float>,
        IEquatable<NullableSingleStandardDeviationFunctionExpression>
    {
        #region constructors
        public NullableSingleStandardDeviationFunctionExpression(NullableExpressionMediator<byte> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public NullableSingleStandardDeviationFunctionExpression(NullableExpressionMediator<short> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public NullableSingleStandardDeviationFunctionExpression(NullableExpressionMediator<int> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public NullableSingleStandardDeviationFunctionExpression(NullableExpressionMediator<long> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public NullableSingleStandardDeviationFunctionExpression(NullableExpressionMediator<double> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public NullableSingleStandardDeviationFunctionExpression(NullableExpressionMediator<decimal> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        public NullableSingleStandardDeviationFunctionExpression(NullableExpressionMediator<float> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableSingleStandardDeviationFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableSingleStandardDeviationFunctionExpression obj)
            => obj is NullableSingleStandardDeviationFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleStandardDeviationFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
