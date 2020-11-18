using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleSumFunctionExpression :
        NullableSumFunctionExpression<float,float?>,
        NullSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleSumFunctionExpression>
    {
        #region constructors
        public NullableSingleSumFunctionExpression(NullSingleElement expression, bool isDistinct) : base(expression, typeof(float?), isDistinct)
        {

        }

        protected NullableSingleSumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, typeof(float?), isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullSingleElement As(string alias)
            => new NullableSingleSumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableSingleSumFunctionExpression obj)
            => obj is NullableSingleSumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleSumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
