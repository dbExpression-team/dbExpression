using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32CastFunctionExpression :
        NullableCastFunctionExpression<int,int?>,
        NullInt32Element,
        AnyInt32Element,
        IEquatable<NullableInt32CastFunctionExpression>
    {
        #region constructors
        public NullableInt32CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }

        protected NullableInt32CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias)
            : base(expression, convertToDbType, size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public NullInt32Element As(string alias)
            => new NullableInt32CastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt32CastFunctionExpression obj)
            => obj is NullableInt32CastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32CastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
