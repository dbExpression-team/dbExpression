using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableBooleanIsNullFunctionExpression :
        NullableIsNullFunctionExpression<bool>,
        IEquatable<NullableBooleanIsNullFunctionExpression>
    {
        #region constructors
        public NullableBooleanIsNullFunctionExpression(NullableExpressionMediator<bool> expression, ExpressionMediator<bool> value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new NullableBooleanIsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableBooleanIsNullFunctionExpression obj)
            => obj is NullableBooleanIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableBooleanIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
