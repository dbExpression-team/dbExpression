using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalAverageFunctionExpression :
        NullableAverageFunctionExpression<decimal,decimal?>,
        NullDecimalElement,
        AnyDecimalElement,
        IEquatable<NullableDecimalAverageFunctionExpression>
    {
        #region constructors
        public NullableDecimalAverageFunctionExpression(NullDecimalElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }
        
        protected NullableDecimalAverageFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullDecimalElement As(string alias)
            => new NullableDecimalAverageFunctionExpression(base.Expression, base.IsDistinct, alias);
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
