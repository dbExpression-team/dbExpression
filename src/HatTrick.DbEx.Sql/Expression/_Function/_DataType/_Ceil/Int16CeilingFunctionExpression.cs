using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16CeilingFunctionExpression :
        CeilFunctionExpression<short>,
        IEquatable<Int16CeilingFunctionExpression>
    {
        #region constructors
        public Int16CeilingFunctionExpression(ExpressionMediator<short> expression) : base(expression)
        {

        }
        #endregion

        #region as
        public new Int16CeilingFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int16CeilingFunctionExpression obj)
            => obj is Int16CeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16CeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
