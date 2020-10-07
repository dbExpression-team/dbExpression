using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetExpressionMediator :
        NullableExpressionMediator<DateTimeOffset>,
        IEquatable<NullableDateTimeOffsetExpressionMediator>
    {
        #region constructors
        private NullableDateTimeOffsetExpressionMediator()
        {
        }

        public NullableDateTimeOffsetExpressionMediator(IExpression expression) : base(expression, typeof(DateTimeOffset?))
        {
        }

        protected NullableDateTimeOffsetExpressionMediator(IExpression expression, string alias) : base(expression, typeof(DateTimeOffset?), alias)
        {
        }
        #endregion

        #region as
        public new NullableDateTimeOffsetExpressionMediator As(string alias)
            => new NullableDateTimeOffsetExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetExpressionMediator obj)
            => obj is NullableDateTimeOffsetExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
