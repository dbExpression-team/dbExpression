using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64AverageFunctionExpression :
        NullableAverageFunctionExpression<long>,
        IEquatable<NullableInt64AverageFunctionExpression>
    {
        #region constructors
        public NullableInt64AverageFunctionExpression(NullableExpressionMediator<long> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableInt64AverageFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt64AverageFunctionExpression obj)
            => obj is NullableInt64AverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64AverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
