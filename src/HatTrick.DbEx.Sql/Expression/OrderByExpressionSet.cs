using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class OrderByExpressionSet : DbExpression, IDbExpressionSet<OrderByExpression>, IDbExpressionAssemblyPart
    {
        #region internals
        public IList<OrderByExpression> Expressions { get; }  = new List<OrderByExpression>();
        #endregion

        #region constructors
        internal OrderByExpressionSet(OrderByExpression a)
        {
            Expressions.Add(a);
        }

        internal OrderByExpressionSet(OrderByExpression a, OrderByExpression b)
        {
            Expressions.Add(a);
            Expressions.Add(b);
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(", ", Expressions.Select(o => o.ToString()));
        #endregion

        #region condition & operators
        public static OrderByExpressionSet operator &(OrderByExpressionSet aSet, OrderByExpression b)
        {
            if (aSet == null)
            {
                aSet = b;
            }
            else
            {
                aSet.Expressions.Add(b);
            }
            return aSet;
        }

        public static OrderByExpressionSet operator &(OrderByExpressionSet aSet, OrderByExpressionSet bSet)
        {
            foreach (var b in bSet.Expressions)
            {
                if (aSet == null)
                {
                    aSet = b;
                }
                else
                {
                    aSet.Expressions.Add(b);
                }
            }
            return aSet;
        }
        #endregion
    }
    
}
