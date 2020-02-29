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

        public U FormatValueType<T, U>(T value)
            where T : IConvertible
            where U : IComparable
        {
            if (!(ValueTypeFormatterFactory(typeof(U)) is IValueTypeFormatter formatter))
                throw new DbExpressionConfigurationException($"Could not resolve a value formatter for type '{value.GetType()}', please ensure an value formatter has been registered during startup initialization of DbExpression.");

            return (U)formatter.Format(value);
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
            where T : class, IAssemblyPart
            => AppendPart(new ExpressionContainer(part), context);

        public void AppendPart(ExpressionContainer part, AssemblyContext context)
        {
            if (part.Object is ExpressionSet set)
            {
                AssembleStatement(set, context);
            }
            else
            {
                var appender = PartAppenderFactory(part.Type);
                if (appender == null)
                {
                    throw new DbExpressionConfigurationException($"Could not resolve an appender for part type '{part.Type}', please ensure an appender has been registered during startup initialization of DbExpression.");
                }

                appender.AppendPart(part.Object, this, context);
            }
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