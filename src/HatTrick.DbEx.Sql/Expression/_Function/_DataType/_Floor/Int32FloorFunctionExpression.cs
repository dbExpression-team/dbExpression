using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32FloorFunctionExpression :
        FloorFunctionExpression<int>,
        Int32Element,
        AnyInt32Element,
        IEquatable<Int32FloorFunctionExpression>
    {
        #region constructors
        public Int32FloorFunctionExpression(Int32Element expression) : base(expression)
        {

        }
        #endregion

        #region as
        public Int32Element As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int32FloorFunctionExpression obj)
            => obj is Int32FloorFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32FloorFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
