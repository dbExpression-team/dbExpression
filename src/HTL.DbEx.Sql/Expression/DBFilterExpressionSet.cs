using HTL.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBFilterExpressionSet : DBExpression, IDBExpressionSet<DBFilterExpression>, ISqlAssemblyPart
    {
        #region interface
        public IList<DBFilterExpression> Expressions { get; } = new List<DBFilterExpression>();
        public readonly DBConditionalExpressionOperator ConditionalOperator;
        public bool Negate { get; set; }
        public (Type,object) LeftPart { get; set; }
        public (Type,object) RightPart { get; set; }
        #endregion

        #region constructors
        internal DBFilterExpressionSet(DBFilterExpression singleFilter)
        {
            RightPart = (typeof(DBFilterExpression), singleFilter);
            Expressions.Add(singleFilter);
        }

        internal DBFilterExpressionSet(DBFilterExpression leftArg, DBFilterExpression rightArg, DBConditionalExpressionOperator conditinalOperator)
        {
            LeftPart = (typeof(DBFilterExpression), leftArg);
            RightPart = (typeof(DBFilterExpression), rightArg);
            ConditionalOperator = conditinalOperator;
            Expressions.Add(leftArg);
            Expressions.Add(rightArg);
        }

        internal DBFilterExpressionSet(DBFilterExpressionSet leftArg, DBFilterExpression rightArg, DBConditionalExpressionOperator conditinalOperator)
        {
            LeftPart = (typeof(DBFilterExpressionSet), leftArg);
            RightPart = (typeof(DBFilterExpression), rightArg);
            ConditionalOperator = conditinalOperator;
            Expressions.Add(rightArg);
        }

        internal DBFilterExpressionSet(DBFilterExpressionSet leftArg, DBFilterExpressionSet rightArg, DBConditionalExpressionOperator conditinalOperator)
        {
            LeftPart = (typeof(DBFilterExpressionSet), leftArg);
            RightPart = (typeof(DBFilterExpressionSet), rightArg);
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
        public static DBFilterExpressionSet operator &(DBFilterExpressionSet a, DBFilterExpression b)
        {
            if (a == null && b != null) { return new DBFilterExpressionSet(b); }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new DBFilterExpressionSet(a, b, DBConditionalExpressionOperator.And);
        }

        public static DBFilterExpressionSet operator &(DBFilterExpressionSet a, DBFilterExpressionSet b)
        {
            if (a == null && b != null) { return b; }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new DBFilterExpressionSet(a, b, DBConditionalExpressionOperator.And);
        }

        public static DBFilterExpressionSet operator |(DBFilterExpressionSet a, DBFilterExpression b)
        {
            if (a == null && b != null) { return new DBFilterExpressionSet(b); }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new DBFilterExpressionSet(a, b, DBConditionalExpressionOperator.Or);
        }

        public static DBFilterExpressionSet operator |(DBFilterExpressionSet a, DBFilterExpressionSet b)
        {
            if (a == null && b != null) { return b; }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new DBFilterExpressionSet(a, b, DBConditionalExpressionOperator.Or);
        }
        #endregion

        #region implicit having expression set operator
        public static implicit operator DBHavingExpression(DBFilterExpressionSet a) => new DBHavingExpression(a);
        #endregion

        #region negation operator
        public static DBFilterExpressionSet operator !(DBFilterExpressionSet filter)
        {
            if (filter != null) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }
    
}
