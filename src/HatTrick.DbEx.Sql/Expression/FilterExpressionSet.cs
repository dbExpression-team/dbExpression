using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Expression
{
    public class FilterExpressionSet : DbExpression, /*IDbExpressionSet<FilterExpression>,*/ IDbExpressionAssemblyPart
    {
        #region interface
        //public IList<FilterExpression> Expressions { get; } = new List<FilterExpression>();
        public readonly ConditionalExpressionOperator ConditionalOperator;
        public bool Negate { get; set; }
        public (Type,object) LeftPart { get; set; }
        public (Type,object) RightPart { get; set; }
        #endregion

        #region constructors
        internal FilterExpressionSet(FilterExpression singleFilter)
        {
            LeftPart = (typeof(FilterExpression), singleFilter);
            //Expressions.Add(singleFilter);
        }

        internal FilterExpressionSet(FilterExpression leftArg, FilterExpression rightArg, ConditionalExpressionOperator conditinalOperator)
        {
            LeftPart = (typeof(FilterExpressionSet), new FilterExpressionSet(leftArg));
            RightPart = (typeof(FilterExpressionSet), new FilterExpressionSet(rightArg));
            ConditionalOperator = conditinalOperator;
            //Expressions.Add(leftArg);
            //Expressions.Add(rightArg);
        }

        internal FilterExpressionSet(FilterExpressionSet leftArg, FilterExpression rightArg, ConditionalExpressionOperator conditinalOperator)
        {
            LeftPart = (typeof(FilterExpressionSet), leftArg);
            RightPart = (typeof(FilterExpression), rightArg);
            ConditionalOperator = conditinalOperator;
            //Expressions.Add(rightArg);
        }

        internal FilterExpressionSet(FilterExpressionSet leftArg, FilterExpressionSet rightArg, ConditionalExpressionOperator conditinalOperator)
        {
            LeftPart = (typeof(FilterExpressionSet), leftArg);
            RightPart = (typeof(FilterExpressionSet), rightArg);
            ConditionalOperator = conditinalOperator;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            string left = LeftPart.Item2.ToString();
            string right = RightPart == default ? string.Empty : RightPart.Item2.ToString();
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
