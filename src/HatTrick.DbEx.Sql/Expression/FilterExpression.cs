using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class FilterExpression : 
        IDbExpression,
        IDbFunctionExpression
    {
        #region interface
        public ExpressionContainerPair Expression { get; set; }
        public readonly FilterExpressionOperator ExpressionOperator;
        public bool Negate { get; set; }
        #endregion

        #region constructors
        public FilterExpression(ExpressionContainer leftArg, ExpressionContainer rightArg, FilterExpressionOperator filterExpressionOperator)
        {
            Expression = new ExpressionContainerPair(leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required."), rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required."));
            ExpressionOperator = filterExpressionOperator;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            string expression = $"{Expression.LeftPart.Object} {ExpressionOperator} {Expression.RightPart.Object}";
            return (Negate) ? $" NOT ({expression})" : expression;
        }
        #endregion

        #region conditional &, | operators
        public static FilterExpressionSet operator &(FilterExpression a, FilterExpression b)
        {
            if (a == null && b != null) { return new FilterExpressionSet(b); }
            if (a != null && b == null) { return new FilterExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new FilterExpressionSet(a, b, ConditionalExpressionOperator.And);
        }

        public static FilterExpressionSet operator |(FilterExpression a, FilterExpression b)
        {
            if (a == null && b != null) { return new FilterExpressionSet(b); }
            if (a != null && b == null) { return new FilterExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new FilterExpressionSet(a, b, ConditionalExpressionOperator.Or);
        }
        #endregion

        #region implicit filter expression set operator
        public static implicit operator FilterExpressionSet(FilterExpression a) => new FilterExpressionSet(a);
        #endregion

        #region implicit having expression set operator
        public static implicit operator HavingExpression(FilterExpression a) => new HavingExpression(a);
        #endregion

        #region negation operator
        public static FilterExpression operator !(FilterExpression filter)
        {
            if (filter != null) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }    
}
