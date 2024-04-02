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

using DbExpression.Sql.Assembler;
using DbExpression.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace DbExpression.Sql.Configuration
{
    public class ExpressionElementAppenderConfigurationBuilder<TDatabase, TElement> : IExpressionElementAppenderConfigurationBuilder<TDatabase, TElement>
        where TDatabase : class, ISqlDatabaseRuntime
        where TElement : class, IExpressionElement
    {
        private readonly IExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase> caller;
        private readonly IServiceCollection services;

        public ExpressionElementAppenderConfigurationBuilder(
            IExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase> caller, 
            IServiceCollection services
        )
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }

        /// <inheritdoc />
        public IExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase> Use(IExpressionElementAppender<TElement> appender)
        {
            services.TryAddSingleton<IExpressionElementAppender<TElement>>(appender);
            return caller;
        }

        /// <inheritdoc />
        public IExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<IExpressionElementAppender<TElement>> factory)
        {
            services.TryAddSingleton<IExpressionElementAppender<TElement>>(sp => factory());
            return caller;
        }

        /// <inheritdoc />
        public IExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase> Use<TAppender>()
            where TAppender : class, IExpressionElementAppender<TElement>, new()
        {
            services.TryAddSingleton<IExpressionElementAppender<TElement>, TAppender>();
            return caller;
        }

        /// <inheritdoc />
        public IExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<IServiceProvider, IExpressionElementAppender<TElement>> appender)
        {
            services.TryAddSingleton<IExpressionElementAppender<TElement>>(sp => appender(sp));
            return caller;
        }
    }
}
