using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleAverageFunctionExpression :
        NullableAverageFunctionExpression<float,float?>,
        NullSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleAverageFunctionExpression>
    {
        #region constructors
        public NullableSingleAverageFunctionExpression(NullSingleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected NullableSingleAverageFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullSingleElement As(string alias)
            => new NullableSingleAverageFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableSingleAverageFunctionExpression obj)
            => obj is NullableSingleAverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleAverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
