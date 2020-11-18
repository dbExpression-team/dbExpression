using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleMaximumFunctionExpression :
        NullableMaximumFunctionExpression<double,double?>,
        NullDoubleElement,
        AnyDoubleElement,
        IEquatable<NullableDoubleMaximumFunctionExpression>
    {
        #region constructors
        public NullableDoubleMaximumFunctionExpression(NullDoubleElement expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        protected NullableDoubleMaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias)
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullDoubleElement As(string alias)
            => new NullableDoubleMaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableDoubleMaximumFunctionExpression obj)
            => obj is NullableDoubleMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
