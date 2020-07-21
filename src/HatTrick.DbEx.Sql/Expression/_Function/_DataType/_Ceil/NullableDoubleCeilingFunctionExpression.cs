using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleCeilingFunctionExpression :
        NullableCeilFunctionExpression<double>,
        IEquatable<NullableDoubleCeilingFunctionExpression>
    {
        #region constructors
        public NullableDoubleCeilingFunctionExpression(NullableExpressionMediator<double> expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableDoubleCeilingFunctionExpression As(string alias)
        {
            base.As(alias);
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
