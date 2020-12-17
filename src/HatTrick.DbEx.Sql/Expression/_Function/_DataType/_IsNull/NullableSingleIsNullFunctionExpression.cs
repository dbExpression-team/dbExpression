using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleIsNullFunctionExpression :
        NullableIsNullFunctionExpression<float,float?>,
        NullableSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleIsNullFunctionExpression>
    {
        #region constructors
        public NullableSingleIsNullFunctionExpression(AnySingleElement expression, NullableSingleElement value)
            : base(expression, value)
        {

        }
        #endregion

        #region as
        public NullableSingleElement As(string alias)
            => new NullableSingleSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableSingleIsNullFunctionExpression obj)
            => obj is NullableSingleIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
