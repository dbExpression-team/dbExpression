using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringMinimumFunctionExpression :
        MinimumFunctionExpression<string>,
        IEquatable<StringMinimumFunctionExpression>
    {
        #region constructors
        public StringMinimumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new StringMinimumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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
