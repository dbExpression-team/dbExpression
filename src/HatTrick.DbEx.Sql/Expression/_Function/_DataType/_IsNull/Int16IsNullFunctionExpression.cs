using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16IsNullFunctionExpression :
        IsNullFunctionExpression<short>,
        IEquatable<Int16IsNullFunctionExpression>
    {
        #region constructors
        public Int16IsNullFunctionExpression(ExpressionMediator<short> expression, ExpressionMediator<short> value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new Int16IsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int16IsNullFunctionExpression obj)
            => obj is Int16IsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16IsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
