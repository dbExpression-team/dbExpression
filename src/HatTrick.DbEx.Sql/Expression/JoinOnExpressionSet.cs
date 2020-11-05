using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class JoinOnExpressionSet :
        IExpression
    {
        #region interface
        public readonly ConditionalExpressionOperator ConditionalOperator;
        public bool Negate { get; set; }
        public IExpression LeftArg { get; set; }
        public IExpression RightArg { get; set; }
        #endregion

        #region constructors
        protected JoinOnExpressionSet()
        { 
        
        }

        public JoinOnExpressionSet(JoinOnExpression singleFilter)
        {
            LeftArg = singleFilter ?? throw new ArgumentNullException($"{nameof(singleFilter)} is required.");
        }

        public JoinOnExpressionSet(JoinOnExpression leftArg, JoinOnExpression rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required.");
            RightArg = rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required.");
            ConditionalOperator = conditionalOperator;
        }

        public JoinOnExpressionSet(JoinOnExpressionSet leftArg, JoinOnExpression rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required.");
            RightArg = rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required.");
            ConditionalOperator = conditionalOperator;
        }

        public JoinOnExpressionSet(JoinOnExpressionSet leftArg, JoinOnExpressionSet rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required.");
            RightArg = rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required.");
            ConditionalOperator = conditionalOperator;
        }
        #endregion

        #region to string
        public override string ToString() => (Negate) ? $"NOT ({LeftArg} {ConditionalOperator} {RightArg})" : $"{LeftArg} {ConditionalOperator} {RightArg}";

        #endregion

        #region conditional &, | operators
        public static JoinOnExpressionSet operator &(JoinOnExpressionSet a, JoinOnExpression b)
        {
            if (a is null && b is object) { return new JoinOnExpressionSet(b); }
            if (a is object && b is null) { return a; }
            if (a is null && b is null) { return null; }

            return new JoinOnExpressionSet(a, b, ConditionalExpressionOperator.And);
        }

        public static JoinOnExpressionSet operator &(JoinOnExpressionSet a, JoinOnExpressionSet b)
        {
            if (a is null && b is object) { return b; }
            if (a is object && b is null) { return a; }
            if (a is null && b is null) { return null; }

            return new JoinOnExpressionSet(a, b, ConditionalExpressionOperator.And);
        }

        public static JoinOnExpressionSet operator |(JoinOnExpressionSet a, JoinOnExpression b)
        {
            if (a is null && b is object) { return new JoinOnExpressionSet(b); }
            if (a is object && b is null) { return a; }
            if (a is null && b is null) { return null; }

            return new JoinOnExpressionSet(a, b, ConditionalExpressionOperator.Or);
        }

        public static JoinOnExpressionSet operator |(JoinOnExpressionSet a, JoinOnExpressionSet b)
        {
            if (a is null && b is object) { return b; }
            if (a is object && b is null) { return a; }
            if (a is null && b is null) { return null; }

            return new JoinOnExpressionSet(a, b, ConditionalExpressionOperator.Or);
        }
        #endregion

        #region negation operator
        public static JoinOnExpressionSet operator !(JoinOnExpressionSet filter)
        {
            if (filter is object) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }
    
}
