using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidCastFunctionExpression :
        NullableCastFunctionExpression<Guid>,
        IEquatable<NullableGuidCastFunctionExpression>
    {
        #region constructors
        public NullableGuidCastFunctionExpression(ExpressionContainer expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new NullableGuidCastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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
