using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeMinimumFunctionExpression :
        NullableMinimumFunctionExpression<DateTime,DateTime?>,
        NullDateTimeElement,
        AnyDateTimeElement,
        IEquatable<NullableDateTimeMinimumFunctionExpression>
    {
        #region constructors
        public NullableDateTimeMinimumFunctionExpression(NullDateTimeElement expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        protected NullableDateTimeMinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) 
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullDateTimeElement As(string alias)
            => new NullableDateTimeMinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
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
