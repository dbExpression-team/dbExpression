using HTL.DbEx.Sql.Assembler;
using System.Collections.Generic;
using System.Linq;

namespace HTL.DbEx.Sql.Expression
{
    public class DBAssignmentExpressionSet : DBExpression, IDBExpressionSet<DBAssignmentExpression>, ISqlAssemblyPart
    {
        #region internals
        public IList<DBAssignmentExpression> Expressions { get; } = new List<DBAssignmentExpression>();
        #endregion

        #region constructors
        internal DBAssignmentExpressionSet()
        {
        }

        internal DBAssignmentExpressionSet(DBAssignmentExpression a1)
        {
            Expressions.Add(a1);
        }

        internal DBAssignmentExpressionSet(DBAssignmentExpression a1, DBAssignmentExpression a2)
        {
            Expressions.Add(a1);
            Expressions.Add(a2);
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(", ", Expressions.Select(a => a.ToString()));
        #endregion

        #region logical & operator
        public static DBAssignmentExpressionSet operator &(DBAssignmentExpressionSet aSet, DBAssignmentExpression b)
        {
            if (aSet == null)
            {
                aSet = new DBAssignmentExpressionSet(b);
            }
            else
            {
                aSet.Expressions.Add(b);
            }
            return aSet;
        }

        public static DBAssignmentExpressionSet operator &(DBAssignmentExpressionSet aSet, DBAssignmentExpressionSet bSet)
        {
            if (aSet == null)
            {
                aSet = new DBAssignmentExpressionSet();
            }
            foreach (var b in bSet.Expressions)
                aSet.Expressions.Add(b);
            return aSet;
        }
        #endregion
    }
    
}
