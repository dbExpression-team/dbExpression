using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleAverageFunctionExpression :
        NullableAverageFunctionExpression<double>,
        IEquatable<NullableDoubleAverageFunctionExpression>
    {
        #region constructors
        public NullableDoubleAverageFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableDoubleAverageFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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
