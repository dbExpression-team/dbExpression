using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64IsNullFunctionExpression :
        NullableIsNullFunctionExpression<long,long?>,
        NullInt64Element,
        AnyInt64Element,
        IEquatable<NullableInt64IsNullFunctionExpression>
    {
        #region constructors
        public NullableInt64IsNullFunctionExpression(AnyInt64Element expression, NullInt64Element value)
            : base(expression, value)
        {

        }

        protected NullableInt64IsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias)
            : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public NullInt64Element As(string alias)
            => new NullableInt64IsNullFunctionExpression(base.Expression, base.Value, alias);
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
