using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SqlStatementBuilder :
        ISqlStatementBuilder
    {
        #region internals
        private int _currentAliasCounter;
        private SqlStatement _sqlStatement;
        #endregion

        public ISqlDatabaseMetadataProvider DatabaseMetadata { get; }
        public SqlStatementAssemblerConfiguration AssemblerConfiguration { get; }
        public QueryExpression Query { get; }
        public Func<QueryExpression, ISqlStatementAssembler> AssemblerFactory { get; }
        public IAssemblyPartAppenderFactory PartAppenderFactory { get; }
        public IAppender Appender { get; }
        public ISqlParameterBuilder Parameters { get; }

        public SqlStatementBuilder(
            ISqlDatabaseMetadataProvider databaseMetadata,
            IAssemblyPartAppenderFactory partAppenderFactory,
            SqlStatementAssemblerConfiguration config,
            QueryExpression query,
            Func<QueryExpression, ISqlStatementAssembler> assemblerFactory,
            IAppender appender,
            ISqlParameterBuilder parameterBuilder
        )
        {
            DatabaseMetadata = databaseMetadata;
            AssemblerConfiguration = config;
            Query = query;
            AssemblerFactory = assemblerFactory;
            PartAppenderFactory = partAppenderFactory;
            Appender = appender;
            Parameters = parameterBuilder;
        }

        public SqlStatement CreateSqlStatement()
        {
            if (_sqlStatement is object)
                return _sqlStatement;

            var context = new AssemblyContext(AssemblerConfiguration);

            var assembler = AssemblerFactory(Query)
                ?? throw new DbExpressionConfigurationException($"Could not resolve an assembler for statement execution type '{Query}', please ensure an assembler has been registered during startup initialization of DbExpression.");

            assembler.AssembleStatement(Query, this, context);

            return _sqlStatement = new SqlStatement(Appender, Parameters.Parameters, DbCommandType.SqlText);
        }

        public void AppendPart<T>(T part, AssemblyContext context)
            where T : class, IExpression
        {           
            var appender = PartAppenderFactory.CreatePartAppender(part);
            if (appender is object)
            { 
                appender.AppendPart(part, this, context);
                return;
            }

            if (part is QueryExpression query)
            {
                AssembleStatement(query, context);
                return;
            }

            throw new DbExpressionConfigurationException($"Could not resolve an appender for part type '{part.GetType()}', please ensure an appender has been registered during startup initialization of DbExpression.");
        }

        public void AssembleStatement(QueryExpression expression, AssemblyContext context)
        {
            var assembler = AssemblerFactory(expression)
                ?? throw new DbExpressionConfigurationException($"Could not resolve an assembler for type '{expression.GetType()}', please ensure an assembler has been registered during startup initialization of DbExpression.");
            
            assembler.AssembleStatement(expression, this, context);
        }

        public string GenerateAlias() => $"_t{++_currentAliasCounter}";

        public ISqlSchemaMetadata FindMetadata(SchemaExpression schema) => DatabaseMetadata.FindSchemaMetadata((schema as ISqlMetadataIdentifier).Identifier);
        public ISqlEntityMetadata FindMetadata(EntityExpression entity) => DatabaseMetadata.FindEntityMetadata((entity as ISqlMetadataIdentifier).Identifier);
        public ISqlFieldMetadata FindMetadata(FieldExpression field) => DatabaseMetadata.FindFieldMetadata((field as ISqlMetadataIdentifier).Identifier);
    }
}