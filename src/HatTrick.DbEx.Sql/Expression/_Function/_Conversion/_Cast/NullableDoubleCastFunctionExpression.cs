using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleCastFunctionExpression :
        NullableCastFunctionExpression<double,double?>,
        NullDoubleElement,
        AnyDoubleElement,
        IEquatable<NullableDoubleCastFunctionExpression>
    {
        #region constructors
        public NullableDoubleCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }

        protected NullableDoubleCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias)
            : base(expression, convertToDbType, size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public NullDoubleElement As(string alias)
            => new NullableDoubleCastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
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
