using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16MaximumFunctionExpression :
        NullableMaximumFunctionExpression<short,short?>,
        NullableInt16Element,
        AnyInt16Element,
        IEquatable<NullableInt16MaximumFunctionExpression>
    {
        #region constructors
        public NullableInt16MaximumFunctionExpression(NullableInt16Element expression) 
            : base(expression)
        {

        }
        #endregion

        #region as
        public NullableInt16Element As(string alias)
            => new NullableInt16SelectExpression(this).As(alias);
        #endregion

        #region distinct
        public NullableInt16MaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt16MaximumFunctionExpression obj)
            => obj is NullableInt16MaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16MaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
