using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleCastFunctionExpression :
        NullableCastFunctionExpression<float>,
        IEquatable<NullableSingleCastFunctionExpression>
    {
        #region constructors
        public NullableSingleCastFunctionExpression(ExpressionMediator expression, DbTypeExpression convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new NullableSingleCastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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
