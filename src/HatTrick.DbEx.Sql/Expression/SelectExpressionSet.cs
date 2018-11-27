using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class SelectExpressionSet : DbExpression, IDbExpressionSet<SelectExpression>, IAssemblyPart
    {
        #region interface
        public IList<SelectExpression> Expressions { get; } = new List<SelectExpression>();
        #endregion

        #region constructor
        internal SelectExpressionSet()
        {
        }

        internal SelectExpressionSet(SelectExpression a)
        {
            Expressions.Add(a);
        }

        internal SelectExpressionSet(SelectExpression a, SelectExpression b)
        {
            Expressions.Add(a);
            Expressions.Add(b);
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
                aSet.Expressions.Add(b);
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
