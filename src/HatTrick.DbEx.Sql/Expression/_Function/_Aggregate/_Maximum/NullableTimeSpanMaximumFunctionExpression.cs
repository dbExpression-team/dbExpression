using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanMaximumFunctionExpression :
        NullableMaximumFunctionExpression<TimeSpan,TimeSpan?>,
        NullTimeSpanElement,
        AnyTimeSpanElement,
        IEquatable<NullableTimeSpanMaximumFunctionExpression>
    {
        #region constructors
        public NullableTimeSpanMaximumFunctionExpression(NullTimeSpanElement expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        protected NullableTimeSpanMaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) 
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullTimeSpanElement As(string alias)
            => new NullableTimeSpanMaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableTimeSpanMaximumFunctionExpression obj)
            => obj is NullableTimeSpanMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableTimeSpanMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
