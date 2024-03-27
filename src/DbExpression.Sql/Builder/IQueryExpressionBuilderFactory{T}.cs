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

using System;
using System.Collections.Generic;

namespace DbExpression.Sql.Builder
{
    public interface IQueryExpressionBuilderFactory<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region select
        #region select one
        SelectEntity<TDatabase, TEntity> CreateSelectEntityBuilder<TEntity>(Table<TEntity> table)
            where TEntity : class, IDbEntity, new();

        SelectDynamic<TDatabase> CreateSelectDynamicBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements);

        SelectDynamic<TDatabase> CreateSelectDynamicBuilder(IEnumerable<AnyElement> elements);

        SelectValue<TDatabase, TEnum> CreateSelectValueBuilder<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable;

        SelectValue<TDatabase, TEnum?> CreateSelectValueBuilder<TEnum>(AnyElement<TEnum?> element)
            where TEnum : struct, Enum, IComparable;

        SelectValue<TDatabase, object?> CreateSelectValueBuilder(ObjectElement element);

        SelectValue<TDatabase, object?> CreateSelectValueBuilder(NullableObjectElement element);

        SelectObject<TDatabase, T> CreateSelectValueBuilder<T>(ObjectElement<T> element)
            where T : class?;

        SelectValue<TDatabase, T> CreateSelectValueBuilder<T>(AliasedElement<T> element);

        SelectValue<TDatabase, bool> CreateSelectValueBuilder(AnyElement<bool> element);

        SelectValue<TDatabase, bool?> CreateSelectValueBuilder(AnyElement<bool?> element);

        SelectValue<TDatabase, byte> CreateSelectValueBuilder(AnyElement<byte> element);

        SelectValue<TDatabase, byte?> CreateSelectValueBuilder(AnyElement<byte?> element);

        SelectValue<TDatabase, byte[]> CreateSelectValueBuilder(ByteArrayElement element);

        SelectValue<TDatabase, byte[]?> CreateSelectValueBuilder(NullableByteArrayElement element);

        SelectValue<TDatabase, DateTime> CreateSelectValueBuilder(AnyElement<DateTime> element);

        SelectValue<TDatabase, DateTime?> CreateSelectValueBuilder(AnyElement<DateTime?> element);

        SelectValue<TDatabase, DateTimeOffset> CreateSelectValueBuilder(AnyElement<DateTimeOffset> element);

        SelectValue<TDatabase, DateTimeOffset?> CreateSelectValueBuilder(AnyElement<DateTimeOffset?> element);

        SelectValue<TDatabase, decimal> CreateSelectValueBuilder(AnyElement<decimal> element);

        SelectValue<TDatabase, decimal?> CreateSelectValueBuilder(AnyElement<decimal?> element);

        SelectValue<TDatabase, double> CreateSelectValueBuilder(AnyElement<double> element);

        SelectValue<TDatabase, double?> CreateSelectValueBuilder(AnyElement<double?> element);

        SelectValue<TDatabase, Guid> CreateSelectValueBuilder(AnyElement<Guid> element);

        SelectValue<TDatabase, Guid?> CreateSelectValueBuilder(AnyElement<Guid?> element);

        SelectValue<TDatabase, short> CreateSelectValueBuilder(AnyElement<short> element);

        SelectValue<TDatabase, short?> CreateSelectValueBuilder(AnyElement<short?> element);

        SelectValue<TDatabase, int> CreateSelectValueBuilder(AnyElement<int> element);

        SelectValue<TDatabase, int?> CreateSelectValueBuilder(AnyElement<int?> element);

        SelectValue<TDatabase, long> CreateSelectValueBuilder(AnyElement<long> element);

        SelectValue<TDatabase, long?> CreateSelectValueBuilder(AnyElement<long?> element);

        SelectValue<TDatabase, float> CreateSelectValueBuilder(AnyElement<float> element);

        SelectValue<TDatabase, float?> CreateSelectValueBuilder(AnyElement<float?> element);

        SelectValue<TDatabase, string> CreateSelectValueBuilder(StringElement element);

        SelectValue<TDatabase, string?> CreateSelectValueBuilder(NullableStringElement element);

        SelectValue<TDatabase, TimeSpan> CreateSelectValueBuilder(AnyElement<TimeSpan> element);

        SelectValue<TDatabase, TimeSpan?> CreateSelectValueBuilder(AnyElement<TimeSpan?> element);
        #endregion

        #region select many
        SelectEntities<TDatabase, TEntity> CreateSelectEntitiesBuilder<TEntity>(Table<TEntity> table)
            where TEntity : class, IDbEntity, new();

        SelectDynamics<TDatabase> CreateSelectDynamicsBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements);

        SelectDynamics<TDatabase> CreateSelectDynamicsBuilder(IEnumerable<AnyElement> elements);

        SelectValues<TDatabase, TEnum> CreateSelectValuesBuilder<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable;

        SelectValues<TDatabase, TEnum?> CreateSelectValuesBuilder<TEnum>(AnyElement<TEnum?> element)
            where TEnum : struct, Enum, IComparable;

        SelectValues<TDatabase, object> CreateSelectValuesBuilder(ObjectElement element);

        SelectValues<TDatabase, object?> CreateSelectValuesBuilder(NullableObjectElement element);

        SelectObjects<TDatabase, T> CreateSelectValuesBuilder<T>(ObjectElement<T> element)
            where T : class?;

        SelectValues<TDatabase, T> CreateSelectValuesBuilder<T>(AliasedElement<T> element);

        SelectValues<TDatabase, bool> CreateSelectValuesBuilder(AnyElement<bool> element);

        SelectValues<TDatabase, bool?> CreateSelectValuesBuilder(AnyElement<bool?> element);

        SelectValues<TDatabase, byte> CreateSelectValuesBuilder(AnyElement<byte> element);

        SelectValues<TDatabase, byte?> CreateSelectValuesBuilder(AnyElement<byte?> element);

        SelectValues<TDatabase, byte[]> CreateSelectValuesBuilder(ByteArrayElement element);

        SelectValues<TDatabase, byte[]?> CreateSelectValuesBuilder(NullableByteArrayElement element);

        SelectValues<TDatabase, DateTime> CreateSelectValuesBuilder(AnyElement<DateTime> element);

        SelectValues<TDatabase, DateTime?> CreateSelectValuesBuilder(AnyElement<DateTime?> element);

        SelectValues<TDatabase, DateTimeOffset> CreateSelectValuesBuilder(AnyElement<DateTimeOffset> element);

        SelectValues<TDatabase, DateTimeOffset?> CreateSelectValuesBuilder(AnyElement<DateTimeOffset?> element);

        SelectValues<TDatabase, decimal> CreateSelectValuesBuilder(AnyElement<decimal> element);

        SelectValues<TDatabase, decimal?> CreateSelectValuesBuilder(AnyElement<decimal?> element);

        SelectValues<TDatabase, double> CreateSelectValuesBuilder(AnyElement<double> element);

        SelectValues<TDatabase, double?> CreateSelectValuesBuilder(AnyElement<double?> element);

        SelectValues<TDatabase, Guid> CreateSelectValuesBuilder(AnyElement<Guid> element);

        SelectValues<TDatabase, Guid?> CreateSelectValuesBuilder(AnyElement<Guid?> element);

        SelectValues<TDatabase, short> CreateSelectValuesBuilder(AnyElement<short> element);

        SelectValues<TDatabase, short?> CreateSelectValuesBuilder(AnyElement<short?> element);

        SelectValues<TDatabase, int> CreateSelectValuesBuilder(AnyElement<int> element);

        SelectValues<TDatabase, int?> CreateSelectValuesBuilder(AnyElement<int?> element);

        SelectValues<TDatabase, long> CreateSelectValuesBuilder(AnyElement<long> element);

        SelectValues<TDatabase, long?> CreateSelectValuesBuilder(AnyElement<long?> element);

        SelectValues<TDatabase, float> CreateSelectValuesBuilder(AnyElement<float> element);

        SelectValues<TDatabase, float?> CreateSelectValuesBuilder(AnyElement<float?> element);

        SelectValues<TDatabase, string> CreateSelectValuesBuilder(StringElement element);

        SelectValues<TDatabase, string?> CreateSelectValuesBuilder(NullableStringElement element);

        SelectValues<TDatabase, TimeSpan> CreateSelectValuesBuilder(AnyElement<TimeSpan> element);

        SelectValues<TDatabase, TimeSpan?> CreateSelectValuesBuilder(AnyElement<TimeSpan?> element);
        #endregion
        #endregion

        #region insert
        InsertEntities<TDatabase, TEntity> CreateInsertQueryBuilder<TEntity>(TEntity entity, params TEntity[] entities)
            where TEntity : class, IDbEntity;

        InsertEntities<TDatabase, TEntity> CreateInsertQueryBuilder<TEntity>(IEnumerable<TEntity> instances)
            where TEntity : class, IDbEntity;

        InsertEntity<TDatabase, TEntity> CreateInsertQueryBuilder<TEntity>(TEntity instance)
            where TEntity : class, IDbEntity;
        #endregion

        #region update
        UpdateEntities<TDatabase> CreateUpdateQueryBuilder(IEnumerable<EntityFieldAssignment> assignments);

        UpdateEntities<TDatabase> CreateUpdateQueryBuilder(EntityFieldAssignment assignment, params EntityFieldAssignment[] assignments);
        #endregion

        #region delete
        DeleteEntities<TDatabase> CreateDeleteQueryBuilder();
        #endregion
    }
}
