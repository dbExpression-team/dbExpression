using HTL.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBFilterExpression : DBExpression, IDBExpression
    {
        #region interface
        public (Type,object) LeftPart { get; set; }
        public (Type,object) RightPart { get; set; }
        public readonly DBFilterExpressionOperator ExpressionOperator;
        public bool Negate { get; set; }
        #endregion

        #region constructors
        internal DBFilterExpression(object leftArg, object rightArg, DBFilterExpressionOperator expressionOperator)
        {
            LeftPart = (leftArg.GetType(), leftArg);
            RightPart = (rightArg.GetType(), rightArg);
            ExpressionOperator = expressionOperator;
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
        public static DBFilterExpressionSet operator &(DBFilterExpression a, DBFilterExpression b)
        {
            if (a == null && b != null) { return new DBFilterExpressionSet(b); }
            if (a != null && b == null) { return new DBFilterExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new DBFilterExpressionSet(a, b, DBConditionalExpressionOperator.And);
        }

        public static DBFilterExpressionSet operator |(DBFilterExpression a, DBFilterExpression b)
        {
            if (a == null && b != null) { return new DBFilterExpressionSet(b); }
            if (a != null && b == null) { return new DBFilterExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new DBFilterExpressionSet(a, b, DBConditionalExpressionOperator.Or);
        }
        #endregion

        #region implicit filter expression set operator
        public static implicit operator DBFilterExpressionSet(DBFilterExpression a) => new DBFilterExpressionSet(a);
        #endregion

        #region implicit having expression set operator
        public static implicit operator DBHavingExpression(DBFilterExpression a) => new DBHavingExpression(a);
        #endregion

        #region negation operator
        public static DBFilterExpression operator !(DBFilterExpression filter)
        {
            if (filter != null) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }    
}
