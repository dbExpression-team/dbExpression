using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleCeilingFunctionExpression :
        CeilFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleCeilingFunctionExpression>
    {
        #region constructors
        public SingleCeilingFunctionExpression(SingleElement expression) : base(expression)
        {

        }

        protected SingleCeilingFunctionExpression(IExpressionElement expression, string alias) : base(expression, alias)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SingleCeilingFunctionExpression(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(SingleCeilingFunctionExpression obj)
            => obj is SingleCeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleCeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
