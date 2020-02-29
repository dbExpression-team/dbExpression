using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalAverageFunctionExpression :
        NullableAverageFunctionExpression<decimal>,
        IEquatable<NullableDecimalAverageFunctionExpression>
    {
        #region constructors
        public NullableDecimalAverageFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableDecimalAverageFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDecimalAverageFunctionExpression obj)
            => obj is NullableDecimalAverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalAverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
