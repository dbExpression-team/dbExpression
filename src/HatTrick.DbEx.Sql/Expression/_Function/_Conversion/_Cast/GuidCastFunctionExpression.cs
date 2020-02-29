using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidCastFunctionExpression :
        CastFunctionExpression<Guid>,
        IEquatable<GuidCastFunctionExpression>
    {
        #region constructors
        public GuidCastFunctionExpression(ExpressionContainer expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new GuidCastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(GuidCastFunctionExpression obj)
            => obj is GuidCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is GuidCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
