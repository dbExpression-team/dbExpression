using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlQueryExpressionBuilderFactory
    {
        #region select one
        public IFromExpressionBuilder<TEntity, ITypeContinuationExpressionBuilder<TEntity>, ITypeContinuationBuilder<TEntity, ITypeContinuationExpressionBuilder<TEntity>>> CreateSelectOneExpressionBuilder<TEntity>(DatabaseConfiguration configuration)
            where TEntity : class, IDbEntity
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<TEntity, ITypeContinuationExpressionBuilder<TEntity>, ITypeContinuationBuilder<TEntity, ITypeContinuationExpressionBuilder<TEntity>>>(configuration);
            builder.Expression.Select.Top(1);
            return builder;
        }

        public IFromExpressionBuilder<TEnum, IValueContinuationExpressionBuilder<TEnum>, IValueContinuationExpressionBuilder<TEnum, IValueContinuationExpressionBuilder<TEnum>>> CreateSelectOneExpressionBuilder<TEnum>(DatabaseConfiguration configuration, IEnumExpressionMediator<TEnum> field)
            where TEnum : struct, Enum, IComparable
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<TEnum, IValueContinuationExpressionBuilder<TEnum>, IValueContinuationExpressionBuilder<TEnum, IValueContinuationExpressionBuilder<TEnum>>>(configuration);
            builder.Expression.Select.Top(1);
            builder.Expression.Select.Expressions.Add(new SelectExpression(new EnumExpressionMediator<TEnum>(field)));
            return builder;
        }

        public IFromExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>> CreateSelectOneExpressionBuilder(DatabaseConfiguration configuration, SelectExpression field1, SelectExpression field2, params SelectExpression[] fields)
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>>(configuration);
            builder.Expression.Select.Top(1);
            builder.Expression.Select.Expressions.Add(field1);
            builder.Expression.Select.Expressions.Add(field2);
            foreach (var field in fields)
                builder.Expression.Select.Expressions.Add(field);
            return builder;
        }

        public IFromExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>, IValueContinuationExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>>> CreateSelectOneExpressionBuilder<TValue>(DatabaseConfiguration configuration, SelectExpression<TValue> field)
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>, IValueContinuationExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>>>(configuration);
            builder.Expression.Select.Top(1);
            builder.Expression.Select.Expressions.Add(field);
            return builder;
        }
        #endregion

        #region select many
        public IListFromExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>, ITypeListContinuationExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>>> CreateSelectManyExpressionBuilder<TEntity>(DatabaseConfiguration configuration)
            where TEntity : IDbEntity
        {
            return new MsSqlSelectQueryExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>, ITypeListContinuationExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>>>(configuration);
        }

        public IListFromExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>, IValueListContinuationExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>>> CreateSelectManyExpressionBuilder<TEnum>(DatabaseConfiguration configuration, IEnumExpressionMediator<TEnum> field)
            where TEnum : struct, Enum, IComparable
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>, IValueListContinuationExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>>>(configuration);
            builder.Expression.Select.Expressions.Add(new SelectExpression(new EnumExpressionMediator<TEnum>(field)));
            return builder;
        }
        public IListFromExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>> CreateSelectManyExpressionBuilder(DatabaseConfiguration configuration, SelectExpression field1, SelectExpression field2, params SelectExpression[] fields)
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>>(configuration);
            builder.Expression.Select.Expressions.Add(field1);
            builder.Expression.Select.Expressions.Add(field2);
            foreach (var field in fields)
                builder.Expression.Select.Expressions.Add(field);
            return builder;
        }

        public IListFromExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>, IValueListContinuationExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>>> CreateSelectManyExpressionBuilder<TValue>(DatabaseConfiguration configuration, SelectExpression<TValue> field)
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>, IValueListContinuationExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>>>(configuration);
            builder.Expression.Select.Expressions.Add(field);
            return builder;
        }
        #endregion

        public IUpdateFromExpressionBuilder CreateUpdateExpressionBuilder(DatabaseConfiguration configuration, params AssignmentExpression[] fields)
        {
            var builder = new MsSqlUpdateQueryExpressionBuilder(configuration);
            foreach (var field in fields)
                builder.Expression.Assign.Expressions.Add(field);
            return builder;
        }

        public IDeleteFromExpressionBuilder CreateDeleteExpressionBulder(DatabaseConfiguration configuration)
        {
            return new MsSqlDeleteQueryExpressionBuilder(configuration);
        }

        public IInsertExpressionBuilder<T> CreateInsertExpressionBuilder<T>(DatabaseConfiguration configuration, T instance)
            where T : class, IDbEntity
        {
            return new MsSqlInsertQueryExpressionBuilder<T>(configuration, new List<T> { instance });
        }

        public IInsertExpressionBuilder<T> CreateInsertExpressionBuilder<T>(DatabaseConfiguration configuration, IList<T> instances)
            where T : class, IDbEntity
        {
            return new MsSqlInsertQueryExpressionBuilder<T>(configuration, instances);
        }
    }
}
