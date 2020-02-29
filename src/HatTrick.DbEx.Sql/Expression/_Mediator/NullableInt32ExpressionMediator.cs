using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32ExpressionMediator :
        NullableExpressionMediator<int>,
        IEquatable<NullableInt32ExpressionMediator>
    {
        #region constructors
        private NullableInt32ExpressionMediator()
        {
        }

        public NullableInt32ExpressionMediator(ExpressionContainer expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableInt32ExpressionMediator As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt32ExpressionMediator obj)
            => obj is NullableInt32ExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32ExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
