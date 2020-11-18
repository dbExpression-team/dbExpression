using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleStandardDeviationFunctionExpression :
        NullableStandardDeviationFunctionExpression<float,float?>,
        NullSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleStandardDeviationFunctionExpression>
    {
        #region constructors
        public NullableSingleStandardDeviationFunctionExpression(NullByteElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }
        
        public NullableSingleStandardDeviationFunctionExpression(NullInt16Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSingleStandardDeviationFunctionExpression(NullInt32Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSingleStandardDeviationFunctionExpression(NullInt64Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSingleStandardDeviationFunctionExpression(NullDoubleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSingleStandardDeviationFunctionExpression(NullDecimalElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public NullableSingleStandardDeviationFunctionExpression(NullSingleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected NullableSingleStandardDeviationFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullSingleElement As(string alias)
            => new NullableSingleStandardDeviationFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableSingleStandardDeviationFunctionExpression obj)
            => obj is NullableSingleStandardDeviationFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleStandardDeviationFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
