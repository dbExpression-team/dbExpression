using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class SelectExpression : 
        IDbExpression, 
        IAssemblyPart
    {
        #region internals
        protected bool IsDistinct { get; private set; }
        #endregion

        #region interface
        public (Type, object) Expression { get; }
        #endregion

        #region constructors
        public SelectExpression(ISupportedForExpression<SelectExpression> expression)
        {
            Expression = (expression.GetType(), expression);
        }
        #endregion

        #region to string
        public override string ToString() => Expression.Item2.ToString();
        #endregion

        #region logical & operator
        public static SelectExpressionSet operator &(SelectExpression a, SelectExpression b) => new SelectExpressionSet(a, b);
        #endregion

        #region implicit select expression set operator
        public static implicit operator SelectExpressionSet(SelectExpression a) => new SelectExpressionSet(a);
        #endregion

        #region equals
        public bool Equals(SelectExpression obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!ReferenceEquals(this.Expression.Item2, obj.Expression.Item2)) return false;
            if (this.IsDistinct != obj.IsDistinct) return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SelectExpression other)) return false;
            return Equals(other);
        }

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
