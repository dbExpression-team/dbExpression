using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleCeilingFunctionExpression :
        NullableCeilFunctionExpression<float>,
        IEquatable<NullableSingleCeilingFunctionExpression>
    {
        #region constructors
        public NullableSingleCeilingFunctionExpression(NullableExpressionMediator<float> expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableSingleCeilingFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableSingleCeilingFunctionExpression obj)
            => obj is NullableSingleCeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleCeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
