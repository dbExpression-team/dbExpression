﻿using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Expression
{
    public class FilterExpression : DbExpression, IDbExpression
    {
        #region interface
        public (Type,object) LeftPart { get; set; }
        public (Type,object) RightPart { get; set; }
        public readonly FilterExpressionOperator ExpressionOperator;
        public bool Negate { get; set; }
        #endregion

        #region constructors
        internal FilterExpression(FieldExpression leftArg, object rightArg, FilterExpressionOperator expressionOperator)
        {
            LeftPart = (leftArg.GetType(), leftArg);
            RightPart = (rightArg.GetType(), rightArg);
            ExpressionOperator = expressionOperator;
        }

        internal FilterExpression(ArithmeticExpression leftArg, object rightArg, FilterExpressionOperator expressionOperator)
        {
            LeftPart = (leftArg.GetType(), leftArg);
            RightPart = (rightArg.GetType(), rightArg);
            ExpressionOperator = expressionOperator;
        }

        internal FilterExpression(SelectExpression leftArg, object rightArg, FilterExpressionOperator expressionOperator)
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
        public static FilterExpressionSet operator &(FilterExpression a, FilterExpression b)
        {
            if (a == null && b != null) { return new FilterExpressionSet(b); }
            if (a != null && b == null) { return new FilterExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new FilterExpressionSet(a, b, ConditionalExpressionOperator.And);
        }

        public static FilterExpressionSet operator |(FilterExpression a, FilterExpression b)
        {
            if (a == null && b != null) { return new FilterExpressionSet(b); }
            if (a != null && b == null) { return new FilterExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new FilterExpressionSet(a, b, ConditionalExpressionOperator.Or);
        }
        #endregion

        #region implicit filter expression set operator
        public static implicit operator FilterExpressionSet(FilterExpression a) => new FilterExpressionSet(a);
        #endregion

        #region implicit having expression set operator
        public static implicit operator HavingExpression(FilterExpression a) => new HavingExpression(a);
        #endregion

        #region negation operator
        public static FilterExpression operator !(FilterExpression filter)
        {
            if (filter != null) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }    
}
