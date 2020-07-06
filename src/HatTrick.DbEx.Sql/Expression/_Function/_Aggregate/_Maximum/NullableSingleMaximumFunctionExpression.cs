using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleMaximumFunctionExpression :
        NullableMaximumFunctionExpression<float>,
        IEquatable<NullableSingleMaximumFunctionExpression>
    {
        #region constructors
        public NullableSingleMaximumFunctionExpression(NullableExpressionMediator<float> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableSingleMaximumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableSingleMaximumFunctionExpression obj)
            => obj is NullableSingleMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
