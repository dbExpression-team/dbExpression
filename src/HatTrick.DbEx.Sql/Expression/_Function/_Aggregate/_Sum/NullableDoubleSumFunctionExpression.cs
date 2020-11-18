using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleSumFunctionExpression :
        NullableSumFunctionExpression<double,double?>,
        NullDoubleElement,
        AnyDoubleElement,
        IEquatable<NullableDoubleSumFunctionExpression>
    {
        #region constructors
        public NullableDoubleSumFunctionExpression(NullDoubleElement expression, bool isDistinct) : base(expression, typeof(double?), isDistinct)
        {

        }

        protected NullableDoubleSumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, typeof(double?), isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullDoubleElement As(string alias)
            => new NullableDoubleSumFunctionExpression(base.Expression, base.IsDistinct, alias);
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
