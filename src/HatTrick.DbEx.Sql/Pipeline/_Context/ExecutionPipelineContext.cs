using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class ExecutionPipelineContext
    {
        #region internals
        private readonly Lazy<IAppender> appender;
        //private readonly Lazy<ISqlStatementBuilder> _statementBuilder;
        private readonly Lazy<ISqlStatementExecutor> _statementExecutor;
        private readonly Lazy<SqlConnection> _connection;

        private SqlStatement _sqlStatement;
        #endregion

        #region interface
        public DatabaseConfiguration Configuration { get; private set; }
        public ExpressionSet ExpressionSet { get; private set; }
        public ISqlStatementBuilder StatementBuilder { get; set; }
        public ISqlStatementExecutor StatementExecutor => _statementExecutor.Value;
        public SqlConnection Connection => _connection.Value;
        public SqlStatement SqlStatement => _sqlStatement ?? (_sqlStatement = StatementBuilder.CreateSqlStatement());
        public ISqlRowReader Reader { get; set; }
        #endregion

        #region constructors
        public ExecutionPipelineContext(DbExpressionConfiguration config, DatabaseConfiguration database, ExpressionSet expressionSet, SqlConnection connection)
        {
            Configuration = database;
            ExpressionSet = expressionSet;
            appender = new Lazy<IAppender>(() => database.AppenderFactory.CreateAppender(database.AssemblerConfiguration));
            //_statementBuilder = new Lazy<ISqlStatementBuilder>(() => config.StatementBuilderFactory.CreateSqlStatementBuilder(config.AssemblerConfiguration, ExpressionSet, appender.Value, config.ParameterBuilderFactory.CreateSqlParameterBuilder()));
            _statementExecutor = new Lazy<ISqlStatementExecutor>(() => database.ExecutorFactory.CreateSqlStatementExecutor(ExpressionSet));
            _connection = new Lazy<SqlConnection>(() => connection ?? database.ConnectionFactory.CreateSqlConnection(config.ConnectionStringSettings[(ExpressionSet.BaseEntity as IDbExpressionMetadataProvider<ISqlEntityMetadata>).Metadata.Schema.Database.ConnectionName]));
        }
        #endregion
    }
}
