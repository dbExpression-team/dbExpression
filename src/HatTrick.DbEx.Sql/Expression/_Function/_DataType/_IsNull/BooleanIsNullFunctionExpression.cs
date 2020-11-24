using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class BooleanIsNullFunctionExpression :
        IsNullFunctionExpression<bool>,
        BooleanElement,
        AnyBooleanElement,
        IEquatable<BooleanIsNullFunctionExpression>
    {
        #region constructors
        public BooleanIsNullFunctionExpression(AnyBooleanElement expression, BooleanElement value) : base(expression, value)
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
        public bool Equals(BooleanIsNullFunctionExpression obj)
            => obj is BooleanIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is BooleanIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
