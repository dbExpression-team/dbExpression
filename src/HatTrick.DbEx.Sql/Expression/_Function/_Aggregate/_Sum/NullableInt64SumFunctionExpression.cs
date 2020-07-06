using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64SumFunctionExpression :
        NullableSumFunctionExpression<long>,
        IEquatable<NullableInt64SumFunctionExpression>
    {
        #region constructors
        public NullableInt64SumFunctionExpression(NullableExpressionMediator<long> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableInt64SumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt64SumFunctionExpression obj)
            => obj is NullableInt64SumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64SumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
