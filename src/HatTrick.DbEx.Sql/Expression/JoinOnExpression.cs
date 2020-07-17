using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class JoinOnExpression : 
        IDbExpression
    {
        #region interface
        public ExpressionMediator LeftArg { get; set; }
        public ExpressionMediator RightArg { get; set; }
        public readonly FilterExpressionOperator ExpressionOperator;
        public bool Negate { get; set; }
        #endregion

        #region constructors
        public JoinOnExpression(FilterExpression expression)
        {
            LeftArg = expression.LeftArg ?? throw new ArgumentNullException($"{nameof(expression)} and the {nameof(expression.LeftArg)} of {nameof(expression)} is required.");
            RightArg = expression.RightArg ?? throw new ArgumentNullException($"{nameof(expression)} and the {nameof(expression.RightArg)} of {nameof(expression)} is required.");
            ExpressionOperator = expression.ExpressionOperator;
            Negate = expression.Negate;
        }

        #endregion

        #region to string
        public override string ToString()
        {
            string expression = $"{LeftArg} {ExpressionOperator} {RightArg}";
            return (Negate) ? $" NOT ({expression})" : expression;
        }
        #endregion

        #region conditional &, | operators
        public static JoinOnExpressionSet operator &(JoinOnExpression a, JoinOnExpression b)
        {
            if (a is null && b is object) { return new JoinOnExpressionSet(b); }
            if (a is object && b is null) { return new JoinOnExpressionSet(a); }
            if (a is null && b is null) { return null; }

            return new JoinOnExpressionSet(a, b, ConditionalExpressionOperator.And);
        }

        public static JoinOnExpressionSet operator |(JoinOnExpression a, JoinOnExpression b)
        {
            if (a is null && b is object) { return new JoinOnExpressionSet(b); }
            if (a is object && b is null) { return new JoinOnExpressionSet(a); }
            if (a is null && b is null) { return null; }

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
            if (filter is object) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }
    
}
