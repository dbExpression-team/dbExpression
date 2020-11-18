using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64AverageFunctionExpression :
        NullableAverageFunctionExpression<long,long?>,
        NullInt64Element,
        AnyInt64Element,
        IEquatable<NullableInt64AverageFunctionExpression>
    {
        #region constructors
        public NullableInt64AverageFunctionExpression(NullInt64Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected NullableInt64AverageFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullInt64Element As(string alias)
            => new NullableInt64AverageFunctionExpression(base.Expression, base.IsDistinct, alias);
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
