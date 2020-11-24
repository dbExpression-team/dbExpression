using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableBooleanIsNullFunctionExpression :
        NullableIsNullFunctionExpression<bool,bool?>,
        NullableBooleanElement,
        AnyBooleanElement,
        IEquatable<NullableBooleanIsNullFunctionExpression>
    {
        #region constructors
        public NullableBooleanIsNullFunctionExpression(AnyBooleanElement expression, NullableBooleanElement value)
            : base(expression, value)
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
        public bool Equals(NullableBooleanIsNullFunctionExpression obj)
            => obj is NullableBooleanIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableBooleanIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
