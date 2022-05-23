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
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using HatTrick.DbEx.MsSql.Configuration;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlQueryExpressionBuilder
    {
        #region select one
        public virtual SelectEntity<TDatabase, TEntity> CreateSelectEntityBuilder<TDatabase, TEntity>(MsSqlSqlDatabaseRuntimeConfiguration configuration)
            where TDatabase : class, ISqlDatabaseRuntime
            where TEntity : class, IDbEntity, new()
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne<TEntity>();

        public virtual SelectDynamic<TDatabase> CreateSelectDynamicBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement element1, AnyElement element2, params AnyElement[] elements)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element1, element2, elements);

        public virtual SelectDynamic<TDatabase> CreateSelectDynamicBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, IEnumerable<AnyElement> elements)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(elements);

        public virtual SelectValue<TDatabase, TEnum> CreateSelectValueBuilder<TDatabase, TEnum>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<TEnum> element)
            where TDatabase : class, ISqlDatabaseRuntime
            where TEnum : struct, Enum, IComparable
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, TEnum?> CreateSelectValueBuilder<TDatabase, TEnum>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<TEnum?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            where TEnum : struct, Enum, IComparable
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, object> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, ObjectElement element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element)!;

        public virtual SelectValue<TDatabase, object?> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, NullableObjectElement element)
            where TDatabase : class, ISqlDatabaseRuntime
           => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectObject<TDatabase, T> CreateSelectValueBuilder<TDatabase, T>(MsSqlSqlDatabaseRuntimeConfiguration configuration, ObjectElement<T> element)
            where TDatabase : class, ISqlDatabaseRuntime
            where T : class
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectObject<TDatabase, T?> CreateSelectValueBuilder<TDatabase, T>(MsSqlSqlDatabaseRuntimeConfiguration configuration, NullableObjectElement<T> element)
            where TDatabase : class, ISqlDatabaseRuntime
            where T : class?
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, bool> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<bool> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, bool?> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<bool?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, byte> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<byte> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, byte?> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<byte?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, byte[]> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<byte[]> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, DateTime> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<DateTime> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, DateTime?> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<DateTime?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, DateTimeOffset> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<DateTimeOffset> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, DateTimeOffset?> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<DateTimeOffset?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, decimal> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<decimal> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, decimal?> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<decimal?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, double> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<double> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, double?> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<double?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, Guid> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<Guid> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, Guid?> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<Guid?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, short> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<short> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, short?> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<short?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, int> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<int> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, int?> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<int?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, long> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<long> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, long?> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<long?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, float> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<float> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, float?> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<float?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, string> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, StringElement element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, string?> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, NullableStringElement element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, string?> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, SelectExpression<string?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, TimeSpan> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<TimeSpan> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);

        public virtual SelectValue<TDatabase, TimeSpan?> CreateSelectValueBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<TimeSpan?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectOneInitiation<TDatabase>>(configuration).SelectOne(element);
        #endregion

        #region select many
        public virtual SelectEntities<TDatabase, TEntity> CreateSelectEntitiesBuilder<TDatabase, TEntity>(MsSqlSqlDatabaseRuntimeConfiguration configuration)
            where TDatabase : class, ISqlDatabaseRuntime
            where TEntity : class, IDbEntity, new()
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany<TEntity>();

        public virtual SelectDynamics<TDatabase> CreateSelectDynamicsBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement element1, AnyElement element2, params AnyElement[] elements)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element1, element2, elements);

        public virtual SelectDynamics<TDatabase> CreateSelectDynamicsBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, IEnumerable<AnyElement> elements)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(elements);

        public virtual SelectValues<TDatabase, TEnum> CreateSelectValuesBuilder<TDatabase, TEnum>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<TEnum> element)
            where TDatabase : class, ISqlDatabaseRuntime
            where TEnum : struct, Enum, IComparable
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, TEnum?> CreateSelectValuesBuilder<TDatabase, TEnum>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<TEnum?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            where TEnum : struct, Enum, IComparable
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, object> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, ObjectElement element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element)!;

        public virtual SelectValues<TDatabase, object?> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, NullableObjectElement element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectObjects<TDatabase, T> CreateSelectValuesBuilder<TDatabase, T>(MsSqlSqlDatabaseRuntimeConfiguration configuration, ObjectElement<T> element)
            where TDatabase : class, ISqlDatabaseRuntime
            where T : class
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectObjects<TDatabase, T?> CreateSelectValuesBuilder<TDatabase, T>(MsSqlSqlDatabaseRuntimeConfiguration configuration, NullableObjectElement<T> element)
            where TDatabase : class, ISqlDatabaseRuntime
            where T: class?
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, bool> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<bool> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, bool?> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<bool?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, byte> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<byte> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, byte?> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<byte?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, byte[]> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<byte[]> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, DateTime> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<DateTime> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, DateTime?> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<DateTime?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, DateTimeOffset> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<DateTimeOffset> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, DateTimeOffset?> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<DateTimeOffset?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, decimal> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<decimal> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, decimal?> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<decimal?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, double> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<double> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, double?> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<double?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, Guid> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<Guid> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, Guid?> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<Guid?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, short> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<short> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, short?> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<short?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, int> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<int> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, int?> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<int?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, long> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<long> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, long?> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<long?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, float> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<float> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, float?> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<float?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, string> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, StringElement element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, string?> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, NullableStringElement element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, string?> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, SelectExpression<string?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, TimeSpan> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<TimeSpan> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        public virtual SelectValues<TDatabase, TimeSpan?> CreateSelectValuesBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, AnyElement<TimeSpan?> element)
            where TDatabase : class, ISqlDatabaseRuntime
            => CreateSelectBuilder<TDatabase, SelectManyInitiation<TDatabase>>(configuration).SelectMany(element);

        private static TReturn CreateSelectBuilder<TDatabase, TReturn>(MsSqlSqlDatabaseRuntimeConfiguration configuration)
            where TDatabase : class, ISqlDatabaseRuntime
            where TReturn : class
            => (new SelectSetQueryExpressionBuilder<TDatabase>(
                    (configuration.QueryExpressionFactory ?? throw new DbExpressionConfigurationException("Could not resolve a query expression factory, please ensure a query expression factory has been properly registered.")).CreateQueryExpression<SelectSetQueryExpression>() ?? throw new DbExpressionException($"Expected query expression factory to return an expression for type {nameof(SelectSetQueryExpression)}"),
                    configuration
                ) as TReturn) ?? throw new DbExpressionException($"Expected query builder to implement interface {typeof(TReturn)}, but it does not.");
        #endregion

        #region update
        public virtual UpdateEntities<TDatabase> CreateUpdateExpressionBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, EntityFieldAssignment assignment, params EntityFieldAssignment[] assignments)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            var expression = (configuration.QueryExpressionFactory ?? throw new DbExpressionConfigurationException("Could not resolve a query expression factory, please ensure a query expression factory has been properly registered.")).CreateQueryExpression<UpdateQueryExpression>() ?? throw new DbExpressionException($"Expected query expression factory to return an expression for type {nameof(UpdateQueryExpression)}");
            expression.Assign = new AssignmentExpressionSet(
                new List<AssignmentExpression>(assignments.Length + 1)
                {
                    assignment as AssignmentExpression ?? throw new DbExpressionException($"Expected {nameof(assignment)} to be assignable to {typeof(AssignmentExpression)}.")
                }
                .Concat(assignments.Select(x => x as AssignmentExpression ?? throw new DbExpressionException($"Expected all {nameof(assignments)} to be assignable to {typeof(AssignmentExpression)}.")))
            );
            return new UpdateQueryExpressionBuilder<TDatabase>(expression, configuration);
        }

        public virtual UpdateEntities<TDatabase> CreateUpdateExpressionBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, IEnumerable<EntityFieldAssignment> assignments)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            var expression = (configuration.QueryExpressionFactory ?? throw new DbExpressionConfigurationException("Could not resolve a query expression factory, please ensure a query expression factory has been properly registered.")).CreateQueryExpression<UpdateQueryExpression>() ?? throw new DbExpressionException($"Expected query expression factory to return an expression for type {nameof(UpdateQueryExpression)}");
            expression.Assign = new AssignmentExpressionSet((assignments ?? throw new ArgumentNullException(nameof(assignments))).Select(x => x as AssignmentExpression ?? throw new DbExpressionException($"Expected all {nameof(assignments)} to be assignable to {typeof(AssignmentExpression)}.")));
            return new UpdateQueryExpressionBuilder<TDatabase>(expression, configuration);
        }
        #endregion

        #region delete
        public virtual DeleteEntities<TDatabase> CreateDeleteExpressionBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration)
            where TDatabase : class, ISqlDatabaseRuntime
            => new DeleteQueryExpressionBuilder<TDatabase>(
                (configuration.QueryExpressionFactory ?? throw new DbExpressionConfigurationException("Could not resolve a query expression factory, please ensure a query expression factory has been properly registered.")).CreateQueryExpression<DeleteQueryExpression>() ?? throw new DbExpressionException($"Expected query expression factory to return an expression for type {nameof(DeleteQueryExpression)}"),
                configuration
            );
        #endregion

        #region insert
        public virtual InsertEntity<TDatabase, TEntity> CreateInsertExpressionBuilder<TDatabase, TEntity>(MsSqlSqlDatabaseRuntimeConfiguration configuration, TEntity instance)
            where TDatabase : class, ISqlDatabaseRuntime
            where TEntity : class, IDbEntity
            => new MsSqlInsertQueryExpressionBuilder<TDatabase, TEntity>(
                (configuration.QueryExpressionFactory ?? throw new DbExpressionConfigurationException("Could not resolve a query expression factory, please ensure a query expression factory has been properly registered.")).CreateQueryExpression<InsertQueryExpression>() ?? throw new DbExpressionException($"Expected query expression factory to return an expression for type {nameof(InsertQueryExpression)}"),
                configuration, 
                new List<TEntity> { instance ?? throw new ArgumentNullException(nameof(instance)) }
            );

        public virtual InsertEntities<TDatabase, TEntity> CreateInsertExpressionBuilder<TDatabase, TEntity>(MsSqlSqlDatabaseRuntimeConfiguration configuration, TEntity entity, params TEntity[] entities)
            where TDatabase : class, ISqlDatabaseRuntime
            where TEntity : class, IDbEntity
            => new MsSqlInsertQueryExpressionBuilder<TDatabase, TEntity>(
                (configuration.QueryExpressionFactory ?? throw new DbExpressionConfigurationException("Could not resolve a query expression factory, please ensure a query expression factory has been properly registered.")).CreateQueryExpression<InsertQueryExpression>() ?? throw new DbExpressionException($"Expected query expression factory to return an expression for type {nameof(InsertQueryExpression)}"),
                configuration, 
                new List<TEntity>(entities.Length + 1) { entity }.Concat(entities)
            );

        public virtual InsertEntities<TDatabase, TEntity> CreateInsertExpressionBuilder<TDatabase, TEntity>(MsSqlSqlDatabaseRuntimeConfiguration configuration, IEnumerable<TEntity> instances)
            where TDatabase : class, ISqlDatabaseRuntime
            where TEntity : class, IDbEntity
            => new MsSqlInsertQueryExpressionBuilder<TDatabase, TEntity>(
                (configuration.QueryExpressionFactory ?? throw new DbExpressionConfigurationException("Could not resolve a query expression factory, please ensure a query expression factory has been properly registered.")).CreateQueryExpression<InsertQueryExpression>() ?? throw new DbExpressionException($"Expected query expression factory to return an expression for type {nameof(InsertQueryExpression)}"),
                configuration, 
                instances ?? throw new ArgumentNullException(nameof(instances))
            );
        #endregion

        #region stored procedure
        public virtual StoredProcedureContinuation<TDatabase> CreateStoredProcedureBuilder<TDatabase>(MsSqlSqlDatabaseRuntimeConfiguration configuration, StoredProcedureExpression entity)
            where TDatabase : class, ISqlDatabaseRuntime
            => new StoredProcedureQueryExpressionBuilder<TDatabase>(
                (configuration.QueryExpressionFactory ?? throw new DbExpressionConfigurationException("Could not resolve a query expression factory, please ensure a query expression factory has been properly registered.")).CreateQueryExpression<StoredProcedureQueryExpression>() ?? throw new DbExpressionException($"Expected query expression factory to return an expression for type {nameof(StoredProcedureQueryExpression)}"),
                configuration, 
                entity
            );
        #endregion
    }
}
