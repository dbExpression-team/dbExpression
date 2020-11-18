using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32AverageFunctionExpression :
        NullableAverageFunctionExpression<int,int?>,
        NullInt32Element,
        AnyInt32Element,
        IEquatable<NullableInt32AverageFunctionExpression>
    {
        #region constructors
        public NullableInt32AverageFunctionExpression(NullByteElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableInt32AverageFunctionExpression(NullInt16Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableInt32AverageFunctionExpression(NullInt32Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected NullableInt32AverageFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullInt32Element As(string alias)
            => new NullableInt32AverageFunctionExpression(base.Expression, base.IsDistinct, alias);
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
