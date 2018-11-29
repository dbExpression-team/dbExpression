using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class SelectExpressionSet : DbExpression//, IDbExpressionSet<IDbExpressionSelectClausePart>, IAssemblyPart
    {
        #region interface
        public IList<(Type,object)> Expressions { get; } = new List<(Type, object)>();
        #endregion

        #region constructor
        internal SelectExpressionSet()
        {
        }

        internal SelectExpressionSet(SelectExpression a)
        {
            Expressions.Add((a.GetType(), a));
        }

        internal SelectExpressionSet(SelectExpression a, SelectExpression b)
        {
            Expressions.Add((a.GetType(), a));
            Expressions.Add((b.GetType(), b));
        }

        internal SelectExpressionSet(FieldExpression a, FieldExpression b)
        {
            Expressions.Add((a.GetType(), a));
            Expressions.Add((b.GetType(), b));
        }

        internal SelectExpressionSet(ArithmeticExpression arithmeticExpression)
        {
            Expressions.Add((arithmeticExpression.GetType(), arithmeticExpression));
        }

        internal SelectExpressionSet(AggregateFunctionExpression aggregateFunctionExpression)
        {
            Expressions.Add((aggregateFunctionExpression.GetType(), aggregateFunctionExpression));
        }

        internal SelectExpressionSet(CoalesceFunctionExpression coalesceFunctionExpression)
        {
            Expressions.Add((coalesceFunctionExpression.GetType(), coalesceFunctionExpression));
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(", ", Expressions.Select(s => s.ToString()));
        #endregion

        #region logical & operator
        public static SelectExpressionSet operator &(SelectExpressionSet aSet, SelectExpression b)
        {
            if (aSet == null)
            {
                aSet = new SelectExpressionSet(b);
            }
            else
            {
                aSet.Expressions.Add((b.GetType(), b));
            }
            return aSet;
        }

        public static SelectExpressionSet operator &(SelectExpressionSet aSet, SelectExpressionSet bSet)
        {
            if (aSet == null)
            {
                aSet = new SelectExpressionSet();
            }
            foreach (var e in bSet.Expressions)
            {
                aSet.Expressions.Add(e);
            }
            return aSet;
        }
        #endregion
    }
    
}
