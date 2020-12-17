using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleExpressionMediator :
        ExpressionMediator<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleExpressionMediator>
    {
        #region constructors
        private SingleExpressionMediator()
        {
        }

        public SingleExpressionMediator(IExpressionElement expression) : base(expression)
        {
        }

        protected SingleExpressionMediator(IExpressionElement expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SingleSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(SingleExpressionMediator obj)
            => obj is SingleExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
