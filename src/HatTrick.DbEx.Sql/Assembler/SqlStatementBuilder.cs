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

        public DbExpressionAssemblerConfiguration AssemblerConfiguration { get; }
        public ExpressionSet ExpressionSet { get; }
        public Func<SqlStatementExecutionType, ISqlStatementAssembler> AssemblerFactory { get; }
        public Func<Type, IAssemblyPartAppender> PartAppenderFactory { get; }
        public IAppender Appender { get; }
        public ISqlParameterBuilder Parameters { get; }

        public SqlStatementBuilder(
            DbExpressionAssemblerConfiguration config,
            ExpressionSet dbExpression,
            Func<SqlStatementExecutionType, ISqlStatementAssembler> assemblerFactory,
            Func<Type, IAssemblyPartAppender> partAppenderFactory,
            IAppender appender,
            ISqlParameterBuilder parameterBuilder
        )
        {
            AssemblerConfiguration = config;
            ExpressionSet = dbExpression;
            AssemblerFactory = assemblerFactory;
            PartAppenderFactory = partAppenderFactory;
            Appender = appender;
            Parameters = parameterBuilder;
        }

        public SqlStatement CreateSqlStatement()
        {
            if (_sqlStatement != null)
                return _sqlStatement;

            var context = new AssemblyContext
            {
                Configuration = AssemblerConfiguration,
            };

            var assembler = AssemblerFactory(ExpressionSet.StatementExecutionType);
            if (assembler == null)
                throw new DbExpressionConfigurationException($"Could not resolve an assembler for statement execution type '{ExpressionSet.StatementExecutionType}', please ensure an assembler has been registered during startup initialization of DbExpression.");

            assembler.AssembleStatement(ExpressionSet, this, context);

            return _sqlStatement = new SqlStatement(Appender, Parameters.Parameters, DbCommandType.SqlText);
        }

        public void AppendPart<T>(T part, AssemblyContext context)
            where T : class, IDbExpression
            => DoAppendPart(new ExpressionContainer(part), context);

        public void AppendPart(ExpressionContainer part, AssemblyContext context)
            => DoAppendPart(part, context);

        private void DoAppendPart(object part, AssemblyContext context)
        {
            if (part is ExpressionSet set)
            {
                AssembleStatement(set, context);
                return;
            }

            if (part is ExpressionContainer container)
            {
                DoAppendPart(container.Object, context);
                return;
            }

            var appender = PartAppenderFactory(part.GetType()) ?? throw new DbExpressionConfigurationException($"Could not resolve an appender for part type '{part.GetType()}', please ensure an appender has been registered during startup initialization of DbExpression.");

            appender.AppendPart(part, this, context);
        }

        public void AssembleStatement(ExpressionSet set, AssemblyContext context)
        {
            var assembler = AssemblerFactory(set.StatementExecutionType);
            if (assembler == null)
            {
                throw new DbExpressionConfigurationException($"Could not resolve an assembler for type '{nameof(ExpressionSet)}', please ensure an assembler has been registered during startup initialization of DbExpression.");
            }
            assembler.AssembleStatement(set, this, context);
        }

        public string GenerateAlias() => $"_t{++_currentAliasCounter}";
    }
}