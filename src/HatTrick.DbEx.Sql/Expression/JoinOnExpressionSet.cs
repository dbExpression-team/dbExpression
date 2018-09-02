using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Expression
{
    public class JoinOnExpressionSet : DbExpression, IDbExpressionSet<JoinOnExpression>, IDbExpressionAssemblyPart
    {
        #region interface
        public IList<JoinOnExpression> Expressions { get; } = new List<JoinOnExpression>();
        public readonly ConditionalExpressionOperator ConditionalOperator;
        public bool Negate { get; set; }
        public (Type,object) LeftPart { get; set; }
        public (Type,object) RightPart { get; set; }
        #endregion

        #region constructors
        internal JoinOnExpressionSet(JoinOnExpression singleJoinOn)
        {
            RightPart = (typeof(JoinOnExpression), singleJoinOn);
            Expressions.Add(singleJoinOn);
        }

        internal JoinOnExpressionSet(JoinOnExpression leftArg, JoinOnExpression rightArg, ConditionalExpressionOperator conditinalOperator)
        {
            LeftPart = (typeof(JoinOnExpression), leftArg);
            RightPart = (typeof(JoinOnExpression), rightArg);
            ConditionalOperator = conditinalOperator;
            Expressions.Add(leftArg);
            Expressions.Add(rightArg);
        }

        internal JoinOnExpressionSet(JoinOnExpressionSet leftArg, JoinOnExpression rightArg, ConditionalExpressionOperator conditinalOperator)
        {
            LeftPart = (typeof(JoinOnExpressionSet), leftArg);
            RightPart = (typeof(JoinOnExpression), rightArg);
            ConditionalOperator = conditinalOperator;
            Expressions.Add(rightArg);
        }

        internal JoinOnExpressionSet(JoinOnExpressionSet leftArg, JoinOnExpressionSet rightArg, ConditionalExpressionOperator conditinalOperator)
        {
            LeftPart = (typeof(JoinOnExpressionSet), leftArg);
            RightPart = (typeof(JoinOnExpressionSet), rightArg);
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
        public static JoinOnExpressionSet operator &(JoinOnExpressionSet a, JoinOnExpression b)
        {
            if (a == null && b != null) { return new JoinOnExpressionSet(b); }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new JoinOnExpressionSet(a, b, ConditionalExpressionOperator.And);
        }

        public static JoinOnExpressionSet operator &(JoinOnExpressionSet a, JoinOnExpressionSet b)
        {
            if (a == null && b != null) { return b; }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new JoinOnExpressionSet(a, b, ConditionalExpressionOperator.And);
        }

        public static JoinOnExpressionSet operator |(JoinOnExpressionSet a, JoinOnExpression b)
        {
            if (a == null && b != null) { return new JoinOnExpressionSet(b); }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new JoinOnExpressionSet(a, b, ConditionalExpressionOperator.Or);
        }

        public static JoinOnExpressionSet operator |(JoinOnExpressionSet a, JoinOnExpressionSet b)
        {
            if (a == null && b != null) { return b; }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new JoinOnExpressionSet(a, b, ConditionalExpressionOperator.Or);
        }
        #endregion

        #region negation operator
        public static JoinOnExpressionSet operator !(JoinOnExpressionSet filter)
        {
            if (filter != null) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }
    
}
