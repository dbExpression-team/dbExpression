using HTL.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace HTL.DbEx.Sql.Expression
{
    public class DBOrderByExpressionSet : DBExpression, IDBExpressionSet<DBOrderByExpression>, ISqlAssemblyPart
    {
        #region internals
        public IList<DBOrderByExpression> Expressions { get; }  = new List<DBOrderByExpression>();
        #endregion

        #region constructors
        internal DBOrderByExpressionSet(DBOrderByExpression a)
        {
            Expressions.Add(a);
        }

        internal DBOrderByExpressionSet(DBOrderByExpression a, DBOrderByExpression b)
        {
            Expressions.Add(a);
            Expressions.Add(b);
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(", ", Expressions.Select(o => o.ToString()));
        #endregion

        #region condition & operators
        public static DBOrderByExpressionSet operator &(DBOrderByExpressionSet aSet, DBOrderByExpression b)
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

        public static DBOrderByExpressionSet operator &(DBOrderByExpressionSet aSet, DBOrderByExpressionSet bSet)
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
