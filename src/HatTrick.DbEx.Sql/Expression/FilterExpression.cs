using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Expression
{
    public class FilterExpression : 
        IDbExpression,
        IAssemblyPart,
        IDbFunctionExpression
    {
        #region interface
        public DbExpressionPair Expression { get; set; }
        public readonly FilterExpressionOperator ExpressionOperator;
        public bool Negate { get; set; }
        #endregion

        #region constructors
        internal FilterExpression(FieldExpression leftArg, object rightArg, FilterExpressionOperator expressionOperator)
        {
            if (rightArg != null)
            {
                Expression = new DbExpressionPair((typeof(FieldExpression), leftArg), (rightArg.GetType(), rightArg));
            }
            else
            {
                Expression = new DbExpressionPair((typeof(FieldExpression), leftArg), (typeof(object), DBNull.Value));
            }
            ExpressionOperator = expressionOperator;
        }

        internal FilterExpression(ArithmeticExpression leftArg, object rightArg, FilterExpressionOperator expressionOperator)
        {
            if (rightArg != null)
            {
                Expression = new DbExpressionPair((typeof(ArithmeticExpression), leftArg), (rightArg.GetType(), rightArg));
            }
            else
            {
                Expression = new DbExpressionPair((typeof(ArithmeticExpression), leftArg), (typeof(object), DBNull.Value));
            }
            ExpressionOperator = expressionOperator;
        }

        internal FilterExpression(CastFunctionExpression leftArg, object rightArg, FilterExpressionOperator expressionOperator)
        {
            if (rightArg != null)
            {
                Expression = new DbExpressionPair((typeof(CastFunctionExpression), leftArg), (rightArg.GetType(), rightArg));
            }
            else
            {
                Expression = new DbExpressionPair((typeof(CastFunctionExpression), leftArg), (typeof(object), DBNull.Value));
            }
            ExpressionOperator = expressionOperator;
        }

        internal FilterExpression(CoalesceFunctionExpression leftArg, object rightArg, FilterExpressionOperator expressionOperator)
        {
            if (rightArg != null)
            {
                Expression = new DbExpressionPair((typeof(CoalesceFunctionExpression), leftArg), (rightArg.GetType(), rightArg));
            }
            else
            {
                Expression = new DbExpressionPair((typeof(CoalesceFunctionExpression), leftArg), (typeof(object), DBNull.Value));
            }
            ExpressionOperator = expressionOperator;
        }

        internal FilterExpression(IsNullFunctionExpression leftArg, object rightArg, FilterExpressionOperator expressionOperator)
        {
            if (rightArg != null)
            {
                Expression = new DbExpressionPair((typeof(IsNullFunctionExpression), leftArg), (rightArg.GetType(), rightArg));
            }
            else
            {
                Expression = new DbExpressionPair((typeof(IsNullFunctionExpression), leftArg), (typeof(object), DBNull.Value));
            }
            ExpressionOperator = expressionOperator;
        }

        public FilterExpression(IDbNumericalFunctionExpression leftArg, object rightArg, FilterExpressionOperator expressionOperator)
        {
            if (rightArg != null)
            {
                Expression = new DbExpressionPair((leftArg.GetType(), leftArg), (rightArg.GetType(), rightArg));
            }
            else
            {
                Expression = new DbExpressionPair((rightArg.GetType(), leftArg), (typeof(object), DBNull.Value));
            }
            ExpressionOperator = expressionOperator;
        }

        public FilterExpression(IDbDateFunctionExpression leftArg, object rightArg, FilterExpressionOperator expressionOperator)
        {
            if (rightArg != null)
            {
                Expression = new DbExpressionPair((leftArg.GetType(), leftArg), (rightArg.GetType(), rightArg));
            }
            else
            {
                Expression = new DbExpressionPair((rightArg.GetType(), leftArg), (typeof(object), DBNull.Value));
            }
            ExpressionOperator = expressionOperator;
        }

        #endregion

        #region to string
        public override string ToString()
        {
            string expression = $"{Expression.LeftPart.Item2} {ExpressionOperator} {Expression.RightPart.Item2}";
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
