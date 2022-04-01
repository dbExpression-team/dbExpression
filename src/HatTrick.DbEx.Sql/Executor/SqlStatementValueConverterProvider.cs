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

using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Executor
{
    public class SqlStatementValueConverterProvider : IValueConverterProvider
    {
        #region internals
        private readonly IEnumerable<IExpressionTypeProvider?>? typeProviders;
        private readonly IValueConverterFactory valueConverterFactory;
        #endregion

        #region constructors
        public SqlStatementValueConverterProvider(IValueConverterFactory valueConverterFactory)
        {
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
        }

        public SqlStatementValueConverterProvider(IValueConverterFactory valueConverterFactory, IEnumerable<FieldExpression?> fieldExpressions)
        {
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
            this.typeProviders = fieldExpressions ?? throw new ArgumentNullException(nameof(fieldExpressions));
        }

        public SqlStatementValueConverterProvider(IValueConverterFactory valueConverterFactory, IEnumerable<ParameterizedExpression?> outputParameters)
        {
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
            this.typeProviders = outputParameters ?? throw new ArgumentNullException(nameof(outputParameters));
        }

        public SqlStatementValueConverterProvider(IValueConverterFactory valueConverterFactory, SelectExpressionSet selectExpressionSet)
        {
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
            if (selectExpressionSet is null)
                throw new ArgumentNullException(nameof(selectExpressionSet));
            this.typeProviders = selectExpressionSet.Expressions.Cast<IExpressionTypeProvider>();
        }
        #endregion

        #region methods
        public IValueConverter? FindConverter(int fieldIndex, Type requestedType, object value)
        {
            IValueConverter? converter;

            //provider's declared type takes precedence over requested type (could be requesting an "int", when the declared type is "int?")
            var provider = typeProviders?.ElementAt(fieldIndex);
            if (provider is not null)
            {
                converter = valueConverterFactory.CreateConverter(provider.DeclaredType);
                if (converter is not null)
                    return converter;
            }

            if (value is DBNull && !requestedType.IsNullableType() && requestedType.IsConvertibleToNullableType())
            {
                converter = valueConverterFactory.CreateConverter(typeof(Nullable<>).MakeGenericType(requestedType));
                if (converter is not null)
                    return converter;
            }

            return valueConverterFactory.CreateConverter(requestedType);
        }
        #endregion
    }
}
