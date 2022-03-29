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

﻿using System.Text;

namespace HatTrick.DbEx.Sql.Expression
{
    public class UpdateQueryExpression : QueryExpression
    {
        #region interface
        public AssignmentExpressionSet Assign { get; set; } = new AssignmentExpressionSet();
        public int? Top { get; set; }
        public FilterExpressionSet? Where { get; set; }
        public JoinExpressionSet? Joins { get; set; }
        #endregion

        #region to string
        public override string? ToString()
        {
            var sb = new StringBuilder("UPDATE ");
            if (Top.HasValue)
            {
                sb.Append("TOP ");
                sb.Append(Top);
            }
            sb.Append(Assign);
            sb.Append("FROM ");
            sb.Append(BaseEntity);
            sb.Append(' ');
            sb.Append(Joins);
            sb.Append(' ');
            if (!(Where as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>)?.Expression?.IsEmpty is not null)
            {
                sb.Append("WHERE ");
                sb.Append(Where);
            }

            return sb.ToString();
        }
        #endregion

        #region operators
        public static UpdateQueryExpression operator &(UpdateQueryExpression query, AssignmentExpression assignment)
        {
            if (query is null)
                return new() { Assign = assignment };

            if (query.Assign is null) { query.Assign = assignment; }
            else { query.Assign &= assignment; }
            return query;
        }

        public static UpdateQueryExpression operator &(UpdateQueryExpression query, AssignmentExpressionSet assignment)
        {
            if (query is null)
                return new() { Assign = assignment };

            if (query.Assign is null) { query.Assign = assignment; }
            else { query.Assign &= assignment; }
            return query;
        }

        public static UpdateQueryExpression operator &(UpdateQueryExpression query, JoinExpression join)
        {
            if (query is null)
                return new() { Joins = join };

            if (query.Joins is null) { query.Joins = join; }
            else { query.Joins &= join; }
            return query;
        }

        public static UpdateQueryExpression operator &(UpdateQueryExpression query, FilterExpression filter)
        {
            if (query is null)
                return new() { Where = filter };

            if (query.Joins is null) { query.Where = filter; }
            else if (query.Where is null) { query.Where = filter; }
            else { query.Where &= filter; }
            return query;
        }

        public static UpdateQueryExpression operator &(UpdateQueryExpression query, FilterExpressionSet filter)
        {
            if (query is null)
                return new() { Where = filter };

            if (query.Joins is null) { query.Where = filter; }
            else if (query.Where is null) { query.Where = filter; }
            else { query.Where &= filter; }
            return query;
        }
        #endregion
    }
    
}
