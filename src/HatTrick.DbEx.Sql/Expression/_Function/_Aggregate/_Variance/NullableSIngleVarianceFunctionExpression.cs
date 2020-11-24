using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleVarianceFunctionExpression :
        NullableVarianceFunctionExpression<float,float?>,
        NullableSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleVarianceFunctionExpression>
    {
        #region constructors
        public NullableSingleVarianceFunctionExpression(NullableByteElement expression) : base(expression)
        {

        }

        public NullableSingleVarianceFunctionExpression(NullableInt16Element expression) : base(expression)
        {

        }

        public NullableSingleVarianceFunctionExpression(NullableInt32Element expression) : base(expression)
        {

        }

        public NullableSingleVarianceFunctionExpression(NullableInt64Element expression) : base(expression)
        {

        }

        public NullableSingleVarianceFunctionExpression(NullableDoubleElement expression) : base(expression)
        {

        }

        public NullableSingleVarianceFunctionExpression(NullableDecimalElement expression) : base(expression)
        {

        }

        public NullableSingleVarianceFunctionExpression(NullableSingleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public NullableSingleElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public NullableSingleVarianceFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
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
