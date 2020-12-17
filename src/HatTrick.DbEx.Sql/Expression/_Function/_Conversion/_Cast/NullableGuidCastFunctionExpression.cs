using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidCastFunctionExpression :
        NullableCastFunctionExpression<Guid,Guid?>,
        NullableGuidElement,
        AnyGuidElement,
        IEquatable<NullableGuidCastFunctionExpression>
    {
        #region constructors
        public NullableGuidCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public NullableGuidElement As(string alias)
            => new NullableGuidSelectExpression(this).As(alias);
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
