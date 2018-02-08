namespace HTL.DbEx.Sql.Expression
{
    public class DBExpressionSet
    {
        #region interface
        public DBSelectExpressionSet Select { get; private set; }

        public DBInsertExpressionSet Insert { get; private set; }

        public DBAssignmentExpressionSet Assign { get; private set; }

        public DBFilterExpressionSet Where { get; private set; }

        public DBJoinExpressionSet Joins { get; private set; }

        public DBOrderByExpressionSet OrderBy { get; private set; }

        public DBGroupByExpressionSet GroupBy { get; private set; }

        public DBHavingExpression Having { get; private set; }
        #endregion

        #region operators
        public static DBExpressionSet operator &(DBExpressionSet set, DBSelectExpression selectExpression)
        {
            if (set != null)
            {
                if (set.Select == null) { set.Select = new DBSelectExpressionSet(selectExpression); }
                else { set.Select &= selectExpression; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBSelectExpressionSet selectExpressionSet)
        {
            if (set != null)
            {
                if (set.Select == null) { set.Select = selectExpressionSet; }
                else { set.Select &= selectExpressionSet; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBInsertExpression insertExpression)
        {
            if (set != null)
            {
                if (set.Insert == null) { set.Insert = new DBInsertExpressionSet(insertExpression); }
                else { set.Insert &= insertExpression; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBInsertExpressionSet insertExpressionSet)
        {
            if (set != null)
            {
                if (set.Insert == null) { set.Insert = insertExpressionSet; }
                else { set.Insert &= insertExpressionSet; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBAssignmentExpression assignmentExpression)
        {
            if (set != null)
            {
                if (set.Assign == null) { set.Assign = new DBAssignmentExpressionSet(assignmentExpression); }
                else { set.Assign &= assignmentExpression; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBAssignmentExpressionSet assignmentExpressionSet)
        {
            if (set != null)
            {
                if (set.Assign == null) { set.Assign = assignmentExpressionSet; }
                else { set.Assign &= assignmentExpressionSet; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBJoinExpression joinExpression)
        {
            if (set != null)
            {
                if (set.Joins == null) { set.Joins = new DBJoinExpressionSet(joinExpression); }
                else { set.Joins &= joinExpression; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBFilterExpression filterExpression)
        {
            if (set != null)
            {
                if (set.Where == null) { set.Where = new DBFilterExpressionSet(filterExpression); }
                else { set.Where &= filterExpression; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBFilterExpressionSet filterExpressionSet)
        {
            if (set != null)
            {
                if (set.Where == null) { set.Where = filterExpressionSet; }
                else { set.Where &= filterExpressionSet; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBOrderByExpression orderByExpression)
        {
            if (set != null)
            {
                if (set.OrderBy == null) { set.OrderBy = new DBOrderByExpressionSet(orderByExpression); }
                else { set.OrderBy &= orderByExpression; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBOrderByExpressionSet orderByExpressionSet)
        {
            if (set != null)
            {
                if (set.OrderBy == null) { set.OrderBy = orderByExpressionSet; }
                else { set.OrderBy &= orderByExpressionSet; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBGroupByExpression groupByExpression)
        {
            if (set != null)
            {
                if (set.GroupBy == null) { set.GroupBy = new DBGroupByExpressionSet(groupByExpression); }
                else { set.GroupBy &= groupByExpression; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBGroupByExpressionSet groupByExpressionSet)
        {
            if (set != null)
            {
                if (set.GroupBy == null) { set.GroupBy = groupByExpressionSet; }
                else { set.GroupBy &= groupByExpressionSet; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBHavingExpression havingCondition)
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
