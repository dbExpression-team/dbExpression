using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleExpressionMediator :
        NullableExpressionMediator<float>,
        IEquatable<NullableSingleExpressionMediator>
    {
        #region constructors
        private NullableSingleExpressionMediator()
        {
        }

        public NullableSingleExpressionMediator(IExpression expression) : base(expression, typeof(float?))
        {
        }

        protected NullableSingleExpressionMediator(IExpression expression, string alias) : base(expression, typeof(float?), alias)
        {
        }
        #endregion

        #region as
        public new NullableSingleExpressionMediator As(string alias)
            => new NullableSingleExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableSingleExpressionMediator obj)
            => obj is NullableSingleExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
