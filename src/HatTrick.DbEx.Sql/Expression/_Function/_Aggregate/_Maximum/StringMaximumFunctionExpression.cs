using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringMaximumFunctionExpression :
        MaximumFunctionExpression<string>,
        StringElement,
        AnyStringElement,
        IEquatable<StringMaximumFunctionExpression>
    {
        #region constructors
        public StringMaximumFunctionExpression(StringElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public StringMaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public StringElement As(string alias)
            => new StringMaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(StringMaximumFunctionExpression obj)
            => obj is StringMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is StringMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
