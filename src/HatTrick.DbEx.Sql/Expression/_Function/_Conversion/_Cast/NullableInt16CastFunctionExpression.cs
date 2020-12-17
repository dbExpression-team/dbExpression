using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16CastFunctionExpression :
        NullableCastFunctionExpression<short,short?>,
        NullableInt16Element,
        AnyInt16Element,
        IEquatable<NullableInt16CastFunctionExpression>
    {
        #region constructors
        public NullableInt16CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public NullableInt16Element As(string alias)
            => new NullableInt16SelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableInt16CastFunctionExpression obj)
            => obj is NullableInt16CastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16CastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
