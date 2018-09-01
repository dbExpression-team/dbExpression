using HTL.DbEx.Sql.Assembler;
using System.Collections.Generic;
using System.Linq;

namespace HTL.DbEx.Sql.Expression
{
    public class DBGroupByExpressionSet : DBExpression, IDBExpressionSet<DBGroupByExpression>, ISqlAssemblyPart
    {
        #region internals
        public IList<DBGroupByExpression> Expressions { get; } = new List<DBGroupByExpression>();
        #endregion

        #region constructors
        internal DBGroupByExpressionSet(DBGroupByExpression a)
        {
            Expressions.Add(a);
        }

        internal DBGroupByExpressionSet(DBGroupByExpression a, DBGroupByExpression b)
        {
            Expressions.Add(a);
            Expressions.Add(b);
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(", ", Expressions.Select(g => g.ToString()));
        #endregion

        #region conditional & operator
        public static DBGroupByExpressionSet operator &(DBGroupByExpressionSet aSet, DBGroupByExpression b)
        {
            if (aSet == null)
            {
                aSet = new DBGroupByExpressionSet(b);
            }
            else
            {
                aSet.Expressions.Add(b);
            }
            return aSet;
        }

        public static DBGroupByExpressionSet operator &(DBGroupByExpressionSet aSet, DBGroupByExpressionSet bSet)
        {
            foreach (var b in bSet.Expressions)
                aSet.Expressions.Add(b);
            return aSet;
        }
        #endregion
    }
    
}
