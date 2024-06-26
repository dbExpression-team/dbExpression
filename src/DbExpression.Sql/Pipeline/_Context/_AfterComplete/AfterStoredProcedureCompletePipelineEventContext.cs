﻿#region license
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

using DbExpression.Sql.Assembler;
using DbExpression.Sql.Expression;
using System;

namespace DbExpression.Sql.Pipeline
{
    public class AfterStoredProcedureCompletePipelineEventContext : AfterCompletePipelineEventContext, IPipelineEventContext
    {
        #region internals
        private readonly StoredProcedureQueryExpression _expression;
        #endregion

        #region interface
        public new StoredProcedureQueryExpression Expression => _expression;
        #endregion

        #region constructors
        public AfterStoredProcedureCompletePipelineEventContext(StoredProcedureQueryExpression expression)
            : base(expression)
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }
        #endregion
    }
}
