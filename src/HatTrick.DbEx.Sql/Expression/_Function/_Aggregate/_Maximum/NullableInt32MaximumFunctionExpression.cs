using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32MaximumFunctionExpression :
        NullableMaximumFunctionExpression<int,int?>,
        NullableInt32Element,
        AnyInt32Element,
        IEquatable<NullableInt32MaximumFunctionExpression>
    {
        #region constructors
        public NullableInt32MaximumFunctionExpression(NullableInt32Element expression) 
            : base(expression)
        {

        }
        #endregion

        #region as
        public NullableInt32Element As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public NullableInt32MaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt32MaximumFunctionExpression obj)
            => obj is NullableInt32MaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32MaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
