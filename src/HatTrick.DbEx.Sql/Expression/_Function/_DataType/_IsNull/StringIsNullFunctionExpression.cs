using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringIsNullFunctionExpression :
        IsNullFunctionExpression<string>,
        StringElement,
        AnyStringElement,
        IEquatable<StringIsNullFunctionExpression>
    {
        #region constructors
        public StringIsNullFunctionExpression(AnyStringElement expression, StringElement value) : base(expression, value)
        {

        }
        #endregion

        #region as
        public StringElement As(string alias)
            => new StringSelectExpression(this).As(alias);
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
