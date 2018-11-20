using HatTrick.DbEx.Sql.Assembler;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class GroupByExpressionSet : DbExpression, IDbExpressionSet<GroupByExpression>, IAssemblyPart
    {
        #region internals
        public IList<GroupByExpression> Expressions { get; } = new List<GroupByExpression>();
        #endregion

        #region constructors
        internal GroupByExpressionSet(GroupByExpression a)
        {
            Expressions.Add(a);
        }

        internal GroupByExpressionSet(GroupByExpression a, GroupByExpression b)
        {
            Expressions.Add(a);
            Expressions.Add(b);
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(", ", Expressions.Select(g => g.ToString()));
        #endregion

        #region conditional & operator
        public static GroupByExpressionSet operator &(GroupByExpressionSet aSet, GroupByExpression b)
        {
            if (aSet == null)
            {
                aSet = new GroupByExpressionSet(b);
            }
            else
            {
                aSet.Expressions.Add(b);
            }
            return aSet;
        }

        public static GroupByExpressionSet operator &(GroupByExpressionSet aSet, GroupByExpressionSet bSet)
        {
            foreach (var b in bSet.Expressions)
                aSet.Expressions.Add(b);
            return aSet;
        }
        #endregion
    }
    
}
