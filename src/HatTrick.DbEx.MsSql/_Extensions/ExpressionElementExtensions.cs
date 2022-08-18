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

﻿using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql
{
    internal static class ExpressionElementExtensions
    {
        internal static FieldExpression? ToFieldExpression(this IExpressionElement expression)
        {
            if (expression is FieldExpression field)
                return field;

            if (expression is SelectExpression select)
                return ToFieldExpression(select.Expression);

            if (expression is ExpressionMediator mediator)
                return ToFieldExpression(mediator.Expression);

            return null;
        }
    }
}
