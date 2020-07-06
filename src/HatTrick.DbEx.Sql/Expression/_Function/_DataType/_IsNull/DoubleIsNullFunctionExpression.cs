using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleIsNullFunctionExpression :
        IsNullFunctionExpression<double>,
        IEquatable<DoubleIsNullFunctionExpression>
    {
        #region constructors
        public DoubleIsNullFunctionExpression(NullableExpressionMediator<double> expression, ExpressionMediator<double> value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new DoubleIsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DoubleIsNullFunctionExpression obj)
            => obj is DoubleIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
