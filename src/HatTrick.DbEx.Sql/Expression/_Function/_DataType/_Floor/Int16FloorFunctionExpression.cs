using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16FloorFunctionExpression :
        FloorFunctionExpression<short>,
        IEquatable<Int16FloorFunctionExpression>
    {
        #region constructors
        public Int16FloorFunctionExpression(ExpressionMediator<short> expression) : base(expression)
        {

        }
        #endregion

        #region as
        public new Int16FloorFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int16FloorFunctionExpression obj)
            => obj is Int16FloorFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16FloorFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
