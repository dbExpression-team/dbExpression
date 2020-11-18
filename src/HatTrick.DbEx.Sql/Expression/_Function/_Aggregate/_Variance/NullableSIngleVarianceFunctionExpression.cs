using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleVarianceFunctionExpression :
        NullableVarianceFunctionExpression<float,float?>,
        NullSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleVarianceFunctionExpression>
    {
        #region constructors
        public NullableSingleVarianceFunctionExpression(NullByteElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSingleVarianceFunctionExpression(NullInt16Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSingleVarianceFunctionExpression(NullInt32Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSingleVarianceFunctionExpression(NullInt64Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSingleVarianceFunctionExpression(NullDoubleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSingleVarianceFunctionExpression(NullDecimalElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSingleVarianceFunctionExpression(NullSingleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected NullableSingleVarianceFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullSingleElement As(string alias)
            => new NullableSingleVarianceFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableSingleVarianceFunctionExpression obj)
            => obj is NullableSingleVarianceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleVarianceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
