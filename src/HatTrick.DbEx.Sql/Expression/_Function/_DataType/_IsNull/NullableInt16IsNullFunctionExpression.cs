using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16IsNullFunctionExpression :
        NullableIsNullFunctionExpression<short,short?>,
        NullableInt16Element,
        AnyInt16Element,
        IEquatable<NullableInt16IsNullFunctionExpression>
    {
        #region constructors
        public NullableInt16IsNullFunctionExpression(AnyInt16Element expression, NullableInt16Element value)
            : base(expression, value)
        {

        }
        #endregion

        #region as
        public NullableInt16Element As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt16IsNullFunctionExpression obj)
            => obj is NullableInt16IsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16IsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
