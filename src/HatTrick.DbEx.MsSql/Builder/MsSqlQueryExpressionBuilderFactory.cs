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
        public IFromExpressionBuilder<TEntity, ITypeContinuationExpressionBuilder<TEntity>, ITypeContinuationBuilder<TEntity, ITypeContinuationExpressionBuilder<TEntity>>> CreateSelectOneExpressionBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration)
            where TEntity : class, IDbEntity
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<TEntity, ITypeContinuationExpressionBuilder<TEntity>, ITypeContinuationBuilder<TEntity, ITypeContinuationExpressionBuilder<TEntity>>>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>());
            builder.Expression.Select.Top(1);
            return builder;
        }

        public IFromExpressionBuilder<TEnum, IValueContinuationExpressionBuilder<TEnum>, IValueContinuationExpressionBuilder<TEnum, IValueContinuationExpressionBuilder<TEnum>>> CreateSelectOneExpressionBuilder<TEnum>(RuntimeSqlDatabaseConfiguration configuration, IEnumExpressionMediator<TEnum> field)
            where TEnum : struct, Enum, IComparable
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<TEnum, IValueContinuationExpressionBuilder<TEnum>, IValueContinuationExpressionBuilder<TEnum, IValueContinuationExpressionBuilder<TEnum>>>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>());
            builder.Expression.Select.Top(1);
            builder.Expression.Select.Expressions.Add(new SelectExpression<TEnum>(new EnumExpressionMediator<TEnum>(field)));
            return builder;
        }

        public IFromExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, ExpressionMediator field1, ExpressionMediator field2, params ExpressionMediator[] fields)
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>());
            builder.Expression.Select.Top(1);
            builder.Expression.Select.Expressions.Add(new SelectExpression(field1, (field1 as IExpressionTypeProvider).DeclaredType));
            builder.Expression.Select.Expressions.Add(new SelectExpression(field2, (field2 as IExpressionTypeProvider).DeclaredType));
            foreach (var field in fields)
                builder.Expression.Select.Expressions.Add(new SelectExpression(field, (field as IExpressionTypeProvider).DeclaredType));
            return builder;
        }

        public IFromExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>, IValueContinuationExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>>> CreateSelectOneExpressionBuilder<TValue>(RuntimeSqlDatabaseConfiguration configuration, ExpressionMediator field)
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>, IValueContinuationExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>>>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>());
            builder.Expression.Select.Top(1);
            builder.Expression.Select.Expressions.Add(new SelectExpression<TValue>(field));
            return builder;
        }
        #endregion

        #region select many
        public IListFromExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>, ITypeListContinuationExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>>> CreateSelectManyExpressionBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration)
            where TEntity : IDbEntity
        {
            return new MsSqlSelectQueryExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>, ITypeListContinuationExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>>>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>());
        }

        public IListFromExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>, IValueListContinuationExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>>> CreateSelectManyExpressionBuilder<TEnum>(RuntimeSqlDatabaseConfiguration configuration, IEnumExpressionMediator<TEnum> field)
            where TEnum : struct, Enum, IComparable
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>, IValueListContinuationExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>>>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>());
            builder.Expression.Select.Expressions.Add(new SelectExpression<TEnum>(new EnumExpressionMediator<TEnum>(field)));
            return builder;
        }
        public IListFromExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, ExpressionMediator field1, ExpressionMediator field2, params ExpressionMediator[] fields)
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>());
            builder.Expression.Select.Expressions.Add(new SelectExpression(field1, (field1 as IExpressionTypeProvider).DeclaredType));
            builder.Expression.Select.Expressions.Add(new SelectExpression(field2, (field2 as IExpressionTypeProvider).DeclaredType));
            foreach (var field in fields)
                builder.Expression.Select.Expressions.Add(new SelectExpression(field, (field as IExpressionTypeProvider).DeclaredType));
            return builder;
        }

        public IListFromExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>, IValueListContinuationExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>>> CreateSelectManyExpressionBuilder<TValue>(RuntimeSqlDatabaseConfiguration configuration, SelectExpression<TValue> field)
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>, IValueListContinuationExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>>>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>());
            builder.Expression.Select.Expressions.Add(field);
            return builder;
        }
        #endregion

        public IUpdateFromExpressionBuilder CreateUpdateExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, params AssignmentExpression[] fields)
        {
            var builder = new MsSqlUpdateQueryExpressionBuilder(configuration);
            foreach (var field in fields)
                builder.Expression.Assign.Expressions.Add(field);
            return builder;
        }

        public IUpdateFromExpressionBuilder<TEntity> CreateUpdateExpressionBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration, TEntity target, TEntity source)
            where TEntity : class, IDbEntity
        {
            return new MsSqlUpdateQueryExpressionBuilder<TEntity>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<UpdateQueryExpression>(), target, source);
        }

        public IDeleteFromExpressionBuilder CreateDeleteExpressionBulder(RuntimeSqlDatabaseConfiguration configuration)
        {
            return new MsSqlDeleteQueryExpressionBuilder(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<DeleteQueryExpression>());
        }

        public IInsertExpressionBuilder<T> CreateInsertExpressionBuilder<T>(RuntimeSqlDatabaseConfiguration configuration, T instance)
            where T : class, IDbEntity
        {
            return new MsSqlInsertQueryExpressionBuilder<T>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<InsertQueryExpression>(), new List<T> { instance });
        }

        public IInsertExpressionBuilder<T> CreateInsertExpressionBuilder<T>(RuntimeSqlDatabaseConfiguration configuration, IList<T> instances)
            where T : class, IDbEntity
        {
            return new MsSqlInsertQueryExpressionBuilder<T>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<InsertQueryExpression>(), instances);
        }
    }
}
