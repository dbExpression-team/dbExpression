using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableBooleanCastFunctionExpression :
        NullableCastFunctionExpression<bool>,
        IEquatable<NullableBooleanCastFunctionExpression>
    {
        #region constructors
        public NullableBooleanCastFunctionExpression(ExpressionContainer expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new NullableBooleanCastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableBooleanCastFunctionExpression obj)
            => obj is NullableBooleanCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableBooleanCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
