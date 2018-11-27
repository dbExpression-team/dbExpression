using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ExpressionSet : IAssemblyPart
    {
        #region interface
        public object Instance { get; set; }

        public EntityExpression BaseEntity { get; set; }

        public ExecutionContext ExecutionContext { get; set; }

        public int? SkipValue { get; set; }

        public int? LimitValue { get; set; }

        public bool Distinct { get; set; }

        public int? Top { get; set; }

        public SelectExpressionSet Select { get; set; }

        public InsertExpressionSet Insert { get; set; }

        public AssignmentExpressionSet Assign { get; set; }

        public FilterExpressionSet Where { get; set; }

        public JoinExpressionSet Joins { get; set; }

        public OrderByExpressionSet OrderBy { get; set; }

        public GroupByExpressionSet GroupBy { get; set; }

        public HavingExpression Having { get; set; }
        #endregion

        #region operators
        public static ExpressionSet operator &(ExpressionSet set, SelectExpression selectExpression)
        {
            if (set != null)
            {
                if (set.Select == null) { set.Select = new SelectExpressionSet(selectExpression); }
                else { set.Select &= selectExpression; }
            }
            return set;
        }

        public static ExpressionSet operator &(ExpressionSet set, SelectExpressionSet selectExpressionSet)
        {
            if (set != null)
            {
                if (set.Select == null) { set.Select = selectExpressionSet; }
                else { set.Select &= selectExpressionSet; }
            }
            return set;
        }

        public static ExpressionSet operator &(ExpressionSet set, InsertExpression insertExpression)
        {
            if (set != null)
            {
                if (set.Insert == null) { set.Insert = new InsertExpressionSet(insertExpression); }
                else { set.Insert &= insertExpression; }
            }
            return set;
        }

        public static ExpressionSet operator &(ExpressionSet set, InsertExpressionSet insertExpressionSet)
        {
            if (set != null)
            {
                if (set.Insert == null) { set.Insert = insertExpressionSet; }
                else { set.Insert &= insertExpressionSet; }
            }
            return set;
        }

        public static ExpressionSet operator &(ExpressionSet set, AssignmentExpression assignmentExpression)
        {
            if (set != null)
            {
                if (set.Assign == null) { set.Assign = new AssignmentExpressionSet(assignmentExpression); }
                else { set.Assign &= assignmentExpression; }
            }
            return set;
        }

        public static ExpressionSet operator &(ExpressionSet set, AssignmentExpressionSet assignmentExpressionSet)
        {
            if (set != null)
            {
                if (set.Assign == null) { set.Assign = assignmentExpressionSet; }
                else { set.Assign &= assignmentExpressionSet; }
            }
            return set;
        }

        public static ExpressionSet operator &(ExpressionSet set, JoinExpression joinExpression)
        {
            if (set != null)
            {
                if (set.Joins == null) { set.Joins = new JoinExpressionSet(joinExpression); }
                else { set.Joins &= joinExpression; }
            }
            return set;
        }

        public static ExpressionSet operator &(ExpressionSet set, FilterExpression filterExpression)
        {
            if (set != null)
            {
                if (set.Where == null) { set.Where = new FilterExpressionSet(filterExpression); }
                else { set.Where &= filterExpression; }
            }
            return set;
        }

        public static ExpressionSet operator &(ExpressionSet set, FilterExpressionSet filterExpressionSet)
        {
            if (set != null)
            {
                if (set.Where == null) { set.Where = filterExpressionSet; }
                else { set.Where &= filterExpressionSet; }
            }
            return set;
        }

        public static ExpressionSet operator &(ExpressionSet set, OrderByExpression orderByExpression)
        {
            if (set != null)
            {
                if (set.OrderBy == null) { set.OrderBy = new OrderByExpressionSet(orderByExpression); }
                else { set.OrderBy &= orderByExpression; }
            }
            return set;
        }

        public static ExpressionSet operator &(ExpressionSet set, OrderByExpressionSet orderByExpressionSet)
        {
            if (set != null)
            {
                if (set.OrderBy == null) { set.OrderBy = orderByExpressionSet; }
                else { set.OrderBy &= orderByExpressionSet; }
            }
            return set;
        }

        public static ExpressionSet operator &(ExpressionSet set, GroupByExpression groupByExpression)
        {
            if (set != null)
            {
                if (set.GroupBy == null) { set.GroupBy = new GroupByExpressionSet(groupByExpression); }
                else { set.GroupBy &= groupByExpression; }
            }
            return set;
        }

        public static ExpressionSet operator &(ExpressionSet set, GroupByExpressionSet groupByExpressionSet)
        {
            if (set != null)
            {
                if (set.GroupBy == null) { set.GroupBy = groupByExpressionSet; }
                else { set.GroupBy &= groupByExpressionSet; }
            }
            return set;
        }

        public static ExpressionSet operator &(ExpressionSet set, HavingExpression havingCondition)
        {
            if (set != null)
            {
                if (set.Having == null) { set.Having = havingCondition; }
                else { set.Having &= havingCondition; }
            }
            return set;
        }
        #endregion

        #region clear selects
        public void ClearSelect()
        {
            this.Select = null;
        }
        #endregion
    }
    
}
