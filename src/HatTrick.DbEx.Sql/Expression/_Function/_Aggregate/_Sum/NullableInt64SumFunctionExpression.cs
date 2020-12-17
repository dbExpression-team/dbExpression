using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64SumFunctionExpression :
        NullableSumFunctionExpression<long,long?>,
        NullableInt64Element,
        AnyInt64Element,
        IEquatable<NullableInt64SumFunctionExpression>
    {
        #region constructors
        public NullableInt64SumFunctionExpression(NullableInt64Element expression) : base(expression)
        {

        }
        #endregion

        #region as
        public NullableInt64Element As(string alias)
            => new NullableInt64SelectExpression(this).As(alias);
        #endregion

        #region distinct
        public NullableInt64SumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt64SumFunctionExpression obj)
            => obj is NullableInt64SumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64SumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
