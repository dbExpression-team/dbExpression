using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class JoinOnExpressionSet :
        IExpressionElement
    {
        #region interface
        public readonly ConditionalExpressionOperator ConditionalOperator;
        public bool Negate { get; set; }
        public IExpressionElement LeftArg { get; set; }
        public IExpressionElement RightArg { get; set; }
        public bool IsSingleFilter => RightArg is null;
        public object SingleFilter => RightArg is null ? LeftArg : null;
        #endregion

        #region constructors
        protected JoinOnExpressionSet()
        {

        }

        public JoinOnExpressionSet(JoinOnExpression singleJoin)
        {
            LeftArg = singleJoin ?? throw new ArgumentNullException($"{nameof(singleJoin)} is required.");
        }

        protected JoinOnExpressionSet(JoinOnExpressionSet leftArg, JoinOnExpression rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required.");
            RightArg = rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required.");
            ConditionalOperator = conditionalOperator;
        }

        protected JoinOnExpressionSet(JoinOnExpressionSet leftArg, JoinOnExpressionSet rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required.");
            RightArg = rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required.");
            ConditionalOperator = conditionalOperator;
        }

        public JoinOnExpressionSet(IExpressionElement leftArg, IExpressionElement rightArg, ConditionalExpressionOperator conditionalOperator, bool negate)
        {
            if (leftArg is null && rightArg is null)
                throw new ArgumentNullException($"{nameof(leftArg)} or {nameof(leftArg)} must be non-null.");

            LeftArg = leftArg;
            RightArg = rightArg;
            ConditionalOperator = conditionalOperator;
            Negate = negate;
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
        public static JoinOnExpressionSet operator !(JoinOnExpressionSet a)
        {
            if (a is object) a.Negate = !a.Negate;
            return a;
        }
        #endregion
    }

}
