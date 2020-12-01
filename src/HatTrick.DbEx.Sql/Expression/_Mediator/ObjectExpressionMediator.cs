using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ObjectExpressionMediator :
        ExpressionMediator<object>,
        AnyElement,
        ObjectElement,
        IEquatable<ObjectExpressionMediator>
    {
        #region constructors
        private ObjectExpressionMediator()
        {
        }

        public ObjectExpressionMediator(IExpressionElement expression) : base(expression)
        {
        }

        protected ObjectExpressionMediator(IExpressionElement expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public ObjectElement As(string alias)
            => new ObjectExpressionMediator(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(ObjectExpressionMediator obj)
            => obj is ObjectExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ObjectExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
