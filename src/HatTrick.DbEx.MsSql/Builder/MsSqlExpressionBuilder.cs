using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Dynamic;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlExpressionBuilderFactory
    {
        #region select one
        public IFromExpressionBuilder<TEntity, ITypeContinuationExpressionBuilder<TEntity>, ITypeContinuationBuilder<TEntity, ITypeContinuationExpressionBuilder<TEntity>>> CreateSelectOneExpressionBuilder<TEntity>(DatabaseConfiguration configuration)
            where TEntity : class, IDbEntity
        {
            return new MsSqlExpressionBuilder<TEntity, ITypeContinuationExpressionBuilder<TEntity>, ITypeContinuationBuilder<TEntity, ITypeContinuationExpressionBuilder<TEntity>>>(configuration, new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectOneType, Select = new SelectExpressionSet().Top(1) });
        }

        public IFromExpressionBuilder<TEnum, IValueContinuationExpressionBuilder<TEnum>, IValueContinuationExpressionBuilder<TEnum, IValueContinuationExpressionBuilder<TEnum>>> CreateSelectOneExpressionBuilder<TEnum>(DatabaseConfiguration configuration, IEnumExpressionMediator<TEnum> field)
            where TEnum : struct, Enum, IComparable
        {
            var builder = new MsSqlExpressionBuilder<TEnum, IValueContinuationExpressionBuilder<TEnum>, IValueContinuationExpressionBuilder<TEnum, IValueContinuationExpressionBuilder<TEnum>>>(configuration, new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectOneValue, Select = new SelectExpressionSet().Top(1) });
            builder.Expression.Select.Expressions.Add(new SelectExpression(new EnumExpressionMediator<TEnum>(field)));
            return builder;
        }

        public IFromExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>> CreateSelectOneExpressionBuilder(DatabaseConfiguration configuration, SelectExpression field1, SelectExpression field2, params SelectExpression[] fields)
        {
            var builder = new MsSqlExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>>(configuration, new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectOneDynamic, Select = new SelectExpressionSet().Top(1) });
            builder.Expression.Select.Expressions.Add(field1);
            builder.Expression.Select.Expressions.Add(field2);
            foreach (var field in fields)
                builder.Expression.Select.Expressions.Add(field);
            return builder;
        }

        public IFromExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>, IValueContinuationExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>>> CreateSelectOneExpressionBuilder<TValue>(DatabaseConfiguration configuration, SelectExpression<TValue> field)
        {
            var builder = new MsSqlExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>, IValueContinuationExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>>>(configuration, new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectOneValue, Select = new SelectExpressionSet().Top(1) });
            builder.Expression.Select.Expressions.Add(field);
            return builder;
        }
        #endregion

        #region select many
        public IListFromExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>, ITypeListContinuationExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>>> CreateSelectManyExpressionBuilder<TEntity>(DatabaseConfiguration configuration)
            where TEntity : IDbEntity
        {
            return new MsSqlExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>, ITypeListContinuationExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>>>(configuration, new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectManyType });
        }

        public IListFromExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>, IValueListContinuationExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>>> CreateSelectManyExpressionBuilder<TEnum>(DatabaseConfiguration configuration, IEnumExpressionMediator<TEnum> field)
            where TEnum : struct, Enum, IComparable
        {
            var builder = new MsSqlExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>, IValueListContinuationExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>>>(configuration, new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectManyValue });
            builder.Expression.Select.Expressions.Add(new SelectExpression(new EnumExpressionMediator<TEnum>(field)));
            return builder;
        }
        public IListFromExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>> CreateSelectManyExpressionBuilder(DatabaseConfiguration configuration, SelectExpression field1, SelectExpression field2, params SelectExpression[] fields)
        {
            var builder = new MsSqlExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>>(configuration, new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectManyDynamic });
            builder.Expression.Select.Expressions.Add(field1);
            builder.Expression.Select.Expressions.Add(field2);
            foreach (var field in fields)
                builder.Expression.Select.Expressions.Add(field);
            return builder;
        }

        public IListFromExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>, IValueListContinuationExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>>> CreateSelectManyExpressionBuilder<TValue>(DatabaseConfiguration configuration, SelectExpression<TValue> field)
        {
            var builder = new MsSqlExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>, IValueListContinuationExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>>>(configuration, new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectManyValue });
            builder.Expression.Select.Expressions.Add(field);
            return builder;
        }
        #endregion

        public IUpdateFromExpressionBuilder CreateUpdateExpressionBuilder(DatabaseConfiguration configuration, params AssignmentExpression[] fields)
        {
            var builder = new MsSqlExpressionBuilder(configuration, new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.Update });
            foreach (var field in fields)
                builder.Expression.Assign.Expressions.Add(field);
            return builder;
        }

        public IDeleteFromExpressionBuilder CreateDeleteExpressionBulder(DatabaseConfiguration configuration)
        {
            return new MsSqlExpressionBuilder(configuration, new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.Delete });
        }

        public IInsertExpressionBuilder<T> CreateInsertExpressionBuilder<T>(DatabaseConfiguration configuration, T instance)
            where T : class, IDbEntity
        {
            return new MsSqlInsertBuilder<T>(configuration, new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.Insert, Instance = instance });
        }
    }


    public partial class MsSqlExpressionBuilder : SqlExpressionBuilder
    {
        #region constructors
        public MsSqlExpressionBuilder(DatabaseConfiguration configuration, ExpressionSet expression) : base(configuration, expression)
        {

        }
        #endregion
    }
}
