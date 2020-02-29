using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class AssignmentExpressionSet : 
        IDbExpressionSet<AssignmentExpression>, 
        IAssemblyPart
    {
        #region interface
        public IList<AssignmentExpression> Expressions { get; }
        #endregion

        #region constructors
        public AssignmentExpressionSet()
        {
            Expressions = new List<AssignmentExpression>();
        }

        public AssignmentExpressionSet(IList<AssignmentExpression> assignments)
        {
            Expressions = assignments?.ToList() ?? throw new ArgumentNullException($"{nameof(assignments)} is required.");
        }

        public AssignmentExpressionSet(AssignmentExpression assignment)
        {
            Expressions.Add(assignment ?? throw new ArgumentNullException($"{nameof(assignment)} is required."));
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
