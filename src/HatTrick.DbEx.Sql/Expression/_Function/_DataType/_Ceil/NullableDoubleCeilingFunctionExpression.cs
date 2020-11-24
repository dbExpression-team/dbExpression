using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleCeilingFunctionExpression :
        NullableCeilFunctionExpression<double,double?>,
        NullableDoubleElement,
        AnyDoubleElement,
        IEquatable<NullableDoubleCeilingFunctionExpression>
    {
        #region constructors
        public NullableDoubleCeilingFunctionExpression(NullableDoubleElement expression) 
            : base(expression)
        {

        }
        #endregion

        #region as
        public NullableDoubleElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDoubleCeilingFunctionExpression obj)
            => obj is NullableDoubleCeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleCeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
