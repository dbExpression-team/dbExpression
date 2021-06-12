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
        private static readonly SchemaExpressionAppender schemaAppender = new SchemaExpressionAppender();
        private static readonly EntityExpressionAppender entityAppender = new EntityExpressionAppender();
        private static readonly FieldExpressionAppender fieldAppender = new FieldExpressionAppender();
        private static readonly AssignmentExpressionAppender assignmentAppender = new AssignmentExpressionAppender();
        private static readonly AssignmentExpressionSetAppender assignmentSetAppender = new AssignmentExpressionSetAppender();
        private static readonly SelectExpressionAppender selectAppender = new SelectExpressionAppender();
        private static readonly SelectExpressionSetAppender selectSetAppender = new SelectExpressionSetAppender();
        private static readonly FilterExpressionAppender filterAppender = new FilterExpressionAppender();
        private static readonly FilterExpressionSetAppender filterSetAppender = new FilterExpressionSetAppender();
        private static readonly JoinExpressionAppender joinAppender = new JoinExpressionAppender();
        private static readonly JoinExpressionSetAppender joinSetAppender = new JoinExpressionSetAppender();
        private static readonly JoinOnExpressionSetAppender joinOnSetAppender = new JoinOnExpressionSetAppender();
        private static readonly JoinOnExpressionAppender joinOnClauseAppender = new JoinOnExpressionAppender();
        private static readonly GroupByExpressionAppender groupByAppender = new GroupByExpressionAppender();
        private static readonly GroupByExpressionSetAppender groupBySetAppender = new GroupByExpressionSetAppender();
        private static readonly HavingExpressionAppender havingClauseAppender = new HavingExpressionAppender();
        private static readonly OrderByExpressionAppender orderByAppender = new OrderByExpressionAppender();
        private static readonly OrderByExpressionSetAppender orderBySetAppender = new OrderByExpressionSetAppender();
        private static readonly ArithmeticExpressionAppender arithmeticAppender = new ArithmeticExpressionAppender();
        private static readonly ExpressionMediatorAppender expressionMediatorAppender = new ExpressionMediatorAppender();
        private static readonly CastFunctionExpressionAppender castFunctionAppender = new CastFunctionExpressionAppender();
        private static readonly CoalesceFunctionExpressionAppender coalesceFunctionAppender = new CoalesceFunctionExpressionAppender();
        private static readonly ConcatFunctionExpressionAppender concatFunctionAppender = new ConcatFunctionExpressionAppender();
        private static readonly IsNullFunctionExpressionAppender isNullFunctionAppender = new IsNullFunctionExpressionAppender();
        private static readonly AverageFunctionExpressionAppender averageFunctionAppender = new AverageFunctionExpressionAppender();
        private static readonly MinimumFunctionExpressionAppender minimumFunctionAppender = new MinimumFunctionExpressionAppender();
        private static readonly MaximumFunctionExpressionAppender maximumFunctionAppender = new MaximumFunctionExpressionAppender();
        private static readonly CountFunctionExpressionAppender countFunctionAppender = new CountFunctionExpressionAppender();
        private static readonly SumFunctionExpressionAppender sumFunctionAppender = new SumFunctionExpressionAppender();
        private static readonly StandardDeviationFunctionExpressionAppender standardDeviationFunctionAppender = new StandardDeviationFunctionExpressionAppender();
        private static readonly PopulationStandardDeviationFunctionExpressionAppender populationStandardDeviationFunctionAppender = new PopulationStandardDeviationFunctionExpressionAppender();
        private static readonly VarianceFunctionExpressionAppender varianceFunctionAppender = new VarianceFunctionExpressionAppender();
        private static readonly PopulationVarianceFunctionExpressionAppender populationVarianceFunctionAppender = new PopulationVarianceFunctionExpressionAppender();
        private static readonly CurrentTimestampFunctionExpressionAppender currentTimestampFunctionAppender = new CurrentTimestampFunctionExpressionAppender();
        private static readonly FloorFunctionExpressionAppender floorFunctionAppender = new FloorFunctionExpressionAppender();
        private static readonly CeilingFunctionExpressionAppender ceilingFunctionAppender = new CeilingFunctionExpressionAppender();
        private static readonly TrimFunctionExpressionAppender trimFunctionAppender = new TrimFunctionExpressionAppender();
        private static readonly LTrimFunctionExpressionAppender lTrimFunctionAppender = new LTrimFunctionExpressionAppender();
        private static readonly RTrimFunctionExpressionAppender rTrimFunctionAppender = new RTrimFunctionExpressionAppender();
        private static readonly LeftFunctionExpressionAppender leftFunctionAppender = new LeftFunctionExpressionAppender();
        private static readonly RightFunctionExpressionAppender rightFunctionAppender = new RightFunctionExpressionAppender();
        private static readonly AbsFunctionExpressionAppender absFunctionAppender = new AbsFunctionExpressionAppender();
        private static readonly LiteralExpressionAppender literalAppender = new LiteralExpressionAppender();
        private static readonly RawExpressionAppender rawAppender = new RawExpressionAppender();
        private static readonly AliasExpressionAppender aliasAppender = new AliasExpressionAppender();
        private static readonly InExpressionAppender inAppender = new InExpressionAppender();
        private static readonly LikeExpressionAppender likeAppender = new LikeExpressionAppender();
        private static readonly DbTypeExpressionAppender dbTypeAppender = new DbTypeExpressionAppender();
        private static readonly StoredProcedureExpressionAppender storedProcedureAppender = new StoredProcedureExpressionAppender();
        private static readonly ParameterExpressionAppender parameterAppender = new ParameterExpressionAppender();

        private readonly ConcurrentDictionary<Type, Func<IExpressionElementAppender>> elementAppenders = new ConcurrentDictionary<Type, Func<IExpressionElementAppender>>();
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
            RegisterElementAppender(filterAppender);
            RegisterElementAppender(filterSetAppender);
            RegisterElementAppender(joinAppender);
            RegisterElementAppender(joinSetAppender);
            RegisterElementAppender(joinOnSetAppender);
            RegisterElementAppender(joinOnClauseAppender);
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
            RegisterElementAppender(literalAppender);
            RegisterElementAppender(rawAppender);
            RegisterElementAppender(aliasAppender);
            RegisterElementAppender(inAppender);
            RegisterElementAppender(likeAppender);
            RegisterElementAppender(dbTypeAppender);
            RegisterElementAppender(storedProcedureAppender);
            RegisterElementAppender(parameterAppender);
        }
        #endregion

        #region methods
        public virtual IExpressionElementAppender CreateElementAppender(IExpressionElement element)
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

        private IExpressionElementAppender ResolveElementAppender(Type current)
        {
            var factory = ResolveElementAppenderFactory(current, current);
            return factory is object ? factory() : null;
        }

        private Func<IExpressionElementAppender> ResolveElementAppenderFactory(Type current, Type original)
        {
            if (elementAppenders.TryGetValue(current, out Func<IExpressionElementAppender> factory))
                return factory;

            if (current.BaseType is null)
                return null;

            factory = ResolveElementAppenderFactory(current.BaseType, original);

            if (factory is object && current == original)
                //reduce runtime recursion by "registering" the original with the found appender
                elementAppenders.TryAdd(original, factory);

            return factory;
        }
        #endregion
    }
}
