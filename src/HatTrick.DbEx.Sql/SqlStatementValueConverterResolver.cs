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
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql
{
    public class SqlStatementValueConverterResolver : IValueConverterFinder
    {
        #region internals
        private readonly IEnumerable<IExpressionTypeProvider> fieldExpressions;
        private readonly IValueConverterFactory valueConverterFactory;
        #endregion

        #region constructors
        public SqlStatementValueConverterResolver(IEnumerable<FieldExpression> fieldExpressions, IValueConverterFactory valueConverterFactory)
        {
            this.fieldExpressions = fieldExpressions ?? throw new ArgumentNullException(nameof(fieldExpressions));
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
        }

        public SqlStatementValueConverterResolver(SelectExpressionSet selectExpressionSet, IValueConverterFactory valueConverterFactory)
        {
            if (selectExpressionSet is null)
                throw new ArgumentNullException(nameof(selectExpressionSet));
            this.fieldExpressions = selectExpressionSet.Expressions.Cast<IExpressionTypeProvider>();
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
        }
        #endregion

        #region methods
        public IValueConverter FindConverter(Type declaredType)
            => valueConverterFactory.CreateConverter(declaredType);

        public IValueConverter FindConverter(int index)
            =>  FindConverter(fieldExpressions.ElementAt(index));

        private IValueConverter FindConverter(IExpressionTypeProvider provider)
        {
            if (provider is null)
                return null;

            return valueConverterFactory.CreateConverter(provider.DeclaredType);
        }
        #endregion
    }
}
