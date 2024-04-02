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

using DbExpression.Sql.Converter;
using DbExpression.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DbExpression.Sql.Executor
{
    public class SqlStatementValueConverterProvider : IValueConverterProvider
    {
        #region internals
        private readonly IValueConverterFactory valueConverterFactory;
        private List<IExpressionTypeProvider?> typeProviders;
        private List<IValueConverter?> valueConverters;
        #endregion

        #region constructors
        public SqlStatementValueConverterProvider(IValueConverterFactory valueConverterFactory)
        {
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
            this.typeProviders = new();
            this.valueConverters = new();
        }

        public SqlStatementValueConverterProvider(IValueConverterFactory valueConverterFactory, IEnumerable<FieldExpression?> fieldExpressions)
        {
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
            this.typeProviders = fieldExpressions?.Cast<IExpressionTypeProvider?>()?.ToList() ?? throw new ArgumentNullException(nameof(fieldExpressions));
            this.valueConverters = new List<IValueConverter?>();
            this.valueConverters.AddRange(Enumerable.Repeat<IValueConverter?>(default, this.typeProviders.Count));
        }

        public SqlStatementValueConverterProvider(IValueConverterFactory valueConverterFactory, IEnumerable<ParameterizedExpression?> outputParameters)
        {
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
            this.typeProviders = outputParameters?.Cast<IExpressionTypeProvider?>()?.ToList() ?? throw new ArgumentNullException(nameof(outputParameters));
            this.valueConverters = new List<IValueConverter?>();
            this.valueConverters.AddRange(Enumerable.Repeat<IValueConverter?>(default, this.typeProviders.Count));
        }

        public SqlStatementValueConverterProvider(IValueConverterFactory valueConverterFactory, SelectExpressionSet selectExpressionSet)
        {
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
            if (selectExpressionSet is null)
                throw new ArgumentNullException(nameof(selectExpressionSet));
            this.typeProviders = selectExpressionSet.Expressions?.Cast<IExpressionTypeProvider?>()?.ToList()!;
            this.valueConverters = new List<IValueConverter?>();
            this.valueConverters.AddRange(Enumerable.Repeat<IValueConverter?>(default, this.typeProviders.Count));
        }
        #endregion

        #region methods
        public IValueConverter? FindConverter(int fieldIndex, Type requestedType, object value)
        {
            EnsureBuckets(fieldIndex + 1);

            IValueConverter? converter = valueConverters![fieldIndex];
            if (converter is not null)
                return converter;

            //provider's declared type takes precedence over requested type (could be requesting an "int", when the declared type is "int?")
            var provider = typeProviders[fieldIndex];
            if (provider is not null)
            {
                converter = valueConverterFactory.CreateConverter(provider.DeclaredType);
                if (converter is not null)
                {
                    valueConverters[fieldIndex] = converter;
                    return converter;
                }
            }

            if (value is DBNull && !requestedType.IsNullableType() && requestedType.IsConvertibleToNullableType())
            {
                converter = valueConverterFactory.CreateConverter(typeof(Nullable<>).MakeGenericType(requestedType));
                if (converter is not null)
                {
                    valueConverters[fieldIndex] = converter;
                    return converter;
                }
            }

            valueConverters[fieldIndex] = valueConverterFactory.CreateConverter(requestedType);
            return valueConverters[fieldIndex];
        }

        private void EnsureBuckets(int size)
        {
            for (var i = 0; i <= size; i++)
            {
                for (var j = valueConverters.Count; j < size; j++)
                    valueConverters.Add(null);

                for (var j = typeProviders.Count; j < size; j++)
                    typeProviders.Add(null);
            }
        }
        #endregion
    }
}
