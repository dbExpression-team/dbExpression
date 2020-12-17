using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleIsNullFunctionExpression :
        IsNullFunctionExpression<double>,
        DoubleElement,
        AnyDoubleElement,
        IEquatable<DoubleIsNullFunctionExpression>
    {
        #region constructors
        public DoubleIsNullFunctionExpression(AnyDoubleElement expression, DoubleElement value) : base(expression, value)
        {

        }
        #endregion

        #region as
        public DoubleElement As(string alias)
            => new DoubleSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(DoubleIsNullFunctionExpression obj)
            => obj is DoubleIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
