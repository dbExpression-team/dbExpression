using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class InsertExpressionSet : DbExpression, IDbExpressionSet<InsertExpression>, IAssemblyPart
    {
        #region interface
        public IList<InsertExpression> Expressions { get; } = new List<InsertExpression>();
        #endregion

        #region constructors
        public InsertExpressionSet()
        {
        }

        public InsertExpressionSet(InsertExpression a)
        {
            Expressions.Add(a);
        }

        public InsertExpressionSet(InsertExpression a, InsertExpression b)
        {
            Expressions.Add(a);
            Expressions.Add(b);
        }
        #endregion

        #region to string
        public override string ToString() => $"{(string.Join(", ", Expressions.Select(e => e.ToString())))}";
        #endregion

        #region logical & operator
        public static InsertExpressionSet operator &(InsertExpressionSet aSet, InsertExpression b)
        {
            if (aSet == null)
            {
                aSet = new InsertExpressionSet(b);
            }
            else
            {
                aSet.Expressions.Add(b);
            }
            return aSet;
        }

        public static InsertExpressionSet operator &(InsertExpressionSet aSet, InsertExpressionSet bSet)
        {
            if (aSet == null)
            {
                aSet = new InsertExpressionSet();
            }
            foreach (var b in bSet.Expressions)
                aSet.Expressions.Add(b);
            return aSet;
        }
        #endregion
    }

}
