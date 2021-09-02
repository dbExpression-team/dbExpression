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

﻿using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class InsertExpression :
        IExpression,
        IAssignmentExpressionProvider
    {
        #region internals
        private readonly FieldExpression assignee;
        private IExpressionElement assignment;
        #endregion

        #region interface
        FieldExpression IAssignmentExpressionProvider.Assignee => assignee;
        IExpressionElement IAssignmentExpressionProvider.Assignment { get => assignment; set => assignment = value; }
        #endregion

        #region constructors
        protected InsertExpression(IExpressionElement assignment, FieldExpression field)
        {
            this.assignment = assignment ?? throw new ArgumentNullException(nameof(assignment));
            this.assignee = field ?? throw new ArgumentNullException(nameof(field));
        }
        #endregion

        #region to string
        public override string ToString() => $"{assignee} = {assignment}";
        #endregion
    }
}
