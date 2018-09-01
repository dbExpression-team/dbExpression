using HTL.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBJoinOnExpressionSet : DBExpression, IDBExpressionSet<DBJoinOnExpression>, ISqlAssemblyPart
    {
        #region interface
        public IList<DBJoinOnExpression> Expressions { get; } = new List<DBJoinOnExpression>();
        public readonly DBConditionalExpressionOperator ConditionalOperator;
        public bool Negate { get; set; }
        public (Type,object) LeftPart { get; set; }
        public (Type,object) RightPart { get; set; }
        #endregion

        #region constructors
        internal DBJoinOnExpressionSet(DBJoinOnExpression singleJoinOn)
        {
            RightPart = (typeof(DBJoinOnExpression), singleJoinOn);
            Expressions.Add(singleJoinOn);
        }

        internal DBJoinOnExpressionSet(DBJoinOnExpression leftArg, DBJoinOnExpression rightArg, DBConditionalExpressionOperator conditinalOperator)
        {
            LeftPart = (typeof(DBJoinOnExpression), leftArg);
            RightPart = (typeof(DBJoinOnExpression), rightArg);
            ConditionalOperator = conditinalOperator;
            Expressions.Add(leftArg);
            Expressions.Add(rightArg);
        }

        internal DBJoinOnExpressionSet(DBJoinOnExpressionSet leftArg, DBJoinOnExpression rightArg, DBConditionalExpressionOperator conditinalOperator)
        {
            LeftPart = (typeof(DBJoinOnExpressionSet), leftArg);
            RightPart = (typeof(DBJoinOnExpression), rightArg);
            ConditionalOperator = conditinalOperator;
            Expressions.Add(rightArg);
        }

        internal DBJoinOnExpressionSet(DBJoinOnExpressionSet leftArg, DBJoinOnExpressionSet rightArg, DBConditionalExpressionOperator conditinalOperator)
        {
            LeftPart = (typeof(DBJoinOnExpressionSet), leftArg);
            RightPart = (typeof(DBJoinOnExpressionSet), rightArg);
            ConditionalOperator = conditinalOperator;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            string left = default(ValueTuple<Type,object>).Equals(LeftPart) ? string.Empty : LeftPart.Item2.ToString();
            string right = RightPart.Item2.ToString();
            string expression = $"{left} {ConditionalOperator} {right}";
            return (Negate) ? $"NOT ({expression})" : expression;
        }
        #endregion

        #region conditional &, | operators
        public static DBJoinOnExpressionSet operator &(DBJoinOnExpressionSet a, DBJoinOnExpression b)
        {
            if (a == null && b != null) { return new DBJoinOnExpressionSet(b); }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new DBJoinOnExpressionSet(a, b, DBConditionalExpressionOperator.And);
        }

        public static DBJoinOnExpressionSet operator &(DBJoinOnExpressionSet a, DBJoinOnExpressionSet b)
        {
            if (a == null && b != null) { return b; }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new DBJoinOnExpressionSet(a, b, DBConditionalExpressionOperator.And);
        }

        public static DBJoinOnExpressionSet operator |(DBJoinOnExpressionSet a, DBJoinOnExpression b)
        {
            if (a == null && b != null) { return new DBJoinOnExpressionSet(b); }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new DBJoinOnExpressionSet(a, b, DBConditionalExpressionOperator.Or);
        }

        public static DBJoinOnExpressionSet operator |(DBJoinOnExpressionSet a, DBJoinOnExpressionSet b)
        {
            if (a == null && b != null) { return b; }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new DBJoinOnExpressionSet(a, b, DBConditionalExpressionOperator.Or);
        }
        #endregion

        #region negation operator
        public static DBJoinOnExpressionSet operator !(DBJoinOnExpressionSet filter)
        {
            if (filter != null) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }
    
}
