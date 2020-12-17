using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleCastFunctionExpression :
        NullableCastFunctionExpression<double,double?>,
        NullableDoubleElement,
        AnyDoubleElement,
        IEquatable<NullableDoubleCastFunctionExpression>
    {
        #region constructors
        public NullableDoubleCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public NullableDoubleElement As(string alias)
            => new NullableDoubleSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableDoubleCastFunctionExpression obj)
            => obj is NullableDoubleCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
