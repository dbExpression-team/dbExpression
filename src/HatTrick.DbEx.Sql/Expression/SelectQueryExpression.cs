namespace HatTrick.DbEx.Sql.Expression
{
    public class SelectQueryExpression : QueryExpression
    {
        #region interface
        public SelectExpressionSet Select { get; set; }
        public bool? Distinct { get; set; }
        public int? Top { get; set; }
        public int? Skip { get; set; }
        public int? Limit { get; set; }
        public FilterExpressionSet Where { get; set; }
        public JoinExpressionSet Joins { get; set; }
        public OrderByExpressionSet OrderBy { get; set; }
        public GroupByExpressionSet GroupBy { get; set; }
        public HavingExpression Having { get; set; }
        #endregion

        #region operators
        public static SelectQueryExpression operator &(SelectQueryExpression query, SelectExpression select)
        {
            if (query is object)
            {
                if (query.Select is null) { query.Select = new SelectExpressionSet(select); }
                else { query.Select &= select; }
            }
            return query;
        }

        public static SelectQueryExpression operator &(SelectQueryExpression query, SelectExpressionSet select)
        {
            if (query is object)
            {
                if (query.Select is null) { query.Select = select; }
                else { query.Select &= select; }
            }
            return query;
        }

        public static SelectQueryExpression operator &(SelectQueryExpression query, JoinExpression join)
        {
            if (query is object)
            {
                if (query.Joins is null) { query.Joins = new JoinExpressionSet(join); }
                else { query.Joins &= join; }
            }
            return query;
        }

        public static SelectQueryExpression operator &(SelectQueryExpression query, FilterExpression filter)
        {
            if (query is object)
            {
                if (query.Where is null) { query.Where = new FilterExpressionSet(filter); }
                else { query.Where &= filter; }
            }
            return query;
        }

        public static QueryExpression operator &(SelectQueryExpression query, FilterExpressionSet filter)
        {
            if (query is object)
            {
                if (query.Where is null) { query.Where = filter; }
                else { query.Where &= filter; }
            }
            return query;
        }

        public static SelectQueryExpression operator &(SelectQueryExpression query, OrderByExpression orderBy)
        {
            if (query is object)
            {
                if (query.OrderBy is null) { query.OrderBy = new OrderByExpressionSet(orderBy); }
                else { query.OrderBy &= orderBy; }
            }
            return query;
        }

        public static SelectQueryExpression operator &(SelectQueryExpression query, OrderByExpressionSet orderBy)
        {
            if (query is object)
            {
                if (query.OrderBy is null) { query.OrderBy = orderBy; }
                else { query.OrderBy &= orderBy; }
            }
            return query;
        }

        public static SelectQueryExpression operator &(SelectQueryExpression query, GroupByExpression groupBy)
        {
            if (query is object)
            {
                if (query.GroupBy is null) { query.GroupBy = new GroupByExpressionSet(groupBy); }
                else { query.GroupBy &= groupBy; }
            }
            return query;
        }

        public static SelectQueryExpression operator &(SelectQueryExpression query, GroupByExpressionSet groupBy)
        {
            if (query is object)
            {
                if (query.GroupBy is null) { query.GroupBy = groupBy; }
                else { query.GroupBy &= groupBy; }
            }
            return query;
        }

        public static SelectQueryExpression operator &(SelectQueryExpression query, HavingExpression having)
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
