using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class JoinOnExpression : 
        IExpression
    {
        #region interface
        public ExpressionMediator LeftArg { get; set; }
        public ExpressionMediator RightArg { get; set; }
        public readonly FilterExpressionOperator ExpressionOperator;
        public bool Negate { get; set; }
        #endregion

        #region constructors
        public JoinOnExpression(ExpressionMediator leftArg, ExpressionMediator rightArg, FilterExpressionOperator filterExpressionOperator)
            : this(leftArg, rightArg, filterExpressionOperator, false)
        {
        }

        public JoinOnExpression(ExpressionMediator leftArg, ExpressionMediator rightArg, FilterExpressionOperator expresionOperator, bool negate)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required.");
            RightArg = rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required.");
            ExpressionOperator = expresionOperator;
            Negate = negate;
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
            return new JoinOnExpressionSet(a ?? throw new ArgumentNullException($"{a} is required."), b ?? throw new ArgumentNullException($"{b} is required."), ConditionalExpressionOperator.And);
        }

        public static JoinOnExpressionSet operator |(JoinOnExpression a, JoinOnExpression b)
        {
            return new JoinOnExpressionSet(a ?? throw new ArgumentNullException($"{a} is required."), b ?? throw new ArgumentNullException($"{b} is required."), ConditionalExpressionOperator.Or);
        }
        #endregion

        #region implicit filter expression set operator
        public static implicit operator JoinOnExpression(FilterExpression a) => new JoinOnExpression(a.LeftArg, a.RightArg, a.ExpressionOperator);

        public static implicit operator JoinOnExpressionSet(JoinOnExpression a) => new JoinOnExpressionSet(a);
        #endregion

        #region negation operator
        public static JoinOnExpression operator !(JoinOnExpression joinOn)
        {
            if (joinOn is object) joinOn.Negate = !joinOn.Negate;
            return joinOn;
        }
        #endregion
    }
    
}
