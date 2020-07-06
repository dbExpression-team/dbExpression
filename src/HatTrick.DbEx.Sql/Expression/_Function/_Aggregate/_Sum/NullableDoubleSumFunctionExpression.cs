using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleSumFunctionExpression :
        NullableSumFunctionExpression<double>,
        IEquatable<NullableDoubleSumFunctionExpression>
    {
        #region constructors
        public NullableDoubleSumFunctionExpression(NullableExpressionMediator<double> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableDoubleSumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDoubleSumFunctionExpression obj)
            => obj is NullableDoubleSumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleSumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
