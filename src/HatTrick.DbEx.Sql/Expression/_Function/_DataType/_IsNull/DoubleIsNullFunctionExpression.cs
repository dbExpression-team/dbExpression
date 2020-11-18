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

        protected DoubleIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias) : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public DoubleElement As(string alias)
            => new DoubleIsNullFunctionExpression(base.Expression, base.Value, alias);
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
