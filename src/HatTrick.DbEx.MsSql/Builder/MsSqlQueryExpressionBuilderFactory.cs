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

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlQueryExpressionBuilderFactory
    {
        #region select one
        public virtual SelectEntity<TEntity> CreateSelectEntityBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration)
            where TEntity : class, IDbEntity, new()
        {
            var expression = (configuration ?? throw new ArgumentNullException(nameof(configuration))).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Top = 1;
            return new SelectEntityQueryExpressionBuilder<TEntity>(configuration, expression);
        }

        public virtual SelectDynamic CreateSelectDynamicBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement field1, AnyElement field2, params AnyElement[] fields)
        {
            var expression = (configuration ?? throw new ArgumentNullException(nameof(configuration))).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            var expressions = new List<SelectExpression>(fields.Length + 2)
            {
                field1?.ToSelectExpression(configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(field1)),
                field2?.ToSelectExpression(configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(field2))
            };
            expressions.AddRange(fields.Select(field => field.ToSelectExpression(configuration.MetadataProvider)));
            expression.Top = 1;
            expression.Select = new SelectExpressionSet(expressions);
            return new SelectDynamicSelectQueryExpressionBuilder(configuration, expression);
        }

        public virtual SelectDynamic CreateSelectDynamicBuilder(RuntimeSqlDatabaseConfiguration configuration, IEnumerable<AnyElement> fields)
        {
            var expression = (configuration ?? throw new ArgumentNullException(nameof(configuration))).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Select = new SelectExpressionSet(fields.Select(field => field?.ToSelectExpression(configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(field))));
            return new SelectDynamicSelectQueryExpressionBuilder(configuration, expression);
        }

        public virtual SelectValue<TEnum> CreateSelectValueBuilder<TEnum>(RuntimeSqlDatabaseConfiguration configuration, AnyElement<TEnum> field)
            where TEnum : struct, Enum, IComparable
        {
            var expression = (configuration ?? throw new ArgumentNullException(nameof(configuration))).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Top = 1;
            expression.Select = new SelectExpressionSet(field?.ToSelectExpression(configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(field)));
            return new SelectValueSelectQueryExpressionBuilder<TEnum>(configuration, expression);
        }

        public virtual SelectValue<TEnum?> CreateSelectValueBuilder<TEnum>(RuntimeSqlDatabaseConfiguration configuration, AnyElement<TEnum?> field)
            where TEnum : struct, Enum, IComparable
        {
            var expression = (configuration ?? throw new ArgumentNullException(nameof(configuration))).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Top = 1;
            expression.Select = new SelectExpressionSet(field?.ToSelectExpression(configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(field)));
            return new SelectValueSelectQueryExpressionBuilder<TEnum?>(configuration, expression);
        }

        public virtual SelectValue<object> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, ObjectElement field)
            => CreateSelectValueBuilder(configuration, field);

        public virtual SelectValue<object?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableObjectElement field)
            => CreateSelectValueBuilder(configuration, field);

        public virtual SelectValue<T> CreateSelectValueBuilder<T>(RuntimeSqlDatabaseConfiguration configuration, ObjectElement<T> field)
            => CreateSelectValueBuilder<T>(configuration, field as AnyElement);

        public virtual SelectValue<T?> CreateSelectValueBuilder<T>(RuntimeSqlDatabaseConfiguration configuration, NullableObjectElement<T> field)
            => CreateSelectValueBuilder<T?>(configuration, field as AnyElement);

        public virtual SelectValue<bool> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<bool> field)
            => CreateSelectValueBuilder<bool>(configuration, field);

        public virtual SelectValue<bool?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<bool?> field)
            => CreateSelectValueBuilder<bool?>(configuration, field);

        public virtual SelectValue<byte> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<byte> field)
            => CreateSelectValueBuilder<byte>(configuration, field);

        public virtual SelectValue<byte?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<byte?> field)
            => CreateSelectValueBuilder<byte?>(configuration, field);

        public virtual SelectValue<byte[]> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<byte[]> field)
            => CreateSelectValueBuilder<byte[]>(configuration, field);

        public virtual SelectValue<DateTime> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<DateTime> field)
            => CreateSelectValueBuilder<DateTime>(configuration, field);

        public virtual SelectValue<DateTime?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<DateTime?> field)
            => CreateSelectValueBuilder<DateTime?>(configuration, field);

        public virtual SelectValue<DateTimeOffset> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<DateTimeOffset> field)
            => CreateSelectValueBuilder<DateTimeOffset>(configuration, field);

        public virtual SelectValue<DateTimeOffset?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<DateTimeOffset?> field)
            => CreateSelectValueBuilder<DateTimeOffset?>(configuration, field);

        public virtual SelectValue<decimal> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<decimal> field)
            => CreateSelectValueBuilder<decimal>(configuration, field);

        public virtual SelectValue<decimal?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<decimal?> field)
            => CreateSelectValueBuilder<decimal?>(configuration, field);

        public virtual SelectValue<double> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<double> field)
            => CreateSelectValueBuilder<double>(configuration, field);

        public virtual SelectValue<double?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<double?> field)
            => CreateSelectValueBuilder<double?>(configuration, field);

        public virtual SelectValue<Guid> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<Guid> field)
            => CreateSelectValueBuilder<Guid>(configuration, field);

        public virtual SelectValue<Guid?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<Guid?> field)
            => CreateSelectValueBuilder<Guid?>(configuration, field);

        public virtual SelectValue<short> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<short> field)
            => CreateSelectValueBuilder<short>(configuration, field);

        public virtual SelectValue<short?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<short?> field)
            => CreateSelectValueBuilder<short?>(configuration, field);

        public virtual SelectValue<int> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<int> field)
            => CreateSelectValueBuilder<int>(configuration, field);

        public virtual SelectValue<int?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<int?> field)
            => CreateSelectValueBuilder<int?>(configuration, field);

        public virtual SelectValue<long> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<long> field)
            => CreateSelectValueBuilder<long>(configuration, field);

        public virtual SelectValue<long?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<long?> field)
            => CreateSelectValueBuilder<long?>(configuration, field);

        public virtual SelectValue<float> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<float> field)
            => CreateSelectValueBuilder<float>(configuration, field);

        public virtual SelectValue<float?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<float?> field)
            => CreateSelectValueBuilder<float?>(configuration, field);

        public virtual SelectValue<string> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, StringElement field)
            => CreateSelectValueBuilder<string>(configuration, field);

        public virtual SelectValue<string?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableStringElement field)
           => CreateSelectValueBuilder<string?>(configuration, field);
        
        public virtual SelectValue<TimeSpan> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<TimeSpan> field)
            => CreateSelectValueBuilder<TimeSpan>(configuration, field);

        public virtual SelectValue<TimeSpan?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<TimeSpan?> field)
            => CreateSelectValueBuilder<TimeSpan?>(configuration, field);

        private static SelectValue<TValue> CreateSelectValueBuilder<TValue>(RuntimeSqlDatabaseConfiguration configuration, AnyElement field)
        {
            var expression = (configuration ?? throw new ArgumentNullException(nameof(configuration))).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Top = 1;
            expression.Select = new SelectExpressionSet(field?.ToSelectExpression(configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(field)));
            return new SelectValueSelectQueryExpressionBuilder<TValue>(configuration, expression);
        }
        #endregion

        #region select many
        public virtual SelectEntities<TEntity> CreateSelectEntitiesBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration)
            where TEntity : class, IDbEntity, new()
        {
            var expression = (configuration ?? throw new ArgumentNullException(nameof(configuration))).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            return new SelectEntitiesSelectQueryExpressionBuilder<TEntity>(configuration, expression);
        }

        public virtual SelectDynamics CreateSelectDynamicsBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement field1, AnyElement field2, params AnyElement[] fields)
        {
            var expression = (configuration ?? throw new ArgumentNullException(nameof(configuration))).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            var expressions = new List<SelectExpression>(fields.Length + 2)
            {
                field1?.ToSelectExpression(configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(field1)),
                field2?.ToSelectExpression(configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(field2))
            };
            expressions.AddRange(fields.Select(field => field.ToSelectExpression(configuration.MetadataProvider)));
            expression.Select = new SelectExpressionSet(expressions);
            return new SelectDynamicsSelectQueryExpressionBuilder(configuration, expression);
        }

        public virtual SelectDynamics CreateSelectDynamicsBuilder(RuntimeSqlDatabaseConfiguration configuration, IEnumerable<AnyElement> fields)
        {
            var expression = (configuration ?? throw new ArgumentNullException(nameof(configuration))).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Select = new SelectExpressionSet(fields.Select(field => field?.ToSelectExpression(configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(field))));
            return new SelectDynamicsSelectQueryExpressionBuilder(configuration, expression);
        }

        public virtual SelectValues<TEnum> CreateSelectValuesBuilder<TEnum>(RuntimeSqlDatabaseConfiguration configuration, AnyElement<TEnum> field)
            where TEnum : struct, Enum, IComparable
        {
            var expression = (configuration ?? throw new ArgumentNullException(nameof(configuration))).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Select = new SelectExpressionSet(field?.ToSelectExpression(configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(field)));
            return new SelectValuesSelectQueryExpressionBuilder<TEnum>(configuration, expression);
        }

        public virtual SelectValues<TEnum?> CreateSelectValuesBuilder<TEnum>(RuntimeSqlDatabaseConfiguration configuration, AnyElement<TEnum?> field)
            where TEnum : struct, Enum, IComparable
        {
            var expression = (configuration ?? throw new ArgumentNullException(nameof(configuration))).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Select = new SelectExpressionSet(field?.ToSelectExpression(configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(field)));
            return new SelectValuesSelectQueryExpressionBuilder<TEnum?>(configuration, expression);
        }

        public virtual SelectValues<object> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, ObjectElement field)
             => CreateSelectValuesBuilder(configuration, field);

        public virtual SelectValues<object?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableObjectElement field)
            => CreateSelectValuesBuilder(configuration, field);

        public virtual SelectValues<T> CreateSelectValuesBuilder<T>(RuntimeSqlDatabaseConfiguration configuration, ObjectElement<T> field)
            => CreateSelectValuesBuilder<T>(configuration, field as AnyElement);

        public virtual SelectValues<T?> CreateSelectValuesBuilder<T>(RuntimeSqlDatabaseConfiguration configuration, NullableObjectElement<T> field)
            => CreateSelectValuesBuilder<T?>(configuration, field as AnyElement);

        public virtual SelectValues<bool> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<bool> field)
            => CreateSelectValuesBuilder<bool>(configuration, field);

        public virtual SelectValues<bool?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<bool?> field)
            => CreateSelectValuesBuilder<bool?>(configuration, field);

        public virtual SelectValues<byte> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<byte> field)
            => CreateSelectValuesBuilder<byte>(configuration, field);

        public virtual SelectValues<byte?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<byte?> field)
            => CreateSelectValuesBuilder<byte?>(configuration, field);

        public virtual SelectValues<byte[]> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<byte[]> field)
            => CreateSelectValuesBuilder<byte[]>(configuration, field);

        public virtual SelectValues<DateTime> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<DateTime> field)
            => CreateSelectValuesBuilder<DateTime>(configuration, field);

        public virtual SelectValues<DateTime?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<DateTime?> field)
            => CreateSelectValuesBuilder<DateTime?>(configuration, field);

        public virtual SelectValues<DateTimeOffset> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<DateTimeOffset> field)
            => CreateSelectValuesBuilder<DateTimeOffset>(configuration, field);

        public virtual SelectValues<DateTimeOffset?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<DateTimeOffset?> field)
            => CreateSelectValuesBuilder<DateTimeOffset?>(configuration, field);

        public virtual SelectValues<decimal> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<decimal> field)
            => CreateSelectValuesBuilder<decimal>(configuration, field);

        public virtual SelectValues<decimal?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<decimal?> field)
            => CreateSelectValuesBuilder<decimal?>(configuration, field);

        public virtual SelectValues<double> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<double> field)
            => CreateSelectValuesBuilder<double>(configuration, field);

        public virtual SelectValues<double?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<double?> field)
            => CreateSelectValuesBuilder<double?>(configuration, field);

        public virtual SelectValues<Guid> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<Guid> field)
            => CreateSelectValuesBuilder<Guid>(configuration, field);

        public virtual SelectValues<Guid?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<Guid?> field)
            => CreateSelectValuesBuilder<Guid?>(configuration, field);

        public virtual SelectValues<short> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<short> field)
            => CreateSelectValuesBuilder<short>(configuration, field);

        public virtual SelectValues<short?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<short?> field)
            => CreateSelectValuesBuilder<short?>(configuration, field);

        public virtual SelectValues<int> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<int> field)
            => CreateSelectValuesBuilder<int>(configuration, field);

        public virtual SelectValues<int?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<int?> field)
            => CreateSelectValuesBuilder<int?>(configuration, field);

        public virtual SelectValues<long> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<long> field)
            => CreateSelectValuesBuilder<long>(configuration, field);

        public virtual SelectValues<long?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<long?> field)
            => CreateSelectValuesBuilder<long?>(configuration, field);

        public virtual SelectValues<float> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<float> field)
            => CreateSelectValuesBuilder<float>(configuration, field);

        public virtual SelectValues<float?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<float?> field)
            => CreateSelectValuesBuilder<float?>(configuration, field);

        public virtual SelectValues<string> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, StringElement field)
            => CreateSelectValuesBuilder<string>(configuration, field);

        public virtual SelectValues<string?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableStringElement field)
            => CreateSelectValuesBuilder<string?>(configuration, field);

        public virtual SelectValues<TimeSpan> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<TimeSpan> field)
            => CreateSelectValuesBuilder<TimeSpan>(configuration, field);

        public virtual SelectValues<TimeSpan?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, AnyElement<TimeSpan?> field)
            => CreateSelectValuesBuilder<TimeSpan?>(configuration, field);

        private static SelectValues<TValue> CreateSelectValuesBuilder<TValue>(RuntimeSqlDatabaseConfiguration configuration, AnyElement field)
        {
            var expression = (configuration ?? throw new ArgumentNullException(nameof(configuration))).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Select = new SelectExpressionSet(field?.ToSelectExpression(configuration.MetadataProvider) ?? throw new ArgumentNullException(nameof(field)));
            return new SelectValuesSelectQueryExpressionBuilder<TValue>(configuration, expression);
        }
        #endregion

        #region update
        public virtual UpdateEntities CreateUpdateExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, EntityFieldAssignment assignment, params EntityFieldAssignment[] assignments)
        {
            var expression = (configuration ?? throw new ArgumentNullException(nameof(configuration))).QueryExpressionFactory?.CreateQueryExpression<UpdateQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Assign = new AssignmentExpressionSet(
                new List<AssignmentExpression>(assignments.Length + 1)
                {
                    assignment as AssignmentExpression ?? throw new DbExpressionException($"Expected {nameof(assignment)} to be assignable to {typeof(AssignmentExpression)}.")
                }
                .Concat(assignments.Select(x => x as AssignmentExpression ?? throw new DbExpressionException($"Expected all {nameof(assignments)} to be assignable to {typeof(AssignmentExpression)}.")))
            );
            return new UpdateQueryExpressionBuilder(configuration, expression);
        }

        public virtual UpdateEntities CreateUpdateExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, IEnumerable<EntityFieldAssignment> assignments)
        {
            var expression = (configuration ?? throw new ArgumentNullException(nameof(configuration))).QueryExpressionFactory?.CreateQueryExpression<UpdateQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Assign = new AssignmentExpressionSet((assignments ?? throw new ArgumentNullException(nameof(assignments))).Select(x => x as AssignmentExpression ?? throw new DbExpressionException($"Expected all {nameof(assignments)} to be assignable to {typeof(AssignmentExpression)}.")));
            return new UpdateQueryExpressionBuilder(configuration, expression);
        }
        #endregion

        #region delete
        public virtual DeleteEntities CreateDeleteExpressionBulder(RuntimeSqlDatabaseConfiguration configuration)
        {
            var expression = (configuration ?? throw new ArgumentNullException(nameof(configuration))).QueryExpressionFactory?.CreateQueryExpression<DeleteQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            return new DeleteQueryExpressionBuilder(configuration, expression);
        }
        #endregion

        #region insert
        public virtual InsertEntity<TEntity> CreateInsertExpressionBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration, TEntity instance)
            where TEntity : class, IDbEntity
            => new MsSqlInsertQueryExpressionBuilder<TEntity>(configuration, (configuration ?? throw new ArgumentNullException(nameof(configuration))).QueryExpressionFactory?.CreateQueryExpression<InsertQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression."), new List<TEntity> { instance ?? throw new ArgumentNullException(nameof(instance)) });

        public virtual InsertEntities<TEntity> CreateInsertExpressionBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration, TEntity entity, params TEntity[] entities)
            where TEntity : class, IDbEntity
            => new MsSqlInsertQueryExpressionBuilder<TEntity>(
                configuration, 
                (configuration ?? throw new ArgumentNullException(nameof(configuration))).QueryExpressionFactory?.CreateQueryExpression<InsertQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression."),
                new List<TEntity>(entities.Length + 1) { entity }.Concat(entities)
            );

        public virtual InsertEntities<TEntity> CreateInsertExpressionBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration, IEnumerable<TEntity> instances)
            where TEntity : class, IDbEntity
            => new MsSqlInsertQueryExpressionBuilder<TEntity>(configuration, (configuration ?? throw new ArgumentNullException(nameof(configuration))).QueryExpressionFactory?.CreateQueryExpression<InsertQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression."), instances ?? throw new ArgumentNullException(nameof(instances)));
        #endregion

        #region stored procedure
        public virtual StoredProcedureContinuation CreateStoredProcedureBuilder(RuntimeSqlDatabaseConfiguration configuration, StoredProcedureExpression entity)
        {
            var expression = (configuration ?? throw new ArgumentNullException(nameof(configuration))).QueryExpressionFactory?.CreateQueryExpression<StoredProcedureQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            return new StoredProcedureQueryExpressionBuilder(configuration, expression, entity);
        }
        #endregion
    }
}
