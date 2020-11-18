using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class GroupByExpressionSet : 
        IExpressionElement, 
        IExpressionSet<GroupByExpression>
    {
        #region interface
        public IEnumerable<GroupByExpression> Expressions { get; private set; } = new List<GroupByExpression>();
        #endregion

        #region constructors
        internal GroupByExpressionSet()
        {

        }

        public GroupByExpressionSet(GroupByExpression groupByExpression)
        {
            Expressions = Expressions.Concat(new GroupByExpression[1] { groupByExpression ?? throw new ArgumentNullException($"{nameof(groupByExpression)} is required.") });
        }

        public GroupByExpressionSet(GroupByExpression aGroupByExpression, GroupByExpression bGroupByExpression)
        {
            Expressions = new List<GroupByExpression>
            {
                aGroupByExpression ?? throw new ArgumentNullException($"{nameof(aGroupByExpression)} is required."),
                bGroupByExpression ?? throw new ArgumentNullException($"{nameof(bGroupByExpression)} is required.")
            };
        }

        public GroupByExpressionSet(IEnumerable<GroupByExpression> groupByExpression)
        {
            Expressions = groupByExpression ?? throw new ArgumentNullException($"{nameof(groupByExpression)} is required.");
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
                aSet = b;
            }
            else
            {
                aSet.Expressions = aSet.Expressions.Concat(new GroupByExpression[1] { b });
            }
            return aSet;
        }

        public static GroupByExpressionSet operator &(GroupByExpressionSet aSet, GroupByExpressionSet bSet)
        {
            if (aSet is null)
                return bSet;

            aSet.Expressions = aSet.Expressions.Concat(bSet?.Expressions);
            return aSet;
        }
        #endregion
    }
    
}
