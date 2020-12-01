using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64CeilingFunctionExpression :
        CeilingFunctionExpression<long>,
        Int64Element,
        AnyInt64Element,
        IEquatable<Int64CeilingFunctionExpression>
    {
        #region constructors
        public Int64CeilingFunctionExpression(Int64Element expression) : base(expression)
        {

        }
        #endregion

        #region as
        public Int64Element As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int64CeilingFunctionExpression obj)
            => obj is Int64CeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int64CeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
