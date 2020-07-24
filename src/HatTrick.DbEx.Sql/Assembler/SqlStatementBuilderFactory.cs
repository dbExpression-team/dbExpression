using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class SqlStatementBuilderFactory : ISqlStatementBuilderFactory
    {
        #region internals
        #region  expression appenders
        private static readonly SelectSqlStatementAssembler _selectSqlStatementAssembler = new SelectSqlStatementAssembler();
        private static readonly InsertSqlStatementAssembler _insertSqlStatementAssembler = new InsertSqlStatementAssembler();
        private static readonly UpdateSqlStatementAssembler _updateSqlStatementAssembler = new UpdateSqlStatementAssembler();
        private static readonly DeleteSqlStatementAssembler _deleteSqlStatementAssembler = new DeleteSqlStatementAssembler();
        private static readonly SchemaExpressionPartAppender _schemaAppender = new SchemaExpressionPartAppender();
        private static readonly EntityExpressionPartAppender _entityAppender = new EntityExpressionPartAppender();
        private static readonly FieldExpressionPartAppender _fieldAppender = new FieldExpressionPartAppender();
        private static readonly AssignmentExpressionPartAppender _assignmentAppender = new AssignmentExpressionPartAppender();
        private static readonly AssignmentExpressionSetPartAppender _assignmentSetAppender = new AssignmentExpressionSetPartAppender();
        private static readonly SelectExpressionPartAppender _selectAppender = new SelectExpressionPartAppender();
        private static readonly SelectExpressionSetPartAppender _selectSetAppender = new SelectExpressionSetPartAppender();
        private static readonly FilterExpressionPartAppender _filterAppender = new FilterExpressionPartAppender();
        private static readonly FilterExpressionSetPartAppender _filterSetAppender = new FilterExpressionSetPartAppender();
        private static readonly JoinExpressionPartAppender _joinAppender = new JoinExpressionPartAppender();
        private static readonly JoinExpressionSetPartAppender _joinSetAppender = new JoinExpressionSetPartAppender();
        private static readonly JoinOnExpressionPartAppender _joinOnClauseAppender = new JoinOnExpressionPartAppender();
        private static readonly GroupByExpressionPartAppender _groupByAppender = new GroupByExpressionPartAppender();
        private static readonly GroupByExpressionSetPartAppender _groupBySetAppender = new GroupByExpressionSetPartAppender();
        private static readonly HavingExpressionPartAppender _havingClauseAppender = new HavingExpressionPartAppender();
        private static readonly OrderByExpressionPartAppender _orderByAppender = new OrderByExpressionPartAppender();
        private static readonly OrderByExpressionSetPartAppender _orderBySetAppender = new OrderByExpressionSetPartAppender();
        private static readonly ArithmeticExpressionPartAppender _arithmeticAppender = new ArithmeticExpressionPartAppender();
        private static readonly ExpressionMediatorPartAppender _expressionMediatorAppender = new ExpressionMediatorPartAppender();
        private static readonly CastFunctionExpressionPartAppender _castFunctionAppender = new CastFunctionExpressionPartAppender();
        private static readonly CoalesceFunctionExpressionPartAppender _coalesceFunctionAppender = new CoalesceFunctionExpressionPartAppender();
        private static readonly ConcatFunctionExpressionPartAppender _concatFunctionAppender = new ConcatFunctionExpressionPartAppender();
        private static readonly IsNullFunctionExpressionPartAppender _isNullFunctionAppender = new IsNullFunctionExpressionPartAppender();
        private static readonly AverageFunctionExpressionPartAppender _averageFunctionAppender = new AverageFunctionExpressionPartAppender();
        private static readonly MinimumFunctionExpressionPartAppender _minimumFunctionAppender = new MinimumFunctionExpressionPartAppender();
        private static readonly MaximumFunctionExpressionPartAppender _maximumFunctionAppender = new MaximumFunctionExpressionPartAppender();
        private static readonly CountFunctionExpressionPartAppender _countFunctionAppender = new CountFunctionExpressionPartAppender();
        private static readonly SumFunctionExpressionPartAppender _sumFunctionAppender = new SumFunctionExpressionPartAppender();
        private static readonly StandardDeviationFunctionExpressionPartAppender _standardDeviationFunctionAppender = new StandardDeviationFunctionExpressionPartAppender();
        private static readonly PopulationStandardDeviationFunctionExpressionPartAppender _populationStandardDeviationFunctionAppender = new PopulationStandardDeviationFunctionExpressionPartAppender();
        private static readonly VarianceFunctionExpressionPartAppender _varianceFunctionAppender = new VarianceFunctionExpressionPartAppender();
        private static readonly PopulationVarianceFunctionExpressionPartAppender _populationVarianceFunctionAppender = new PopulationVarianceFunctionExpressionPartAppender();
        private static readonly CurrentTimestampFunctionExpressionPartAppender _currentTimestampFunctionAppender = new CurrentTimestampFunctionExpressionPartAppender();
        private static readonly FloorFunctionExpressionPartAppender _floorFunctionAppender = new FloorFunctionExpressionPartAppender();
        private static readonly CeilingFunctionExpressionPartAppender _ceilingFunctionAppender = new CeilingFunctionExpressionPartAppender();
        private static readonly LiteralExpressionPartAppender _literalAppender = new LiteralExpressionPartAppender();
        #endregion

        #region value type appenders 
        private static readonly ValueTypePartAppender<bool> _booleanAppender = new ValueTypePartAppender<bool>();
        private static readonly NullableValueTypePartAppender<bool?> _nullableBooleanAppender = new NullableValueTypePartAppender<bool?>();
        private static readonly ValueTypePartAppender<byte> _byteAppender = new ValueTypePartAppender<byte>();
        private static readonly NullableValueTypePartAppender<byte?> _nullableByteAppender = new NullableValueTypePartAppender<byte?>();
        private static readonly ByteArrayPartAppender _byteArrayAppender = new ByteArrayPartAppender();
        private static readonly ValueTypePartAppender<DateTime> _dateTimeAppender = new ValueTypePartAppender<DateTime>();
        private static readonly NullableValueTypePartAppender<DateTime?> _nullableDateTimeAppender = new NullableValueTypePartAppender<DateTime?>();
        private static readonly ValueTypePartAppender<DateTimeOffset> _dateTimeOffsetAppender = new ValueTypePartAppender<DateTimeOffset>();
        private static readonly NullableValueTypePartAppender<DateTimeOffset?> _nullableDateTimeOffsetAppender = new NullableValueTypePartAppender<DateTimeOffset?>();
        private static readonly ValueTypePartAppender<decimal> _decimalAppender = new ValueTypePartAppender<decimal>();
        private static readonly NullableValueTypePartAppender<decimal?> _nullableDecimalAppender = new NullableValueTypePartAppender<decimal?>();
        private static readonly ValueTypePartAppender<double> _doubleAppender = new ValueTypePartAppender<double>();
        private static readonly NullableValueTypePartAppender<double?> _nullableDoubleAppender = new NullableValueTypePartAppender<double?>();
        private static readonly ValueTypePartAppender<float> _floatAppender = new ValueTypePartAppender<float>();
        private static readonly NullableValueTypePartAppender<float?> _nullableFloatAppender = new NullableValueTypePartAppender<float?>();
        private static readonly ValueTypePartAppender<Guid> _guidAppender = new ValueTypePartAppender<Guid>();
        private static readonly NullableValueTypePartAppender<Guid?> _nullableGuidAppender = new NullableValueTypePartAppender<Guid?>();
        private static readonly ValueTypePartAppender<int> _int32Appender = new ValueTypePartAppender<int>();
        private static readonly NullableValueTypePartAppender<int?> _nullableInt32Appender = new NullableValueTypePartAppender<int?>();
        private static readonly ValueTypePartAppender<long> _int64Appender = new ValueTypePartAppender<long>();
        private static readonly NullableValueTypePartAppender<long?> _nullableInt64Appender = new NullableValueTypePartAppender<long?>();
        private static readonly ValueTypePartAppender<short> _int16Appender = new ValueTypePartAppender<short>();
        private static readonly NullableValueTypePartAppender<short?> _nullableInt16Appender = new NullableValueTypePartAppender<short?>();
        private static readonly EnumValueTypePartAppender _enumAppender = new EnumValueTypePartAppender();
        private static readonly ValueTypePartAppender<string> _stringAppender = new ValueTypePartAppender<string>();
        private static readonly DBNullValueTypePartAppender _dbNullAppender = new DBNullValueTypePartAppender();
        #endregion

        private Func<Type, ISqlStatementAssembler> _statementAssemblerFactory;
        private Func<Type, IAssemblyPartAppender> _partAppenderFactory;

        private readonly ConcurrentDictionary<Type, Func<IAssemblyPartAppender>> _partAppenders = new ConcurrentDictionary<Type, Func<IAssemblyPartAppender>>();
        private readonly ConcurrentDictionary<Type, Func<ISqlStatementAssembler>> _statementAssemblers = new ConcurrentDictionary<Type, Func<ISqlStatementAssembler>>();
        #endregion

        #region interface
        public virtual Func<Type, ISqlStatementAssembler> AssemblerFactory
            => _statementAssemblerFactory ?? (_statementAssemblerFactory = new Func<Type, ISqlStatementAssembler>(sqlExecutionType =>
                {
                    if (_statementAssemblers.TryGetValue(sqlExecutionType, out var assemblerFactory))
                        return assemblerFactory();

                    throw new DbExpressionConfigurationException($"Could not resolve an assembler, please ensure an executor has been registered for sql statement execution type of '{sqlExecutionType}'");
                }));

        public virtual Func<Type, IAssemblyPartAppender> PartAppenderFactory
            => _partAppenderFactory ?? (_partAppenderFactory = new Func<Type, IAssemblyPartAppender>(t => ResolvePartAppender(t, t)));
        #endregion

        #region methods
        public void RegisterPartAppender<T, U>()
            where U : class, IAssemblyPartAppender<T>, new()
            => _partAppenders.AddOrUpdate(typeof(T), () => new U(), (t,f) => () => new U());

        public void RegisterPartAppender<T>(IAssemblyPartAppender<T> appender)
            => RegisterPartAppender(() => appender);

        public void RegisterPartAppender<T>(Func<IAssemblyPartAppender<T>> appenderFactory)
            => _partAppenders.AddOrUpdate(typeof(T), appenderFactory, (t,f) => appenderFactory);

        public virtual void RegisterDefaultPartAppenders()
        {
            _partAppenders.TryAdd(typeof(SchemaExpression), () => _schemaAppender);
            _partAppenders.TryAdd(typeof(EntityExpression), () => _entityAppender);
            _partAppenders.TryAdd(typeof(FieldExpression), () => _fieldAppender);
            _partAppenders.TryAdd(typeof(AssignmentExpression), () => _assignmentAppender);
            _partAppenders.TryAdd(typeof(AssignmentExpressionSet), () => _assignmentSetAppender);
            _partAppenders.TryAdd(typeof(SelectExpression), () => _selectAppender);
            _partAppenders.TryAdd(typeof(SelectExpressionSet), () => _selectSetAppender);
            _partAppenders.TryAdd(typeof(FilterExpression), () => _filterAppender);
            _partAppenders.TryAdd(typeof(FilterExpressionSet), () => _filterSetAppender);
            _partAppenders.TryAdd(typeof(JoinExpression), () => _joinAppender);
            _partAppenders.TryAdd(typeof(JoinExpressionSet), () => _joinSetAppender);
            _partAppenders.TryAdd(typeof(JoinOnExpression), () => _joinOnClauseAppender);
            _partAppenders.TryAdd(typeof(GroupByExpression), () => _groupByAppender);
            _partAppenders.TryAdd(typeof(GroupByExpressionSet), () => _groupBySetAppender);
            _partAppenders.TryAdd(typeof(HavingExpression), () => _havingClauseAppender);
            _partAppenders.TryAdd(typeof(OrderByExpression), () => _orderByAppender);
            _partAppenders.TryAdd(typeof(OrderByExpressionSet), () => _orderBySetAppender);
            _partAppenders.TryAdd(typeof(ArithmeticExpression), () => _arithmeticAppender);
            _partAppenders.TryAdd(typeof(ExpressionMediator), () => _expressionMediatorAppender);
            _partAppenders.TryAdd(typeof(CastFunctionExpression), () => _castFunctionAppender);
            _partAppenders.TryAdd(typeof(CoalesceFunctionExpression), () => _coalesceFunctionAppender);
            _partAppenders.TryAdd(typeof(ConcatFunctionExpression), () => _concatFunctionAppender);
            _partAppenders.TryAdd(typeof(IsNullFunctionExpression), () => _isNullFunctionAppender);
            _partAppenders.TryAdd(typeof(AverageFunctionExpression), () => _averageFunctionAppender);
            _partAppenders.TryAdd(typeof(MinimumFunctionExpression), () => _minimumFunctionAppender);
            _partAppenders.TryAdd(typeof(MaximumFunctionExpression), () => _maximumFunctionAppender);
            _partAppenders.TryAdd(typeof(CountFunctionExpression), () => _countFunctionAppender);
            _partAppenders.TryAdd(typeof(SumFunctionExpression), () => _sumFunctionAppender);
            _partAppenders.TryAdd(typeof(StandardDeviationFunctionExpression), () => _standardDeviationFunctionAppender);
            _partAppenders.TryAdd(typeof(PopulationStandardDeviationFunctionExpression), () => _populationStandardDeviationFunctionAppender);
            _partAppenders.TryAdd(typeof(VarianceFunctionExpression), () => _varianceFunctionAppender);
            _partAppenders.TryAdd(typeof(PopulationVarianceFunctionExpression), () => _populationVarianceFunctionAppender);
            _partAppenders.TryAdd(typeof(CurrentTimestampFunctionExpression), () => _currentTimestampFunctionAppender);
            _partAppenders.TryAdd(typeof(FloorFunctionExpression), () => _floorFunctionAppender);
            _partAppenders.TryAdd(typeof(CeilingFunctionExpression), () => _ceilingFunctionAppender);
            _partAppenders.TryAdd(typeof(LiteralExpression), () => _literalAppender);

            _partAppenders.TryAdd(typeof(bool), () => _booleanAppender);
            _partAppenders.TryAdd(typeof(bool?), () => _nullableBooleanAppender);
            _partAppenders.TryAdd(typeof(byte), () => _byteAppender);
            _partAppenders.TryAdd(typeof(byte?), () => _nullableByteAppender);
            _partAppenders.TryAdd(typeof(byte[]), () => _byteArrayAppender);
            _partAppenders.TryAdd(typeof(DateTime), () => _dateTimeAppender);
            _partAppenders.TryAdd(typeof(DateTime?), () => _nullableDateTimeAppender);
            _partAppenders.TryAdd(typeof(DateTimeOffset), () => _dateTimeOffsetAppender);
            _partAppenders.TryAdd(typeof(DateTimeOffset?), () => _nullableDateTimeOffsetAppender);
            _partAppenders.TryAdd(typeof(decimal), () => _decimalAppender);
            _partAppenders.TryAdd(typeof(decimal?), () => _nullableDecimalAppender);
            _partAppenders.TryAdd(typeof(double), () => _doubleAppender);
            _partAppenders.TryAdd(typeof(double?), () => _nullableDoubleAppender);
            _partAppenders.TryAdd(typeof(Enum), () => _enumAppender);
            _partAppenders.TryAdd(typeof(float), () => _floatAppender);
            _partAppenders.TryAdd(typeof(float?), () => _nullableFloatAppender);
            _partAppenders.TryAdd(typeof(Guid), () => _guidAppender);
            _partAppenders.TryAdd(typeof(Guid?), () => _nullableGuidAppender);
            _partAppenders.TryAdd(typeof(int), () => _int32Appender);
            _partAppenders.TryAdd(typeof(int?), () => _nullableInt32Appender);
            _partAppenders.TryAdd(typeof(long), () => _int64Appender);
            _partAppenders.TryAdd(typeof(long?), () => _nullableInt64Appender);
            _partAppenders.TryAdd(typeof(short), () => _int16Appender);
            _partAppenders.TryAdd(typeof(short?), () => _nullableInt16Appender);
            _partAppenders.TryAdd(typeof(string), () => _stringAppender);

            _partAppenders.TryAdd(typeof(DBNull), () => _dbNullAppender);
        }

        public virtual void RegisterStatementAssembler<T, U>()
            where T : QueryExpression
            where U : class, ISqlStatementAssembler, new()
            => _statementAssemblers.AddOrUpdate(typeof(T), () => new U(), (t, f) => () => new U());

        public virtual void RegisterStatementAssembler<T, U>(U assembler)
            where T : QueryExpression
            where U : class, ISqlStatementAssembler
            => _statementAssemblers.AddOrUpdate(typeof(T), () => assembler, (t, f) => () => assembler);

        public virtual void RegisterStatementAssembler<T, U>(Func<U> assemblerFactory)
            where T : QueryExpression
            where U : class, ISqlStatementAssembler
            => _statementAssemblers.AddOrUpdate(typeof(T), assemblerFactory, (t,f) => assemblerFactory);

        public virtual void RegisterDefaultStatementAssemblers()
        {
            _statementAssemblers.TryAdd(typeof(SelectQueryExpression), () => _selectSqlStatementAssembler);
            _statementAssemblers.TryAdd(typeof(InsertQueryExpression), () => _insertSqlStatementAssembler);
            _statementAssemblers.TryAdd(typeof(UpdateQueryExpression), () => _updateSqlStatementAssembler);
            _statementAssemblers.TryAdd(typeof(DeleteQueryExpression), () => _deleteSqlStatementAssembler);
        }

        public ISqlStatementBuilder CreateSqlStatementBuilder(DbExpressionAssemblerConfiguration config, QueryExpression expression, IAppender appender, ISqlParameterBuilder parameterBuilder)
            => new SqlStatementBuilder(config, expression, e => AssemblerFactory(e.GetType()), PartAppenderFactory, appender, parameterBuilder);

        private IAssemblyPartAppender ResolvePartAppender(Type current, Type original)
        {
            if (_partAppenders.TryGetValue(current, out Func<IAssemblyPartAppender> appenderFactory))
            {
                if (current != original)
                {
                    //reduce runtime recursion by "registering" the original with the found appender
                    _partAppenders.TryAdd(original, appenderFactory);
                }
                return appenderFactory();
            }
            
            if (current.BaseType == typeof(object)) //crawled up to Type=object and didn't find an appender, resolve if it is an Enum and the part appender for an Enum
                return ResolveEnumPartAppender(original, original) ?? throw new DbExpressionConfigurationException($"Could not resolve a part appender for type '{original}', please ensure an appender has been registered for type '{original}'");

            if (current.BaseType is null)
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
                _partAppenders.TryAdd(original, () => _enumAppender);
                return ResolvePartAppender(original, original);
            }

            return ResolveEnumPartAppender(current.BaseType, original);
        }
        #endregion
    }
}
