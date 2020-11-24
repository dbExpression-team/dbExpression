using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32SumFunctionExpression :
        NullableSumFunctionExpression<int,int?>,
        NullableInt32Element,
        AnyInt32Element,
        IEquatable<NullableInt32SumFunctionExpression>
    {
        #region constructors
        public NullableInt32SumFunctionExpression(NullableByteElement expression) : base(expression)
        {

        }

        public NullableInt32SumFunctionExpression(NullableInt16Element expression) : base(expression)
        {

        }

        public NullableInt32SumFunctionExpression(NullableInt32Element expression) : base(expression)
        {

        }
        #endregion

        #region as
        public NullableInt32Element As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public NullableInt32SumFunctionExpression Distinct()
        {
            IsDistinct = true;
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
