using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32MaximumFunctionExpression :
        MaximumFunctionExpression<int>,
        Int32Element,
        AnyInt32Element,
        IEquatable<Int32MaximumFunctionExpression>
    {
        #region constructors
        public Int32MaximumFunctionExpression(Int32Element expression) : base(expression)
        {

        }
        #endregion

        #region as
        public Int32Element As(string alias)
            => new Int32SelectExpression(this).As(alias);
        #endregion

        #region distinct
        public Int32MaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int32MaximumFunctionExpression obj)
            => obj is Int32MaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32MaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
