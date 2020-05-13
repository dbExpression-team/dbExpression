using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class JoinOnExpression : 
        IDbExpression
    {
        #region interface
        public ExpressionContainer LeftPart { get; set; }
        public ExpressionContainer RightPart { get; set; }
        public readonly FilterExpressionOperator ExpressionOperator;
        public bool Negate { get; set; }
        #endregion

        #region constructors
        public JoinOnExpression(FilterExpression expression)
        {
            LeftPart = expression.Expression?.LeftPart ?? throw new ArgumentNullException($"{nameof(expression)} and the {nameof(expression.Expression.LeftPart)} of {nameof(expression)} is required.");
            RightPart = expression.Expression?.RightPart ?? throw new ArgumentNullException($"{nameof(expression)} and the {nameof(expression.Expression.LeftPart)} of {nameof(expression)} is required.");
            ExpressionOperator = expression.ExpressionOperator;
            Negate = expression.Negate;
        }

        #endregion

        #region to string
        public override string ToString()
        {
            string expression = $"{LeftPart.Object} {ExpressionOperator} {RightPart.Object}";
            return (Negate) ? $" NOT ({expression})" : expression;
        }
        #endregion

        #region conditional &, | operators
        public static JoinOnExpressionSet operator &(JoinOnExpression a, JoinOnExpression b)
        {
            if (a == null && b != null) { return new JoinOnExpressionSet(b); }
            if (a != null && b == null) { return new JoinOnExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new JoinOnExpressionSet(a, b, ConditionalExpressionOperator.And);
        }

        public static JoinOnExpressionSet operator |(JoinOnExpression a, JoinOnExpression b)
        {
            if (a == null && b != null) { return new JoinOnExpressionSet(b); }
            if (a != null && b == null) { return new JoinOnExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new JoinOnExpressionSet(a, b, ConditionalExpressionOperator.Or);
        }
        #endregion

        #region implicit filter expression set operator
        public static implicit operator JoinOnExpression(FilterExpression a) => new JoinOnExpression(a);

        public static implicit operator JoinOnExpressionSet(JoinOnExpression a) => new JoinOnExpressionSet(a);
        #endregion

        #region negation operator
        public static JoinOnExpression operator !(JoinOnExpression filter)
        {
            if (filter != null) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }
    
}
