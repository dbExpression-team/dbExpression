using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16MinimumFunctionExpression :
        NullableMinimumFunctionExpression<short,short?>,
        NullableInt16Element,
        AnyInt16Element,
        IEquatable<NullableInt16MinimumFunctionExpression>
    {
        #region constructors
        public NullableInt16MinimumFunctionExpression(NullableInt16Element expression) 
            : base(expression)
        {

        }
        #endregion

        #region as
        public NullableInt16Element As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public NullableInt16MinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt16MinimumFunctionExpression obj)
            => obj is NullableInt16MinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16MinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
