using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class SelectExpression<TValue> : 
        SelectExpression,
        IEquatable<SelectExpression<TValue>>
    {
        #region constructors
        public SelectExpression(ExpressionMediator expression) : base(expression, typeof(TValue))
        {
        }
        #endregion

        #region logical & operator
        public static SelectExpressionSet operator &(SelectExpression<TValue> a, SelectExpression<TValue> b) => new SelectExpressionSet(a, b);
        #endregion

        #region implicit select expression set operator
        public static implicit operator SelectExpressionSet(SelectExpression<TValue> a) => new SelectExpressionSet(a);
        #endregion

        #region equals
        public bool Equals(SelectExpression<TValue> obj)
            => obj is SelectExpression<TValue> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SelectExpression<TValue> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
