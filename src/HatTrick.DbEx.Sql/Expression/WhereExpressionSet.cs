using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class WhereExpressionSet : DbExpression, IDbExpressionSet<WhereExpression>, IDbExpressionAssemblyPart
    {
        #region interface
        public IList<WhereExpression> Expressions { get; } = new List<WhereExpression>();
        public readonly ConditionalExpressionOperator ConditionalOperator;
        public bool Negate { get; set; }
        public (Type, object) LeftPart { get; set; }
        public (Type, object) RightPart { get; set; }
        #endregion

        #region constructors
        internal WhereExpressionSet(WhereExpression singleFilter)
        {
            RightPart = (typeof(WhereExpression), singleFilter);
            Expressions.Add(singleFilter);
        }

        internal WhereExpressionSet(WhereExpression leftArg, WhereExpression rightArg, ConditionalExpressionOperator conditinalOperator)
        {
            LeftPart = (typeof(FilterExpression), leftArg);
            RightPart = (typeof(FilterExpression), rightArg);
            ConditionalOperator = conditinalOperator;
            Expressions.Add(leftArg);
            Expressions.Add(rightArg);
        }

        internal WhereExpressionSet(WhereExpressionSet leftArg, WhereExpression rightArg, ConditionalExpressionOperator conditinalOperator)
        {
            LeftPart = (typeof(WhereExpressionSet), leftArg);
            RightPart = (typeof(WhereExpression), rightArg);
            ConditionalOperator = conditinalOperator;
            Expressions.Add(rightArg);
        }

        internal WhereExpressionSet(WhereExpressionSet leftArg, WhereExpressionSet rightArg, ConditionalExpressionOperator conditinalOperator)
        {
            LeftPart = (typeof(WhereExpressionSet), leftArg);
            RightPart = (typeof(WhereExpressionSet), rightArg);
            ConditionalOperator = conditinalOperator;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            string left = default(ValueTuple<Type, object>).Equals(LeftPart) ? string.Empty : LeftPart.Item2.ToString();
            string right = RightPart.Item2.ToString();
            string expression = $"{left} {ConditionalOperator} {right}";
            return (Negate) ? $"NOT ({expression})" : expression;
        }
        #endregion


        #region logical & operator
        public static WhereExpressionSet operator &(WhereExpressionSet aSet, WhereExpression b)
        {
            aSet.Expressions.Add(b);
            return aSet;
        }

        public static WhereExpressionSet operator &(WhereExpressionSet aSet, WhereExpressionSet bSet)
        {
            foreach (var b in bSet.Expressions)
                aSet.Expressions.Add(b);
            return aSet;
        }
        #endregion
    }
    
}
