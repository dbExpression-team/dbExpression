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
            : base(expression, convertToDbType, typeof(Guid))
        {

        }

        protected GuidCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias)
            : base(expression, convertToDbType, typeof(Guid), size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public GuidElement As(string alias)
            => new GuidCastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
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
