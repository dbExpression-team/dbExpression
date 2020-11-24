using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32MinimumFunctionExpression :
        MinimumFunctionExpression<int>,
        Int32Element,
        AnyInt32Element,
        IEquatable<Int32MinimumFunctionExpression>
    {
        #region constructors
        public Int32MinimumFunctionExpression(Int32Element expression) : base(expression)
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

        #region distinct
        public Int32MinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int32MinimumFunctionExpression obj)
            => obj is Int32MinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32MinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
