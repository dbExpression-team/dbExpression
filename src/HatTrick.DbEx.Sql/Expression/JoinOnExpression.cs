﻿using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Expression
{
    public class JoinOnExpression : DbExpression, IDbExpressionAssemblyPart
    {
        #region interface
        public (Type,object) LeftPart { get; set; }
        public (Type,object) RightPart { get; set; }
        public readonly FilterExpressionOperator ExpressionOperator;
        public bool Negate { get; set; }
        
        //TODO: JRod, remove this and cache some static based on enum attributes to avoid out of sync issues moving forward...
        private static string[] _operatorStrings = new string[] { " = ", " <> ", " < ", " <= ", " > ", " >= ", " LIKE ", " IN " };
        #endregion

        #region constructors
        internal JoinOnExpression(object leftArg, object rightArg, FilterExpressionOperator expressionOperator)
        {
            LeftPart = (leftArg.GetType(), leftArg);
            RightPart = (rightArg.GetType(), rightArg);
            ExpressionOperator = expressionOperator;
        }

        internal JoinOnExpression(FilterExpression expression)
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
        public static JoinOnExpressionSet operator &(JoinOnExpression a, JoinOnExpression b)
        {
            if (a == null && b != null) { return new JoinOnExpressionSet(b); }
            if (a != null && b == null) { return new JoinOnExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new JoinOnExpressionSet(a, b, ConditionalExpressionOperator.And);
        }

        public static JoinOnExpressionSet operator |(JoinOnExpression a, JoinOnExpression b)
        {
            if (a == null && b != null) { return new JoinOnExpressionSet(b); }
            if (a != null && b == null) { return new JoinOnExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new JoinOnExpressionSet(a, b, ConditionalExpressionOperator.Or);
        }
        #endregion

        #region implicit filter expression set operator
        public static implicit operator JoinOnExpression(FilterExpression a) => new JoinOnExpression(a);

        public static implicit operator JoinOnExpressionSet(JoinOnExpression a) => new JoinOnExpressionSet(a);
        #endregion

        #region negation operator
        public static JoinOnExpression operator !(JoinOnExpression filter)
        {
            if (filter != null) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }
    
}
