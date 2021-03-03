using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class JoinOnExpression :
        IExpressionElement
    {
        #region interface
        public IExpressionElement LeftArg { get; private set; }
        public IExpressionElement RightArg { get; private set; }
        public FilterExpressionOperator ExpressionOperator { get; private set; }
        public bool Negate { get; private set; }
        #endregion

        #region constructors
        public JoinOnExpression(IExpressionElement leftArg, IExpressionElement rightArg, FilterExpressionOperator filterExpressionOperator)
            : this(leftArg, rightArg, filterExpressionOperator, false)
        {
        }

        public JoinOnExpression(IExpressionElement leftArg, IExpressionElement rightArg, FilterExpressionOperator expresionOperator, bool negate)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException(nameof(leftArg));
            RightArg = rightArg ?? throw new ArgumentNullException(nameof(rightArg));
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

        #region implicit filter expression set operator
        public static implicit operator JoinOnExpressionSet(JoinOnExpression a)
            => a is null ? null : new JoinOnExpressionSet(a);
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
