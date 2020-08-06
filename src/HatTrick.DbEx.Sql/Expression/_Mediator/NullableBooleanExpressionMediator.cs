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

        public NullableBooleanExpressionMediator(IExpression expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableBooleanExpressionMediator As(string alias)
        {
            base.As(alias);
            return this;
        }
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
