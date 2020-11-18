using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableBooleanCastFunctionExpression :
        NullableCastFunctionExpression<bool,bool?>,
        NullBooleanElement,
        AnyBooleanElement,
        IEquatable<NullableBooleanCastFunctionExpression>
    {
        #region constructors
        public NullableBooleanCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }

        protected NullableBooleanCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias)
            : base(expression, convertToDbType, size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public NullBooleanElement As(string alias)
            => new NullableBooleanCastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
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
