using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableBooleanExpressionMediator :
        NullableExpressionMediator<bool>,
        IEquatable<NullableBooleanExpressionMediator>
    {
        #region constructors
        private NullableBooleanExpressionMediator()
        {
        }

        public NullableBooleanExpressionMediator(IExpression expression) : base(expression, typeof(bool?))
        {
        }

        protected NullableBooleanExpressionMediator(IExpression expression, string alias) : base(expression, typeof(bool?), alias)
        {
        }
        #endregion

        #region as
        public new NullableBooleanExpressionMediator As(string alias)
            => new NullableBooleanExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableBooleanExpressionMediator obj)
            => obj is NullableBooleanExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableBooleanExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
