using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class GroupByExpressionSet : 
        IExpressionElement, 
        IExpressionSet<AnyGroupByClause>
    {
        #region interface
        public IEnumerable<AnyGroupByClause> Expressions { get; private set; } = new List<AnyGroupByClause>();
        #endregion

        #region constructors
        private GroupByExpressionSet()
        {

        }

        public GroupByExpressionSet(AnyGroupByClause groupBy)
        {
            Expressions = Expressions.Concat(new AnyGroupByClause[1] { (groupBy ?? throw new ArgumentNullException(nameof(groupBy))) is GroupByExpression ? groupBy : new GroupByExpression(groupBy) });
        }

        public GroupByExpressionSet(GroupByExpression aGroupBy, GroupByExpression bGroupBy)
        {
            Expressions = new List<AnyGroupByClause>
            {
                aGroupBy ?? throw new ArgumentNullException(nameof(aGroupBy)),
                bGroupBy ?? throw new ArgumentNullException(nameof(bGroupBy))
            };
        }

        public GroupByExpressionSet(IEnumerable<AnyGroupByClause> groupBys)
        {
            Expressions = (groupBys ?? throw new ArgumentNullException(nameof(groupBys))).Select(x => x is GroupByExpression ? x : new GroupByExpression(x));
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
                aSet.Expressions = aSet.Expressions.Concat(new AnyGroupByClause[1] { b });
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
