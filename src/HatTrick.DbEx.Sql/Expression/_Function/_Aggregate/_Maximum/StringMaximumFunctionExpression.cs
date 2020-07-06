using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringMaximumFunctionExpression :
        MaximumFunctionExpression<string>,
        IEquatable<StringMaximumFunctionExpression>
    {
        #region constructors
        public StringMaximumFunctionExpression(ExpressionMediator<string> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new StringMaximumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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
