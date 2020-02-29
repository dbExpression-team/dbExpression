using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleMinimumFunctionExpression :
        NullableMinimumFunctionExpression<float>,
        IEquatable<NullableSingleMinimumFunctionExpression>
    {
        #region constructors
        public NullableSingleMinimumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableSingleMinimumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableSingleMinimumFunctionExpression obj)
            => obj is NullableSingleMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
