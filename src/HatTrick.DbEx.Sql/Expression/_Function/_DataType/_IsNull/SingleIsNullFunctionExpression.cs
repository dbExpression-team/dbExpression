using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleIsNullFunctionExpression :
        IsNullFunctionExpression<float>,
        IEquatable<SingleIsNullFunctionExpression>
    {
        #region constructors
        public SingleIsNullFunctionExpression(NullableExpressionMediator<float> expression, ExpressionMediator<float> value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new SingleIsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SingleIsNullFunctionExpression obj)
            => obj is SingleIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
