using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class AssignmentExpressionSet : 
        IExpressionElement,
        IExpressionSet<AssignmentExpression>
    {
        #region interface
        public IEnumerable<AssignmentExpression> Expressions { get; private set; }
        #endregion

        #region constructors
        public AssignmentExpressionSet()
        {
            Expressions = new List<AssignmentExpression>();
        }

        public AssignmentExpressionSet(IEnumerable<AssignmentExpression> assignments)
        {
            Expressions = assignments?.ToList() ?? throw new ArgumentNullException($"{nameof(assignments)} is required.");
        }

        public AssignmentExpressionSet(AssignmentExpression assignment)
        {
            Expressions = Expressions.Concat(new AssignmentExpression[1] { assignment ?? throw new ArgumentNullException($"{nameof(assignment)} is required.") });
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(", ", Expressions.Select(g => g.ToString()));
        #endregion

        #region logical & operator
        public static AssignmentExpressionSet operator &(AssignmentExpressionSet aSet, AssignmentExpression b)
        {
            if (aSet is null)
            {
                aSet = b;
            }
            else
            {
                aSet.Expressions = aSet.Expressions.Concat(new AssignmentExpression[1] { b });
            }
            return aSet;
        }

        public static AssignmentExpressionSet operator &(AssignmentExpressionSet aSet, AssignmentExpressionSet bSet)
        {
            if (aSet is null)
                return bSet;

            aSet.Expressions = aSet.Expressions.Concat(bSet?.Expressions);
            return aSet;
        }
        #endregion
    }
    
}
