using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16IsNullFunctionExpression :
        NullableIsNullFunctionExpression<short,short?>,
        NullInt16Element,
        AnyInt16Element,
        IEquatable<NullableInt16IsNullFunctionExpression>
    {
        #region constructors
        public NullableInt16IsNullFunctionExpression(AnyInt16Element expression, NullInt16Element value)
            : base(expression, value)
        {

        }

        protected NullableInt16IsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias)
            : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public NullInt16Element As(string alias)
            => new NullableInt16IsNullFunctionExpression(base.Expression, base.Value, alias);
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
