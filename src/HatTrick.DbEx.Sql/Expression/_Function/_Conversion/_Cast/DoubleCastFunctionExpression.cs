using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleCastFunctionExpression :
        CastFunctionExpression<double>,
        IEquatable<DoubleCastFunctionExpression>
    {
        #region constructors
        public DoubleCastFunctionExpression(ExpressionContainer expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new DoubleCastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DoubleCastFunctionExpression obj)
            => obj is DoubleCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
