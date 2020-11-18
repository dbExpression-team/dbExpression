using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableBooleanIsNullFunctionExpression :
        NullableIsNullFunctionExpression<bool,bool?>,
        NullBooleanElement,
        AnyBooleanElement,
        IEquatable<NullableBooleanIsNullFunctionExpression>
    {
        #region constructors
        public NullableBooleanIsNullFunctionExpression(AnyBooleanElement expression, NullBooleanElement value)
            : base(expression, value)
        {

        }

        protected NullableBooleanIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias)
            : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public NullBooleanElement As(string alias)
            => new NullableBooleanIsNullFunctionExpression(base.Expression, base.Value, alias);
        #endregion

        #region equals
        public bool Equals(NullableBooleanIsNullFunctionExpression obj)
            => obj is NullableBooleanIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableBooleanIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
