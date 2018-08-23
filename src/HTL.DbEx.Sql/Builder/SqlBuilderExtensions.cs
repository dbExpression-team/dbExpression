using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Assembler;
using HTL.DbEx.Sql.Builder.Syntax;
using HTL.DbEx.Sql.Executor;
using HTL.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.Linq;

namespace HTL.DbEx.Sql.Builder
{
    public static class SqlBuilderExtensions
    {
        public static void Execute(this ITerminationBuilder builder) => builder.Execute((SqlConnection)null);

        //TODO: feature/interface-implementation: should this be an actual Transaction and not a connection? 
        public static void Execute(this ITerminationBuilder builder, SqlConnection transaction)
        {
            var expression = (builder as IDBExpressionProvider).GetExpression();

            if (transaction == null)
                transaction = DBExpressionConfiguration.ConnectionFactory.CreateSqlConnection(DBExpressionConfiguration.ConnectionStringSettings.Single(c => c.Name == expression.BaseEntity.Schema.ConnectionName));

            //var validator  ??;

            var assembler = DBExpressionConfiguration.AssemblerFactory.CreateSqlStatementBuilder(expression, DBExpressionConfiguration.ParameterBuilderFactory.CreateSqlParameterBuilder());
            (string sql, IList<DbParameter> parameters) = assembler.CreateSqlStatement();

            var executor = DBExpressionConfiguration.ExecutorFactory.CreateSqlStatementExecutor(expression);
            executor.ExecuteNonQuery(transaction, sql, DbCommandType.SqlText, parameters);
        }

        public static T Execute<T>(this IValueTerminationBuilder<T> builder) => builder.Execute((SqlConnection)null);

        public static T Execute<T>(this IValueTerminationBuilder<T> builder, SqlConnection transaction)
        {
            var value = default(T);

            var expression = (builder as IDBExpressionProvider).GetExpression();

            var queryResults = Execute(expression, transaction);
            if (!queryResults.HasData() || queryResults.Rows[0].Fields[0].Item3 == null)
                return value;

            var mapper = DBExpressionConfiguration.MapperFactory.CreateMapper<T>();
            mapper.Map(value, queryResults.Rows[0]);

            return value;
        }

        public static IList<T> Execute<T>(this IValueListTerminationBuilder<T> builder) => builder.Execute((SqlConnection)null);

        public static IList<T> Execute<T>(this IValueListTerminationBuilder<T> builder, SqlConnection transaction)
        {
            var values = new List<T>();

            var expression = (builder as IDBExpressionProvider).GetExpression();

            var queryResults = Execute(expression, transaction);
            if (!queryResults.HasData())
                return values;

            var mapper = DBExpressionConfiguration.MapperFactory.CreateMapper<T>();
            foreach (var row in queryResults.Rows)
            {
                var value = default(T);
                mapper.Map(value, row);
                values.Add(value);
            }

            return values;
        }

        public static dynamic Execute(this IValueTerminationBuilder<ExpandoObject> builder) => builder.Execute((SqlConnection)null);

        public static dynamic Execute(this IValueTerminationBuilder<ExpandoObject> builder, SqlConnection transaction)
        {
            var value = default(ExpandoObject);

            var expression = (builder as IDBExpressionProvider).GetExpression();

            var queryResults = Execute(expression, transaction);
            if (!queryResults.HasData() || queryResults.Rows[0].Fields[0].Item3 == null)
                return value;

            var mapper = DBExpressionConfiguration.MapperFactory.CreateMapper<ExpandoObject>();
            mapper.Map(value, queryResults.Rows[0]);

            return (dynamic)value;
        }


        public static IList<dynamic> Execute(this IValueListTerminationBuilder<ExpandoObject> builder) => builder.Execute((SqlConnection)null);

        public static IList<dynamic> Execute(this IValueListTerminationBuilder<ExpandoObject> builder, SqlConnection transaction)
        {
            var values = new List<dynamic>();

            var expression = (builder as IDBExpressionProvider).GetExpression();

            var queryResults = Execute(expression, transaction);
            if (!queryResults.HasData())
                return values;

            var mapper = DBExpressionConfiguration.MapperFactory.CreateMapper<ExpandoObject>();
            foreach (var row in queryResults.Rows)
            {
                var value = new ExpandoObject();
                mapper.Map(value, row);
                values.Add(value);
            }

            return values;
        }

        public static T Execute<T>(this ITypeTerminationBuilder<T> builder) where T : class, IDBEntity, new()
            => builder.Execute((SqlConnection)null);

        public static T Execute<T>(this ITypeTerminationBuilder<T> builder, SqlConnection transaction)
            where T : class, IDBEntity, new()
        {
            var value = default(T);

            var expression = (builder as IDBExpressionProvider).GetExpression();

            var queryResults = Execute(expression, transaction);
            if (!queryResults.HasData() || queryResults.Rows[0].Fields[0].Item3 == null)
                return value;

            value = new T();
            var mapper = DBExpressionConfiguration.MapperFactory.CreateMapper(expression.BaseEntity as DBExpressionEntity<T>);
            mapper.Map(value, queryResults.Rows[0]);

            return value;
        }

        public static IList<T> Execute<T>(this ITypeListTerminationBuilder<T> builder)
            where T : class, IDBEntity, new()
            => builder.Execute((SqlConnection)null);

        public static IList<T> Execute<T>(this ITypeListTerminationBuilder<T> builder, SqlConnection transaction)
            where T : class, IDBEntity, new()
        {
            var values = new List<T>();

            var expression = (builder as IDBExpressionProvider).GetExpression();

            var queryResults = Execute(expression, transaction);

            if (!queryResults.HasData())
                return values;

            var mapper = DBExpressionConfiguration.MapperFactory.CreateMapper(expression.BaseEntity as DBExpressionEntity<T>);
            foreach (var row in queryResults.Rows)
            {
                var t = new T();
                mapper.Map(t, row);
                values.Add(t);
            }
            return values;
        }

        private static ResultSet Execute(DBExpressionSet expression, SqlConnection transaction)
        {
            transaction = transaction ?? DBExpressionConfiguration.ConnectionFactory.CreateSqlConnection(DBExpressionConfiguration.ConnectionStringSettings.Single(c => c.Name == expression.BaseEntity.Schema.ConnectionName));
            
            //var validator  ??;

            var builder = DBExpressionConfiguration.AssemblerFactory.CreateSqlStatementBuilder(expression, DBExpressionConfiguration.ParameterBuilderFactory.CreateSqlParameterBuilder());
            (string sql, IList<DbParameter> parameters) = builder.CreateSqlStatement();

            var executor = DBExpressionConfiguration.ExecutorFactory.CreateSqlStatementExecutor(expression);
            return executor.ExecuteQuery(transaction, sql, DbCommandType.SqlText, parameters);
        }
    }
}
