using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalMaximumFunctionExpression :
        NullableMaximumFunctionExpression<decimal,decimal?>,
        NullableDecimalElement,
        AnyDecimalElement,
        IEquatable<NullableDecimalMaximumFunctionExpression>
    {
        #region constructors
        public NullableDecimalMaximumFunctionExpression(NullableDecimalElement expression) 
            : base(expression)
        {

        }
        #endregion

        #region as
        public NullableDecimalElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public NullableDecimalMaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDecimalMaximumFunctionExpression obj)
            => obj is NullableDecimalMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
