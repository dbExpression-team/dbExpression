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
        private static readonly LiteralAppender _literalAppender = new LiteralAppender();
        private static readonly StringAppender _stringAppender = new StringAppender();
        private static readonly ByteAppender _byteAppender = new ByteAppender();
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

        private IDictionary<Type, Func<IAssemblyPartAppender>> PartAppenders { get; } = new Dictionary<Type, Func<IAssemblyPartAppender>>();
        private IDictionary<SqlStatementExecutionType, Func<ISqlStatementAssembler>> Assemblers { get; } = new Dictionary<SqlStatementExecutionType, Func<ISqlStatementAssembler>>();
        private IDictionary<Type, Func<IValueTypeFormatter>> ValueFormatters { get; } = new Dictionary<Type, Func<IValueTypeFormatter>>();

        private Func<SqlStatementExecutionType, ISqlStatementAssembler> _assemblerResolver;
        private Func<Type, IAssemblyPartAppender> _partAppenderAccessor;
        private Func<Type, IValueTypeFormatter> _valueFormatterAccessor;

        public virtual Func<SqlStatementExecutionType, ISqlStatementAssembler> AssemblerResolver
        {
            get
            {
                if (_assemblerResolver != null)
                    return _assemblerResolver;

                return _assemblerResolver = new Func<SqlStatementExecutionType, ISqlStatementAssembler>(ec => Assemblers[ec]());
            }
        }

        public virtual Func<Type, IAssemblyPartAppender> PartAppenderResolver
        {
            get
            {
                if (_partAppenderAccessor != null)
                    return _partAppenderAccessor;

                _partAppenderAccessor = new Func<Type, IAssemblyPartAppender>(t =>
                    {
                        if (t.IsEnum)
                            return PartAppenders[typeof(Enum)]();

                        if (PartAppenders.TryGetValue(t, out Func<IAssemblyPartAppender> value))
                            return value();

                        if (typeof(FieldExpression).IsAssignableFrom(t)) //IsAssignableFrom is required as type may be DBExpressionField<int>, DBExpressionField<Guid>, etc
                            return PartAppenders[typeof(FieldExpression)]();

                        if (typeof(EntityExpression).IsAssignableFrom(t))
                            return PartAppenders[typeof(EntityExpression)]();

                        if (typeof(ArithmeticExpression).IsAssignableFrom(t)) //IsAssignableFrom is required as type may be ArithmeticExpression<int>, ArithmeticExpression<Guid>, etc
                            return PartAppenders[typeof(ArithmeticExpression)]();

                        if (typeof(IsNullFunctionExpression).IsAssignableFrom(t)) //IsAssignableFrom is required as type may be IsNullFunctionExpression<int>, IsNullFunctionExpression<Guid>, etc
                            return PartAppenders[typeof(IsNullFunctionExpression)]();

                        if (typeof(CastFunctionExpression).IsAssignableFrom(t)) //IsAssignableFrom is required as type may be CastFunctionExpression<int>, CastFunctionExpression<Guid>, etc
                            return PartAppenders[typeof(CastFunctionExpression)]();

                        if (typeof(CoalesceFunctionExpression).IsAssignableFrom(t)) //IsAssignableFrom is required as type may be CoalesceFunctionExpression<int>, CoalesceFunctionExpression<Guid>, etc
                            return PartAppenders[typeof(CoalesceFunctionExpression)]();

                        if (typeof(LiteralExpression).IsAssignableFrom(t))
                            return PartAppenders[typeof(LiteralExpression)]();

                        throw new ConfigurationErrorsException($"A part appender for type '{t}' has not been configured.");
                    }
                );

                return _partAppenderAccessor;
            }
        }

        public virtual Func<Type, IValueTypeFormatter> ValueTypeFormatterResolver
        {
            get
            {
                if (_valueFormatterAccessor != null)
                    return _valueFormatterAccessor;

                return _valueFormatterAccessor = new Func<Type, IValueTypeFormatter>(t => ValueFormatters[t]());
            }
        }
        #endregion

        #region constructors
        public SqlStatementBuilderFactory()
        {
        
        }
        #endregion

        #region methods
        public void RegisterPartAssembler<T, U>()
            where T : class, IAssemblyPart
            where U : class, IAssemblyPartAppender<T>, new()
        {
            PartAppenders[typeof(T)] = () => new U();
        }

        public void RegisterPartAppender<T>(IAssemblyPartAppender<T> assembler)
            where T : class, IAssemblyPart
        {
            PartAppenders[typeof(T)] = () => assembler;
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
            PartAppenders.Add(typeof(LiteralExpression), () => _literalAppender);
            PartAppenders.Add(typeof(string), () => _stringAppender);
            PartAppenders.Add(typeof(byte), () => _byteAppender);
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
            Assemblers[statementExecutionType] = () => new T();
        }

        public virtual void RegisterAssembler<T>(SqlStatementExecutionType statementExecutionType, T assembler)
            where T : class, ISqlStatementAssembler
        {
            Assemblers[statementExecutionType] = () => assembler;
        }

        public virtual void RegisterDefaultAssemblers()
        {
            Assemblers.Add(SqlStatementExecutionType.SelectOneType, () => _selectSqlStatementAssembler);
            Assemblers.Add(SqlStatementExecutionType.SelectOneDynamic, () => _selectSqlStatementAssembler);
            Assemblers.Add(SqlStatementExecutionType.SelectOneValue, () => _selectSqlStatementAssembler);
            Assemblers.Add(SqlStatementExecutionType.SelectManyType, () => _selectSqlStatementAssembler);
            Assemblers.Add(SqlStatementExecutionType.SelectManyDynamic, () => _selectSqlStatementAssembler);
            Assemblers.Add(SqlStatementExecutionType.SelectManyValue, () => _selectSqlStatementAssembler);
            Assemblers.Add(SqlStatementExecutionType.Insert, () => _insertSqlStatementAssembler);
            Assemblers.Add(SqlStatementExecutionType.Update, () => _updateSqlStatementAssembler);
            Assemblers.Add(SqlStatementExecutionType.Delete, () => _deleteSqlStatementAssembler);
        }

        public void RegisterValueFormatter<T, U>()
           where T : IComparable
           where U : class, IValueTypeFormatter<T>, new()
        {
            ValueFormatters[typeof(T)] = () => new U();
        }

        public void RegisterValueFormatter<T>(IValueTypeFormatter<T> valueFormatter)
            where T : IComparable, IValueTypeFormatter
        {
            ValueFormatters[typeof(T)] = () => valueFormatter;
        }

        public virtual void RegisterDefaultValueFormatters()
        {
            ValueFormatters.Add(typeof(string), () => _valueTypeFormatter);
            ValueFormatters.Add(typeof(bool), () => _valueTypeFormatter);
            ValueFormatters.Add(typeof(byte), () => _valueTypeFormatter);
            ValueFormatters.Add(typeof(short), () => _valueTypeFormatter);
            ValueFormatters.Add(typeof(int), () => _valueTypeFormatter);
            ValueFormatters.Add(typeof(long), () => _valueTypeFormatter);
            ValueFormatters.Add(typeof(decimal), () => _valueTypeFormatter);
            ValueFormatters.Add(typeof(DateTime), () => _valueTypeFormatter);
            ValueFormatters.Add(typeof(Guid), () => _valueTypeFormatter);
            ValueFormatters.Add(typeof(Enum), () => _enumValueTypeFormatter);
        }

        public ISqlStatementBuilder CreateSqlStatementBuilder(DbExpressionAssemblerConfiguration config, ExpressionSet expression, IAppender appender, ISqlParameterBuilder parameterBuilder)
            => new SqlStatementBuilder(config, expression, AssemblerResolver, PartAppenderResolver, ValueTypeFormatterResolver, appender, parameterBuilder);
        #endregion
    }
}
