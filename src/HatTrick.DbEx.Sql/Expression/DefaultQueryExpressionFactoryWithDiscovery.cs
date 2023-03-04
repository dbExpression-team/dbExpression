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

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public sealed class DefaultQueryExpressionFactoryWithDiscovery : IQueryExpressionFactory
    {
        #region internals
        private readonly Func<Type, QueryExpression?> overrides;
        #endregion

        #region constructors
        public DefaultQueryExpressionFactoryWithDiscovery(Func<Type, QueryExpression?> overrides)
        {
            this.overrides = overrides ?? throw new ArgumentNullException(nameof(overrides));
        }
        #endregion

        #region methods
        public TQuery CreateQueryExpression<TQuery>()
            where TQuery : QueryExpression, new()
        {
            var expression = CreateQueryExpression(typeof(TQuery));
            if (expression is not null)
                return (expression as TQuery)!;

            return new TQuery();
        }

        public QueryExpression CreateQueryExpression(Type type)
        {
            if (TryResolveQueryExpression(type, out QueryExpression? queryExpression))
                return queryExpression!;

            return DbExpressionConfigurationException.ThrowServiceResolutionWithReturn<QueryExpression>(type);
        }

        private bool TryResolveQueryExpression(Type type, out QueryExpression? queryExpression)
        {
            queryExpression = default;
            try
            {
                queryExpression = ResolveQueryExpression(type, type);
            }
            catch
            {
                return false;
            }
            return queryExpression is not null;
        }

        private QueryExpression? ResolveQueryExpression(Type currentType, Type requestedType)
        {
            if (currentType is null)
                return null;

            var @override = overrides(currentType);
            if (@override is not null)
            {
                return @override;
            }

            if (currentType.BaseType is null)
                return null;

            return ResolveQueryExpression(currentType.BaseType, requestedType);
        }
        #endregion
    }
}
