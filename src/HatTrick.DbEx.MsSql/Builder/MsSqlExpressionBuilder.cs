using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlExpressionBuilder : SqlExpressionBuilder
    {
        #region constructors
        public MsSqlExpressionBuilder(ExpressionSet expression) : base(expression)
        { }
        #endregion

        #region select one
        public static IFromExpressionBuilder<T, ITypeContinuationBuilder<T>, ITypeContinuationBuilder<T, ITypeContinuationBuilder<T>>> SelectOne<T>()
            where T : class, IDbEntity
        {
            return new MsSqlExpressionBuilder<T, ITypeContinuationBuilder<T>, ITypeContinuationBuilder<T, ITypeContinuationBuilder<T>>>(new ExpressionSet { ExecutionContext = ExecutionContext.Get }) 
                as IFromExpressionBuilder<T, ITypeContinuationBuilder<T>, ITypeContinuationBuilder<T, ITypeContinuationBuilder<T>>>;
        }

        public static IFromExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>> SelectOne<T>(FieldExpression<T> field)
            where T : IComparable
        {
            var builder = new MsSqlExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>>(new ExpressionSet { ExecutionContext = ExecutionContext.GetValue });
            builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IFromExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>>;
        }

        public static IFromExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>> SelectOne<T>(IDbExpressionSelectClausePart field)
            where T : IComparable
        {
            var builder = new MsSqlExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>>(new ExpressionSet { ExecutionContext = ExecutionContext.GetValue });
            builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IFromExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>>;
        }

        public static IFromExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>> SelectOne(IDbExpressionSelectClausePart field1, IDbExpressionSelectClausePart field2, params IDbExpressionSelectClausePart[] fields)
        {
            var builder = new MsSqlExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>> (new ExpressionSet { ExecutionContext = ExecutionContext.GetDynamic });
            builder.Expression.Select.Expressions.Add((field1.GetType(), field1));
            builder.Expression.Select.Expressions.Add((field2.GetType(), field2));
            foreach (var field in fields)
                builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IFromExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>>;
        }
        #endregion

        #region select all
        public static IListFromExpressionBuilder<T, ITypeListContinuationBuilder<T>, ITypeListContinuationBuilder<T, ITypeListContinuationBuilder<T>>> SelectAll<T>()
            where T : IDbEntity
        {
            return new MsSqlExpressionBuilder<T, ITypeListContinuationBuilder<T>, ITypeListContinuationBuilder<T, ITypeListContinuationBuilder<T>>>(new ExpressionSet { ExecutionContext = ExecutionContext.GetList })
                as IListFromExpressionBuilder<T, ITypeListContinuationBuilder<T>, ITypeListContinuationBuilder<T, ITypeListContinuationBuilder<T>>>;
        }

        public static IListFromExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>, IValueListContinuationExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>>> SelectAll<T>(FieldExpression<T> field)
             where T : IComparable
        {
            var builder = new MsSqlExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>, IValueListContinuationExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>>>(new ExpressionSet { ExecutionContext = ExecutionContext.GetValueList });
            builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IListFromExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>, IValueListContinuationExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>>>;
        }

        public static IListFromExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>, IValueListContinuationExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>>> SelectAll<T>(IDbExpressionSelectClausePart field)
        {
            var builder = new MsSqlExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>, IValueListContinuationExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>>>(new ExpressionSet { ExecutionContext = ExecutionContext.GetValueList });
            builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IListFromExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>, IValueListContinuationExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>>>;
        }

        public static IListFromExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>> SelectAll(IDbExpressionSelectClausePart field1, IDbExpressionSelectClausePart field2, params IDbExpressionSelectClausePart[] fields)
        {
            var builder = new MsSqlExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>>(new ExpressionSet { ExecutionContext = ExecutionContext.GetDynamicList });
            builder.Expression.Select.Expressions.Add((field1.GetType(), field1));
            builder.Expression.Select.Expressions.Add((field2.GetType(), field2));
            foreach (var field in fields)
                builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IListFromExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>>;
        }
        #endregion

        public static IUpdateFromExpressionBuilder Update(params AssignmentExpression[] fields)
        {
            var builder = new MsSqlExpressionBuilder(new ExpressionSet { ExecutionContext = ExecutionContext.Update });
            foreach (var field in fields)
                builder.Expression &= field;
            return builder as IUpdateFromExpressionBuilder;
        }

        public static IDeleteFromExpressionBuilder Delete()
        {
            return new MsSqlExpressionBuilder(new ExpressionSet { ExecutionContext = ExecutionContext.Delete })
                as IDeleteFromExpressionBuilder;
        }

        public static IInsertExpressionBuilder<T> Insert<T>(T instance)
            where T : class, IDbEntity
        {
            return new MsSqlInsertBuilder<T>(new ExpressionSet { ExecutionContext = ExecutionContext.Insert, Instance = instance })
                as IInsertExpressionBuilder<T>;
        }

        public static CoalesceFunctionExpression Coalesce<T>(IDbExpressionSelectClausePart<T> field1, IDbExpressionSelectClausePart<T> field2, params IDbExpressionSelectClausePart<T>[] fields)
            where T : IComparable
        {
            var parts = new List<IDbExpressionSelectClausePart>(fields == null ? 2 : 2 + fields.Length);
            parts.Add(field1);
            parts.Add(field2);
            foreach (var f in fields)
                parts.Add(f);
            return new CoalesceFunctionExpression(parts);
        }

        public static AverageFunctionExpression Avg(IDbExpressionSelectClausePart<short> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);

        public static AverageFunctionExpression Avg(IDbExpressionSelectClausePart<int> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);

        public static AverageFunctionExpression Avg(IDbExpressionSelectClausePart<long> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);

        public static AverageFunctionExpression Avg(IDbExpressionSelectClausePart<double> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);

        public static AverageFunctionExpression Avg(IDbExpressionSelectClausePart<decimal> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);

        public static AverageFunctionExpression Avg(IDbExpressionSelectClausePart<float> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);
    }
}
