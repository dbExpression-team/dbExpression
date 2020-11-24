using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableBooleanCastFunctionExpression :
        NullableCastFunctionExpression<bool,bool?>,
        NullableBooleanElement,
        AnyBooleanElement,
        IEquatable<NullableBooleanCastFunctionExpression>
    {
        #region constructors
        public NullableBooleanCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public NullableBooleanElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableBooleanCastFunctionExpression obj)
            => obj is NullableBooleanCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableBooleanCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
