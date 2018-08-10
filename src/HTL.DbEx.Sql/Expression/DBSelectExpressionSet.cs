using HTL.DbEx.Sql.Assembler;
using System.Collections.Generic;
using System.Linq;

namespace HTL.DbEx.Sql.Expression
{
    public class DBSelectExpressionSet : DBExpression, IDBExpressionSet<DBSelectExpression>, ISqlAssemblyPart
    {
        #region internals
        public IList<DBSelectExpression> Expressions { get; } = new List<DBSelectExpression>();
        #endregion

        #region constructor
        internal DBSelectExpressionSet()
        {
        }

        internal DBSelectExpressionSet(DBSelectExpression a)
        {
            Expressions.Add(a);
        }

        internal DBSelectExpressionSet(DBSelectExpression a, DBSelectExpression b)
        {
            Expressions.Add(a);
            Expressions.Add(b);
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(", ", Expressions.Select(s => s.ToString()));
        #endregion

        #region logical & operator
        public static DBSelectExpressionSet operator &(DBSelectExpressionSet aSet, DBSelectExpression b)
        {
            if (aSet == null)
            {
                aSet = new DBSelectExpressionSet(b);
            }
            else
            {
                aSet.Expressions.Add(b);
            }
            return aSet;
        }

        public static DBSelectExpressionSet operator &(DBSelectExpressionSet aSet, DBSelectExpressionSet bSet)
        {
            if (aSet == null)
            {
                aSet = new DBSelectExpressionSet();
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
