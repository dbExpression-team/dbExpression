using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalMinimumFunctionExpression :
        NullableMinimumFunctionExpression<decimal,decimal?>,
        NullableDecimalElement,
        AnyDecimalElement,
        IEquatable<NullableDecimalMinimumFunctionExpression>
    {
        #region constructors
        public NullableDecimalMinimumFunctionExpression(NullableDecimalElement expression) 
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
        public NullableDecimalMinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDecimalMinimumFunctionExpression obj)
            => obj is NullableDecimalMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
