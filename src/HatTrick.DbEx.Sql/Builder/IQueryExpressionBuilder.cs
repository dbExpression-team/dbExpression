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

using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Builder
{
    public interface IQueryExpressionBuilder
    {
        #region select one
        SelectEntity<TEntity> CreateSelectEntityBuilder<TEntity>(Table<TEntity> table)
            where TEntity : class, IDbEntity, new();

        SelectDynamic CreateSelectDynamicBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements);

        SelectDynamic CreateSelectDynamicBuilder(IEnumerable<AnyElement> elements);

        SelectValue<TEnum> CreateSelectValueBuilder<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable;

        SelectValue<TEnum?> CreateSelectValueBuilder<TEnum>(AnyElement<TEnum?> element)
            where TEnum : struct, Enum, IComparable;

        SelectValue<object> CreateSelectValueBuilder(ObjectElement element);

        SelectValue<object?> CreateSelectValueBuilder(NullableObjectElement element);

        SelectObject<T> CreateSelectValueBuilder<T>(ObjectElement<T> element)
            where T : class?;

        SelectValue<T> CreateSelectValueBuilder<T>(AliasedElement<T> element);

        SelectValue<bool> CreateSelectValueBuilder(AnyElement<bool> element);

        SelectValue<bool?> CreateSelectValueBuilder(AnyElement<bool?> element);

        SelectValue<byte> CreateSelectValueBuilder(AnyElement<byte> element);

        SelectValue<byte?> CreateSelectValueBuilder(AnyElement<byte?> element);

        SelectValue<byte[]> CreateSelectValueBuilder(AnyElement<byte[]> element);

        SelectValue<DateTime> CreateSelectValueBuilder(AnyElement<DateTime> element);
        SelectValue<DateTime?> CreateSelectValueBuilder(AnyElement<DateTime?> element);
        SelectValue<DateTimeOffset> CreateSelectValueBuilder(AnyElement<DateTimeOffset> element);

        SelectValue<DateTimeOffset?> CreateSelectValueBuilder(AnyElement<DateTimeOffset?> element);

        SelectValue<decimal> CreateSelectValueBuilder(AnyElement<decimal> element);

        SelectValue<decimal?> CreateSelectValueBuilder(AnyElement<decimal?> element);

        SelectValue<double> CreateSelectValueBuilder(AnyElement<double> element);

        SelectValue<double?> CreateSelectValueBuilder(AnyElement<double?> element);
        SelectValue<Guid> CreateSelectValueBuilder(AnyElement<Guid> element);

        SelectValue<Guid?> CreateSelectValueBuilder(AnyElement<Guid?> element);
        SelectValue<short> CreateSelectValueBuilder(AnyElement<short> element);

        SelectValue<short?> CreateSelectValueBuilder(AnyElement<short?> element);

        SelectValue<int> CreateSelectValueBuilder(AnyElement<int> element);
        SelectValue<int?> CreateSelectValueBuilder(AnyElement<int?> element);

        SelectValue<long> CreateSelectValueBuilder(AnyElement<long> element);

        SelectValue<long?> CreateSelectValueBuilder(AnyElement<long?> element);
        SelectValue<float> CreateSelectValueBuilder(AnyElement<float> element);
        SelectValue<float?> CreateSelectValueBuilder(AnyElement<float?> element);
        SelectValue<string> CreateSelectValueBuilder(StringElement element);
        SelectValue<string?> CreateSelectValueBuilder(NullableStringElement element);
        SelectValue<TimeSpan> CreateSelectValueBuilder(AnyElement<TimeSpan> element);
        SelectValue<TimeSpan?> CreateSelectValueBuilder(AnyElement<TimeSpan?> element);
        #endregion

        #region select many
        SelectEntities<TEntity> CreateSelectEntitiesBuilder<TEntity>(Table<TEntity> table)
            where TEntity : class, IDbEntity, new();
        SelectDynamics CreateSelectDynamicsBuilder(AnyElement element1, AnyElement element2, params AnyElement[] elements);
        SelectDynamics CreateSelectDynamicsBuilder(IEnumerable<AnyElement> elements);
        SelectValues<TEnum> CreateSelectValuesBuilder<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable;
        SelectValues<TEnum?> CreateSelectValuesBuilder<TEnum>(AnyElement<TEnum?> element)
            where TEnum : struct, Enum, IComparable;
        SelectValues<object> CreateSelectValuesBuilder(ObjectElement element);
        SelectValues<object?> CreateSelectValuesBuilder(NullableObjectElement element);
        SelectObjects<T> CreateSelectValuesBuilder<T>(ObjectElement<T> element)
            where T : class?;
        SelectValues<T> CreateSelectValuesBuilder<T>(AliasedElement<T> element);
        SelectValues<bool> CreateSelectValuesBuilder(AnyElement<bool> element);
        SelectValues<bool?> CreateSelectValuesBuilder(AnyElement<bool?> element);
        SelectValues<byte> CreateSelectValuesBuilder(AnyElement<byte> element);
        SelectValues<byte?> CreateSelectValuesBuilder(AnyElement<byte?> element);
        SelectValues<byte[]> CreateSelectValuesBuilder(AnyElement<byte[]> element);
        SelectValues<DateTime> CreateSelectValuesBuilder(AnyElement<DateTime> element);
        SelectValues<DateTime?> CreateSelectValuesBuilder(AnyElement<DateTime?> element);
        SelectValues<DateTimeOffset> CreateSelectValuesBuilder(AnyElement<DateTimeOffset> element);
        SelectValues<DateTimeOffset?> CreateSelectValuesBuilder(AnyElement<DateTimeOffset?> element);
        SelectValues<decimal> CreateSelectValuesBuilder(AnyElement<decimal> element);
        SelectValues<decimal?> CreateSelectValuesBuilder(AnyElement<decimal?> element);
        SelectValues<double> CreateSelectValuesBuilder(AnyElement<double> element);
        SelectValues<double?> CreateSelectValuesBuilder(AnyElement<double?> element);
        SelectValues<Guid> CreateSelectValuesBuilder(AnyElement<Guid> element);
        SelectValues<Guid?> CreateSelectValuesBuilder(AnyElement<Guid?> element);
        SelectValues<short> CreateSelectValuesBuilder(AnyElement<short> element);
        SelectValues<short?> CreateSelectValuesBuilder(AnyElement<short?> element);
        SelectValues<int> CreateSelectValuesBuilder(AnyElement<int> element);
        SelectValues<int?> CreateSelectValuesBuilder(AnyElement<int?> element);
        SelectValues<long> CreateSelectValuesBuilder(AnyElement<long> element);
        SelectValues<long?> CreateSelectValuesBuilder(AnyElement<long?> element);
        SelectValues<float> CreateSelectValuesBuilder(AnyElement<float> element);
        SelectValues<float?> CreateSelectValuesBuilder(AnyElement<float?> element);
        SelectValues<string> CreateSelectValuesBuilder(StringElement element);
        SelectValues<string?> CreateSelectValuesBuilder(NullableStringElement element);
        SelectValues<TimeSpan> CreateSelectValuesBuilder(AnyElement<TimeSpan> element);
        SelectValues<TimeSpan?> CreateSelectValuesBuilder(AnyElement<TimeSpan?> element);

        #endregion

        #region update
        UpdateEntities CreateUpdateExpressionBuilder(EntityFieldAssignment assignment, params EntityFieldAssignment[] assignments);

        UpdateEntities CreateUpdateExpressionBuilder(IEnumerable<EntityFieldAssignment> assignments);
        #endregion

        #region delete
        DeleteEntities CreateDeleteExpressionBuilder();
        #endregion

        #region insert
        InsertEntity<TEntity> CreateInsertExpressionBuilder<TEntity>(TEntity instance)
            where TEntity : class, IDbEntity;

        InsertEntities<TEntity> CreateInsertExpressionBuilder<TEntity>(TEntity entity, params TEntity[] entities)
            where TEntity : class, IDbEntity;

        InsertEntities<TEntity> CreateInsertExpressionBuilder<TEntity>(IEnumerable<TEntity> instances)
            where TEntity : class, IDbEntity;
        #endregion

        #region stored procedure
        StoredProcedureContinuation CreateStoredProcedureBuilder(StoredProcedureExpression entity);
        #endregion
    }
}
