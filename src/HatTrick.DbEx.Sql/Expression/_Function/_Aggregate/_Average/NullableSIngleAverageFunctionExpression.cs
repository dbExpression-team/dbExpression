using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleAverageFunctionExpression :
        NullableAverageFunctionExpression<float>,
        IEquatable<NullableSingleAverageFunctionExpression>
    {
        #region constructors
        public NullableSingleAverageFunctionExpression(NullableExpressionMediator<float> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableSingleAverageFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableSingleAverageFunctionExpression obj)
            => obj is NullableSingleAverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleAverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
