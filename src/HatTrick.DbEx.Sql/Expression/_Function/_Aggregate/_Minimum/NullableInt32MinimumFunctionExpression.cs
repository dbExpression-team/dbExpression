using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32MinimumFunctionExpression :
        NullableMinimumFunctionExpression<int,int?>,
        NullableInt32Element,
        AnyInt32Element,
        IEquatable<NullableInt32MinimumFunctionExpression>
    {
        #region constructors
        public NullableInt32MinimumFunctionExpression(NullableInt32Element expression) 
            : base(expression)
        {

        }
        #endregion

        #region as
        public NullableInt32Element As(string alias)
            => new NullableInt32SelectExpression(this).As(alias);
        #endregion

        #region distinct
        public NullableInt32MinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt32MinimumFunctionExpression obj)
            => obj is NullableInt32MinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32MinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
