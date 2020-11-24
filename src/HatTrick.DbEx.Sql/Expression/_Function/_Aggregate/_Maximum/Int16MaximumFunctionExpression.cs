using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16MaximumFunctionExpression :
        MaximumFunctionExpression<short>,
        Int16Element,
        AnyInt16Element,
        IEquatable<Int16MaximumFunctionExpression>
    {
        #region constructors
        public Int16MaximumFunctionExpression(Int16Element expression) : base(expression)
        {

        }
        #endregion

        #region as
        public Int16Element As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public Int16MaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int16MaximumFunctionExpression obj)
            => obj is Int16MaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16MaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
