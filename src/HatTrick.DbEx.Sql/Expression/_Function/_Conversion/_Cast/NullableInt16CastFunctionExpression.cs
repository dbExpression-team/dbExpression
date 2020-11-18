using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16CastFunctionExpression :
        NullableCastFunctionExpression<short,short?>,
        NullInt16Element,
        AnyInt16Element,
        IEquatable<NullableInt16CastFunctionExpression>
    {
        #region constructors
        public NullableInt16CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }

        protected NullableInt16CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias)
            : base(expression, convertToDbType, size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public NullInt16Element As(string alias)
            => new NullableInt16CastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
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
