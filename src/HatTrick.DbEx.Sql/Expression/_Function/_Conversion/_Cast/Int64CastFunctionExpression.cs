using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64CastFunctionExpression :
        CastFunctionExpression<long>,
        IEquatable<Int64CastFunctionExpression>
    {
        #region constructors
        public Int64CastFunctionExpression(ExpressionMediator expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new Int64CastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int64CastFunctionExpression obj)
            => obj is Int64CastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int64CastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
