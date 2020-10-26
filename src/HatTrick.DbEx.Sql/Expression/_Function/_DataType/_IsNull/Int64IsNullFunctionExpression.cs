using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64IsNullFunctionExpression :
        IsNullFunctionExpression<long>,
        IEquatable<Int64IsNullFunctionExpression>
    {
        #region constructors
        public Int64IsNullFunctionExpression(ExpressionMediator<long> expression, ExpressionMediator<long> value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new Int64IsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int64IsNullFunctionExpression obj)
            => obj is Int64IsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int64IsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
