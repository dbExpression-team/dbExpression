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

﻿using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ExpressionElementAppenderFactory : IExpressionElementAppenderFactory
    {
        #region internals
        private static readonly SchemaExpressionAppender schemaAppender = new();
        private static readonly EntityExpressionAppender entityAppender = new();
        private static readonly FieldExpressionAppender fieldAppender = new();
        private static readonly AssignmentExpressionAppender assignmentAppender = new();
        private static readonly AssignmentExpressionSetAppender assignmentSetAppender = new();
        private static readonly SelectExpressionAppender selectAppender = new();
        private static readonly SelectExpressionSetAppender selectSetAppender = new();
        private static readonly FromExpressionAppender fromAppender = new();
        private static readonly FilterExpressionAppender filterAppender = new();
        private static readonly FilterExpressionSetAppender filterSetAppender = new();
        private static readonly JoinExpressionAppender joinAppender = new();
        private static readonly JoinExpressionSetAppender joinSetAppender = new();
        private static readonly GroupByExpressionAppender groupByAppender = new();
        private static readonly GroupByExpressionSetAppender groupBySetAppender = new();
        private static readonly HavingExpressionAppender havingClauseAppender = new();
        private static readonly OrderByExpressionAppender orderByAppender = new();
        private static readonly OrderByExpressionSetAppender orderBySetAppender = new();
        private static readonly ArithmeticExpressionAppender arithmeticAppender = new();
        private static readonly ExpressionMediatorAppender expressionMediatorAppender = new();
        private static readonly CastFunctionExpressionAppender castFunctionAppender = new();
        private static readonly CoalesceFunctionExpressionAppender coalesceFunctionAppender = new();
        private static readonly ConcatFunctionExpressionAppender concatFunctionAppender = new();
        private static readonly IsNullFunctionExpressionAppender isNullFunctionAppender = new();
        private static readonly AverageFunctionExpressionAppender averageFunctionAppender = new();
        private static readonly MinimumFunctionExpressionAppender minimumFunctionAppender = new();
        private static readonly MaximumFunctionExpressionAppender maximumFunctionAppender = new();
        private static readonly CountFunctionExpressionAppender countFunctionAppender = new();
        private static readonly SumFunctionExpressionAppender sumFunctionAppender = new();
        private static readonly StandardDeviationFunctionExpressionAppender standardDeviationFunctionAppender = new();
        private static readonly PopulationStandardDeviationFunctionExpressionAppender populationStandardDeviationFunctionAppender = new();
        private static readonly VarianceFunctionExpressionAppender varianceFunctionAppender = new();
        private static readonly PopulationVarianceFunctionExpressionAppender populationVarianceFunctionAppender = new();
        private static readonly CurrentTimestampFunctionExpressionAppender currentTimestampFunctionAppender = new();
        private static readonly FloorFunctionExpressionAppender floorFunctionAppender = new();
        private static readonly CeilingFunctionExpressionAppender ceilingFunctionAppender = new();
        private static readonly TrimFunctionExpressionAppender trimFunctionAppender = new();
        private static readonly LTrimFunctionExpressionAppender lTrimFunctionAppender = new();
        private static readonly RTrimFunctionExpressionAppender rTrimFunctionAppender = new();
        private static readonly LeftFunctionExpressionAppender leftFunctionAppender = new();
        private static readonly RightFunctionExpressionAppender rightFunctionAppender = new();
        private static readonly AbsFunctionExpressionAppender absFunctionAppender = new();
        private static readonly SubstringFunctionExpressionAppender substringFunctionAppender = new();
        private static readonly ReplaceFunctionExpressionAppender replaceFunctionAppender = new();
        private static readonly LiteralExpressionAppender literalAppender = new();
        private static readonly AliasExpressionAppender aliasAppender = new();
        private static readonly InExpressionAppender inAppender = new();
        private static readonly LikeExpressionAppender likeAppender = new();
        private static readonly DbTypeExpressionAppender dbTypeAppender = new();
        private static readonly StoredProcedureExpressionAppender storedProcedureAppender = new();
        private static readonly ParameterExpressionAppender parameterAppender = new();
        private static readonly UnionExpressionAppender unionAppender = new();
        private static readonly UnionAllExpressionAppender unionAllAppender = new();

        private readonly ConcurrentDictionary<Type, Func<IExpressionElementAppender>> elementAppenders = new();
        #endregion

        #region constructors
        public ExpressionElementAppenderFactory()
        {
            RegisterElementAppender(schemaAppender);
            RegisterElementAppender(entityAppender);
            RegisterElementAppender(fieldAppender);
            RegisterElementAppender(assignmentAppender);
            RegisterElementAppender(assignmentSetAppender);
            RegisterElementAppender(selectAppender);
            RegisterElementAppender(selectSetAppender);
            RegisterElementAppender(fromAppender);
            RegisterElementAppender(filterAppender); 
            RegisterElementAppender(filterSetAppender);
            RegisterElementAppender(joinAppender);
            RegisterElementAppender(joinSetAppender);
            RegisterElementAppender(groupByAppender);
            RegisterElementAppender(groupBySetAppender);
            RegisterElementAppender(havingClauseAppender);
            RegisterElementAppender(orderByAppender);
            RegisterElementAppender(orderBySetAppender);
            RegisterElementAppender(arithmeticAppender);
            RegisterElementAppender(expressionMediatorAppender);
            RegisterElementAppender(castFunctionAppender);
            RegisterElementAppender(coalesceFunctionAppender);
            RegisterElementAppender(concatFunctionAppender);
            RegisterElementAppender(isNullFunctionAppender);
            RegisterElementAppender(averageFunctionAppender);
            RegisterElementAppender(minimumFunctionAppender);
            RegisterElementAppender(maximumFunctionAppender);
            RegisterElementAppender(countFunctionAppender);
            RegisterElementAppender(sumFunctionAppender);
            RegisterElementAppender(standardDeviationFunctionAppender);
            RegisterElementAppender(populationStandardDeviationFunctionAppender);
            RegisterElementAppender(varianceFunctionAppender);
            RegisterElementAppender(populationVarianceFunctionAppender);
            RegisterElementAppender(currentTimestampFunctionAppender);
            RegisterElementAppender(floorFunctionAppender);
            RegisterElementAppender(ceilingFunctionAppender);
            RegisterElementAppender(trimFunctionAppender);
            RegisterElementAppender(lTrimFunctionAppender);
            RegisterElementAppender(rTrimFunctionAppender);
            RegisterElementAppender(leftFunctionAppender);
            RegisterElementAppender(rightFunctionAppender);
            RegisterElementAppender(absFunctionAppender);
            RegisterElementAppender(substringFunctionAppender);
            RegisterElementAppender(replaceFunctionAppender);
            RegisterElementAppender(literalAppender);
            RegisterElementAppender(aliasAppender);
            RegisterElementAppender(inAppender);
            RegisterElementAppender(likeAppender);
            RegisterElementAppender(dbTypeAppender);
            RegisterElementAppender(storedProcedureAppender);
            RegisterElementAppender(parameterAppender);
            RegisterElementAppender(unionAppender);
            RegisterElementAppender(unionAllAppender);
        }
        #endregion

        #region methods
        public virtual IExpressionElementAppender? CreateElementAppender(IExpressionElement element)
            => ResolveElementAppender(element.GetType());

        public virtual void RegisterElementAppender<T, U>()
            where T : IExpressionElement
            where U : class, IExpressionElementAppender<T>, new()
        {
            var appender = new U();
            RegisterElementAppender(() => appender);
        }

        public virtual void RegisterElementAppender<T>(IExpressionElementAppender<T> appender)
            where T : IExpressionElement
            => RegisterElementAppender(() => appender);

        public virtual void RegisterElementAppender<T>(Func<IExpressionElementAppender<T>> appenderFactory)
            where T : IExpressionElement
            => elementAppenders.AddOrUpdate(typeof(T), appenderFactory, (t, f) => appenderFactory);

        private IExpressionElementAppender? ResolveElementAppender(Type current)
        {
            var factory = ResolveElementAppenderFactory(current, current);
            return factory is not null ? factory() : null;
        }

        private Func<IExpressionElementAppender>? ResolveElementAppenderFactory(Type current, Type original)
        {
            if (elementAppenders.TryGetValue(current, out Func<IExpressionElementAppender>? factory))
                return factory;

            if (current.BaseType is null)
                return null;

            factory = ResolveElementAppenderFactory(current.BaseType, original);

            if (factory is not null && current == original)
                //reduce runtime recursion by "registering" the original with the found appender
                elementAppenders.TryAdd(original, factory);

            return factory;
        }
        #endregion
    }
}
