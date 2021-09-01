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

using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeInsertAssemblyPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        #region internals
        #endregion

        #region interace
        public ISqlParameterBuilder ParameterBuilder { get; private set; }
        #endregion

        #region constructors
        public BeforeInsertAssemblyPipelineExecutionContext(RuntimeSqlDatabaseConfiguration database, InsertQueryExpression expression, ISqlParameterBuilder parameterBuilder)
            : base(database, expression)
        {
            ParameterBuilder = parameterBuilder ?? throw new ArgumentNullException(nameof(parameterBuilder));
        }
        #endregion

        #region methods
        public void SetFieldValue<T>(string fieldName, T value)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentException($"{nameof(fieldName)} parameter is required.");
            if (!TrySetFieldValue(fieldName, value))
                throw new DbExpressionException($"A field with name {fieldName} is not a field on entity {(Expression.BaseEntity as IExpressionNameProvider).Name}.");
        }

        public void SetFieldValue<T>(FieldExpression<T> fieldExpression, T? value)
            where T : struct, IComparable
        {
            if (fieldExpression is null)
                throw new ArgumentNullException(nameof(fieldExpression));
            if (!TrySetFieldValue(fieldExpression, value))
                throw new DbExpressionException($"A field with name {(fieldExpression as IExpressionNameProvider).Name} is not a field on entity {(Expression.BaseEntity as IExpressionNameProvider).Name}.");
        }

        public void SetEnumFieldValue<T>(EnumFieldExpression<T> fieldExpression, T value)
            where T : struct, Enum, IComparable
        {
            if (fieldExpression is null)
                throw new ArgumentNullException(nameof(fieldExpression));
            if (!TrySetEnumFieldValue(fieldExpression, value))
                throw new DbExpressionException($"A field with name {(fieldExpression as IExpressionNameProvider).Name} is not a field on entity {(Expression.BaseEntity as IExpressionNameProvider).Name}.");
        }

        public void SetEnumFieldValue<T>(NullableEnumFieldExpression<T> fieldExpression, T? value)
           where T : struct, Enum, IComparable
        {
            if (fieldExpression is null)
                throw new ArgumentNullException(nameof(fieldExpression));
            if (!TrySetEnumFieldValue(fieldExpression, value))
                throw new DbExpressionException($"A field with name {(fieldExpression as IExpressionNameProvider).Name} is not a field on entity {(Expression.BaseEntity as IExpressionNameProvider).Name}.");
        }

        public void SetEnumFieldValue<T>(NullableEnumFieldExpression<T> fieldExpression, DBNull value)
           where T : struct, Enum, IComparable
        {
            if (fieldExpression is null)
                throw new ArgumentNullException(nameof(fieldExpression));
            if (!TrySetEnumFieldValue(fieldExpression, value))
                throw new DbExpressionException($"A field with name {(fieldExpression as IExpressionNameProvider).Name} is not a field on entity {(Expression.BaseEntity as IExpressionNameProvider).Name}.");
        }

        public void SetFieldValue<T>(FieldExpression<T> fieldExpression, T value)
        {
            if (fieldExpression is null)
                throw new ArgumentNullException(nameof(fieldExpression));
            if (!TrySetFieldValue(fieldExpression, value))
                throw new DbExpressionException($"A field with name {(fieldExpression as IExpressionNameProvider).Name} is not a field on entity {(Expression.BaseEntity as IExpressionNameProvider).Name}.");
        }

        public bool TrySetFieldValue<T>(string fieldName, T value)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                return false;
            try
            {
                var insert = Expression as InsertQueryExpression;
                var entity = insert.BaseEntity as IExpressionListProvider<FieldExpression>;
                var field = entity.Expressions.SingleOrDefault(x => string.Compare((x as IExpressionNameProvider).Name, fieldName, true) == 0);
                if (field is null)
                    return false;

                return TrySetFieldValue(insert, field, value);
            }
            catch
            {
                return false;
            }
        }

        public bool TrySetFieldValue<T>(string fieldName, T? value)
            where T : struct, IComparable
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                return false;
            try
            {
                var insert = Expression as InsertQueryExpression;
                var entity = insert.BaseEntity as IExpressionListProvider<FieldExpression>;
                var field = entity.Expressions.SingleOrDefault(x => string.Compare((x as IExpressionNameProvider).Name, fieldName, true) == 0);
                if (field is null)
                    return false;

                return TrySetFieldValue(insert, field, value);
            }
            catch
            {
                return false;
            }
        }

        public bool TrySetFieldValue<T>(FieldExpression<T> field, T value)
        {
            if (field is null)
                return false;
            try
            {
                var insert = Expression as InsertQueryExpression;
                var entity = insert.BaseEntity as IExpressionListProvider<FieldExpression>;

                if ((field as IExpressionProvider<EntityExpression>).Expression != (EntityExpression)insert.BaseEntity)
                    return true;

                var found = entity.Expressions.SingleOrDefault(x => string.Compare((x as IExpressionNameProvider).Name, (field as IExpressionNameProvider).Name, true) == 0);
                if (found is null)
                    return false;

                return TrySetFieldValue(insert, found, value);
            }
            catch
            {
                return false;
            }
        }

        public bool TrySetEnumFieldValue<T>(EnumFieldExpression<T> field, T value)
            where T : struct, Enum, IComparable
        {
            if (field is null)
                return false;
            try
            {
                var insert = Expression as InsertQueryExpression;
                var entity = insert.BaseEntity as IExpressionListProvider<FieldExpression>;

                if ((field as IExpressionProvider<EntityExpression>).Expression != (EntityExpression)insert.BaseEntity)
                    return true;

                var found = entity.Expressions.SingleOrDefault(x => string.Compare((x as IExpressionNameProvider).Name, (field as IExpressionNameProvider).Name, true) == 0);
                if (found is null)
                    return false;

                return TrySetFieldValue(insert, found, value);
            }
            catch
            {
                return false;
            }
        }

        public bool TrySetFieldValue<T>(FieldExpression<T> field, T? value)
            where T : struct, IComparable
        {
            if (field is null)
                return false;
            try
            {
                var insert = Expression as InsertQueryExpression;
                var entity = insert.BaseEntity as IExpressionListProvider<FieldExpression>;

                if ((field as IExpressionProvider<EntityExpression>).Expression != (EntityExpression)insert.BaseEntity)
                    return true;

                var found = entity.Expressions.SingleOrDefault(x => string.Compare((x as IExpressionNameProvider).Name, (field as IExpressionNameProvider).Name, true) == 0);
                if (found is null)
                    return false;

                return TrySetFieldValue(insert, found, value);
            }
            catch
            {
                return false;
            }
        }

        public bool TrySetEnumFieldValue<T>(NullableEnumFieldExpression<T> field, T? value)
            where T : struct, Enum, IComparable
        {
            if (field is null)
                return false;
            try
            {
                var insert = Expression as InsertQueryExpression;
                var entity = insert.BaseEntity as IExpressionListProvider<FieldExpression>;

                if ((field as IExpressionProvider<EntityExpression>).Expression != (EntityExpression)insert.BaseEntity)
                    return true;

                var found = entity.Expressions.SingleOrDefault(x => string.Compare((x as IExpressionNameProvider).Name, (field as IExpressionNameProvider).Name, true) == 0);
                if (found is null)
                    return false;

                return TrySetFieldValue(insert, found, value);
            }
            catch
            {
                return false;
            }
        }

        public bool TrySetEnumFieldValue<T>(NullableEnumFieldExpression<T> field, DBNull value)
            where T : struct, Enum, IComparable
        {
            if (field is null)
                return false;
            try
            {
                var insert = Expression as InsertQueryExpression;
                var entity = insert.BaseEntity as IExpressionListProvider<FieldExpression>;

                if ((field as IExpressionProvider<EntityExpression>).Expression != (EntityExpression)insert.BaseEntity)
                    return true;

                var found = entity.Expressions.SingleOrDefault(x => string.Compare((x as IExpressionNameProvider).Name, (field as IExpressionNameProvider).Name, true) == 0);
                if (found is null)
                    return false;

                return TrySetFieldValue(insert, found, value);
            }
            catch
            {
                return false;
            }
        }

        private bool TrySetFieldValue<T>(InsertQueryExpression insert, FieldExpression field, T value)
        {
            try
            {
                for (var i = 0; i < insert.Inserts.Count; i++)
                {
                    var provider = insert.Inserts[i] as IExpressionListProvider<InsertExpression>;
                    var existing = provider.Expressions.SingleOrDefault(x => (x as IAssignmentExpressionProvider).Assignee == field);
                    if (existing is null)
                    {
                        insert.Inserts[i] = new InsertExpressionSet(insert.Inserts[i].Entity, provider.Expressions.Concat(new[] { new InsertExpression<T>(value, field) }));
                    }
                    else
                    {
                        (existing as IAssignmentExpressionProvider).Assignment = new LiteralExpression<T>(value);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool TrySetFieldValue<T>(InsertQueryExpression insert, FieldExpression field, T? value)
            where T : struct, IComparable
        {
            try
            {
                for (var i = 0; i < insert.Inserts.Count; i++)
                {
                    var provider = insert.Inserts[i] as IExpressionListProvider<InsertExpression>;
                    var existing = provider.Expressions.SingleOrDefault(x => (x as IAssignmentExpressionProvider).Assignee == field);
                    if (existing is null)
                    {
                        if (value is null)
                            insert.Inserts[i] = new InsertExpressionSet(insert.Inserts[i].Entity, provider.Expressions.Concat(new[] { new InsertExpression<T>(DBNull.Value, field) }));
                        else
                            insert.Inserts[i] = new InsertExpressionSet(insert.Inserts[i].Entity, provider.Expressions.Concat(new[] { new InsertExpression<T>(value.Value, field) }));
                    }
                    else
                    {
                        if (value is null)
                            (existing as IAssignmentExpressionProvider).Assignment = new LiteralExpression<T>(DBNull.Value);
                        else
                            (existing as IAssignmentExpressionProvider).Assignment = new LiteralExpression<T>(value.Value);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
