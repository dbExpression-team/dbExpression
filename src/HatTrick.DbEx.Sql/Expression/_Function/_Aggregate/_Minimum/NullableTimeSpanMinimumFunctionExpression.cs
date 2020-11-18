using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanMinimumFunctionExpression :
        NullableMinimumFunctionExpression<TimeSpan,TimeSpan?>,
        NullTimeSpanElement,
        AnyTimeSpanElement, 
        IEquatable<NullableTimeSpanMinimumFunctionExpression>
    {
        #region constructors
        public NullableTimeSpanMinimumFunctionExpression(NullTimeSpanElement expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        public NullableTimeSpanMinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) 
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullTimeSpanElement As(string alias)
            => new NullableTimeSpanMinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableTimeSpanMinimumFunctionExpression obj)
            => obj is NullableTimeSpanMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableTimeSpanMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
