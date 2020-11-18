using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleIsNullFunctionExpression :
        IsNullFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleIsNullFunctionExpression>
    {
        #region constructors
        public SingleIsNullFunctionExpression(AnySingleElement expression, SingleElement value) : base(expression, value)
        {

        }

        protected SingleIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias) : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SingleIsNullFunctionExpression(base.Expression, base.Value, alias);
        #endregion

        #region equals
        public bool Equals(SingleIsNullFunctionExpression obj)
            => obj is SingleIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
