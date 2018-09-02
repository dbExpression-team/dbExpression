using HatTrick.DbEx.Sql.Assembler;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class AssignmentExpressionSet : DbExpression, IDbExpressionSet<AssignmentExpression>, IDbExpressionAssemblyPart
    {
        #region internals
        public IList<AssignmentExpression> Expressions { get; } = new List<AssignmentExpression>();
        #endregion

        #region constructors
        internal AssignmentExpressionSet()
        {
        }

        internal AssignmentExpressionSet(AssignmentExpression a1)
        {
            Expressions.Add(a1);
        }

        internal AssignmentExpressionSet(AssignmentExpression a1, AssignmentExpression a2)
        {
            Expressions.Add(a1);
            Expressions.Add(a2);
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(", ", Expressions.Select(a => a.ToString()));
        #endregion

        #region logical & operator
        public static AssignmentExpressionSet operator &(AssignmentExpressionSet aSet, AssignmentExpression b)
        {
            if (aSet == null)
            {
                aSet = new AssignmentExpressionSet(b);
            }
            else
            {
                aSet.Expressions.Add(b);
            }
            return aSet;
        }

        public static AssignmentExpressionSet operator &(AssignmentExpressionSet aSet, AssignmentExpressionSet bSet)
        {
            if (aSet == null)
            {
                aSet = new AssignmentExpressionSet();
            }
            foreach (var b in bSet.Expressions)
                aSet.Expressions.Add(b);
            return aSet;
        }
        #endregion
    }
    
}
