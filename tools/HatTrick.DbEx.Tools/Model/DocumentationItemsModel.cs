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

﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Tools.Model
{
    public class DocumentationItemsModel
    {
        #region internals
        private readonly DatabasePairModel? database;
        private EntityPairModel? _entity;
        private readonly Dictionary<string, ColumnPairModel> columns = new();
        private ColumnPairModel? enumField;
        private ColumnPairModel? nullableEnumField;
        private ColumnPairModel? objectField;
        private ColumnPairModel? nullableObjectField;
        #endregion

        #region interface
        public EntityExpressionModel? AnyEntityExpression
        { 
            get
            {
                if (_entity is not null)
                    return _entity.EntityExpression;

                _entity = database?.Schemas.FirstOrDefault()?.Entities.FirstOrDefault();

                return _entity?.EntityExpression;
            }
        }

        #region bool
        public FieldExpressionModel? AnyFieldExpressionOfTypeBoolean
            => GetColumnPairOfType(nameof(Boolean), false)?.FieldExpression;

        public FieldExpressionModel? AnyFieldExpressionOfTypeNullableBoolean
            => GetColumnPairOfType(nameof(Boolean), true)?.FieldExpression;

        public ColumnModel? AnyColumnOfTypeBoolean
            => GetColumnPairOfType(nameof(Boolean), false)?.Column;

        public ColumnModel? AnyColumnOfTypeNullableBoolean
            => GetColumnPairOfType(nameof(Boolean), true)?.Column;
        #endregion

        #region byte
        public FieldExpressionModel? AnyFieldExpressionOfByte
            => GetColumnPairOfType(nameof(Byte), false)?.FieldExpression;

        public FieldExpressionModel? AnyFieldExpressionOfTypeNullableByte
            => GetColumnPairOfType(nameof(Byte), true)?.FieldExpression;

        public ColumnModel? AnyColumnOfTypeByte
            => GetColumnPairOfType(nameof(Byte), false)?.Column;

        public ColumnModel? AnyColumnOfTypeNullableByte
            => GetColumnPairOfType(nameof(Byte), true)?.Column;
        #endregion

        #region byte[]
        public FieldExpressionModel? AnyFieldExpressionOfByteArray
            => GetColumnPairOfType("ByteArray", false)?.FieldExpression;

        public FieldExpressionModel? AnyFieldExpressionOfTypeNullableByteArray
            => GetColumnPairOfType("ByteArray", true)?.FieldExpression;

        public ColumnModel? AnyColumnOfTypeByteArray
            => GetColumnPairOfType("ByteArray", false)?.Column;

        public ColumnModel? AnyColumnOfTypeNullableByteArray
            => GetColumnPairOfType("ByteArray", true)?.Column;
        #endregion

        #region DateTime
        public FieldExpressionModel? AnyFieldExpressionOfDateTime
            => GetColumnPairOfType(nameof(DateTime), false)?.FieldExpression;

        public FieldExpressionModel? AnyFieldExpressionOfTypeNullableDateTime
            => GetColumnPairOfType(nameof(DateTime), true)?.FieldExpression;

        public ColumnModel? AnyColumnOfTypeDateTime
            => GetColumnPairOfType(nameof(DateTime), false)?.Column;

        public ColumnModel? AnyColumnOfTypeNullableDateTime
            => GetColumnPairOfType(nameof(DateTime), true)?.Column;
        #endregion

        #region DateTimeOffset
        public FieldExpressionModel? AnyFieldExpressionOfDateTimeOffset
            => GetColumnPairOfType(nameof(DateTimeOffset), false)?.FieldExpression;

        public FieldExpressionModel? AnyFieldExpressionOfTypeNullableDateTimeOffset
            => GetColumnPairOfType(nameof(DateTimeOffset), true)?.FieldExpression;

        public ColumnModel? AnyColumnOfTypeDateTimeOffset
            => GetColumnPairOfType(nameof(DateTimeOffset), false)?.Column;

        public ColumnModel? AnyColumnOfTypeNullableDateTimeOffset
            => GetColumnPairOfType(nameof(DateTimeOffset), true)?.Column;
        #endregion

        #region Decimal
        public FieldExpressionModel? AnyFieldExpressionOfDecimal
            => GetColumnPairOfType(nameof(Decimal), false)?.FieldExpression;

        public FieldExpressionModel? AnyFieldExpressionOfTypeNullableDecimal
            => GetColumnPairOfType(nameof(Decimal), true)?.FieldExpression;

        public ColumnModel? AnyColumnOfTypeDecimal
            => GetColumnPairOfType(nameof(Decimal), false)?.Column;

        public ColumnModel? AnyColumnOfTypeNullableDecimal
            => GetColumnPairOfType(nameof(Decimal), true)?.Column;
        #endregion

        #region Double
        public FieldExpressionModel? AnyFieldExpressionOfDouble
            => GetColumnPairOfType(nameof(Double), false)?.FieldExpression;

        public FieldExpressionModel? AnyFieldExpressionOfTypeNullableDouble
            => GetColumnPairOfType(nameof(Double), true)?.FieldExpression;

        public ColumnModel? AnyColumnOfTypeDouble
            => GetColumnPairOfType(nameof(Double), false)?.Column;

        public ColumnModel? AnyColumnOfTypeNullableDouble
            => GetColumnPairOfType(nameof(Double), true)?.Column;
        #endregion

        #region Guid
        public FieldExpressionModel? AnyFieldExpressionOfGuid
            => GetColumnPairOfType(nameof(Guid), false)?.FieldExpression;

        public FieldExpressionModel? AnyFieldExpressionOfTypeNullableGuid
            => GetColumnPairOfType(nameof(Guid), true)?.FieldExpression;

        public ColumnModel? AnyColumnOfTypeGuid
            => GetColumnPairOfType(nameof(Guid), false)?.Column;

        public ColumnModel? AnyColumnOfTypeNullableGuid
            => GetColumnPairOfType(nameof(Guid), true)?.Column;
        #endregion

        #region short
        public FieldExpressionModel? AnyFieldExpressionOfInt16
            => GetColumnPairOfType(nameof(Int16), false)?.FieldExpression;

        public FieldExpressionModel? AnyFieldExpressionOfTypeNullableInt16
            => GetColumnPairOfType(nameof(Int16), true)?.FieldExpression;

        public ColumnModel? AnyColumnOfTypeInt16
            => GetColumnPairOfType(nameof(Int16), false)?.Column;

        public ColumnModel? AnyColumnOfTypeNullableInt16
            => GetColumnPairOfType(nameof(Int16), true)?.Column;
        #endregion

        #region int
        public FieldExpressionModel? AnyFieldExpressionOfTypeInt32
            => GetColumnPairOfType(nameof(Int32), false)?.FieldExpression;

        public FieldExpressionModel? AnyFieldExpressionOfTypeNullableInt32
            => GetColumnPairOfType(nameof(Int32), true)?.FieldExpression;

        public ColumnModel? AnyColumnOfTypeInt32
            => GetColumnPairOfType(nameof(Int32), false)?.Column;

        public ColumnModel? AnyColumnOfTypeNullableInt32
            => GetColumnPairOfType(nameof(Int32), true)?.Column;
        #endregion

        #region long
        public FieldExpressionModel? AnyFieldExpressionOfTypeInt64
            => GetColumnPairOfType(nameof(Int64), false)?.FieldExpression;

        public FieldExpressionModel? AnyFieldExpressionOfTypeNullableInt64
            => GetColumnPairOfType(nameof(Int64), true)?.FieldExpression;

        public ColumnModel? AnyColumnOfTypeInt64
            => GetColumnPairOfType(nameof(Int64), false)?.Column;

        public ColumnModel? AnyColumnOfTypeNullableInt64
            => GetColumnPairOfType(nameof(Int64), true)?.Column;
        #endregion

        #region float
        public FieldExpressionModel? AnyFieldExpressionOfTypeSingle
            => GetColumnPairOfType(nameof(Single), false)?.FieldExpression;

        public FieldExpressionModel? AnyFieldExpressionOfTypeNullableSingle
            => GetColumnPairOfType(nameof(Single), true)?.FieldExpression;

        public ColumnModel? AnyColumnOfTypeSingle
            => GetColumnPairOfType(nameof(Single), false)?.Column;

        public ColumnModel? AnyColumnOfTypeNullableSingle
            => GetColumnPairOfType(nameof(Single), true)?.Column;
        #endregion

        #region string
        public FieldExpressionModel? AnyFieldExpressionOfTypeString
            => GetColumnPairOfType(nameof(String), false)?.FieldExpression;

        public FieldExpressionModel? AnyFieldExpressionOfTypeNullableString
            => GetColumnPairOfType(nameof(String), true)?.FieldExpression;

        public ColumnModel? AnyColumnOfTypeString
            => GetColumnPairOfType(nameof(String), false)?.Column;

        public ColumnModel? AnyColumnOfTypeNullableString
            => GetColumnPairOfType(nameof(String), true)?.Column;
        #endregion

        #region string
        public FieldExpressionModel? AnyFieldExpressionOfTypeTimeSpan
            => GetColumnPairOfType(nameof(TimeSpan), false)?.FieldExpression;

        public FieldExpressionModel? AnyFieldExpressionOfTypeNullableTimeSpan
            => GetColumnPairOfType(nameof(TimeSpan), true)?.FieldExpression;

        public ColumnModel? AnyColumnOfTypeTimeSpan
            => GetColumnPairOfType(nameof(TimeSpan), false)?.Column;

        public ColumnModel? AnyColumnOfTypeNullableTimeSpan
            => GetColumnPairOfType(nameof(TimeSpan), true)?.Column;
        #endregion

        #region enum
        public ColumnModel? AnyEnumColumnExpression
        {
            get
            {
                if (enumField is not null)
                    return enumField.Column;

                if (database is not null)
                {
                    foreach (var schema in database.Schemas)
                        foreach (var entity in schema.Entities)
                        {
                            var field = entity.Columns.FirstOrDefault(x => x.FieldExpression.Type.IsEnum && !x.FieldExpression.Type.IsNullable);
                            if (field is not null)
                            {
                                enumField = field;
                                return enumField.Column;
                            }
                        }
                }

                return null;
            }
        }

        public ColumnModel? AnyNullableEnumColumnExpression
        {
            get
            {
                if (nullableEnumField is not null)
                    return nullableEnumField.Column;

                if (database is not null)
                {
                    foreach (var schema in database.Schemas)
                        foreach (var entity in schema.Entities)
                        {
                            var field = entity.Columns.FirstOrDefault(x => x.FieldExpression.Type.IsEnum && x.FieldExpression.Type.IsNullable);
                            if (field is not null)
                            {
                                nullableEnumField = field;
                                return nullableEnumField.Column;
                            }
                        }
                }
                return null;
            }
        }
        #endregion

        #region object
        public ColumnModel? AnyObjectColumnExpression
        {
            get
            {
                if (objectField is not null)
                    return objectField.Column;

                if (database is not null)
                {
                    foreach (var schema in database.Schemas)
                        foreach (var entity in schema.Entities)
                        {
                            var field = entity.Columns.FirstOrDefault(x => x.FieldExpression.Type.IsUserDefinedType && !x.FieldExpression.Type.IsEnum && !x.FieldExpression.Type.IsNullable);
                            if (field is not null)
                            {
                                objectField = field;
                                return objectField.Column;
                            }
                        }
                }

                return null;
            }
        }

        public ColumnModel? AnyNullableObjectColumnExpression
        {
            get
            {
                if (nullableObjectField is not null)
                    return nullableObjectField.Column;

                if (database is not null)
                {
                    foreach (var schema in database.Schemas)
                        foreach (var entity in schema.Entities)
                        {
                            var field = entity.Columns.FirstOrDefault(x => x.FieldExpression.Type.IsUserDefinedType && !x.FieldExpression.Type.IsEnum && x.FieldExpression.Type.IsNullable);
                            if (field is not null)
                            {
                                nullableObjectField = field;
                                return nullableObjectField.Column;
                            }
                        }
                }
                return null;
            }
        }
        #endregion
        #endregion

        #region constructors
        public DocumentationItemsModel(DatabasePairModel database)
        {
            this.database = database ?? throw new ArgumentNullException(nameof(database));
        }
        #endregion

        #region methods
        private ColumnPairModel? GetColumnPairOfType(string typeName, bool isNullable = false)
        {
            var key = isNullable ? $"{typeName}?" : typeName;

            if (columns.ContainsKey(key))
                return columns[key];


            if (database is not null)
            {
                foreach (var schema in database.Schemas)
                    foreach (var entity in schema.Entities)
                    {
                        var field = entity.Columns.FirstOrDefault(x => x.FieldExpression.Type.TypeName == typeName && x.FieldExpression.Type.IsNullable == isNullable);
                        if (field is not null)
                        {
                            columns.Add(key, field);
                            return field;
                        }
                    }
            }

            return null;

        }
        #endregion
    }
}
