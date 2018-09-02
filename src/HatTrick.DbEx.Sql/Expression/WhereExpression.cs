using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class WhereExpression : DbExpression
    {
        #region interface
        public (Type, object) LeftPart { get; set; }
        public (Type, object) RightPart { get; set; }
        public readonly FilterExpressionOperator ExpressionOperator;
        public bool Negate { get; set; }
        #endregion

        #region constructors
        internal WhereExpression(object leftArg, object rightArg, FilterExpressionOperator expressionOperator)
        {
            LeftPart = (leftArg.GetType(), leftArg);
            RightPart = (rightArg.GetType(), rightArg);
            ExpressionOperator = expressionOperator;
        }

        internal WhereExpression(FilterExpression expression)
        {
            LeftPart = expression.LeftPart;
            RightPart = expression.RightPart;
            ExpressionOperator = expression.ExpressionOperator;
            Negate = expression.Negate;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            string expression = $"{LeftPart.Item2} {ExpressionOperator} {RightPart.Item2}";
            return (Negate) ? $" NOT ({expression})" : expression;
        }
        #endregion

        #region conditional &, | operators
        public static WhereExpressionSet operator |(WhereExpression a, WhereExpression b)
        {
            if (a == null && b != null) { return new WhereExpressionSet(b); }
            if (a != null && b == null) { return new WhereExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new WhereExpressionSet(a, b, ConditionalExpressionOperator.Or);
        }
        #endregion

        #region implicit filter expression set operator
        public static implicit operator WhereExpression(FilterExpression a) => new WhereExpression(a);
        public static implicit operator WhereExpressionSet(WhereExpression a) => new WhereExpressionSet(a);

        #endregion

        #region negation operator
        public static WhereExpression operator !(WhereExpression filter)
        {
            if (filter != null) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }

}
