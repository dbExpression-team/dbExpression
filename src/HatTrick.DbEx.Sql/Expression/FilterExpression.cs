using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class FilterExpression : 
        IExpressionElement
    {
        #region interface
        public IExpressionElement LeftArg { get; private set; }
        public IExpressionElement RightArg { get; private set; }
        public FilterExpressionOperator ExpressionOperator { get; private set; }
        public bool Negate { get; set; }
        #endregion

        #region constructors
        public FilterExpression(IExpressionElement leftArg, IExpressionElement rightArg, FilterExpressionOperator filterExpressionOperator)
            : this(leftArg, rightArg, filterExpressionOperator, false)
        {
        }

        public FilterExpression(IExpressionElement leftArg, IExpressionElement rightArg, FilterExpressionOperator filterExpressionOperator, bool negate)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required.");
            RightArg = rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required.");
            ExpressionOperator = filterExpressionOperator;
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
        public static FilterExpressionSet operator &(FilterExpression a, FilterExpression b)
        {
            if (a is null && b is object) { return new FilterExpressionSet(b); }
            if (a is object && b is null) { return new FilterExpressionSet(a); }
            if (a is null && b is null) { return null; }

            return new FilterExpressionSet(a, b, ConditionalExpressionOperator.And);
        }

        public static FilterExpressionSet operator |(FilterExpression a, FilterExpression b)
        {
            if (a is null && b is object) { return new FilterExpressionSet(b); }
            if (a is object && b is null) { return new FilterExpressionSet(a); }
            if (a is null && b is null) { return null; }

            return new FilterExpressionSet(a, b, ConditionalExpressionOperator.Or);
        }
        #endregion

        #region implicit operators
        public static implicit operator FilterExpressionSet(FilterExpression a) 
            => a is null ? null : new FilterExpressionSet(a);

        public static implicit operator HavingExpression(FilterExpression a) 
            => new HavingExpression(a);

        public static implicit operator JoinOnExpressionSet(FilterExpression a)
            => a?.ConvertToJoinOnExpressionSet();
        #endregion

        #region negation operator
        public static FilterExpression operator !(FilterExpression filter)
        {
            if (filter is object) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }    
}
