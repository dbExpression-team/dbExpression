using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16CeilingFunctionExpression :
        NullableCeilFunctionExpression<short,short?>,
        NullableInt16Element,
        AnyInt16Element,
        IEquatable<NullableInt16CeilingFunctionExpression>
    {
        #region constructors
        public NullableInt16CeilingFunctionExpression(NullableInt16Element expression) 
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

        #region equals
        public bool Equals(NullableInt16CeilingFunctionExpression obj)
            => obj is NullableInt16CeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16CeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
