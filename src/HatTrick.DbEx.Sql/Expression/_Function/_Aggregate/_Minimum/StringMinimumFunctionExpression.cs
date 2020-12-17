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
        public StringMinimumFunctionExpression(StringElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public StringElement As(string alias)
            => new StringSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public StringMinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
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
