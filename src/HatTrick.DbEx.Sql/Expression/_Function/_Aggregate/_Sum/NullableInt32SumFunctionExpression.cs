using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32SumFunctionExpression :
        NullableSumFunctionExpression<int>,
        IEquatable<NullableInt32SumFunctionExpression>
    {
        #region constructors
        public NullableInt32SumFunctionExpression(NullableExpressionMediator<byte> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }

        public NullableInt32SumFunctionExpression(NullableExpressionMediator<short> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }

        public NullableInt32SumFunctionExpression(NullableExpressionMediator<int> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableInt32SumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt32SumFunctionExpression obj)
            => obj is NullableInt32SumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32SumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
