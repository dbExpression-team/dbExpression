using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Builder;
using HTL.DbEx.Sql.Builder.Syntax;
using HTL.DbEx.Sql.Expression;
using HTL.DbEx.Sql.Extensions.Expression;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace HTL.DbEx.MsSql.Builder
{
    public class MsSqlBuilder : SqlBuilder
    {
        #region constructors
        public MsSqlBuilder(DBExpressionSet expression) : base(expression)
        { }
        #endregion

        #region select
        public static IFromBuilder<T, ITypeContinuationBuilder<T>, ITypeContinuationBuilder<T, ITypeContinuationBuilder<T>>> Select<T>()
            where T : class, IDBEntity
        {
            return new MsSqlBuilder<T, ITypeContinuationBuilder<T>, ITypeContinuationBuilder<T, ITypeContinuationBuilder<T>>>(new DBExpressionSet { ExecutionContext = ExecutionContext.Get }) 
                as IFromBuilder<T, ITypeContinuationBuilder<T>, ITypeContinuationBuilder<T, ITypeContinuationBuilder<T>>>;
        }

        public static IFromBuilder<T, IValueContinuationBuilder<T>, IValueContinuationBuilder<T, IValueContinuationBuilder<T>>> Select<T>(DBExpressionField<T> field)
            where T : IComparable
        {
            var builder = new MsSqlBuilder<T, IValueContinuationBuilder<T>, IValueContinuationBuilder<T, IValueContinuationBuilder<T>>>(new DBExpressionSet { ExecutionContext = ExecutionContext.GetValue });
            builder.Expression &= field;
            return builder as IFromBuilder<T, IValueContinuationBuilder<T>, IValueContinuationBuilder<T, IValueContinuationBuilder<T>>>;
        }

        public static IFromBuilder<T, IValueContinuationBuilder<T>, IValueContinuationBuilder<T, IValueContinuationBuilder<T>>> Select<T>(IDBExpressionSelectClausePart field)
            where T : IComparable
        {
            var builder = new MsSqlBuilder<T, IValueContinuationBuilder<T>, IValueContinuationBuilder<T, IValueContinuationBuilder<T>>>(new DBExpressionSet { ExecutionContext = ExecutionContext.GetValue });
            builder.Expression &= field.ToSelectExpression();
            return builder as IFromBuilder<T, IValueContinuationBuilder<T>, IValueContinuationBuilder<T, IValueContinuationBuilder<T>>>;
        }

        public static IFromBuilder<ExpandoObject, IValueContinuationBuilder<ExpandoObject>, IValueContinuationBuilder<ExpandoObject, IValueContinuationBuilder<ExpandoObject>>> Select(IDBExpressionSelectClausePart field1, IDBExpressionSelectClausePart field2, params IDBExpressionSelectClausePart[] fields)
        {
            var builder = new MsSqlBuilder<ExpandoObject, IValueContinuationBuilder<ExpandoObject>, IValueContinuationBuilder<ExpandoObject, IValueContinuationBuilder<ExpandoObject>>> (new DBExpressionSet { ExecutionContext = ExecutionContext.GetDynamic });
            builder.Expression &= field1.ToSelectExpression();
            builder.Expression &= field2.ToSelectExpression();
            foreach (var f in fields)
                builder.Expression &= f.ToSelectExpression();
            return builder as IFromBuilder<ExpandoObject, IValueContinuationBuilder<ExpandoObject>, IValueContinuationBuilder<ExpandoObject, IValueContinuationBuilder<ExpandoObject>>>;
        }
        #endregion

        #region select all
        public static IListFromBuilder<T, ITypeListContinuationBuilder<T>, ITypeListContinuationBuilder<T, ITypeListContinuationBuilder<T>>> SelectAll<T>()
            where T : IDBEntity
        {
            return new MsSqlBuilder<T, ITypeListContinuationBuilder<T>, ITypeListContinuationBuilder<T, ITypeListContinuationBuilder<T>>>(new DBExpressionSet { ExecutionContext = ExecutionContext.GetList })
                as IListFromBuilder<T, ITypeListContinuationBuilder<T>, ITypeListContinuationBuilder<T, ITypeListContinuationBuilder<T>>>;
        }

        public static IListFromBuilder<T, IValueListContinuationBuilder<T>, IValueListContinuationBuilder<T, IValueListContinuationBuilder<T>>> SelectAll<T>(DBExpressionField<T> field)
             where T : IComparable
        {
            var builder = new MsSqlBuilder<T, IValueListContinuationBuilder<T>, IValueListContinuationBuilder<T, IValueListContinuationBuilder<T>>>(new DBExpressionSet { ExecutionContext = ExecutionContext.GetValueList });
            builder.Expression &= field;
            return builder as IListFromBuilder<T, IValueListContinuationBuilder<T>, IValueListContinuationBuilder<T, IValueListContinuationBuilder<T>>>;
        }

        public static IListFromBuilder<T, IValueListContinuationBuilder<T>, IValueListContinuationBuilder<T, IValueListContinuationBuilder<T>>> SelectAll<T>(IDBExpressionSelectClausePart field)
        {
            var builder = new MsSqlBuilder<T, IValueListContinuationBuilder<T>, IValueListContinuationBuilder<T, IValueListContinuationBuilder<T>>>(new DBExpressionSet { ExecutionContext = ExecutionContext.GetValueList });
            builder.Expression &= field.ToSelectExpression();
            return builder as IListFromBuilder<T, IValueListContinuationBuilder<T>, IValueListContinuationBuilder<T, IValueListContinuationBuilder<T>>>;
        }

        public static IListFromBuilder<ExpandoObject, IValueListContinuationBuilder<ExpandoObject>, IValueListContinuationBuilder<ExpandoObject, IValueListContinuationBuilder<ExpandoObject>>> SelectAll(IDBExpressionSelectClausePart field1, IDBExpressionSelectClausePart field2, params IDBExpressionSelectClausePart[] fields)
        {
            var builder = new MsSqlBuilder<ExpandoObject, IValueListContinuationBuilder<ExpandoObject>, IValueListContinuationBuilder<ExpandoObject, IValueListContinuationBuilder<ExpandoObject>>>(new DBExpressionSet { ExecutionContext = ExecutionContext.GetDynamicList });
            builder.Expression &= field1.ToSelectExpression();
            builder.Expression &= field2.ToSelectExpression();
            foreach (var f in fields)
                builder.Expression &= f.ToSelectExpression();
            return builder as IListFromBuilder<ExpandoObject, IValueListContinuationBuilder<ExpandoObject>, IValueListContinuationBuilder<ExpandoObject, IValueListContinuationBuilder<ExpandoObject>>>;
        }
        #endregion

        public static IUpdateFromBuilder Update(params DBAssignmentExpression[] fields)
        {
            var builder = new MsSqlBuilder(new DBExpressionSet { ExecutionContext = ExecutionContext.Update });
            foreach (var field in fields)
                builder.Expression &= field;
            return builder as IUpdateFromBuilder;
        }

        public static IDeleteFromBuilder Delete()
        {
            return new MsSqlBuilder(new DBExpressionSet { ExecutionContext = ExecutionContext.Delete })
                as IDeleteFromBuilder;
        }

        public static IInsertBuilder<T> Insert<T>(T instance)
            where T : class, IDBEntity
        {
            return new MsSqlInsertBuilder<T>(new DBExpressionSet { ExecutionContext = ExecutionContext.Insert, Instance = instance })
                as IInsertBuilder<T>;
        }
    }
}
