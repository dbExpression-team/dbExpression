using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringIsNullFunctionExpression :
        IsNullFunctionExpression<string>,
        IEquatable<StringIsNullFunctionExpression>
    {
        #region constructors
        public StringIsNullFunctionExpression(ExpressionContainer expression, ExpressionContainer value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new StringIsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(StringIsNullFunctionExpression obj)
            => obj is StringIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is StringIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
