using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64CastFunctionExpression :
        NullableCastFunctionExpression<long,long?>,
        NullInt64Element,
        AnyInt64Element,
        IEquatable<NullableInt64CastFunctionExpression>
    {
        #region constructors
        public NullableInt64CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }

        protected NullableInt64CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias)
            : base(expression, convertToDbType, size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public NullInt64Element As(string alias)
            => new NullableInt64CastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt64CastFunctionExpression obj)
            => obj is NullableInt64CastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64CastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
