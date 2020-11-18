using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class BooleanCastFunctionExpression :
        CastFunctionExpression<bool>,
        BooleanElement,
        AnyBooleanElement,
        IEquatable<BooleanCastFunctionExpression>
    {
        #region constructors
        public BooleanCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType, typeof(bool))
        {

        }

        protected BooleanCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias) 
            : base(expression, convertToDbType, typeof(bool), size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public BooleanElement As(string alias)
            => new BooleanCastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
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
