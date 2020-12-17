using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64AverageFunctionExpression :
        NullableAverageFunctionExpression<long,long?>,
        NullableInt64Element,
        AnyInt64Element,
        IEquatable<NullableInt64AverageFunctionExpression>
    {
        #region constructors
        public NullableInt64AverageFunctionExpression(NullableInt64Element expression) : base(expression)
        {

        }
        #endregion

        #region as
        public NullableInt64Element As(string alias)
             => new NullableInt64SelectExpression(this).As(alias);
        #endregion

        #region distinct
        public NullableInt64AverageFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt64AverageFunctionExpression obj)
            => obj is NullableInt64AverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64AverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
