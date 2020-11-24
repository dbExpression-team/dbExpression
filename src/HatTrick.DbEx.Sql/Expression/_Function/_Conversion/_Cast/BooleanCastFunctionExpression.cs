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
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public BooleanElement As(string alias)
        {
            Alias = alias;
            return this;
        }
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
