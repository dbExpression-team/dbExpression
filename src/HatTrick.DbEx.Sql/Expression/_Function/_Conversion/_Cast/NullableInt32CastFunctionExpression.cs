using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32CastFunctionExpression :
        NullableCastFunctionExpression<int,int?>,
        NullableInt32Element,
        AnyInt32Element,
        IEquatable<NullableInt32CastFunctionExpression>
    {
        #region constructors
        public NullableInt32CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public NullableInt32Element As(string alias)
            => new NullableInt32SelectExpression(this).As(alias);
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
