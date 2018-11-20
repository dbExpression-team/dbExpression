using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Extensions.Builder
{
    public static class SqlExpressionBuilderExtensions
    {
        public static void Execute(this ITerminationExpressionBuilder builder) => builder.Execute((SqlConnection)null);

        //TODO: feature/interface-implementation: should this be an actual Transaction and not a connection? 
        public static void Execute(this ITerminationExpressionBuilder builder, SqlConnection transaction)
        {
            var expression = (builder as IExpressionProvider).GetExpression();

            if (transaction == null)
            {
                var provider = expression.BaseEntity as IExpressionMetadataProvider<EntityExpressionMetadata>;
                transaction = DbExConfigurationSettings.Settings.ConnectionFactory.CreateSqlConnection(DbExConfigurationSettings.Settings.ConnectionStringSettings[provider.Metadata.Schema.ConnectionName]);
            }

            //var validator  ??;

            var assembler = DbExConfigurationSettings.Settings.StatementBuilderFactory.CreateSqlStatementBuilder(
                DbExConfigurationSettings.Settings.AssemblerConfiguration,
                expression,
                DbExConfigurationSettings.Settings.AppenderFactory.CreateAppender(DbExConfigurationSettings.Settings.AssemblerConfiguration),
                DbExConfigurationSettings.Settings.ParameterBuilderFactory.CreateSqlParameterBuilder()
            );
            var statement = assembler.CreateSqlStatement();

            var executor = DbExConfigurationSettings.Settings.ExecutorFactory.CreateSqlStatementExecutor(expression);
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

            var mapper = DbExConfigurationSettings.Settings.MapperFactory.CreateValueMapper<T>();
            return mapper.Map(queryResults.Rows[0].Fields[0].Value);
        }

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder) => builder.Execute((SqlConnection)null);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection transaction)
        {
            var values = new List<T>();

            var expression = (builder as IExpressionProvider).GetExpression();

            var queryResults = Execute(expression, transaction);
            if (!queryResults.HasData())
                return values;

            var mapper = DbExConfigurationSettings.Settings.MapperFactory.CreateValueMapper<T>();
            foreach (var row in queryResults.Rows)
                values.Add(mapper.Map(row.Fields[0].Value));

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

            var mapper = DbExConfigurationSettings.Settings.MapperFactory.CreateExpandoObjectMapper();
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

            var mapper = DbExConfigurationSettings.Settings.MapperFactory.CreateExpandoObjectMapper();
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
            var entity = default(T);

            var expression = (builder as IExpressionProvider).GetExpression();

            var queryResults = Execute(expression, transaction);
            if (!queryResults.HasData() || queryResults.Rows[0].Fields[0].Value == null)
                return entity;

            entity = DbExConfigurationSettings.Settings.EntityFactory.CreateEntity<T>();
            var entityMapper = DbExConfigurationSettings.Settings.MapperFactory.CreateEntityMapper(expression.BaseEntity as EntityExpression<T>);
            var valueMapper = DbExConfigurationSettings.Settings.MapperFactory.CreateValueMapper();
            entityMapper.Map(queryResults.Rows[0], entity, valueMapper);

            return entity;
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

            var entityMapper = DbExConfigurationSettings.Settings.MapperFactory.CreateEntityMapper(expression.BaseEntity as EntityExpression<T>);
            var valueMapper = DbExConfigurationSettings.Settings.MapperFactory.CreateValueMapper();
            foreach (var row in queryResults.Rows)
            {
                var entity = DbExConfigurationSettings.Settings.EntityFactory.CreateEntity<T>();
                entityMapper.Map(row, entity, valueMapper);
                values.Add(entity);
            }
            return values;
        }

        private static SqlStatementExecutionResultSet Execute(ExpressionSet expression, SqlConnection transaction)
        {
            if (transaction == null)
            {
                var provider = expression.BaseEntity as IExpressionMetadataProvider<EntityExpressionMetadata>;
                transaction = DbExConfigurationSettings.Settings.ConnectionFactory.CreateSqlConnection(DbExConfigurationSettings.Settings.ConnectionStringSettings[provider.Metadata.Schema.ConnectionName]);
            }

            //var validator  ??;

            var builder = DbExConfigurationSettings.Settings.StatementBuilderFactory.CreateSqlStatementBuilder(
                DbExConfigurationSettings.Settings.AssemblerConfiguration,
                expression,
                DbExConfigurationSettings.Settings.AppenderFactory.CreateAppender(DbExConfigurationSettings.Settings.AssemblerConfiguration),
                DbExConfigurationSettings.Settings.ParameterBuilderFactory.CreateSqlParameterBuilder()
            );
            var statement = builder.CreateSqlStatement();

            var executor = DbExConfigurationSettings.Settings.ExecutorFactory.CreateSqlStatementExecutor(expression);
            return executor.ExecuteQuery(statement, transaction);
        }
    }
}
