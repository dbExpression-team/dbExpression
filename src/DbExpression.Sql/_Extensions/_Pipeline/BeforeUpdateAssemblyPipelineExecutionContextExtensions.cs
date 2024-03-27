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

using DbExpression.Sql.Expression;
using DbExpression.Sql.Pipeline;
using System;
using System.Linq;

namespace DbExpression.Sql
{
    public static class BeforeUpdateAssemblyPipelineExecutionContextExtensions
    {
        public static void SetFieldValue<T>(this BeforeUpdateStartPipelineEventContext context, string fieldName, T value, bool overrideExistingAssignment = false)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentException($"{nameof(fieldName)} parameter is required.");

            var entity = context.Expression.From ?? DbExpressionPipelineEventException.ThrowNullValueUnexpectedWithReturn<Table>(context.Expression);
            var field = entity.Fields?.SingleOrDefault(x => string.Compare(x.Name, fieldName, true) == 0);
            if (field is null)
                DbExpressionPipelineEventException.ThrowUpdatePipelineEventNoFieldFound(context.Expression, fieldName, context.Expression.From!.Name);

            var (success, exception) = DoSetFieldValue(context, field.AsFieldExpression()!, value, overrideExistingAssignment);
            if (!success)
            {
                if (exception is not null)
                    throw exception;
                DbExpressionPipelineEventException.ThrowUpdatePipelineEventSetValueFailed<T>(context.Expression, fieldName, context.Expression.From!.Name, value);
            }
        }

        public static void SetFieldValue<T>(this BeforeUpdateStartPipelineEventContext context, string fieldName, NullElement value, bool overrideExistingAssignment = false)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentException($"{nameof(fieldName)} parameter is required.");

            var entity = context.Expression.From ?? DbExpressionPipelineEventException.ThrowNullValueUnexpectedWithReturn<Table>(context.Expression);
            var field = entity.Fields?.SingleOrDefault(x => string.Compare(x.Name, fieldName, true) == 0);
            if (field is null)
                DbExpressionPipelineEventException.ThrowUpdatePipelineEventNoFieldFound(context.Expression, fieldName, context.Expression.From?.Name ?? "[UNKNOWN]");

