using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class BooleanIsNullFunctionExpression :
        IsNullFunctionExpression<bool>,
        IEquatable<BooleanIsNullFunctionExpression>
    {
        #region constructors
        public BooleanIsNullFunctionExpression(ExpressionMediator<bool> expression, ExpressionMediator<bool> notNull) : base(expression, notNull)
        {
        }
        #endregion

        #region as
        public new BooleanIsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(BooleanIsNullFunctionExpression obj)
            => obj is BooleanIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is BooleanIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
