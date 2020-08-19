using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class JoinOnExpressionSet :
        IExpression,
        IExpressionSet<JoinOnExpression>
    {
        #region internals
        private readonly IList<IExpression> expressions;
        #endregion

        #region interface
        public IList<JoinOnExpression> Expressions { get; }
        public ExpressionPair JoinPair => new ExpressionPair(expressions.First(), expressions.Skip(1).First());

        public readonly ConditionalExpressionOperator ConditionalOperator;
        public bool Negate { get; set; }
        #endregion

        #region constructors
        protected JoinOnExpressionSet()
        { 
        
        }

        public JoinOnExpressionSet(JoinOnExpression leftArg, JoinOnExpression rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            expressions = new List<IExpression>
            {
                leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required."),
                rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required.")
            };
            ConditionalOperator = conditionalOperator;
        }

        public JoinOnExpressionSet(IExpression leftArg, IExpression rightArg, ConditionalExpressionOperator conditionalOperator, bool negate)
        {
            expressions = new List<IExpression>
            {
                leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required."),
                rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required.")
            };
            ConditionalOperator = conditionalOperator;
            Negate = negate;
        }

        private JoinOnExpressionSet(JoinOnExpressionSet leftArg, JoinOnExpression rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            expressions = new List<IExpression>
            {
                leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required."),
                rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required.")
            };
            ConditionalOperator = conditionalOperator;
        }

        private JoinOnExpressionSet(JoinOnExpressionSet leftArg, JoinOnExpressionSet rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            expressions = new List<IExpression>
            {
                leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required."),
                rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required.")
            };
            ConditionalOperator = conditionalOperator;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            string left = JoinPair.LeftPart.ToString();
            string right = JoinPair?.RightPart?.ToString();
            string expression = $"{left} {ConditionalOperator} {right}";
            return (Negate) ? $"NOT ({expression})" : expression;
        }
        #endregion

        #region conditional &, | operators
        public static JoinOnExpressionSet operator &(JoinOnExpressionSet a, JoinOnExpression b)
        {
            if (a is null && b is object) { return new JoinOnExpressionSet(new NullableLiteralExpression(), b, a.ConditionalOperator, a.Negate); }
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
            if (a is null && b is object) { return new JoinOnExpressionSet(new NullableLiteralExpression(), b, a.ConditionalOperator, a.Negate); }
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
