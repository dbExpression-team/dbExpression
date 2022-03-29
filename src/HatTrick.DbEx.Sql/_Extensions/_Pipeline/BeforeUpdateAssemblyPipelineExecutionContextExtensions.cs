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
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql
{
    public static class BeforeUpdateAssemblyPipelineExecutionContextExtensions
    {
        public static void SetFieldValue<T>(this BeforeUpdateAssemblyPipelineExecutionContext context, string fieldName, T value, bool overrideExistingAssignment = false)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentException($"{nameof(fieldName)} parameter is required.");

            if (!context.TrySetFieldValue(fieldName, value, overrideExistingAssignment))
                throw new DbExpressionException($"A field with name {fieldName} is not a field on entity {context.Expression.BaseEntity?.Name ?? "[UNKNOWN]"}.");
        }

        public static void SetFieldValue<T>(this BeforeUpdateAssemblyPipelineExecutionContext context, string fieldName, DBNull value, bool overrideExistingAssignment = false)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentException($"{nameof(fieldName)} parameter is required.");

            if (!context.TrySetFieldValue(fieldName, value, overrideExistingAssignment))
                throw new DbExpressionException($"A field with name {fieldName} is not a field on entity {context.Expression.BaseEntity?.Name ?? "[UNKNOWN]"}.");
        }

        public static void SetFieldValue<T>(this BeforeUpdateAssemblyPipelineExecutionContext context, EnumFieldExpression<T> fieldExpression, T value, bool overrideExistingAssignment = false)
            where T : struct, Enum, IComparable
        {
            if (fieldExpression is null)
                throw new ArgumentNullException(nameof(fieldExpression));

            if (!DoTrySetFieldValue(context, fieldExpression, value, overrideExistingAssignment))
                throw new DbExpressionException($"A field with name {(fieldExpression as IExpressionNameProvider).Name} is not a field on entity {context.Expression.BaseEntity?.Name ?? "[UNKNOWN]"}.");
        }

        public static void SetFieldValue<T>(this BeforeUpdateAssemblyPipelineExecutionContext context, NullableEnumFieldExpression<T> fieldExpression, T? value, bool overrideExistingAssignment = false)
           where T : struct, Enum, IComparable
        {
            if (fieldExpression is null)
                throw new ArgumentNullException(nameof(fieldExpression));

            if (!DoTrySetFieldValue(context, fieldExpression, value, overrideExistingAssignment))
                throw new DbExpressionException($"A field with name {(fieldExpression as IExpressionNameProvider).Name} is not a field on entity {context.Expression.BaseEntity?.Name ?? "[UNKNOWN]"}.");
        }

        public static void SetFieldValue<T>(this BeforeUpdateAssemblyPipelineExecutionContext context, NullableEnumFieldExpression<T> fieldExpression, DBNull value, bool overrideExistingAssignment = false)
            where T : struct, Enum, IComparable
        {
            if (fieldExpression is null)
                throw new ArgumentNullException(nameof(fieldExpression));

            if (!DoTrySetFieldValue(context, fieldExpression, value, overrideExistingAssignment))
                throw new DbExpressionException($"A field with name {(fieldExpression as IExpressionNameProvider).Name} is not a field on entity {context.Expression.BaseEntity?.Name ?? "[UNKNOWN]"}.");
        }

        public static void SetFieldValue<T>(this BeforeUpdateAssemblyPipelineExecutionContext context, FieldExpression<T> fieldExpression, T value, bool overrideExistingAssignment = false)
        {
            if (fieldExpression is null)
                throw new ArgumentNullException(nameof(fieldExpression));

            if (!DoTrySetFieldValue(context, fieldExpression, value, overrideExistingAssignment))
                throw new DbExpressionException($"A field with name {(fieldExpression as IExpressionNameProvider).Name} is not a field on entity {context.Expression.BaseEntity?.Name ?? "[UNKNOWN]"}.");
        }

        public static bool TrySetFieldValue<T>(this BeforeUpdateAssemblyPipelineExecutionContext context, string fieldName, T value, bool overrideExistingAssignment = false)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                return false;

            try
            {
                if (context.Expression is not UpdateQueryExpression insert)
                    return false;

                var entity = insert.BaseEntity as EntityExpression ?? throw new DbExpressionException($"Expected query expression base entity to be of type {typeof(EntityExpression)}");
                var field = (entity as Table).Fields?.SingleOrDefault(x => string.Compare(x.Name, fieldName, true) == 0);
                if (field is null)
                    return false;

                return DoTrySetFieldValue(context, field as FieldExpression ?? throw new DbExpressionException($"Expected field with name {fieldName} to be of type {typeof(FieldExpression)}"), value, overrideExistingAssignment);
            }
            catch
            {
                return false;
            }
        }

        public static bool TrySetFieldValue<T>(this BeforeUpdateAssemblyPipelineExecutionContext context, FieldExpression<T> fieldExpression, T value, bool overrideExistingAssignment = false)
        {
            return DoTrySetFieldValue(context, fieldExpression, value, overrideExistingAssignment);
        }

        public static bool TrySetFieldValue<T>(this BeforeUpdateAssemblyPipelineExecutionContext context, EnumFieldExpression<T> fieldExpression, T value, bool overrideExistingAssignment = false)
           where T : struct, Enum, IComparable
        {
            return DoTrySetFieldValue(context, fieldExpression, value, overrideExistingAssignment);
        }

        public static bool TrySetFieldValue<T>(this BeforeUpdateAssemblyPipelineExecutionContext context, NullableEnumFieldExpression<T> fieldExpression, T? value, bool overrideExistingAssignment = false)
            where T : struct, Enum, IComparable
        {
            return DoTrySetFieldValue(context, fieldExpression, value, overrideExistingAssignment);
        }

        public static bool TrySetFieldValue<T>(this BeforeUpdateAssemblyPipelineExecutionContext context, NullableEnumFieldExpression<T> fieldExpression, DBNull value, bool overrideExistingAssignment = false)
            where T : struct, Enum, IComparable
        {
            return DoTrySetFieldValue(context, fieldExpression, value, overrideExistingAssignment);
        }

        private static bool DoTrySetFieldValue<T>(BeforeUpdateAssemblyPipelineExecutionContext context, FieldExpression fieldExpression, T value, bool overwrite)
        {
            if (fieldExpression is null)
                return false;

            try
            {
                if (context.Expression is not UpdateQueryExpression update)
                    return false;

                var entity = update.BaseEntity ?? throw new InvalidOperationException($"Expected {nameof(update.BaseEntity)} to be of type {typeof(Table)}");
                if ((fieldExpression as Field).Table != update.BaseEntity)
                    return true;

                var field = entity.Fields.SingleOrDefault(x => (FieldExpression)x == fieldExpression);
                if (field is null)
                     throw new InvalidOperationException($"Expected {nameof(update.BaseEntity)} to have a field of type {typeof(FieldExpression)} with name {(fieldExpression as IExpressionNameProvider).Name}");

                var existing = update.Assign.Expressions.SingleOrDefault(x => ((x as IAssignmentExpressionProvider).Assignee as IExpressionNameProvider).Name == field.Name);
                if (existing is not null)
                {
                     if (!overwrite)
                        return true; //field assignment is already part of the UpdateQueryExpression

                   (existing as IAssignmentExpressionProvider).Assignment = new LiteralExpression<T>(value, fieldExpression);
                }
                else
                {
                    update.Assign &= new AssignmentExpression(fieldExpression, new LiteralExpression<T>(value, fieldExpression));
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
