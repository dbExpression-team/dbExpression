using System;

namespace HTL.DbEx.Sql.Expression
{
    public class DBWhereExpression : DBExpression
    {
        #region interface
        public (Type, object) LeftPart { get; set; }
        public (Type, object) RightPart { get; set; }
        public readonly DBFilterExpressionOperator ExpressionOperator;
        public bool Negate { get; set; }
        #endregion

        #region constructors
        internal DBWhereExpression(object leftArg, object rightArg, DBFilterExpressionOperator expressionOperator)
        {
            LeftPart = (leftArg.GetType(), leftArg);
            RightPart = (rightArg.GetType(), rightArg);
            ExpressionOperator = expressionOperator;
        }

        internal DBWhereExpression(DBFilterExpression expression)
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
        public static DBWhereExpressionSet operator |(DBWhereExpression a, DBWhereExpression b)
        {
            if (a == null && b != null) { return new DBWhereExpressionSet(b); }
            if (a != null && b == null) { return new DBWhereExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new DBWhereExpressionSet(a, b, DBConditionalExpressionOperator.Or);
        }
        #endregion

        #region implicit filter expression set operator
        public static implicit operator DBWhereExpression(DBFilterExpression a) => new DBWhereExpression(a);
        public static implicit operator DBWhereExpressionSet(DBWhereExpression a) => new DBWhereExpressionSet(a);

        #endregion

        #region negation operator
        public static DBWhereExpression operator !(DBWhereExpression filter)
        {
            if (filter != null) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }

}
