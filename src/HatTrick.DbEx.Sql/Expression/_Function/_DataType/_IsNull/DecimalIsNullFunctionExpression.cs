using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalIsNullFunctionExpression :
        IsNullFunctionExpression<decimal>,
        IEquatable<DecimalIsNullFunctionExpression>
    {
        #region constructors
        public DecimalIsNullFunctionExpression(ExpressionContainer expression, ExpressionContainer value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new DecimalIsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DecimalIsNullFunctionExpression obj)
            => obj is DecimalIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DecimalIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
