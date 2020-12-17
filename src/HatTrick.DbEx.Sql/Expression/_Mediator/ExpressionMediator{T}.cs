using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ExpressionMediator<TValue> : ExpressionMediator,
        IExpressionElement<TValue>
    {
        #region constructors
        protected ExpressionMediator()
        {
        }

        public ExpressionMediator(IExpressionElement expression) : base(expression, expression is IExpressionTypeProvider p ? p.DeclaredType : typeof(TValue))
        {
        }

        protected ExpressionMediator(IExpressionElement expression, string alias) : base(expression, expression is IExpressionTypeProvider p ? p.DeclaredType : typeof(TValue), alias)
        {
        }

        protected ExpressionMediator(IExpressionElement expression, Type declaredType, string alias) : base(expression, declaredType, alias)
        {
        }
        #endregion

        #region equals
        public bool Equals(ExpressionMediator<TValue> obj)
            => obj is ExpressionMediator<TValue> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ExpressionMediator<TValue> exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<TValue>(ExpressionMediator<TValue> a) => new SelectExpression<TValue>(a);
        #endregion
    }
}
