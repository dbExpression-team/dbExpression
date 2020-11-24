using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleAverageFunctionExpression :
        NullableAverageFunctionExpression<float,float?>,
        NullableSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleAverageFunctionExpression>
    {
        #region constructors
        public NullableSingleAverageFunctionExpression(NullableSingleElement expression) : base(expression)
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
        public NullableSingleAverageFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableSingleAverageFunctionExpression obj)
            => obj is NullableSingleAverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleAverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
