using HTL.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBJoinOnExpression : DBExpression, IDBExpression
    {
        #region interface
        public (Type,object) LeftPart { get; set; }
        public (Type,object) RightPart { get; set; }
        public readonly DBFilterExpressionOperator ExpressionOperator;
        public bool Negate { get; set; }
        
        //TODO: JRod, remove this and cache some static based on enum attributes to avoid out of sync issues moving forward...
        private static string[] _operatorStrings = new string[] { " = ", " <> ", " < ", " <= ", " > ", " >= ", " LIKE ", " IN " };
        #endregion

        #region constructors
        internal DBJoinOnExpression(object leftArg, object rightArg, DBFilterExpressionOperator expressionOperator)
        {
            LeftPart = (leftArg.GetType(), leftArg);
            RightPart = (rightArg.GetType(), rightArg);
            ExpressionOperator = expressionOperator;
        }

        internal DBJoinOnExpression(DBFilterExpression expression)
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
        public static DBJoinOnExpressionSet operator &(DBJoinOnExpression a, DBJoinOnExpression b)
        {
            if (a == null && b != null) { return new DBJoinOnExpressionSet(b); }
            if (a != null && b == null) { return new DBJoinOnExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new DBJoinOnExpressionSet(a, b, DBConditionalExpressionOperator.And);
        }

        public static DBJoinOnExpressionSet operator |(DBJoinOnExpression a, DBJoinOnExpression b)
        {
            if (a == null && b != null) { return new DBJoinOnExpressionSet(b); }
            if (a != null && b == null) { return new DBJoinOnExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new DBJoinOnExpressionSet(a, b, DBConditionalExpressionOperator.Or);
        }
        #endregion

        #region implicit filter expression set operator
        public static implicit operator DBJoinOnExpression(DBFilterExpression a) => new DBJoinOnExpression(a);

        public static implicit operator DBJoinOnExpressionSet(DBJoinOnExpression a) => new DBJoinOnExpressionSet(a);
        #endregion

        #region negation operator
        public static DBJoinOnExpression operator !(DBJoinOnExpression filter)
        {
            if (filter != null) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }
    
}
