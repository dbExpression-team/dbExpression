using HTL.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HTL.DbEx.Sql.Expression
{
    public class DBJoinExpressionSet : DBExpression, IDBExpressionSet<DBJoinExpression>, ISqlAssemblyPart
    {
        #region internals
        public IList<DBJoinExpression> Expressions { get; }  = new List<DBJoinExpression>();
        #endregion

        #region constructors
        public DBJoinExpressionSet(DBJoinExpression a)
        {
            Expressions.Add(a);
        }

        public DBJoinExpressionSet(DBJoinExpression a, DBJoinExpression b)
        {
            Expressions.Add(a);
            Expressions.Add(b);
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(Environment.NewLine, Expressions.Select(j => j.ToString()));
        #endregion

        #region logical & operator
        public static DBJoinExpressionSet operator &(DBJoinExpressionSet aSet, DBJoinExpression b)
        {
            aSet.Expressions.Add(b);
            return aSet;
        }

        public static DBJoinExpressionSet operator &(DBJoinExpressionSet aSet, DBJoinExpressionSet bSet)
        {
            foreach (var b in bSet.Expressions)
                aSet.Expressions.Add(b);
            return aSet;
        }
        #endregion
    }
    
}
