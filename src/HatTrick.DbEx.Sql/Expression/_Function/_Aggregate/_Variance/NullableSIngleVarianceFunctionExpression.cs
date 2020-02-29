using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleVarianceFunctionExpression :
        NullableVarianceFunctionExpression<float>,
        IEquatable<NullableSingleVarianceFunctionExpression>
    {
        #region constructors
        public NullableSingleVarianceFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableSingleVarianceFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableSingleVarianceFunctionExpression obj)
            => obj is NullableSingleVarianceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleVarianceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
