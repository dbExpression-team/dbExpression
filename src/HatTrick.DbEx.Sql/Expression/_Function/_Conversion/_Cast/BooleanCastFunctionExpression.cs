using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class BooleanCastFunctionExpression :
        CastFunctionExpression<bool>,
        IEquatable<BooleanCastFunctionExpression>
    {
        #region constructors
        public BooleanCastFunctionExpression(ExpressionMediator expression, DbTypeExpression convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new BooleanCastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(BooleanCastFunctionExpression obj)
            => obj is BooleanCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is BooleanCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
