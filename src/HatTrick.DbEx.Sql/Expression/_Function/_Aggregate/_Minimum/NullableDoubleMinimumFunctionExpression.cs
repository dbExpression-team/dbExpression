using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleMinimumFunctionExpression :
        NullableMinimumFunctionExpression<double,double?>,
        NullDoubleElement,
        AnyDoubleElement,
        IEquatable<NullableDoubleMinimumFunctionExpression>
    {
        #region constructors
        public NullableDoubleMinimumFunctionExpression(NullDoubleElement expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        protected NullableDoubleMinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) 
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullDoubleElement As(string alias)
            => new NullableDoubleMinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableDoubleMinimumFunctionExpression obj)
            => obj is NullableDoubleMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
