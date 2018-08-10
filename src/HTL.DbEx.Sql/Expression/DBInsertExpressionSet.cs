using HTL.DbEx.Sql.Assembler;
using System.Collections.Generic;
using System.Linq;

namespace HTL.DbEx.Sql.Expression
{
    public class DBInsertExpressionSet : DBExpression, IDBExpressionSet<DBInsertExpression>, ISqlAssemblyPart
    {
        #region internals
        public IList<DBInsertExpression> Expressions { get; } = new List<DBInsertExpression>();
        #endregion

        #region constructors
        public DBInsertExpressionSet()
        {
        }

        public DBInsertExpressionSet(DBInsertExpression a)
        {
            Expressions.Add(a);
        }

        public DBInsertExpressionSet(DBInsertExpression a, DBInsertExpression b)
        {
            Expressions.Add(a);
            Expressions.Add(b);
        }
        #endregion

        #region to string
        public override string ToString() => $"{(string.Join(", ", Expressions.Select(e => e.ToString())))}";
        #endregion

        #region logical & operator
        public static DBInsertExpressionSet operator &(DBInsertExpressionSet aSet, DBInsertExpression b)
        {
            if (aSet == null)
            {
                aSet = new DBInsertExpressionSet(b);
            }
            else
            {
                aSet.Expressions.Add(b);
            }
            return aSet;
        }

        public static DBInsertExpressionSet operator &(DBInsertExpressionSet aSet, DBInsertExpressionSet bSet)
        {
            if (aSet == null)
            {
                aSet = new DBInsertExpressionSet();
            }
            foreach (var b in bSet.Expressions)
                aSet.Expressions.Add(b);
            return aSet;
        }
        #endregion
    }

}
