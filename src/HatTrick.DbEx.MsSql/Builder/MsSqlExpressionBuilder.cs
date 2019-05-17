using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace HatTrick.DbEx.MsSql.Builder
{
    public partial class MsSqlExpressionBuilder : SqlExpressionBuilder
    {
        #region constructors
        public MsSqlExpressionBuilder(ExpressionSet expression) : base(expression)
        { }
        #endregion

        #region select one
        public static IFromExpressionBuilder<T, ITypeContinuationExpressionBuilder<T>, ITypeContinuationBuilder<T, ITypeContinuationExpressionBuilder<T>>> SelectOne<T>()
            where T : class, IDbEntity
        {
            return new MsSqlExpressionBuilder<T, ITypeContinuationExpressionBuilder<T>, ITypeContinuationBuilder<T, ITypeContinuationExpressionBuilder<T>>>(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectOneType, Select = new SelectExpressionSet().Top(1) })
                as IFromExpressionBuilder<T, ITypeContinuationExpressionBuilder<T>, ITypeContinuationBuilder<T, ITypeContinuationExpressionBuilder<T>>>;
        }

        public static IFromExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>, IValueContinuationExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>>> SelectOne<TEntity, TValue>(ISupportedForSelectEntityExpression<TEntity, TValue> field)
            where TEntity : IDbEntity
            where TValue : IComparable
        {
            var builder = new MsSqlExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>, IValueContinuationExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>>>(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectOneValue, Select = new SelectExpressionSet().Top(1) });
            builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IFromExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>, IValueContinuationExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>>>;
        }

        public static IFromExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>> SelectOne<T>(ISupportedForExpression<SelectExpression> field)
            where T : IComparable
        {
            var builder = new MsSqlExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>>(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectOneValue, Select = new SelectExpressionSet().Top(1) });
            builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IFromExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>>;
        }

        public static IFromExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>> SelectOne(ISupportedForExpression<SelectExpression> field1, ISupportedForExpression<SelectExpression> field2, params ISupportedForExpression<SelectExpression>[] fields)
        {
            var builder = new MsSqlExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>>(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectOneDynamic, Select = new SelectExpressionSet().Top(1) });
            builder.Expression.Select.Expressions.Add((field1.GetType(), field1));
            builder.Expression.Select.Expressions.Add((field2.GetType(), field2));
            foreach (var field in fields)
                builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IFromExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>>;
        }
        #endregion

        #region select all
        public static IListFromExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T>, ITypeListContinuationExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T>>> SelectMany<T>()
            where T : IDbEntity
        {
            return new MsSqlExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T>, ITypeListContinuationExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T>>>(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectManyType })
                as IListFromExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T>, ITypeListContinuationExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T>>>;
        }

        public static IListFromExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>, IValueListContinuationExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>>> SelectMany<TValue>(ISupportedForSelectFieldExpression<TValue> field)
            where TValue : IComparable
        {
            var builder = new MsSqlExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>, IValueListContinuationExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>>>(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectManyValue });
            builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IListFromExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>, IValueListContinuationExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>>>;
        }

        public static IListFromExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>, IValueListContinuationExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>>> SelectMany<TValue>(ISupportedForExpression<SelectExpression> field)
            where TValue : IComparable
        {
            var builder = new MsSqlExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>, IValueListContinuationExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>>>(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectManyValue });
            builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IListFromExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>, IValueListContinuationExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>>>;
        }

        public static IListFromExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>> SelectMany(ISupportedForExpression<SelectExpression> field1, ISupportedForExpression<SelectExpression> field2, params ISupportedForExpression<SelectExpression>[] fields)
        {
            var builder = new MsSqlExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>>(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectManyDynamic });
            builder.Expression.Select.Expressions.Add((field1.GetType(), field1));
            builder.Expression.Select.Expressions.Add((field2.GetType(), field2));
            foreach (var field in fields)
                builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IListFromExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>>;
        }
        #endregion

        public static IUpdateFromExpressionBuilder Update(params AssignmentExpression[] fields)
        {
            var builder = new MsSqlExpressionBuilder(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.Update });
            foreach (var field in fields)
                builder.Expression.Assign.Expressions.Add(field);
            return builder as IUpdateFromExpressionBuilder;
        }

        public static IDeleteFromExpressionBuilder Delete()
        {
            return new MsSqlExpressionBuilder(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.Delete })
                as IDeleteFromExpressionBuilder;
        }

        public static IInsertExpressionBuilder<T> Insert<T>(T instance)
            where T : class, IDbEntity
        {
            return new MsSqlInsertBuilder<T>(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.Insert, Instance = instance })
                as IInsertExpressionBuilder<T>;
        }

        #pragma warning disable IDE1006
        public class fx : MsSqlFunctionExpressionBuilder
        {

        }
    }
}
