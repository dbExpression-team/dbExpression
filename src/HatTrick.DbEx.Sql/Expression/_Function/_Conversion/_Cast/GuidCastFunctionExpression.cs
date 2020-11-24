using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidCastFunctionExpression :
        CastFunctionExpression<Guid>,
        GuidElement,
        AnyGuidElement,
        IEquatable<GuidCastFunctionExpression>
    {
        #region constructors
        public GuidCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public GuidElement As(string alias)
        {
            Alias = alias;
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
