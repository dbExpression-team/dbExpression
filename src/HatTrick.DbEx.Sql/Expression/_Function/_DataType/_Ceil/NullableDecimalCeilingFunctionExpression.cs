using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalCeilingFunctionExpression :
        NullableCeilFunctionExpression<decimal,decimal?>,
        NullDecimalElement,
        AnyDecimalElement,
        IEquatable<NullableDecimalCeilingFunctionExpression>
    {
        #region constructors
        public NullableDecimalCeilingFunctionExpression(NullDecimalElement expression) : base(expression)
        {

        }

        protected NullableDecimalCeilingFunctionExpression(IExpressionElement expression, string alias) : base(expression, alias)
        {

        }
        #endregion

        #region as
        public NullDecimalElement As(string alias)
            => new NullableDecimalCeilingFunctionExpression(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableDecimalCeilingFunctionExpression obj)
            => obj is NullableDecimalCeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalCeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
