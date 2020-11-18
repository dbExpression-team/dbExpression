namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class QueryExpression : IExpressionElement
    {
        #region interface
        public EntityExpression BaseEntity { get; set; }

        public int? SkipValue { get; set; }

        public int? LimitValue { get; set; }

        public FilterExpressionSet Where { get; set; } = new FilterExpressionSet();

        public JoinExpressionSet Joins { get; set; } = new JoinExpressionSet();

        public OrderByExpressionSet OrderBy { get; set; } = new OrderByExpressionSet();

        public GroupByExpressionSet GroupBy { get; set; } = new GroupByExpressionSet();

        public HavingExpression Having { get; set; } = new HavingExpression();
        #endregion

        #region operators
        public static QueryExpression operator &(QueryExpression query, JoinExpression join)
        {
            if (query is object)
            {
                if (query.Joins is null) { query.Joins = new JoinExpressionSet(join); }
                else { query.Joins &= join; }
            }
            return query;
        }

        public static QueryExpression operator &(QueryExpression query, FilterExpression filter)
        {
            if (query is object)
            {
                if (query.Where is null) { query.Where = new FilterExpressionSet(filter); }
                else { query.Where &= filter; }
            }
            return query;
        }

        public static QueryExpression operator &(QueryExpression query, FilterExpressionSet filter)
        {
            if (query is object)
            {
                if (query.Where is null) { query.Where = filter; }
                else { query.Where &= filter; }
            }
            return query;
        }

        public static QueryExpression operator &(QueryExpression query, OrderByExpression orderBy)
        {
            if (query is object)
            {
                if (query.OrderBy is null) { query.OrderBy = new OrderByExpressionSet(orderBy); }
                else { query.OrderBy &= orderBy; }
            }
            return query;
        }

        public static QueryExpression operator &(QueryExpression query, OrderByExpressionSet orderBy)
        {
            if (query is object)
            {
                if (query.OrderBy is null) { query.OrderBy = orderBy; }
                else { query.OrderBy &= orderBy; }
            }
            return query;
        }

        public static QueryExpression operator &(QueryExpression query, GroupByExpression groupBy)
        {
            if (query is object)
            {
                if (query.GroupBy is null) { query.GroupBy = new GroupByExpressionSet(groupBy); }
                else { query.GroupBy &= groupBy; }
            }
            return query;
        }

        public static QueryExpression operator &(QueryExpression query, GroupByExpressionSet groupBy)
        {
            if (query is object)
            {
                if (query.GroupBy is null) { query.GroupBy = groupBy; }
                else { query.GroupBy &= groupBy; }
            }
            return query;
        }

        public static QueryExpression operator &(QueryExpression query, HavingExpression having)
        {
            if (query is object)
            {
                if (query.Having is null) { query.Having = having; }
                else { query.Having &= having; }
            }
            return query;
        }
        #endregion
    }
    
}
