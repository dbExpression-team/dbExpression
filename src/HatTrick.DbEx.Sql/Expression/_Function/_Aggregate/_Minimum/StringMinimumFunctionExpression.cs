using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringMinimumFunctionExpression :
        MinimumFunctionExpression<string>,
        StringElement,
        AnyStringElement,
        IEquatable<StringMinimumFunctionExpression>
    {
        #region constructors
        public StringMinimumFunctionExpression(StringElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected StringMinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public StringElement As(string alias)
            => new StringMinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(StringMinimumFunctionExpression obj)
            => obj is StringMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is StringMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
