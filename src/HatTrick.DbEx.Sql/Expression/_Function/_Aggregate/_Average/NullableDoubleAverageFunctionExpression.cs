using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleAverageFunctionExpression :
        NullableAverageFunctionExpression<double,double?>,
        NullDoubleElement,
        AnyDoubleElement,
        IEquatable<NullableDoubleAverageFunctionExpression>
    {
        #region constructors
        public NullableDoubleAverageFunctionExpression(NullDoubleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected NullableDoubleAverageFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullDoubleElement As(string alias)
            => new NullableDoubleAverageFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableDoubleAverageFunctionExpression obj)
            => obj is NullableDoubleAverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleAverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
