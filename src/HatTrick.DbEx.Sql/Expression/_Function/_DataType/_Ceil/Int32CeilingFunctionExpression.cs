using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32CeilingFunctionExpression :
        CeilFunctionExpression<int>,
        Int32Element,
        AnyInt32Element,
        IEquatable<Int32CeilingFunctionExpression>
    {
        #region constructors
        public Int32CeilingFunctionExpression(Int32Element expression) : base(expression)
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
        public bool Equals(Int32CeilingFunctionExpression obj)
            => obj is Int32CeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32CeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
