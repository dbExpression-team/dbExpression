#region license
// Copyright (c) dbExpression.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

using DbExpression.Sql.Expression;
using System;
using System.Data;

namespace DbExpression.Sql.Pipeline
{
    public class AfterDeleteCommandPipelineEventContext : AfterCommandPipelineEventContext, IPipelineEventContext
    {
        private readonly DeleteQueryExpression _expression;

        public new DeleteQueryExpression Expression => _expression;

        public AfterDeleteCommandPipelineEventContext(DeleteQueryExpression expression, IDbCommand command)
            : base(expression, command)
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }
    }
}
