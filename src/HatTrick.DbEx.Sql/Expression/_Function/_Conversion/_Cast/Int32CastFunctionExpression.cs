using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32CastFunctionExpression :
        CastFunctionExpression<int>,
        IEquatable<Int32CastFunctionExpression>
    {
        #region constructors
        public Int32CastFunctionExpression(ExpressionContainer expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new Int32CastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int32CastFunctionExpression obj)
            => obj is Int32CastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32CastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
