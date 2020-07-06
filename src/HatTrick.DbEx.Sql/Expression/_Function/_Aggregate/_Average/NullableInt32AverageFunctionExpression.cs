using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32AverageFunctionExpression :
        NullableAverageFunctionExpression<int>,
        IEquatable<NullableInt32AverageFunctionExpression>
    {
        #region constructors
        public NullableInt32AverageFunctionExpression(NullableExpressionMediator<byte> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }

        public NullableInt32AverageFunctionExpression(NullableExpressionMediator<short> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }

        public NullableInt32AverageFunctionExpression(NullableExpressionMediator<int> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableInt32AverageFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt32AverageFunctionExpression obj)
            => obj is NullableInt32AverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32AverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
