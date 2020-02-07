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
        private static readonly ExpressionMediatorAppender _expressionMediatorAppender = new ExpressionMediatorAppender();
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
        private static readonly NullableByteAppender _nullableByteAppender = new NullableByteAppender();
        private static readonly ByteArrayAppender _byteArrayAppender = new ByteArrayAppender();
        private static readonly Int16Appender _int16Appender = new Int16Appender();
        private static readonly NullableInt16Appender _nullableInt16Appender = new NullableInt16Appender();
        private static readonly Int32Appender _int32Appender = new Int32Appender();
        private static readonly NullableInt32Appender _nullableInt32Appender = new NullableInt32Appender();
        private static readonly Int64Appender _int64Appender = new Int64Appender();
        private static readonly NullableInt64Appender _nullableInt64Appender = new NullableInt64Appender();
        private static readonly BooleanAppender _booleanAppender = new BooleanAppender();
        private static readonly NullableBooleanAppender _nullableBooleanAppender = new NullableBooleanAppender();
        private static readonly DecimalAppender _decimalAppender = new DecimalAppender();
        private static readonly NullableDecimalAppender _nullableDecimalAppender = new NullableDecimalAppender();
        private static readonly SingleAppender _floatAppender = new SingleAppender();
        private static readonly NullableSingleAppender _nullableFloatAppender = new NullableSingleAppender();
        private static readonly DateTimeAppender _dateTimeAppender = new DateTimeAppender();
        private static readonly NullableDateTimeAppender _nullableDateTimeAppender = new NullableDateTimeAppender();
        private static readonly GuidAppender _guidAppender = new GuidAppender();
        private static readonly NullableGuidAppender _nullableGuidAppender = new NullableGuidAppender();
        private static readonly EnumAppender _enumAppender = new EnumAppender();
        private static readonly ArrayAppender _arrayAppender = new ArrayAppender();
        private static readonly ValueTypeFormatter _valueTypeFormatter = new ValueTypeFormatter();
        private static readonly EnumValueTypeFormatter _enumValueTypeFormatter = new EnumValueTypeFormatter();

        private Func<SqlStatementExecutionType, ISqlStatementAssembler> _statementAssemblerFactory;
        private Func<Type, IAssemblyPartAppender> _partAppenderFactory;
        private Func<Type, IValueTypeFormatter> _valueTypeFormatterFactory;

        private readonly IDictionary<Type, Func<IAssemblyPartAppender>> partAppenders = new Dictionary<Type, Func<IAssemblyPartAppender>>();
        private readonly IDictionary<SqlStatementExecutionType, Func<ISqlStatementAssembler>> statementAssemblers = new Dictionary<SqlStatementExecutionType, Func<ISqlStatementAssembler>>();
        private readonly IDictionary<Type, Func<IValueTypeFormatter>> valueTypeFormatters = new Dictionary<Type, Func<IValueTypeFormatter>>();
        private readonly IDictionary<Type, IAssemblyPartAppender> discoveredEnumAppenders = new Dictionary<Type, IAssemblyPartAppender>();
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
                    if (statementAssemblers.TryGetValue(sqlExecutionType, out var assemblerFactory))
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

                return _partAppenderFactory = new Func<Type, IAssemblyPartAppender>(t => ResolvePartAppender(t, t));
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
                    if (valueTypeFormatters.TryGetValue(t, out var formatterFactory))
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
            partAppenders[typeof(T)] = () => new U();
        }

        public void RegisterPartAppender<T>(IAssemblyPartAppender<T> appender)
        {
            partAppenders[typeof(T)] = () => appender;
        }

        public void RegisterPartAppender<T>(Func<IAssemblyPartAppender<T>> appenderFactory)
        {
            partAppenders[typeof(T)] = appenderFactory;
        }

        public virtual void RegisterDefaultPartAppenders()
        {
            partAppenders.Add(typeof(ExpressionSet), () => _expressionSetAppender);
            partAppenders.Add(typeof(SchemaExpression), () => _schemaAppender);
            partAppenders.Add(typeof(EntityExpression), () => _entityAppender);
            partAppenders.Add(typeof(FieldExpression), () => _fieldAppender);
            partAppenders.Add(typeof(SelectExpression), () => _selectClauseAppender);
            partAppenders.Add(typeof(SelectExpressionSet), () => _selectClauseAppender);
            partAppenders.Add(typeof(FilterExpression), () => _whereClauseAppender);
            partAppenders.Add(typeof(FilterExpressionSet), () => _whereClauseAppender);
            partAppenders.Add(typeof(JoinExpression), () => _joinClauseAppender);
            partAppenders.Add(typeof(JoinExpressionSet), () => _joinClauseAppender);
            partAppenders.Add(typeof(JoinOnExpression), () => _joinOnClauseAppender);
            partAppenders.Add(typeof(GroupByExpression), () => _groupByClauseAppender);
            partAppenders.Add(typeof(GroupByExpressionSet), () => _groupByClauseAppender);
            partAppenders.Add(typeof(HavingExpression), () => _havingClauseAppender);
            partAppenders.Add(typeof(OrderByExpression), () => _orderByClauseAppender);
            partAppenders.Add(typeof(OrderByExpressionSet), () => _orderByClauseAppender);
            partAppenders.Add(typeof(ArithmeticExpression), () => _arithmeticAppender);
            partAppenders.Add(typeof(ExpressionMediator), () => _expressionMediatorAppender);
            partAppenders.Add(typeof(CastFunctionExpression), () => _castFunctionAppender);
            partAppenders.Add(typeof(CoalesceFunctionExpression), () => _coalesceFunctionAppender);
            partAppenders.Add(typeof(ConcatFunctionExpression), () => _concatFunctionAppender);
            partAppenders.Add(typeof(IsNullFunctionExpression), () => _isNullFunctionAppender);
            partAppenders.Add(typeof(AverageFunctionExpression), () => _averageFunctionAppender);
            partAppenders.Add(typeof(MinimumFunctionExpression), () => _minimumFunctionAppender);
            partAppenders.Add(typeof(MaximumFunctionExpression), () => _maximumFunctionAppender);
            partAppenders.Add(typeof(CountFunctionExpression), () => _countFunctionAppender);
            partAppenders.Add(typeof(SumFunctionExpression), () => _sumFunctionAppender);
            partAppenders.Add(typeof(StandardDeviationFunctionExpression), () => _standardDeviationFunctionAppender);
            partAppenders.Add(typeof(PopulationStandardDeviationFunctionExpression), () => _populationStandardDeviationFunctionAppender);
            partAppenders.Add(typeof(VarianceFunctionExpression), () => _varianceFunctionAppender);
            partAppenders.Add(typeof(PopulationVarianceFunctionExpression), () => _populationVarianceFunctionAppender);
            partAppenders.Add(typeof(CurrentTimestampFunctionExpression), () => _currentTimestampFunctionAppender);
            partAppenders.Add(typeof(LiteralExpression), () => _literalAppender);
            partAppenders.Add(typeof(string), () => _stringAppender);
            partAppenders.Add(typeof(byte), () => _byteAppender);
            partAppenders.Add(typeof(byte?), () => _nullableByteAppender);
            partAppenders.Add(typeof(byte[]), () => _byteArrayAppender);
            partAppenders.Add(typeof(short), () => _int16Appender);
            partAppenders.Add(typeof(short?), () => _nullableInt16Appender);
            partAppenders.Add(typeof(int), () => _int32Appender);
            partAppenders.Add(typeof(int?), () => _nullableInt32Appender);
            partAppenders.Add(typeof(long), () => _int64Appender);
            partAppenders.Add(typeof(long?), () => _nullableInt64Appender);
            partAppenders.Add(typeof(bool), () => _booleanAppender);
            partAppenders.Add(typeof(bool?), () => _nullableBooleanAppender);
            partAppenders.Add(typeof(decimal), () => _decimalAppender);
            partAppenders.Add(typeof(decimal?), () => _nullableDecimalAppender);
            partAppenders.Add(typeof(float), () => _floatAppender);
            partAppenders.Add(typeof(float?), () => _nullableFloatAppender);
            partAppenders.Add(typeof(DateTime), () => _dateTimeAppender);
            partAppenders.Add(typeof(DateTime?), () => _nullableDateTimeAppender);
            partAppenders.Add(typeof(Guid), () => _guidAppender);
            partAppenders.Add(typeof(Guid?), () => _nullableGuidAppender);
            partAppenders.Add(typeof(Enum), () => _enumAppender);
            partAppenders.Add(typeof(Array), () => _arrayAppender);
        }

        public virtual void RegisterAssembler<T>(SqlStatementExecutionType statementExecutionType)
            where T : class, ISqlStatementAssembler, new()
        {
            statementAssemblers[statementExecutionType] = () => new T();
        }

        public virtual void RegisterAssembler<T>(SqlStatementExecutionType statementExecutionType, T assembler)
            where T : class, ISqlStatementAssembler
        {
            statementAssemblers[statementExecutionType] = () => assembler;
        }

        public virtual void RegisterDefaultAssemblers()
        {
            statementAssemblers.Add(SqlStatementExecutionType.SelectOneType, () => _selectSqlStatementAssembler);
            statementAssemblers.Add(SqlStatementExecutionType.SelectOneDynamic, () => _selectSqlStatementAssembler);
            statementAssemblers.Add(SqlStatementExecutionType.SelectOneValue, () => _selectSqlStatementAssembler);
            statementAssemblers.Add(SqlStatementExecutionType.SelectManyType, () => _selectSqlStatementAssembler);
            statementAssemblers.Add(SqlStatementExecutionType.SelectManyDynamic, () => _selectSqlStatementAssembler);
            statementAssemblers.Add(SqlStatementExecutionType.SelectManyValue, () => _selectSqlStatementAssembler);
            statementAssemblers.Add(SqlStatementExecutionType.Insert, () => _insertSqlStatementAssembler);
            statementAssemblers.Add(SqlStatementExecutionType.Update, () => _updateSqlStatementAssembler);
            statementAssemblers.Add(SqlStatementExecutionType.Delete, () => _deleteSqlStatementAssembler);
        }

        public void RegisterValueFormatter<T, U>()
           where T : IComparable
           where U : class, IValueTypeFormatter<T>, new()
        {
            valueTypeFormatters[typeof(T)] = () => new U();
        }

        public void RegisterValueFormatter<T>(IValueTypeFormatter<T> valueFormatter)
            where T : IComparable, IValueTypeFormatter
        {
            valueTypeFormatters[typeof(T)] = () => valueFormatter;
        }

        public void RegisterValueFormatter<T>(Func<IValueTypeFormatter<T>> valueFormatterFactory)
            where T : IComparable, IValueTypeFormatter
        {
            valueTypeFormatters[typeof(T)] = valueFormatterFactory;
        }

        public virtual void RegisterDefaultValueFormatters()
        {
            valueTypeFormatters.Add(typeof(string), () => _valueTypeFormatter);
            valueTypeFormatters.Add(typeof(bool), () => _valueTypeFormatter);
            valueTypeFormatters.Add(typeof(byte), () => _valueTypeFormatter);
            valueTypeFormatters.Add(typeof(short), () => _valueTypeFormatter);
            valueTypeFormatters.Add(typeof(int), () => _valueTypeFormatter);
            valueTypeFormatters.Add(typeof(long), () => _valueTypeFormatter);
            valueTypeFormatters.Add(typeof(decimal), () => _valueTypeFormatter);
            valueTypeFormatters.Add(typeof(float), () => _valueTypeFormatter);
            valueTypeFormatters.Add(typeof(DateTime), () => _valueTypeFormatter);
            valueTypeFormatters.Add(typeof(Guid), () => _valueTypeFormatter);
            valueTypeFormatters.Add(typeof(Enum), () => _enumValueTypeFormatter);
        }

        public ISqlStatementBuilder CreateSqlStatementBuilder(DbExpressionAssemblerConfiguration config, ExpressionSet expression, IAppender appender, ISqlParameterBuilder parameterBuilder)
            => new SqlStatementBuilder(config, expression, AssemblerFactory, PartAppenderFactory, ValueTypeFormatterFactory, appender, parameterBuilder);

        private IAssemblyPartAppender ResolvePartAppender(Type current, Type original)
        {
            if (partAppenders.TryGetValue(current, out Func<IAssemblyPartAppender> appenderFactory))
                return appenderFactory();
            
            if (current.BaseType == typeof(object))
                return ResolveEnumPartAppender(original, original) ?? throw new DbExpressionConfigurationException($"Could not resolve a part appender for type '{original}', please ensure an appender has been registered for type '{original}'");

            if (current.BaseType == null)
                throw new DbExpressionConfigurationException($"Could not resolve a part appender for type '{original}', please ensure an appender has been registered for type '{original}'");

            return ResolvePartAppender(current.BaseType, original);
        }

        private IAssemblyPartAppender ResolveEnumPartAppender(Type current, Type original)
        {
            if (!current.IsGenericType)
                return null;

            var generic = current.GetGenericArguments();
            if (generic[0].IsEnum)
            {
                partAppenders.Add(original, () => _enumAppender);
                return ResolvePartAppender(original, original);
            }

            return ResolveEnumPartAppender(current.BaseType, original);
        }
        #endregion
    }
}
