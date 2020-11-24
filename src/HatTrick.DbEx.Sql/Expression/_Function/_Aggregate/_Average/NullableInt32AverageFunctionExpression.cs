using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32AverageFunctionExpression :
        NullableAverageFunctionExpression<int,int?>,
        NullableInt32Element,
        AnyInt32Element,
        IEquatable<NullableInt32AverageFunctionExpression>
    {
        #region constructors
        public NullableInt32AverageFunctionExpression(NullableByteElement expression) : base(expression)
        {

        }

        public NullableInt32AverageFunctionExpression(NullableInt16Element expression) : base(expression)
        {

        }

        public NullableInt32AverageFunctionExpression(NullableInt32Element expression) : base(expression)
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
        public NullableInt32AverageFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt32AverageFunctionExpression obj)
            => obj is NullableInt32AverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32AverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
