using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidCastFunctionExpression :
        NullableCastFunctionExpression<Guid,Guid?>,
        NullGuidElement,
        AnyGuidElement,
        IEquatable<NullableGuidCastFunctionExpression>
    {
        #region constructors
        public NullableGuidCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }

        public NullableGuidCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias)
            : base(expression, convertToDbType, size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public NullGuidElement As(string alias)
            => new NullableGuidCastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
        #endregion

        #region equals
        public bool Equals(NullableGuidCastFunctionExpression obj)
            => obj is NullableGuidCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableGuidCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
