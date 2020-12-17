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
        public StringMaximumFunctionExpression(StringElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public StringElement As(string alias)
            => new StringSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public StringMaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
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
