using HTL.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HTL.DbEx.Sql.Expression
{
    public class DBWhereExpressionSet : DBExpression, IDBExpressionSet<DBWhereExpression>, ISqlAssemblyPart
    {
        #region interface
        public IList<DBWhereExpression> Expressions { get; } = new List<DBWhereExpression>();
        public readonly DBConditionalExpressionOperator ConditionalOperator;
        public bool Negate { get; set; }
        public (Type, object) LeftPart { get; set; }
        public (Type, object) RightPart { get; set; }
        #endregion

        #region constructors
        internal DBWhereExpressionSet(DBWhereExpression singleFilter)
        {
            RightPart = (typeof(DBWhereExpression), singleFilter);
            Expressions.Add(singleFilter);
        }

        internal DBWhereExpressionSet(DBWhereExpression leftArg, DBWhereExpression rightArg, DBConditionalExpressionOperator conditinalOperator)
        {
            LeftPart = (typeof(DBFilterExpression), leftArg);
            RightPart = (typeof(DBFilterExpression), rightArg);
            ConditionalOperator = conditinalOperator;
            Expressions.Add(leftArg);
            Expressions.Add(rightArg);
        }

        internal DBWhereExpressionSet(DBWhereExpressionSet leftArg, DBWhereExpression rightArg, DBConditionalExpressionOperator conditinalOperator)
        {
            LeftPart = (typeof(DBWhereExpressionSet), leftArg);
            RightPart = (typeof(DBWhereExpression), rightArg);
            ConditionalOperator = conditinalOperator;
            Expressions.Add(rightArg);
        }

        internal DBWhereExpressionSet(DBWhereExpressionSet leftArg, DBWhereExpressionSet rightArg, DBConditionalExpressionOperator conditinalOperator)
        {
            LeftPart = (typeof(DBWhereExpressionSet), leftArg);
            RightPart = (typeof(DBWhereExpressionSet), rightArg);
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
        public static DBWhereExpressionSet operator &(DBWhereExpressionSet aSet, DBWhereExpression b)
        {
            aSet.Expressions.Add(b);
            return aSet;
        }

        public static DBWhereExpressionSet operator &(DBWhereExpressionSet aSet, DBWhereExpressionSet bSet)
        {
            foreach (var b in bSet.Expressions)
                aSet.Expressions.Add(b);
            return aSet;
        }
        #endregion
    }
    
}
