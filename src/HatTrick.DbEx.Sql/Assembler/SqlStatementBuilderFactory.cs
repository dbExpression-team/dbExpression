using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class SqlStatementBuilderFactory : ISqlStatementBuilderFactory
    {
        #region internals
        private static readonly SelectSqlStatementAssembler _selectSqlStatementAssembler = new SelectSqlStatementAssembler();
        private static readonly InsertSqlStatementAssembler _insertSqlStatementAssembler = new InsertSqlStatementAssembler();
        private static readonly UpdateSqlStatementAssembler _updateSqlStatementAssembler = new UpdateSqlStatementAssembler();
        private static readonly DeleteSqlStatementAssembler _deleteSqlStatementAssembler = new DeleteSqlStatementAssembler();
        private static readonly ExpressionSetAppender _expressionSetAppender = new ExpressionSetAppender();
        private static readonly SchemaAppender _schemaAppender = new SchemaAppender();
        private static readonly EntityAppender _entityAppender = new EntityAppender();
        private static readonly FieldAppender _fieldAppender = new FieldAppender();
        private static readonly SelectAppender _selectClauseAppender = new SelectAppender();
        private static readonly FilterAppender _whereClauseAppender = new FilterAppender();
        private static readonly JoinAppender _joinClauseAppender = new JoinAppender();
        private static readonly JoinOnAppender _joinOnClauseAppender = new JoinOnAppender();
        private static readonly GroupByAppender _groupByClauseAppender = new GroupByAppender();
        private static readonly HavingAppender _havingClauseAppender = new HavingAppender();
        private static readonly OrderByAppender _orderByClauseAppender = new OrderByAppender();
        private static readonly ArithmeticAppender _arithmeticAppender = new ArithmeticAppender();
        private static readonly CastFunctionAppender _castFunctionAppender = new CastFunctionAppender();
        private static readonly CoalesceFunctionAppender _coalesceFunctionAppender = new CoalesceFunctionAppender();
        private static readonly ConcatFunctionAppender _concatFunctionAppender = new ConcatFunctionAppender();
        private static readonly IsNullFunctionAppender _isNullFunctionAppender = new IsNullFunctionAppender();
        private static readonly AverageFunctionAppender _averageFunctionAppender = new AverageFunctionAppender();
        private static readonly MinimumFunctionAppender _minimumFunctionAppender = new MinimumFunctionAppender();
        private static readonly MaximumFunctionAppender _maximumFunctionAppender = new MaximumFunctionAppender();
        private static readonly CountFunctionAppender _countFunctionAppender = new CountFunctionAppender();
        private static readonly SumFunctionAppender _sumFunctionAppender = new SumFunctionAppender();
        private static readonly StandardDeviationFunctionAppender _standardDeviationFunctionAppender = new StandardDeviationFunctionAppender();
        private static readonly PopulationStandardDeviationFunctionAppender _populationStandardDeviationFunctionAppender = new PopulationStandardDeviationFunctionAppender();
        private static readonly VarianceFunctionAppender _varianceFunctionAppender = new VarianceFunctionAppender();
        private static readonly PopulationVarianceFunctionAppender _populationVarianceFunctionAppender = new PopulationVarianceFunctionAppender();
        private static readonly CurrentTimestampFunctionAppender _currentTimestampFunctionAppender = new CurrentTimestampFunctionAppender();
        private static readonly LiteralAppender _literalAppender = new LiteralAppender();
        private static readonly StringAppender _stringAppender = new StringAppender();
        private static readonly ByteAppender _byteAppender = new ByteAppender();
        private static readonly ByteArrayAppender _byteArrayAppender = new ByteArrayAppender();
        private static readonly Int16Appender _int16Appender = new Int16Appender();
        private static readonly Int32Appender _int32Appender = new Int32Appender();
        private static readonly Int64Appender _int64Appender = new Int64Appender();
        private static readonly BooleanAppender _booleanAppender = new BooleanAppender();
        private static readonly DecimalAppender _decimalAppender = new DecimalAppender();
        private static readonly DateTimeAppender _dateTimeAppender = new DateTimeAppender();
        private static readonly GuidAppender _guidAppender = new GuidAppender();
        private static readonly EnumAppender _enumAppender = new EnumAppender();
        private static readonly ArrayAppender _arrayAppender = new ArrayAppender();
        private static readonly ValueTypeFormatter _valueTypeFormatter = new ValueTypeFormatter();
        private static readonly EnumValueTypeFormatter _enumValueTypeFormatter = new EnumValueTypeFormatter();

        private Func<SqlStatementExecutionType, ISqlStatementAssembler> _statementAssemblerFactory;
        private Func<Type, IAssemblyPartAppender> _partAppenderFactory;
        private Func<Type, IValueTypeFormatter> _valueTypeFormatterFactory;

        private readonly IDictionary<Type, Func<IAssemblyPartAppender>> PartAppenders = new Dictionary<Type, Func<IAssemblyPartAppender>>();
        private readonly IDictionary<SqlStatementExecutionType, Func<ISqlStatementAssembler>> StatementAssemblers = new Dictionary<SqlStatementExecutionType, Func<ISqlStatementAssembler>>();
        private readonly IDictionary<Type, Func<IValueTypeFormatter>> ValueTypeFormatters = new Dictionary<Type, Func<IValueTypeFormatter>>();
        #endregion

        #region interface
        public virtual Func<SqlStatementExecutionType, ISqlStatementAssembler> AssemblerFactory
        {
            get
            {
                if (_statementAssemblerFactory != null)
                    return _statementAssemblerFactory;

                return _statementAssemblerFactory = new Func<SqlStatementExecutionType, ISqlStatementAssembler>(sqlExecutionType =>
                {
                    if (StatementAssemblers.TryGetValue(sqlExecutionType, out var assemblerFactory))
                        return assemblerFactory();

                    throw new DbExpressionConfigurationException($"Could not resolve an assembler, please ensure an executor has been registered for sql statement execution type of '{sqlExecutionType}'");
                });
            }
        }

        public virtual Func<Type, IAssemblyPartAppender> PartAppenderFactory
        {
            get
            {
                if (_partAppenderFactory != null)
                    return _partAppenderFactory;

                return _partAppenderFactory = new Func<Type, IAssemblyPartAppender>(t => ResolvePartAppenderFactory(t, t));
            }
        }

        public virtual Func<Type, IValueTypeFormatter> ValueTypeFormatterFactory
        {
            get
            {
                if (_valueTypeFormatterFactory != null)
                    return _valueTypeFormatterFactory;

                return _valueTypeFormatterFactory = new Func<Type, IValueTypeFormatter>(t =>
                {
                    if (ValueTypeFormatters.TryGetValue(t, out var formatterFactory))
                        return formatterFactory();

                    throw new DbExpressionConfigurationException($"Could not resolve a formatter, please ensure a formatter has been registered for type '{t}'");
                });
            }
        }
        #endregion

        #region methods
        public void RegisterPartAppender<T, U>()
            where U : class, IAssemblyPartAppender<T>, new()
        {
            PartAppenders[typeof(T)] = () => new U();
        }

        public void RegisterPartAppender<T>(IAssemblyPartAppender<T> appender)
        {
            PartAppenders[typeof(T)] = () => appender;
        }

        public void RegisterPartAppender<T>(Func<IAssemblyPartAppender<T>> appenderFactory)
        {
            PartAppenders[typeof(T)] = appenderFactory;
        }

        public virtual void RegisterDefaultPartAppenders()
        {
            PartAppenders.Add(typeof(ExpressionSet), () => _expressionSetAppender);
            PartAppenders.Add(typeof(SchemaExpression), () => _schemaAppender);
            PartAppenders.Add(typeof(EntityExpression), () => _entityAppender);
            PartAppenders.Add(typeof(FieldExpression), () => _fieldAppender);
            PartAppenders.Add(typeof(SelectExpression), () => _selectClauseAppender);
            PartAppenders.Add(typeof(SelectExpressionSet), () => _selectClauseAppender);
            PartAppenders.Add(typeof(FilterExpression), () => _whereClauseAppender);
            PartAppenders.Add(typeof(FilterExpressionSet), () => _whereClauseAppender);
            PartAppenders.Add(typeof(JoinExpression), () => _joinClauseAppender);
            PartAppenders.Add(typeof(JoinExpressionSet), () => _joinClauseAppender);
            PartAppenders.Add(typeof(JoinOnExpression), () => _joinOnClauseAppender);
            PartAppenders.Add(typeof(GroupByExpression), () => _groupByClauseAppender);
            PartAppenders.Add(typeof(GroupByExpressionSet), () => _groupByClauseAppender);
            PartAppenders.Add(typeof(HavingExpression), () => _havingClauseAppender);
            PartAppenders.Add(typeof(OrderByExpression), () => _orderByClauseAppender);
            PartAppenders.Add(typeof(OrderByExpressionSet), () => _orderByClauseAppender);
            PartAppenders.Add(typeof(ArithmeticExpression), () => _arithmeticAppender);
            PartAppenders.Add(typeof(CastFunctionExpression), () => _castFunctionAppender);
            PartAppenders.Add(typeof(CoalesceFunctionExpression), () => _coalesceFunctionAppender);
            PartAppenders.Add(typeof(ConcatFunctionExpression), () => _concatFunctionAppender);
            PartAppenders.Add(typeof(IsNullFunctionExpression), () => _isNullFunctionAppender);
            PartAppenders.Add(typeof(AverageFunctionExpression), () => _averageFunctionAppender);
            PartAppenders.Add(typeof(MinimumFunctionExpression), () => _minimumFunctionAppender);
            PartAppenders.Add(typeof(MaximumFunctionExpression), () => _maximumFunctionAppender);
            PartAppenders.Add(typeof(CountFunctionExpression), () => _countFunctionAppender);
            PartAppenders.Add(typeof(SumFunctionExpression), () => _sumFunctionAppender);
            PartAppenders.Add(typeof(StandardDeviationFunctionExpression), () => _standardDeviationFunctionAppender);
            PartAppenders.Add(typeof(PopulationStandardDeviationFunctionExpression), () => _populationStandardDeviationFunctionAppender);
            PartAppenders.Add(typeof(VarianceFunctionExpression), () => _varianceFunctionAppender);
            PartAppenders.Add(typeof(PopulationVarianceFunctionExpression), () => _populationVarianceFunctionAppender);
            PartAppenders.Add(typeof(CurrentTimestampFunctionExpression), () => _currentTimestampFunctionAppender);
            PartAppenders.Add(typeof(LiteralExpression), () => _literalAppender);
            PartAppenders.Add(typeof(string), () => _stringAppender);
            PartAppenders.Add(typeof(byte), () => _byteAppender);
            PartAppenders.Add(typeof(byte[]), () => _byteArrayAppender);
            PartAppenders.Add(typeof(short), () => _int16Appender);
            PartAppenders.Add(typeof(int), () => _int32Appender);
            PartAppenders.Add(typeof(long), () => _int64Appender);
            PartAppenders.Add(typeof(bool), () => _booleanAppender);
            PartAppenders.Add(typeof(decimal), () => _decimalAppender);
            PartAppenders.Add(typeof(DateTime), () => _dateTimeAppender);
            PartAppenders.Add(typeof(Guid), () => _guidAppender);
            PartAppenders.Add(typeof(Enum), () => _enumAppender);
            PartAppenders.Add(typeof(Array), () => _arrayAppender);
        }

        public virtual void RegisterAssembler<T>(SqlStatementExecutionType statementExecutionType)
            where T : class, ISqlStatementAssembler, new()
        {
            StatementAssemblers[statementExecutionType] = () => new T();
        }

        public virtual void RegisterAssembler<T>(SqlStatementExecutionType statementExecutionType, T assembler)
            where T : class, ISqlStatementAssembler
        {
            StatementAssemblers[statementExecutionType] = () => assembler;
        }

        public virtual void RegisterDefaultAssemblers()
        {
            StatementAssemblers.Add(SqlStatementExecutionType.SelectOneType, () => _selectSqlStatementAssembler);
            StatementAssemblers.Add(SqlStatementExecutionType.SelectOneDynamic, () => _selectSqlStatementAssembler);
            StatementAssemblers.Add(SqlStatementExecutionType.SelectOneValue, () => _selectSqlStatementAssembler);
            StatementAssemblers.Add(SqlStatementExecutionType.SelectManyType, () => _selectSqlStatementAssembler);
            StatementAssemblers.Add(SqlStatementExecutionType.SelectManyDynamic, () => _selectSqlStatementAssembler);
            StatementAssemblers.Add(SqlStatementExecutionType.SelectManyValue, () => _selectSqlStatementAssembler);
            StatementAssemblers.Add(SqlStatementExecutionType.Insert, () => _insertSqlStatementAssembler);
            StatementAssemblers.Add(SqlStatementExecutionType.Update, () => _updateSqlStatementAssembler);
            StatementAssemblers.Add(SqlStatementExecutionType.Delete, () => _deleteSqlStatementAssembler);
        }

        public void RegisterValueFormatter<T, U>()
           where T : IComparable
           where U : class, IValueTypeFormatter<T>, new()
        {
            ValueTypeFormatters[typeof(T)] = () => new U();
        }

        public void RegisterValueFormatter<T>(IValueTypeFormatter<T> valueFormatter)
            where T : IComparable, IValueTypeFormatter
        {
            ValueTypeFormatters[typeof(T)] = () => valueFormatter;
        }

        public void RegisterValueFormatter<T>(Func<IValueTypeFormatter<T>> valueFormatterFactory)
            where T : IComparable, IValueTypeFormatter
        {
            ValueTypeFormatters[typeof(T)] = valueFormatterFactory;
        }

        public virtual void RegisterDefaultValueFormatters()
        {
            ValueTypeFormatters.Add(typeof(string), () => _valueTypeFormatter);
            ValueTypeFormatters.Add(typeof(bool), () => _valueTypeFormatter);
            ValueTypeFormatters.Add(typeof(byte), () => _valueTypeFormatter);
            ValueTypeFormatters.Add(typeof(short), () => _valueTypeFormatter);
            ValueTypeFormatters.Add(typeof(int), () => _valueTypeFormatter);
            ValueTypeFormatters.Add(typeof(long), () => _valueTypeFormatter);
            ValueTypeFormatters.Add(typeof(decimal), () => _valueTypeFormatter);
            ValueTypeFormatters.Add(typeof(DateTime), () => _valueTypeFormatter);
            ValueTypeFormatters.Add(typeof(Guid), () => _valueTypeFormatter);
            ValueTypeFormatters.Add(typeof(Enum), () => _enumValueTypeFormatter);
        }

        public ISqlStatementBuilder CreateSqlStatementBuilder(DbExpressionAssemblerConfiguration config, ExpressionSet expression, IAppender appender, ISqlParameterBuilder parameterBuilder)
            => new SqlStatementBuilder(config, expression, AssemblerFactory, PartAppenderFactory, ValueTypeFormatterFactory, appender, parameterBuilder);

        private IAssemblyPartAppender ResolvePartAppenderFactory(Type current, Type original)
        {
            if (PartAppenders.TryGetValue(current, out Func<IAssemblyPartAppender> appenderFactory))
                return appenderFactory();

            if (current.BaseType == null)
                throw new DbExpressionConfigurationException($"Could not resolve a part appender for type '{original}', please ensure an appender has been registered for type '{original}'");

            return ResolvePartAppenderFactory(current.BaseType, original);
        }
        #endregion
    }
}
