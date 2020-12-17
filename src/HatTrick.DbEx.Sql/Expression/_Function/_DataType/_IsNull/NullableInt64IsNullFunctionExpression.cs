using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64IsNullFunctionExpression :
        NullableIsNullFunctionExpression<long,long?>,
        NullableInt64Element,
        AnyInt64Element,
        IEquatable<NullableInt64IsNullFunctionExpression>
    {
        #region constructors
        public NullableInt64IsNullFunctionExpression(AnyInt64Element expression, NullableInt64Element value)
            : base(expression, value)
        {

        }
        #endregion

        #region as
        public NullableInt64Element As(string alias)
            => new NullableInt64SelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableInt64IsNullFunctionExpression obj)
            => obj is NullableInt64IsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64IsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
