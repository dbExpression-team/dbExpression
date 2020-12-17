using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleIsNullFunctionExpression :
        NullableIsNullFunctionExpression<double,double?>,
        NullableDoubleElement,
        AnyDoubleElement,
        IEquatable<NullableDoubleIsNullFunctionExpression>
    {
        #region constructors
        public NullableDoubleIsNullFunctionExpression(AnyDoubleElement expression, NullableDoubleElement value)
            : base(expression, value)
        {

        }
        #endregion

        #region as
        public NullableDoubleElement As(string alias)
            => new NullableDoubleSelectExpression(this).As(alias);
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
