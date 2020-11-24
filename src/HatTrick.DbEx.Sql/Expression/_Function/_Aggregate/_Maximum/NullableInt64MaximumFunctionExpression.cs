using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64MaximumFunctionExpression :
        NullableMaximumFunctionExpression<long,long?>,
        NullableInt64Element,
        AnyInt64Element,
        IEquatable<NullableInt64MaximumFunctionExpression>
    {
        #region constructors
        public NullableInt64MaximumFunctionExpression(NullableInt64Element expression) 
            : base(expression)
        {

        }
        #endregion

        #region as
        public NullableInt64Element As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public NullableInt64MaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt64MaximumFunctionExpression obj)
            => obj is NullableInt64MaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64MaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
