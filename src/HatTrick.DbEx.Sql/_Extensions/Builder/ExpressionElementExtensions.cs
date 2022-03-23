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
    internal static class ExpressionElementExtensions
    {
        internal static bool IsDBNull(this IExpressionElement expression)
        {
            if (expression is LiteralExpression literal)
                return literal.Expression is DBNull;

            if (expression is SelectExpression select)
                return IsDBNull(select.Expression);

            if (expression is ExpressionMediator mediator)
                return IsDBNull(mediator.Expression);

            return false;
        }

        internal static FieldExpression? AsFieldExpression(this IExpressionElement expression)
        {
            if (expression is FieldExpression field)
                return field;

            if (expression is SelectExpression select)
                return AsFieldExpression(select.Expression);

            if (expression is ExpressionMediator mediator)
                return AsFieldExpression(mediator.Expression);

            return null;
        }
    }
}
