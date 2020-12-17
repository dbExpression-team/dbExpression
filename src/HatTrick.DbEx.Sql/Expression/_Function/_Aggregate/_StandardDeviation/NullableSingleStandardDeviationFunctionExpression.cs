using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleStandardDeviationFunctionExpression :
        NullableStandardDeviationFunctionExpression<float,float?>,
        NullableSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleStandardDeviationFunctionExpression>
    {
        #region constructors
        public NullableSingleStandardDeviationFunctionExpression(NullableByteElement expression) : base(expression)
        {

        }
        
        public NullableSingleStandardDeviationFunctionExpression(NullableInt16Element expression) : base(expression)
        {

        }

        public NullableSingleStandardDeviationFunctionExpression(NullableInt32Element expression) : base(expression)
        {

        }

        public NullableSingleStandardDeviationFunctionExpression(NullableInt64Element expression) : base(expression)
        {

        }

        public NullableSingleStandardDeviationFunctionExpression(NullableDoubleElement expression) : base(expression)
        {

        }

        public NullableSingleStandardDeviationFunctionExpression(NullableDecimalElement expression) : base(expression)
        {

        }

        public NullableSingleStandardDeviationFunctionExpression(NullableSingleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public NullableSingleElement As(string alias)
            => new NullableSingleSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public NullableSingleStandardDeviationFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
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
