namespace HatTrick.DbEx.Sql.Expression
{
    public class UpdateQueryExpression : QueryExpression
    {
        public AssignmentExpressionSet Assign { get; set; } = new AssignmentExpressionSet();

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
    }
    
}
