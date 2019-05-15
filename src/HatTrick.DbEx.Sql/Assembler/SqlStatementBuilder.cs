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
        public Func<SqlStatementExecutionType, ISqlStatementAssembler> AssemblerResolver { get; }
        public Func<Type, IAssemblyPartAppender> PartAppenderResolver { get; }
        public Func<Type, IValueTypeFormatter> ValueTypeFormatterResolver { get; }
        public IAppender Appender { get; }
        public ISqlParameterBuilder Parameters { get; }

        public SqlStatementBuilder(
            DbExpressionAssemblerConfiguration config,
            ExpressionSet dbExpression,
            Func<SqlStatementExecutionType, ISqlStatementAssembler> assemblerResolver,
            Func<Type, IAssemblyPartAppender> partAppenderResolver,
            Func<Type, IValueTypeFormatter> valueTypeFormatterResolver,
            IAppender appender,
            ISqlParameterBuilder parameterBuilder
        )
        {
            AssemblerConfiguration = config;
            ExpressionSet = dbExpression;
            AssemblerResolver = assemblerResolver;
            PartAppenderResolver = partAppenderResolver;
            ValueTypeFormatterResolver = valueTypeFormatterResolver;
            Appender = appender;
            Parameters = parameterBuilder;
        }

        protected virtual IAssemblyPartAppender ResolvePartAppender(Type t)
            => PartAppenderResolver(t);

        protected virtual IAssemblyPartAppender<T> ResolvePartAppender<T>()
            where T : IAssemblyPart
            => PartAppenderResolver(typeof(T)) as IAssemblyPartAppender<T>;

        protected virtual IValueTypeFormatter ResolveValueFormatter<T>()
            where T : IComparable
            => ValueTypeFormatterResolver(typeof(T)) as IValueTypeFormatter;

        protected virtual IValueTypeFormatter ResolveValueFormatter(Type t)
            => ValueTypeFormatterResolver(t);

        public string FormatValueType((Type, object) value)
        {
            var formatter = ResolveValueFormatter(value.Item1);
            return formatter.Format(value.Item2);
        }

        public string FormatValueType<T>(object value)
            where T : IComparable
        {
            var formatter = ResolveValueFormatter<T>();
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

            AssemblerResolver(ExpressionSet.StatementExecutionType).AssembleStatement(ExpressionSet, this, context);
            _sqlStatement = new SqlStatement(Appender, Parameters.Parameters, DbCommandType.SqlText);

            return _sqlStatement;
        }

        public void AppendPart<T>(object part)
          where T : class, IAssemblyPart => AppendPart(part as T, new AssemblyContext());

        public void AppendPart((Type, object) part, AssemblyContext context)
        {
            var assembler = ResolvePartAppender(part.Item1);
            assembler.AppendPart(part.Item2, this, context);
        }

        public void AppendPart<T>(T part, AssemblyContext context)
            where T : class, IAssemblyPart
        {
            var assembler = ResolvePartAppender(typeof(T));
            assembler.AppendPart(part, this, context);
        }

        public string GenerateAlias() => $"_t{++_currentAliasCounter}";
    }
}
