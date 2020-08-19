using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteCastFunctionExpression :
        CastFunctionExpression<byte>,
        IEquatable<ByteCastFunctionExpression>
    {
        #region constructors
        public ByteCastFunctionExpression(ExpressionMediator expression, DbTypeExpression convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new ByteCastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ByteCastFunctionExpression obj)
            => obj is ByteCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
