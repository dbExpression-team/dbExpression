using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringConcatFunctionExpression :
        ConcatFunctionExpression<string>,
        IEquatable<StringConcatFunctionExpression>
    {
        #region constructors
        private StringConcatFunctionExpression()
        {
        }

        public StringConcatFunctionExpression(params StringExpressionMediator[] expressions) : base(expressions)
        {
        }
        #endregion

        #region as
        public new StringConcatFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(StringConcatFunctionExpression obj)
            => obj is StringConcatFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is StringConcatFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
