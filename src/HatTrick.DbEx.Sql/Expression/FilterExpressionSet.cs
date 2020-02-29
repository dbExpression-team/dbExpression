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
        public ExpressionContainerPair Expression { get; set; }
        public bool IsSingleFilter => Expression?.RightPart == null;
        public ExpressionContainer SingleFilter => Expression?.RightPart == null ? Expression.LeftPart : null;
        #endregion

        #region constructors
        internal FilterExpressionSet()
        { 
        
        }        
        
        public FilterExpressionSet(FilterExpression singleFilter)
        {
            Expression = new ExpressionContainerPair(new ExpressionContainer(singleFilter ?? throw new ArgumentNullException($"{nameof(singleFilter)} is required.")));
        }

        public FilterExpressionSet(FilterExpression leftArg, FilterExpression rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            Expression = new ExpressionContainerPair(new ExpressionContainer(leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required.")), new ExpressionContainer(rightArg));
            ConditionalOperator = conditionalOperator;
        }

        public FilterExpressionSet(FilterExpressionSet leftArg, FilterExpression rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            Expression = new ExpressionContainerPair(new ExpressionContainer(leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required.")), new ExpressionContainer(rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required.")));
            ConditionalOperator = conditionalOperator;
        }

        public FilterExpressionSet(FilterExpressionSet leftArg, FilterExpressionSet rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            Expression = new ExpressionContainerPair(new ExpressionContainer(leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required.")), new ExpressionContainer(rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required.")));
            ConditionalOperator = conditionalOperator;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            string left = Expression.LeftPart.Object.ToString();
            string right = Expression.RightPart == default ? string.Empty : Expression.RightPart.Object.ToString();
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
