using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public static class SqlExpressionBuilderExtensions
    {
        public static void Execute(this ITerminationExpressionBuilder builder) => builder.Execute((SqlConnection)null);

        //TODO: feature/interface-implementation: should this be an actual Transaction and not a connection? 
        public static void Execute(this ITerminationExpressionBuilder builder, SqlConnection transaction)
        {
            var expression = (builder as IExpressionProvider).GetExpression();

            if (transaction == null)
                transaction = DbExpressionConfiguration.ConnectionFactory.CreateSqlConnection(DbExpressionConfiguration.ConnectionStringSettings.Single(c => c.Name == expression.BaseEntity.Schema.ConnectionName));

            //var validator  ??;

            var assembler = DbExpressionConfiguration.StatementBuilderFactory.CreateSqlStatementBuilder(DbExpressionConfiguration.AssemblerConfiguration, expression, DbExpressionConfiguration.ParameterBuilderFactory.CreateSqlParameterBuilder());
            var statement = assembler.CreateSqlStatement();

            var executor = DbExpressionConfiguration.ExecutorFactory.CreateSqlStatementExecutor(expression);
            executor.ExecuteNonQuery(statement, transaction);
        }

        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder) => builder.Execute((SqlConnection)null);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder, SqlConnection transaction)
        {
            var value = default(T);

            var expression = (builder as IExpressionProvider).GetExpression();

            var queryResults = Execute(expression, transaction);
            if (!queryResults.HasData() || queryResults.Rows[0].Fields[0].Value == null)
                return value;

            var mapper = DbExpressionConfiguration.MapperFactory.CreateValueMapper<T>();
            return mapper.Map(queryResults.Rows[0].Fields[0]);
        }

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder) => builder.Execute((SqlConnection)null);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection transaction)
        {
            var values = new List<T>();

            var expression = (builder as IExpressionProvider).GetExpression();

            var queryResults = Execute(expression, transaction);
            if (!queryResults.HasData())
                return values;

            var mapper = DbExpressionConfiguration.MapperFactory.CreateValueMapper<T>();
            foreach (var row in queryResults.Rows)
                values.Add(mapper.Map(row.Fields[0]));

            return values;
        }

        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder) => builder.Execute((SqlConnection)null);

        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection transaction)
        {
            var value = default(ExpandoObject);

            var expression = (builder as IExpressionProvider).GetExpression();

            var queryResults = Execute(expression, transaction);
            if (!queryResults.HasData() || queryResults.Rows[0].Fields[0].Value == null)
                return value;

            var mapper = DbExpressionConfiguration.MapperFactory.CreateExpandoObjectMapper();
            mapper.Map(value, queryResults.Rows[0]);

            return (dynamic)value;
        }


        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder) => builder.Execute((SqlConnection)null);

        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection transaction)
        {
            var values = new List<dynamic>();

            var expression = (builder as IExpressionProvider).GetExpression();

            var queryResults = Execute(expression, transaction);
            if (!queryResults.HasData())
                return values;

            var mapper = DbExpressionConfiguration.MapperFactory.CreateExpandoObjectMapper();
            foreach (var row in queryResults.Rows)
            {
                var value = new ExpandoObject();
                mapper.Map(value, row);
                values.Add(value);
            }

            return values;
        }

        public static T Execute<T>(this ITypeTerminationBuilder<T> builder) where T : class, IDbEntity, new()
            => builder.Execute((SqlConnection)null);

        public static T Execute<T>(this ITypeTerminationBuilder<T> builder, SqlConnection transaction)
            where T : class, IDbEntity, new()
        {
            var value = default(T);

            var expression = (builder as IExpressionProvider).GetExpression();

            var queryResults = Execute(expression, transaction);
            if (!queryResults.HasData() || queryResults.Rows[0].Fields[0].Value == null)
                return value;

            value = new T();
            var mapper = DbExpressionConfiguration.MapperFactory.CreateEntityMapper(expression.BaseEntity as EntityExpression<T>);
            mapper.Map(value, queryResults.Rows[0]);

            return value;
        }

        public static IList<T> Execute<T>(this ITypeListTerminationBuilder<T> builder)
            where T : class, IDbEntity, new()
            => builder.Execute((SqlConnection)null);

        public static IList<T> Execute<T>(this ITypeListTerminationBuilder<T> builder, SqlConnection transaction)
            where T : class, IDbEntity, new()
        {
            var values = new List<T>();

            var expression = (builder as IExpressionProvider).GetExpression();

            var queryResults = Execute(expression, transaction);

            if (!queryResults.HasData())
                return values;

            var mapper = DbExpressionConfiguration.MapperFactory.CreateEntityMapper(expression.BaseEntity as EntityExpression<T>);
            foreach (var row in queryResults.Rows)
            {
                var t = new T();
                mapper.Map(t, row);
                values.Add(t);
            }
            return values;
        }

        private static SqlStatementExecutionResultSet Execute(ExpressionSet expression, SqlConnection transaction)
        {
            transaction = transaction ?? DbExpressionConfiguration.ConnectionFactory.CreateSqlConnection(DbExpressionConfiguration.ConnectionStringSettings.Single(c => c.Name == expression.BaseEntity.Schema.ConnectionName));
            
            //var validator  ??;

            var builder = DbExpressionConfiguration.StatementBuilderFactory.CreateSqlStatementBuilder(DbExpressionConfiguration.AssemblerConfiguration, expression, DbExpressionConfiguration.ParameterBuilderFactory.CreateSqlParameterBuilder());
            var statement = builder.CreateSqlStatement();

            var executor = DbExpressionConfiguration.ExecutorFactory.CreateSqlStatementExecutor(expression);
            return executor.ExecuteQuery(statement, transaction);
        }
    }
}
