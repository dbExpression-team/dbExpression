using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16CastFunctionExpression :
        CastFunctionExpression<short>,
        IEquatable<Int16CastFunctionExpression>
    {
        #region constructors
        public Int16CastFunctionExpression(ExpressionContainer expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new Int16CastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int16CastFunctionExpression obj)
            => obj is Int16CastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16CastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
