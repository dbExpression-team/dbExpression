using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64MinimumFunctionExpression :
        NullableMinimumFunctionExpression<long,long?>,
        NullableInt64Element,
        AnyInt64Element,
        IEquatable<NullableInt64MinimumFunctionExpression>
    {
        #region constructors
        public NullableInt64MinimumFunctionExpression(NullableInt64Element expression) 
            : base(expression)
        {

        }
        #endregion

        #region as
        public NullableInt64Element As(string alias)
            => new NullableInt64SelectExpression(this).As(alias);
        #endregion

        #region distinct
        public NullableInt64MinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt64MinimumFunctionExpression obj)
            => obj is NullableInt64MinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64MinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
