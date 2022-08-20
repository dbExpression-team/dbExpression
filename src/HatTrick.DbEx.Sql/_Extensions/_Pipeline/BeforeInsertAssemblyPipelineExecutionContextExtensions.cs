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
    public static class BeforeInsertAssemblyPipelineExecutionContextExtensions
    {
        public static void SetFieldValue<T>(this BeforeInsertAssemblyPipelineExecutionContext context, string fieldName, T value)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentException($"{nameof(fieldName)} is required.");

            if (!context.TrySetFieldValue(fieldName, value))
                throw new DbExpressionException($"Could not set field {fieldName} value on entity {context.Expression.Into?.Name ?? "[UNKNOWN]"}.");
        }

        public static void SetFieldValue<T>(this BeforeInsertAssemblyPipelineExecutionContext context, string fieldName, NullElement value)
        {
            if (!context.TrySetFieldValue(fieldName, value))
                throw new DbExpressionException($"Could not set field {fieldName} value on entity {context.Expression.Into?.Name ?? "[UNKNOWN]"}.");
        }

        public static void SetFieldValue<T>(this BeforeInsertAssemblyPipelineExecutionContext context, EnumFieldExpression<T> fieldExpression, T value)
            where T : struct, Enum, IComparable
        {
            if (fieldExpression is null)
                throw new ArgumentNullException(nameof(fieldExpression));

            if (!DoTrySetFieldValue(context, fieldExpression, value))
                throw new DbExpressionException($"Could not set field {fieldExpression} value on entity {context.Expression.Into?.Name ?? "[UNKNOWN]"}.");
        }

        public static void SetFieldValue<T>(this BeforeInsertAssemblyPipelineExecutionContext context, NullableEnumFieldExpression<T> fieldExpression, T? value)
           where T : struct, Enum, IComparable
        {
            if (fieldExpression is null)
                throw new ArgumentNullException(nameof(fieldExpression));

            if (!DoTrySetFieldValue(context, fieldExpression, value))
                throw new DbExpressionException($"Could not set field {fieldExpression} value on entity {context.Expression.Into?.Name ?? "[UNKNOWN]"}.");
        }

        public static void SetFieldValue<T>(this BeforeInsertAssemblyPipelineExecutionContext context, NullableEnumFieldExpression<T> fieldExpression, NullElement value)
            where T : struct, Enum, IComparable
        {
            if (fieldExpression is null)
                throw new ArgumentNullException(nameof(fieldExpression));

            if (!DoTrySetFieldValue(context, fieldExpression, value))
                throw new DbExpressionException($"Could not set field {fieldExpression} value on entity {context.Expression.Into?.Name ?? "[UNKNOWN]"}.");
        }

        public static void SetFieldValue<T>(this BeforeInsertAssemblyPipelineExecutionContext context, FieldExpression<T> fieldExpression, T value)
        {
            if (fieldExpression is null)
                throw new ArgumentNullException(nameof(fieldExpression));

            if (!DoTrySetFieldValue(context, fieldExpression, value))
                throw new DbExpressionException($"Could not set field {fieldExpression} value on entity {context.Expression.Into?.Name ?? "[UNKNOWN]"}.");
        }

        public static bool TrySetFieldValue<T>(this BeforeInsertAssemblyPipelineExecutionContext context, string fieldName, T value)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                return false;

            try
            {
                var field = context.Expression.Into!.Fields?.SingleOrDefault(x => string.Compare(x.Name, fieldName, true) == 0);
                if (field is null)
                    return false;

                return DoTrySetFieldValue(context, field as FieldExpression ?? throw new DbExpressionException($"Expected field with name {fieldName} to be of type {typeof(FieldExpression)}"), value);
            }
            catch
            {
                return false;
            }
        }

        public static bool TrySetFieldValue<T>(this BeforeInsertAssemblyPipelineExecutionContext context, FieldExpression<T> fieldExpression, T value)
        {
            return DoTrySetFieldValue(context, fieldExpression, value);
        }

        public static bool TrySetFieldValue<T>(this BeforeInsertAssemblyPipelineExecutionContext context, EnumFieldExpression<T> fieldExpression, T value)
             where T : struct, Enum, IComparable
        {
            return DoTrySetFieldValue(context, fieldExpression, value);
        }

        public static bool TrySetFieldValue<T>(this BeforeInsertAssemblyPipelineExecutionContext context, NullableEnumFieldExpression<T> fieldExpression, T? value)
            where T : struct, Enum, IComparable
        {
            return DoTrySetFieldValue(context, fieldExpression, value);
        }

        public static bool TrySetFieldValue<T>(this BeforeInsertAssemblyPipelineExecutionContext context, NullableEnumFieldExpression<T> fieldExpression, NullElement value)
            where T : struct, Enum, IComparable
        {
            return DoTrySetFieldValue(context, fieldExpression, value);
        }

        private static bool DoTrySetFieldValue<T>(BeforeInsertAssemblyPipelineExecutionContext context, FieldExpression fieldExpression, T value)
        {
            try
            {
                if (fieldExpression is null)
                    return false;

                var field = fieldExpression as Field;

                var found = context.Expression.Into!.Fields.SingleOrDefault(x => x.Identifier == field.Identifier);
                if (found is null)
                    return true;

                if ((field as Field).Table != context.Expression.Into)
                    return true;

                for (var i = 0; i < context.Expression.Inserts.Count; i++)
                {
                    var provider = context.Expression.Inserts[i] as IExpressionListProvider<InsertExpression>;
                    var existing = provider.Expressions.SingleOrDefault(x => (x as IAssignmentExpressionProvider).Assignee == fieldExpression);
                    if (existing is null)
                    {
                        context.Expression.Inserts[i] = new InsertExpressionSet(context.Expression.Inserts[i].Entity, provider.Expressions.Concat(new[] { new InsertExpression<T>(value, fieldExpression) }));
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
    }
}
