using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalExpressionMediator :
        NullableExpressionMediator<decimal,decimal?>,
        NullableDecimalElement,
        AnyDecimalElement,
        IEquatable<NullableDecimalExpressionMediator>
    {
        #region constructors
        private NullableDecimalExpressionMediator()
        {
        }

        public NullableDecimalExpressionMediator(IExpressionElement expression) : base(expression, typeof(decimal?))
        {
        }

        protected NullableDecimalExpressionMediator(IExpressionElement expression, string alias) : base(expression, typeof(decimal?), alias)
        {
        }
        #endregion

        #region as
        public NullableDecimalElement As(string alias)
            => new NullableDecimalSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableDecimalExpressionMediator obj)
            => obj is NullableDecimalExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
