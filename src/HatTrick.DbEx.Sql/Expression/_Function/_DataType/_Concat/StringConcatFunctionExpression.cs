using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringConcatFunctionExpression :
        ConcatFunctionExpression<string>,
        StringElement,
        AnyStringElement,
        IEquatable<StringConcatFunctionExpression>
    {
        #region constructors
        public StringConcatFunctionExpression(IList<AnyElement> expressions) : base(expressions?.Cast<IExpressionElement>()?.ToList())
        {

        }
        #endregion

        #region as
        public StringElement As(string alias)
            => new StringSelectExpression(this).As(alias);
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
