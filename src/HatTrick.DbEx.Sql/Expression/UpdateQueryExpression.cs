namespace HatTrick.DbEx.Sql.Expression
{
    public class UpdateQueryExpression : QueryExpression
    {
        #region interface
        public AssignmentExpressionSet Assign { get; set; } = new AssignmentExpressionSet();
        public int? Top { get; set; }
        public FilterExpressionSet Where { get; set; }
        public JoinExpressionSet Joins { get; set; }
        #endregion

        #region operators
        public static UpdateQueryExpression operator &(UpdateQueryExpression query, AssignmentExpression assignment)
        {
            if (query is object)
            {
                if (query.Assign is null) { query.Assign = new AssignmentExpressionSet(assignment); }
                else { query.Assign &= assignment; }
            }
            return query;
        }

        public static UpdateQueryExpression operator &(UpdateQueryExpression query, AssignmentExpressionSet assignment)
        {
            if (query is object)
            {
                if (query.Assign is null) { query.Assign = assignment; }
                else { query.Assign &= assignment; }
            }
            return query;
        }

        public static UpdateQueryExpression operator &(UpdateQueryExpression query, JoinExpression join)
        {
            if (query is object)
            {
                if (query.Joins is null) { query.Joins = new JoinExpressionSet(join); }
                else { query.Joins &= join; }
            }
            return query;
        }

        public static UpdateQueryExpression operator &(UpdateQueryExpression query, FilterExpression filter)
        {
            if (query is object)
            {
                if (query.Where is null) { query.Where = new FilterExpressionSet(filter); }
                else { query.Where &= filter; }
            }
            return query;
        }

        public static UpdateQueryExpression operator &(UpdateQueryExpression query, FilterExpressionSet filter)
        {
            if (query is object)
            {
                if (query.Where is null) { query.Where = filter; }
                else { query.Where &= filter; }
            }
            return query;
        }
        #endregion
    }
    
}
