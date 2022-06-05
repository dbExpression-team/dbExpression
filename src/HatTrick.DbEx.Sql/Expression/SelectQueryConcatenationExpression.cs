﻿#region license
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

using System;
using System.Text;

namespace HatTrick.DbEx.Sql.Expression
{
    public class SelectQueryConcatenationExpression :
        IExpressionElement
    {
        public SelectQueryExpression SelectQueryExpression { get; private set; }
        public IExpressionElement? ConcatenationExpression { get; set; }

        public SelectQueryConcatenationExpression(SelectQueryExpression expression)
        {
            SelectQueryExpression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        #region to string
        public override string? ToString()
        {
            var sb = new StringBuilder();
            sb.Append(SelectQueryExpression);
            if (ConcatenationExpression is not null)
            {
                sb.Append(' ');
                sb.Append(ConcatenationExpression);
                sb.Append(' ');
            }
            return sb.ToString();
        }
        #endregion
    }
}
