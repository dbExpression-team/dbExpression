using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SqlStatementBuilder : 
        ISqlStatementBuilder
    {
        #region internals
        private int _currentAliasCounter;
        private SqlStatement _sqlStatement;
        #endregion

        public DbExpressionAssemblerConfiguration Configuration { get; }
        public ExpressionSet DBExpression { get; }
        public Func<ExecutionContext, ISqlStatementAssembler> AssemblerResolver { get; }
        public Func<Type, IAssemblyPartAliasProvider> AliasProviderResolver { get; }
        public Func<Type, IAssemblyPartAppender> PartAppenderResolver { get; }
        public Func<Type, IValueTypeFormatter> ValueTypeFormatterResolver { get; }
        public IAppender Appender { get; }
        public ISqlParameterBuilder Parameters { get; }

        public SqlStatementBuilder(
            DbExpressionAssemblerConfiguration config,
            ExpressionSet dbExpression,
            Func<ExecutionContext, ISqlStatementAssembler> assemblerResolver,
            Func<Type, IAssemblyPartAliasProvider> aliasProviderResolver,
            Func<Type, IAssemblyPartAppender> partAppenderResolver,
            Func<Type, IValueTypeFormatter> valueTypeFormatterResolver,
            IAppender appender,
            ISqlParameterBuilder parameterBuilder
        )
        {
            Configuration = config;
            DBExpression = dbExpression;
            AssemblerResolver = assemblerResolver;
            AliasProviderResolver = aliasProviderResolver;
            PartAppenderResolver = partAppenderResolver;
            ValueTypeFormatterResolver = valueTypeFormatterResolver;
            Appender = appender;
            Parameters = parameterBuilder;
        }

        protected virtual IAssemblyPartAppender ResolvePartAppender(Type t)
            => PartAppenderResolver(t);

        protected virtual IValueTypeFormatter<T> ResolveValueFormatter<T>()
            where T : IComparable
            => ValueTypeFormatterResolver(typeof(T)) as IValueTypeFormatter<T>;

        protected virtual IValueTypeFormatter ResolveValueFormatter(Type t)
            => ValueTypeFormatterResolver(t);

        protected virtual IAssemblyPartAppender<T> ResolvePartAppender<T>()
            where T : IAssemblyPart
            => PartAppenderResolver(typeof(T)) as IAssemblyPartAppender<T>;

        protected virtual IAssemblyPartAliasProvider<T> ResolveAliasProvider<T>()
            where T : IAssemblyPart
            => AliasProviderResolver(typeof(T)) as IAssemblyPartAliasProvider<T>;

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

            var discoveredAliases = new Dictionary<int, AliasDiscovery>();
            DiscoverAliases(DBExpression, 0, Configuration, discoveredAliases);
            var context = new AssemblerContext
            {
                Configuration = Configuration,
                EntityAliases = discoveredAliases,
                CurrentDepth = 0
            };

            AssemblerResolver(DBExpression.ExecutionContext).AssembleStatement(DBExpression, this, context);
            _sqlStatement = new SqlStatement(Appender.ToString(), Parameters.Parameters, DbCommandType.SqlText);

            return _sqlStatement;
        }

        public void DiscoverAliases<T>(T expression, int currentLevel, DbExpressionAssemblerConfiguration config, IDictionary<int, AliasDiscovery> discoveredAliases)
            where T : IAssemblyPart
        {
            var provider = ResolveAliasProvider<T>();
            if (provider == null)
                return;

            provider.DiscoverAliases(expression, this, currentLevel, config, discoveredAliases);
        }

        public void AppendPart<T>(object part)
          where T : IAssemblyPart => AppendPart<T>(part, new AssemblerContext());

        public void AppendPart((Type, object) part, AssemblerContext context)
        {
            if (part.Item2 is ExpressionSet set)
            {
                AssemblerResolver(set.ExecutionContext).AssembleStatement(set, this, context);
                return;
            }
            var assembler = ResolvePartAppender(part.Item1);
            assembler.AppendPart(part.Item2, this, context);
        }

        public void AppendPart<T>(object part, AssemblerContext context)
            where T : IAssemblyPart
        {
            if (part is ExpressionSet set)
            {
                AssemblerResolver(set.ExecutionContext).AssembleStatement(set, this, context);
                return;
            }
            var assembler = ResolvePartAppender(typeof(T));
            assembler.AppendPart(part, this, context);
        }

        public string GenerateAlias() => $"t{++_currentAliasCounter}";
    }
}
