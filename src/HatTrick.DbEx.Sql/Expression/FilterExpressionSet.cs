using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Expression
{
    public class FilterExpressionSet : 
        IDbExpression, 
        IAssemblyPart,
        IDbFunctionExpression
    {
        #region interface
        public readonly ConditionalExpressionOperator ConditionalOperator;
        public bool Negate { get; set; }
        public DbExpressionPair Expression { get; set; }
        #endregion

        #region constructors
        internal FilterExpressionSet()
        {
        }

        internal FilterExpressionSet(FilterExpression singleFilter)
        {
            Expression = new DbExpressionPair((typeof(FilterExpression), singleFilter), (null, null));
        }

        internal FilterExpressionSet(FilterExpression leftArg, FilterExpression rightArg, ConditionalExpressionOperator conditinalOperator)
        {
            Expression = new DbExpressionPair((typeof(FilterExpression), leftArg), (typeof(FilterExpression), rightArg));
            ConditionalOperator = conditinalOperator;
        }

        internal FilterExpressionSet(FilterExpressionSet leftArg, FilterExpression rightArg, ConditionalExpressionOperator conditinalOperator)
        {
            Expression = new DbExpressionPair((typeof(FilterExpressionSet), leftArg), (typeof(FilterExpressionSet), rightArg));
            ConditionalOperator = conditinalOperator;
        }

        internal FilterExpressionSet(FilterExpressionSet leftArg, FilterExpressionSet rightArg, ConditionalExpressionOperator conditinalOperator)
        {
            Expression = new DbExpressionPair((typeof(FilterExpressionSet), leftArg), (typeof(FilterExpressionSet), rightArg));
            ConditionalOperator = conditinalOperator;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            string left = Expression.LeftPart.Item2.ToString();
            string right = Expression.RightPart == default ? string.Empty : Expression.RightPart.Item2.ToString();
            string expression = $"{left} {ConditionalOperator} {right}";
            return (Negate) ? $"NOT ({expression})" : expression;
        }
        #endregion

        #region conditional &, | operators
        public static FilterExpressionSet operator &(FilterExpressionSet a, FilterExpression b)
        {
            if (a == null && b != null) { return new FilterExpressionSet(b); }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new FilterExpressionSet(a, b, ConditionalExpressionOperator.And);
        }

        public static FilterExpressionSet operator &(FilterExpressionSet a, FilterExpressionSet b)
        {
            if (a == null && b != null) { return b; }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new FilterExpressionSet(a, b, ConditionalExpressionOperator.And);
        }

        public static FilterExpressionSet operator |(FilterExpressionSet a, FilterExpression b)
        {
            if (a == null && b != null) { return new FilterExpressionSet(b); }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new FilterExpressionSet(a, b, ConditionalExpressionOperator.Or);
        }

        public static FilterExpressionSet operator |(FilterExpressionSet a, FilterExpressionSet b)
        {
            if (a == null && b != null) { return b; }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new FilterExpressionSet(a, b, ConditionalExpressionOperator.Or);
        }
        #endregion

        #region implicit having expression set operator
        public static implicit operator HavingExpression(FilterExpressionSet a) => new HavingExpression(a);
        #endregion

        #region negation operator
        public static FilterExpressionSet operator !(FilterExpressionSet filter)
        {
            if (filter != null) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }
}
