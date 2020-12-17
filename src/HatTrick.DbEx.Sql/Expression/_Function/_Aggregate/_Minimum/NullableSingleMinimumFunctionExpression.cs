using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleMinimumFunctionExpression :
        NullableMinimumFunctionExpression<float,float?>,
        NullableSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleMinimumFunctionExpression>
    {
        #region constructors
        public NullableSingleMinimumFunctionExpression(NullableSingleElement expression) 
            : base(expression)
        {

        }
        #endregion

        #region as
        public NullableSingleElement As(string alias)
            => new NullableSingleSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public NullableSingleMinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableSingleMinimumFunctionExpression obj)
            => obj is NullableSingleMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
