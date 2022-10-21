#region license
// Copyright (c) HatTrick Labs, LLC.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/HatTrickLabs/db-ex
#endregion

using System.Linq;
using System.Text;

namespace HatTrick.DbEx.Sql.Expression
{
    public class SelectQueryExpression : QueryExpression
    {
        #region interface
        public SelectExpressionSet Select { get; set; } = new SelectExpressionSet();
        public FromExpression? From { get; set; }
        public bool? Distinct { get; set; }
        public int? Top { get; set; }
        public int? Offset { get; set; }
        public int? Limit { get; set; }
        public FilterExpressionSet? Where { get; set; }
        public JoinExpressionSet? Joins { get; set; }
        public OrderByExpressionSet? OrderBy { get; set; }
        public GroupByExpressionSet? GroupBy { get; set; }
        public HavingExpression? Having { get; set; }
        public QueryExpressionContinuationExpression? ContinuationExpression { get; set; }
        #endregion

        #region to string
        public override string? ToString()
        {
            var sb = new StringBuilder("SELECT");
            if (Distinct.HasValue && Distinct.Value)
                sb.Append(" DISTINCT");
            if (Top.HasValue)
            {
                sb.Append(" TOP ");
                sb.Append(Top);
            }
            sb.Append(' ');
            sb.Append(Select);
            sb.Append(" FROM ");
            sb.Append(From);
            if (Joins is not null && Joins.Expressions.Any())
            {
                sb.Append(' ');
                sb.Append(Joins);
            }
            var where = (Where as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>)?.Expression;
            if (where is not null && where.Args.Any())
            {
                sb.Append(" WHERE ");
                sb.Append(Where);
            }
            if (OrderBy?.Expressions is not null)
            {
                sb.Append(" ORDER BY ");
                sb.Append(OrderBy);
            }
            if (GroupBy?.Expressions is not null)
            {
                sb.Append(" GROUP BY ");
                sb.Append(GroupBy);
            }
            if (Having is not null)
            {
                sb.Append(" HAVING ");
                sb.Append(Having);
            }

            return sb.ToString();
        }
        #endregion

        #region operators
        public static SelectQueryExpression operator &(SelectQueryExpression? query, SelectExpression select)
        {
            if (query is not null)
            {
                if (query.Select is null) { query.Select = new SelectExpressionSet(select); }
                else { query.Select &= select; }
            }
            return query ?? new();
        }

        public static SelectQueryExpression operator &(SelectQueryExpression? query, SelectExpressionSet select)
        {
            if (query is not null)
            {
                if (query.Select is null) { query.Select = select; }
                else { query.Select &= select; }
            }
            return query ?? new();
        }

        public static SelectQueryExpression operator &(SelectQueryExpression? query, JoinExpression join)
        {
            if (query is not null)
            {
                if (query.Joins is null) { query.Joins = new JoinExpressionSet(join); }
                else { query.Joins &= join; }
            }
            return query ?? new();
        }

        public static SelectQueryExpression operator &(SelectQueryExpression? query, FilterExpression filter)
        {
            if (query is not null)
            {
                if (query.Where is null) { query.Where = new FilterExpressionSet(filter); }
                else { query.Where &= filter; }
            }
            return query ?? new();
        }

        public static QueryExpression operator &(SelectQueryExpression? query, FilterExpressionSet filter)
        {
            if (query is not null)
            {
                if (query.Where is null) { query.Where = filter; }
                else { query.Where &= filter; }
            }
            return query ?? new();
        }

        public static SelectQueryExpression operator &(SelectQueryExpression? query, OrderByExpression orderBy)
        {
            if (query is not null)
            {
                if (query.OrderBy is null) { query.OrderBy = new OrderByExpressionSet(orderBy); }
                else { query.OrderBy &= orderBy; }
            }
            return query ?? new();
        }

        public static SelectQueryExpression operator &(SelectQueryExpression? query, OrderByExpressionSet orderBy)
        {
            if (query is not null)
            {
                if (query.OrderBy is null) { query.OrderBy = orderBy; }
                else { query.OrderBy &= orderBy; }
            }
            return query ?? new();
        }

        public static SelectQueryExpression operator &(SelectQueryExpression? query, GroupByExpression groupBy)
        {
            if (query is not null)
            {
                if (query.GroupBy is null) { query.GroupBy = new GroupByExpressionSet(groupBy); }
                else { query.GroupBy &= groupBy; }
            }
            return query ?? new();
        }

        public static SelectQueryExpression operator &(SelectQueryExpression? query, GroupByExpressionSet groupBy)
        {
            if (query is not null)
            {
                if (query.GroupBy is null) { query.GroupBy = groupBy; }
                else { query.GroupBy &= groupBy; }
            }
            return query ?? new();
        }

        public static SelectQueryExpression operator &(SelectQueryExpression? query, HavingExpression having)
        {
            if (query is not null)
            {
                if (query.Having is null) { query.Having = having; }
                else { query.Having &= having; }
            }
            return query ?? new();
        }
        #endregion
    }
}