            var (success, exception) = DoSetFieldValue(context, field.AsFieldExpression()!, value, overrideExistingAssignment);
            if (!success)
            {
                if (exception is not null)
                    throw exception;
                DbExpressionPipelineEventException.ThrowUpdatePipelineEventSetValueFailed<NullElement>(context.Expression, fieldName, context.Expression.From!.Name, value);
            }
        }

        public static void SetFieldValue<T>(this BeforeUpdateStartPipelineEventContext context, EnumFieldExpression<T> fieldExpression, T value, bool overrideExistingAssignment = false)
            where T : struct, Enum, IComparable
        {
            if (fieldExpression is null)
                throw new ArgumentNullException(nameof(fieldExpression));

            var (success, exception) = DoSetFieldValue(context, fieldExpression, value, overrideExistingAssignment);
            if (!success)
            {
                if (exception is not null)
                    throw exception;
                DbExpressionPipelineEventException.ThrowUpdatePipelineEventSetValueFailed<T>(context.Expression, (fieldExpression as IExpressionNameProvider).Name, context.Expression.From!.Name, value);
            }
        }

        public static void SetFieldValue<T>(this BeforeUpdateStartPipelineEventContext context, NullableEnumFieldExpression<T> fieldExpression, T? value, bool overrideExistingAssignment = false)
           where T : struct, Enum, IComparable
        {
            if (fieldExpression is null)
                throw new ArgumentNullException(nameof(fieldExpression));

            var (success, exception) = DoSetFieldValue(context, fieldExpression, value, overrideExistingAssignment);
            if (!success)
            {
                if (exception is not null)
                    throw exception;
                DbExpressionPipelineEventException.ThrowUpdatePipelineEventSetValueFailed<T?>(context.Expression, (fieldExpression as IExpressionNameProvider).Name, context.Expression.From!.Name, value);
            }
        }

        public static void SetFieldValue<T>(this BeforeUpdateStartPipelineEventContext context, NullableEnumFieldExpression<T> fieldExpression, NullElement value, bool overrideExistingAssignment = false)
            where T : struct, Enum, IComparable
        {
            if (fieldExpression is null)
                throw new ArgumentNullException(nameof(fieldExpression));

            var (success, exception) = DoSetFieldValue(context, fieldExpression, value, overrideExistingAssignment);
            if (!success)
            {
                if (exception is not null)
                    throw exception;
                DbExpressionPipelineEventException.ThrowUpdatePipelineEventSetValueFailed<NullElement>(context.Expression, (fieldExpression as IExpressionNameProvider).Name, context.Expression.From!.Name, value);
            }
        }

        public static void SetFieldValue<T>(this BeforeUpdateStartPipelineEventContext context, FieldExpression<T> fieldExpression, T value, bool overrideExistingAssignment = false)
        {
            if (fieldExpression is null)
                throw new ArgumentNullException(nameof(fieldExpression));

            var (success, exception) = DoSetFieldValue(context, fieldExpression, value, overrideExistingAssignment);
            if (!success)
            {
                if (exception is not null)
                    throw exception;
                DbExpressionPipelineEventException.ThrowUpdatePipelineEventSetValueFailed<T>(context.Expression, (fieldExpression as IExpressionNameProvider).Name, context.Expression.From!.Name, value);
            }
        }

        public static bool TrySetFieldValue<T>(this BeforeUpdateStartPipelineEventContext context, string fieldName, T value, bool overrideExistingAssignment = false)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                return false;

            try
            {
                var entity = context.Expression.From ?? DbExpressionPipelineEventException.ThrowNullValueUnexpectedWithReturn<Table>(context.Expression);
                var field = entity.Fields?.SingleOrDefault(x => string.Compare(x.Name, fieldName, true) == 0);
                if (field is null)
                    return false;

                return DoSetFieldValue(
                    context, 
                    field as FieldExpression ?? DbExpressionPipelineEventException.ThrowNullValueUnexpectedWithReturn<FieldExpression>(context.Expression), 
                    value, 
                    overrideExistingAssignment
                ).Success;
            }
            catch
            {
                return false;
            }
        }

        public static bool TrySetFieldValue<T>(this BeforeUpdateStartPipelineEventContext context, FieldExpression<T> fieldExpression, T value, bool overrideExistingAssignment = false)
        {
            return DoSetFieldValue(context, fieldExpression, value, overrideExistingAssignment).Success;
        }

        public static bool TrySetFieldValue<T>(this BeforeUpdateStartPipelineEventContext context, EnumFieldExpression<T> fieldExpression, T value, bool overrideExistingAssignment = false)
           where T : struct, Enum, IComparable
        {
            return DoSetFieldValue(context, fieldExpression, value, overrideExistingAssignment).Success;
        }

        public static bool TrySetFieldValue<T>(this BeforeUpdateStartPipelineEventContext context, NullableEnumFieldExpression<T> fieldExpression, T? value, bool overrideExistingAssignment = false)
            where T : struct, Enum, IComparable
        {
            return DoSetFieldValue(context, fieldExpression, value, overrideExistingAssignment).Success;
        }

        public static bool TrySetFieldValue<T>(this BeforeUpdateStartPipelineEventContext context, NullableEnumFieldExpression<T> fieldExpression, NullElement value, bool overrideExistingAssignment = false)
            where T : struct, Enum, IComparable
        {
            return DoSetFieldValue(context, fieldExpression, value, overrideExistingAssignment).Success;
        }

        private static (bool Success, Exception? Exception) DoSetFieldValue<T>(BeforeUpdateStartPipelineEventContext context, FieldExpression fieldExpression, T value, bool overwrite)
        {
            if (fieldExpression is null)
                return (false, null);

            try
            {
                if (context.Expression is not UpdateQueryExpression update)
                    return (false, null);

                var entity = update.From ?? throw new InvalidOperationException(ExceptionMessages.NullValueUnexpected());
                if ((fieldExpression as Field).Table != update.From)
                    return (true, null);

                var field = entity.Fields.SingleOrDefault(x => (FieldExpression)x == fieldExpression);
                if (field is null)
                     return (false, new InvalidOperationException(ExceptionMessages.UpdatePipelineEventNoFieldFound((fieldExpression as IExpressionNameProvider).Name, update.From.Name)));

                var existing = update.Assign.Expressions.SingleOrDefault(x => ((x as IAssignmentExpressionProvider).Assignee as IExpressionNameProvider).Name == field.Name);
                if (existing is not null)
                {
                     if (!overwrite)
                        return (true, null); //field assignment is already part of the UpdateQueryExpression

                   (existing as IAssignmentExpressionProvider).Assignment = new LiteralExpression<T>(value, fieldExpression);
                }
                else
                {
                    update.Assign &= new AssignmentExpression(fieldExpression, new LiteralExpression<T>(value, fieldExpression));
                }

                return (true, null);
            }
            catch (Exception e)
            {
                return (false, e);
            }
        }
    }
}
