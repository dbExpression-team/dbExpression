using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleCastFunctionExpression :
        NullableCastFunctionExpression<float,float?>,
        NullSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleCastFunctionExpression>
    {
        #region constructors
        public NullableSingleCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }

        protected NullableSingleCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias)
            : base(expression, convertToDbType, size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public NullSingleElement As(string alias)
            => new NullableSingleCastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
        #endregion

        #region equals
        public bool Equals(NullableSingleCastFunctionExpression obj)
            => obj is NullableSingleCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
