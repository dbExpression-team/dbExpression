using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64CastFunctionExpression :
        NullableCastFunctionExpression<long,long?>,
        NullableInt64Element,
        AnyInt64Element,
        IEquatable<NullableInt64CastFunctionExpression>
    {
        #region constructors
        public NullableInt64CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public NullableInt64Element As(string alias)
            => new NullableInt64SelectExpression(this).As(alias);
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
