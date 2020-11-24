using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64MaximumFunctionExpression :
        MaximumFunctionExpression<long>,
        Int64Element,
        AnyInt64Element,
        IEquatable<Int64MaximumFunctionExpression>
    {
        #region constructors
        public Int64MaximumFunctionExpression(Int64Element expression) : base(expression)
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

        #region distinct
        public Int64MaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int64MaximumFunctionExpression obj)
            => obj is Int64MaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int64MaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
