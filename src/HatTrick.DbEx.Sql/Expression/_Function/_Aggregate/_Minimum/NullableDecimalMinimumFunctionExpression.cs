using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalMinimumFunctionExpression :
        NullableMinimumFunctionExpression<decimal,decimal?>,
        NullDecimalElement,
        AnyDecimalElement,
        IEquatable<NullableDecimalMinimumFunctionExpression>
    {
        #region constructors
        public NullableDecimalMinimumFunctionExpression(NullDecimalElement expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        protected NullableDecimalMinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) 
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullDecimalElement As(string alias)
            => new NullableDecimalMinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableDecimalMinimumFunctionExpression obj)
            => obj is NullableDecimalMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
