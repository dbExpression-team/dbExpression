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
    public class BeforeUpdateAssemblyPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        #region internals
        #endregion

        #region interace
        public ISqlParameterBuilder ParameterBuilder { get; private set; }
        #endregion

        #region constructors
        public BeforeUpdateAssemblyPipelineExecutionContext(RuntimeSqlDatabaseConfiguration database, UpdateQueryExpression expression, ISqlParameterBuilder parameterBuilder)
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

        public void SetFieldValue<T>(string fieldName, T? value)
            where T : struct, IComparable
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
                var update = Expression as UpdateQueryExpression;
                var entity = update.BaseEntity as IExpressionListProvider<FieldExpression>;
                var field = entity.Expressions.SingleOrDefault(x => string.Compare((x as IExpressionNameProvider).Name, fieldName, true) == 0);
                if (field is null || field as FieldExpression<T> is null)
                    return false;
                var existing = update.Assign.Expressions.SingleOrDefault(x => (x as IAssignmentExpressionProvider).Assignee == field);
                if (existing is object)
                    return true; //value explicitly set
                update.Assign &= new AssignmentExpression(field, new LiteralExpression<T>(value, field));
                return true;
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
                var update = Expression as UpdateQueryExpression;
                var entity = update.BaseEntity as IExpressionListProvider<FieldExpression>;
                var field = entity.Expressions.SingleOrDefault(x => string.Compare((x as IExpressionNameProvider).Name, fieldName, true) == 0);
                if (field is null || field as FieldExpression<T> is null)
                    return false;
                var existing = update.Assign.Expressions.SingleOrDefault(x => (x as IAssignmentExpressionProvider).Assignee == field);
                if (existing is object)
                    return true; //value explicitly set
                if (value is null)
                    update.Assign &= new AssignmentExpression(field, new LiteralExpression<T?>(DBNull.Value, field));
                else
                    update.Assign &= new AssignmentExpression(field, new LiteralExpression<T?>(value, field));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool TrySetFieldValue<T>(FieldExpression<T> fieldExpression, T value)
        {
            if (fieldExpression is null)
                return false;
            try
            {
                var update = Expression as UpdateQueryExpression;
                var entity = update.BaseEntity as IExpressionListProvider<FieldExpression>;
                var field = entity.Expressions.SingleOrDefault(x => x == fieldExpression);
                if (field is null)
                    return false;
                var existing = update.Assign.Expressions.SingleOrDefault(x => (x as IAssignmentExpressionProvider).Assignee == field);
                if (existing is object)
                    return true; //value explicitly set
                update.Assign &= new AssignmentExpression(field, new LiteralExpression<T>(value, field));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool TrySetFieldValue<T>(FieldExpression<T> fieldExpression, T? value)
            where T : struct, IComparable
        {
            if (fieldExpression is null)
                return false;
            try
            {
                var entity = Expression.BaseEntity as IExpressionListProvider<FieldExpression>;
                var field = entity.Expressions.SingleOrDefault(x => x == fieldExpression);
                if (field is null)
                    return false;
                var update = Expression as UpdateQueryExpression;
                if (value is null)
                    update.Assign &= new AssignmentExpression(field, new LiteralExpression<T?>(DBNull.Value, field));
                else
                    update.Assign &= new AssignmentExpression(field, new LiteralExpression<T?>(value, field));
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
