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
    public class DeleteQueryExpression : QueryExpression
    {
        #region interface
        public int? Top { get; set; }
        public FilterExpressionSet? Where { get; set; }
        public JoinExpressionSet? Joins { get; set; }
        #endregion

        #region to string
        public override string? ToString()
        {
            var sb = new StringBuilder("DELETE ");
            if (Top.HasValue)
            {
                sb.Append("TOP ");
                sb.Append(Top);
            }
            sb.Append("FROM ");
            sb.Append(BaseEntity);
            sb.Append(' ');
            sb.Append(Joins);
            sb.Append(' ');
            var where = (Where as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>)?.Expression;
            if (where is not null && where.Args.Any())
            {
                sb.Append("WHERE ");
                sb.Append(Where);
            }

            return sb.ToString();
        }
        #endregion

        #region operators
        public static DeleteQueryExpression operator &(DeleteQueryExpression? query, JoinExpression? join)
        {
            if (query is not null && join is not null)
            {
                if (query.Joins is null) { query.Joins = new JoinExpressionSet(join); }
                else { query.Joins &= join; }
            }
            return query ?? new();
        }

        public static DeleteQueryExpression operator &(DeleteQueryExpression? query, FilterExpression? filter)
        {
            if (query is not null && filter is not null)
            {
                if (query.Where is null) { query.Where = new FilterExpressionSet(filter); }
                else { query.Where &= filter; }
            }
            return query ?? new();
        }

        public static DeleteQueryExpression operator &(DeleteQueryExpression? query, FilterExpressionSet? filter)
        {
            if (query is not null && filter is not null)
            {
                if (query.Where is null) { query.Where = filter; }
                else { query.Where &= filter; }
            }
            return query ?? new();
        }
        #endregion
    }

}
