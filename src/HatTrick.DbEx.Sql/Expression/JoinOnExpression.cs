using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class JoinOnExpression : 
        IExpression
    {
        #region interface
        public IExpression LeftArg { get; set; }
        public IExpression RightArg { get; set; }
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

        private JoinOnExpression(IExpression leftArg, IExpression rightArg, FilterExpressionOperator expresionOperator, bool negate)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required.");
            RightArg = rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required.");
            ExpressionOperator = expresionOperator;
            Negate =negate;
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
            if (a is null && b is object) { return new JoinOnExpressionSet(new NullableLiteralExpression(), b, ConditionalExpressionOperator.And, b.Negate); }
            if (a is object && b is null) { return new JoinOnExpressionSet(a, new NullableLiteralExpression(), ConditionalExpressionOperator.And, a.Negate); }
            if (a is null && b is null) { return null; }

            return new JoinOnExpressionSet(a, b, ConditionalExpressionOperator.And);
        }

        public static JoinOnExpressionSet operator |(JoinOnExpression a, JoinOnExpression b)
        {
            if (a is null && b is object) { return new JoinOnExpressionSet(new NullableLiteralExpression(), b, ConditionalExpressionOperator.Or, b.Negate); }
            if (a is object && b is null) { return new JoinOnExpressionSet(a, new NullableLiteralExpression(), ConditionalExpressionOperator.Or, a.Negate); }
            if (a is null && b is null) { return null; }

            return new JoinOnExpressionSet(a, b, ConditionalExpressionOperator.Or);
        }
        #endregion

        #region implicit filter expression set operator
        public static implicit operator JoinOnExpression(FilterExpression a) => new JoinOnExpression(a);

        public static implicit operator JoinOnExpressionSet(JoinOnExpression a) => new JoinOnExpressionSet(a.LeftArg, a.RightArg, ConditionalExpressionOperator.And, a.Negate);
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
