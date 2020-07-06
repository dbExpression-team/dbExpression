using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringCastFunctionExpression :
        CastFunctionExpression<string>,
        IEquatable<StringCastFunctionExpression>
    {
        #region constructors
        public StringCastFunctionExpression(ExpressionMediator expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new StringCastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(StringCastFunctionExpression obj)
            => obj is StringCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is StringCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
