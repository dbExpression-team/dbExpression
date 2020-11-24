using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleMaximumFunctionExpression :
        NullableMaximumFunctionExpression<float,float?>,
        NullableSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleMaximumFunctionExpression>
    {
        #region constructors
        public NullableSingleMaximumFunctionExpression(NullableSingleElement expression) 
            : base(expression)
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
        public NullableSingleMaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableSingleMaximumFunctionExpression obj)
            => obj is NullableSingleMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
