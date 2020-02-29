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

        public NullableSingleExpressionMediator(ExpressionContainer expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableSingleExpressionMediator As(string alias)
        {
            base.As(alias);
            return this;
        }
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
