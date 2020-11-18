using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16FloorFunctionExpression :
        FloorFunctionExpression<short>,
        Int16Element,
        AnyInt16Element,
        IEquatable<Int16FloorFunctionExpression>
    {
        #region constructors
        public Int16FloorFunctionExpression(Int16Element expression) : base(expression)
        {

        }

        protected Int16FloorFunctionExpression(IExpressionElement expression, string alias) : base(expression, alias)
        {

        }
        #endregion

        #region as
        public Int16Element As(string alias)
            => new Int16FloorFunctionExpression(base.Expression, alias);
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
