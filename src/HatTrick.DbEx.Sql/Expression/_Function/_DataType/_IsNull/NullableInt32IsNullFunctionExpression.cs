using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32IsNullFunctionExpression :
        NullableIsNullFunctionExpression<int,int?>,
        NullableInt32Element,
        AnyInt32Element,
        IEquatable<NullableInt32IsNullFunctionExpression>
    {
        #region constructors
        public NullableInt32IsNullFunctionExpression(AnyInt32Element expression, NullableInt32Element value)
            : base(expression, value)
        {

        }
        #endregion

        #region as
        public NullableInt32Element As(string alias)
            => new NullableInt32SelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableInt32IsNullFunctionExpression obj)
            => obj is NullableInt32IsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32IsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
