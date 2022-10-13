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

﻿using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeUpdateCommandPipelineEventContext : BeforeCommandPipelineEventContext, IPipelineEventContext
    {
        #region internals
        private readonly UpdateQueryExpression _expression;
        #endregion

        #region interface
        public new UpdateQueryExpression Expression => _expression;
        public IEnumerable<AssignmentExpression> Fields { get; private set; }
        #endregion

        #region constructors
        public BeforeUpdateCommandPipelineEventContext(UpdateQueryExpression expression, IDbCommand command, SqlStatement statement)
            : base(expression, command, statement)
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
            Fields = expression.Assign.Expressions.ToList().AsReadOnly();
        }
        #endregion
    }
}
