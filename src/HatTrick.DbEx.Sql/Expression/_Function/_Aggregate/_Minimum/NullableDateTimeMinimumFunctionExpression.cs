using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeMinimumFunctionExpression :
        NullableMinimumFunctionExpression<DateTime>,
        IEquatable<NullableDateTimeMinimumFunctionExpression>
    {
        #region constructors
        public NullableDateTimeMinimumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableDateTimeMinimumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDateTimeMinimumFunctionExpression obj)
            => obj is NullableDateTimeMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
