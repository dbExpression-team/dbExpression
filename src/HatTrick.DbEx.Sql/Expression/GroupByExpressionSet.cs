using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class GroupByExpressionSet : 
        IExpression, 
        IExpressionSet<GroupByExpression>
    {
        #region interface
        public IList<GroupByExpression> Expressions { get; } = new List<GroupByExpression>();
        #endregion

        #region constructors
        internal GroupByExpressionSet()
        {

        }

        public GroupByExpressionSet(GroupByExpression groupByExpression)
        {
            Expressions.Add(groupByExpression ?? throw new ArgumentNullException($"{nameof(groupByExpression)} is required."));
        }

        public GroupByExpressionSet(GroupByExpression aGroupByExpression, GroupByExpression bGroupByExpression)
        {
            Expressions.Add(aGroupByExpression ?? throw new ArgumentNullException($"{nameof(aGroupByExpression)} is required."));
            Expressions.Add(bGroupByExpression ?? throw new ArgumentNullException($"{nameof(bGroupByExpression)} is required."));
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(", ", Expressions.Select(g => g.ToString()));
        #endregion

        #region conditional & operator
        public static GroupByExpressionSet operator &(GroupByExpressionSet aSet, GroupByExpression b)
        {
            if (aSet is null)
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
