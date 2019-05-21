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
        public Func<Type, IValueTypeFormatter> ValueTypeFormatterFactory { get; }
        public IAppender Appender { get; }
        public ISqlParameterBuilder Parameters { get; }

        public SqlStatementBuilder(
            DbExpressionAssemblerConfiguration config,
            ExpressionSet dbExpression,
            Func<SqlStatementExecutionType, ISqlStatementAssembler> assemblerFactory,
            Func<Type, IAssemblyPartAppender> partAppenderFactory,
            Func<Type, IValueTypeFormatter> valueTypeFormatterFactory,
            IAppender appender,
            ISqlParameterBuilder parameterBuilder
        )
        {
            AssemblerConfiguration = config;
            ExpressionSet = dbExpression;
            AssemblerFactory = assemblerFactory;
            PartAppenderFactory = partAppenderFactory;
            ValueTypeFormatterFactory = valueTypeFormatterFactory;
            Appender = appender;
            Parameters = parameterBuilder;
        }

        public string FormatValueType((Type, object) value)
        {
            var formatter = ValueTypeFormatterFactory(value.Item1);
            if (formatter == null)
                throw new DbExpressionConfigurationException($"Could not resolve a value formatter for type '{value.Item1}', please ensure an value formatter has been registered during startup initialization of DbExpression.");

            return formatter.Format(value.Item2);
        }

        public string FormatValueType<T>(object value)
            where T : IComparable
        {
            if (!(ValueTypeFormatterFactory(typeof(T)) is IValueTypeFormatter formatter))
                throw new DbExpressionConfigurationException($"Could not resolve a value formatter for type '{value.GetType()}', please ensure an value formatter has been registered during startup initialization of DbExpression.");

            return formatter.Format(value);
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

        public void AppendPart((Type, object) part, AssemblyContext context)
        {
            var appender = PartAppenderFactory(part.Item1);
            if (appender == null)
                throw new DbExpressionConfigurationException($"Could not resolve an appender for part type '{part.Item1}', please ensure an appender has been registered during startup initialization of DbExpression.");

            appender.AppendPart(part.Item2, this, context);
        }

        public void AppendPart<T>(T part, AssemblyContext context)
            where T : class, IAssemblyPart
        {
            var appender = PartAppenderFactory(typeof(T));
            if (appender == null)
                throw new DbExpressionConfigurationException($"Could not resolve an appender for part type '{typeof(T)}', please ensure an appender has been registered during startup initialization of DbExpression.");

            PartAppenderFactory(typeof(T)).AppendPart(part, this, context);
        }

        public string GenerateAlias() => $"_t{++_currentAliasCounter}";
    }
}