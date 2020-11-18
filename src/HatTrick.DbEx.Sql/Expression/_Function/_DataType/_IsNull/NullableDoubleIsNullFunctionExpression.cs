using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleIsNullFunctionExpression :
        NullableIsNullFunctionExpression<double,double?>,
        NullDoubleElement,
        AnyDoubleElement,
        IEquatable<NullableDoubleIsNullFunctionExpression>
    {
        #region constructors
        public NullableDoubleIsNullFunctionExpression(AnyDoubleElement expression, NullDoubleElement value)
            : base(expression, value)
        {

        }

        protected NullableDoubleIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias)
            : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public NullDoubleElement As(string alias)
            => new NullableDoubleIsNullFunctionExpression(base.Expression, base.Value, alias);
        #endregion

        #region equals
        public bool Equals(NullableDoubleIsNullFunctionExpression obj)
            => obj is NullableDoubleIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
