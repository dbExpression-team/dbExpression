using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32IsNullFunctionExpression :
        NullableIsNullFunctionExpression<int>,
        IEquatable<NullableInt32IsNullFunctionExpression>
    {
        #region constructors
        public NullableInt32IsNullFunctionExpression(ExpressionMediator<int> expression, ExpressionMediator<int> value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new NullableInt32IsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt32IsNullFunctionExpression obj)
            => obj is NullableInt32IsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32IsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
