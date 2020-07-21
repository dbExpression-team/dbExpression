using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32CeilingFunctionExpression :
        NullableCeilFunctionExpression<int>,
        IEquatable<NullableInt32CeilingFunctionExpression>
    {
        #region constructors
        public NullableInt32CeilingFunctionExpression(NullableExpressionMediator<int> expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableInt32CeilingFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt32CeilingFunctionExpression obj)
            => obj is NullableInt32CeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32CeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
