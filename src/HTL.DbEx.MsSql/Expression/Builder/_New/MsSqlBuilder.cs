using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Expression;
using System;

namespace HTL.DbEx.MsSql.Expression._New
{
    public class MsSqlBuilder : SqlBuilder
    {
        #region constructors
        public MsSqlBuilder(DBExpressionSet expression) : base(expression)
        { }
        #endregion

        public static IFromBuilder<T, ISelectContinuationBuilder<T>, ISelectContinuationBuilder<T, ISelectContinuationBuilder<T>>> Select<T>()
            where T : class, IDBEntity
        {
            return new MsSqlBuilder<T, ISelectContinuationBuilder<T>, ISelectContinuationBuilder<T, ISelectContinuationBuilder<T>>>(new DBExpressionSet { ExecutionContext = ExecutionContext.Get }) 
                as IFromBuilder<T, ISelectContinuationBuilder<T>, ISelectContinuationBuilder<T, ISelectContinuationBuilder<T>>>;
        }

        public static IFromBuilder<T, ISelectContinuationBuilder<T>, ISelectContinuationBuilder<T, ISelectContinuationBuilder<T>>> Select<T>(DBExpressionField<T> field)
            where T : IComparable
        {
            var builder = new MsSqlBuilder<T, ISelectContinuationBuilder<T>, ISelectContinuationBuilder<T, ISelectContinuationBuilder<T>>>(new DBExpressionSet { ExecutionContext = ExecutionContext.GetValue });
            builder.Expression &= field;
            return builder as IFromBuilder<T, ISelectContinuationBuilder<T>, ISelectContinuationBuilder<T, ISelectContinuationBuilder<T>>>;
        }

        public static IFromBuilder<dynamic, ISelectContinuationBuilder<dynamic>, ISelectContinuationBuilder<dynamic, ISelectContinuationBuilder<dynamic>>> Select(DBExpressionField field1, DBExpressionField field2, params DBExpressionField[] fields)
        {
            var builder = new MsSqlBuilder<dynamic, ISelectContinuationBuilder<dynamic>, ISelectContinuationBuilder<dynamic, ISelectContinuationBuilder<dynamic>>> (new DBExpressionSet { ExecutionContext = ExecutionContext.GetDynamic });
            builder.Expression &= field1;
            builder.Expression &= field2;
            foreach (var f in fields)
                builder.Expression &= f;
            return builder as IFromBuilder<dynamic, ISelectContinuationBuilder<dynamic>, ISelectContinuationBuilder<dynamic, ISelectContinuationBuilder<dynamic>>>;
        }

        public static IFromBuilder<T, ISelectAllContinuationBuilder<T>, ISelectAllContinuationBuilder<T, ISelectAllContinuationBuilder<T>>> SelectAll<T>()
             where T : IDBEntity
        {
            return new MsSqlBuilder<T, ISelectAllContinuationBuilder<T>, ISelectAllContinuationBuilder<T, ISelectAllContinuationBuilder<T>>>(new DBExpressionSet { ExecutionContext = ExecutionContext.Get })
                as IFromBuilder<T, ISelectAllContinuationBuilder<T>, ISelectAllContinuationBuilder<T, ISelectAllContinuationBuilder<T>>>;
        }

        public static IFromBuilder<T, ISelectAllContinuationBuilder<T>, ISelectAllContinuationBuilder<T, ISelectAllContinuationBuilder<T>>> SelectAll<T>(DBExpressionField field)
             where T : IComparable
        {
            var builder = new MsSqlBuilder<T, ISelectAllContinuationBuilder<T>, ISelectAllContinuationBuilder<T, ISelectAllContinuationBuilder<T>>>(new DBExpressionSet { ExecutionContext = ExecutionContext.GetValue });
            builder.Expression &= field;
            return builder as IFromBuilder<T, ISelectAllContinuationBuilder<T>, ISelectAllContinuationBuilder<T, ISelectAllContinuationBuilder<T>>>;
        }

        public static IFromBuilder<dynamic, ISelectAllContinuationBuilder<dynamic>, ISelectAllContinuationBuilder<dynamic, ISelectAllContinuationBuilder<dynamic>>> SelectAll(DBExpressionField field1, DBExpressionField field2, params DBExpressionField[] fields)
        {
            var builder = new MsSqlBuilder<dynamic, ISelectAllContinuationBuilder<dynamic>, ISelectAllContinuationBuilder<dynamic, ISelectAllContinuationBuilder<dynamic>>>(new DBExpressionSet { ExecutionContext = ExecutionContext.GetDynamic });
            builder.Expression &= field1;
            builder.Expression &= field2;
            foreach (var f in fields)
                builder.Expression &= f;
            return builder as IFromBuilder<dynamic, ISelectAllContinuationBuilder<dynamic>, ISelectAllContinuationBuilder<dynamic, ISelectAllContinuationBuilder<dynamic>>>;
        }

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
