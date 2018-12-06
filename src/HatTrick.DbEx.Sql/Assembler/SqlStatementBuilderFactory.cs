using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class SqlStatementBuilderFactory : ISqlStatementBuilderFactory
    {
        #region internals
        private static readonly SelectSqlStatementAssembler _selectSqlStatementAssembler = new SelectSqlStatementAssembler();
        private static readonly SelectAllSqlStatementAssembler _selectAllSqlStatementAssembler = new SelectAllSqlStatementAssembler();
        private static readonly InsertSqlStatementAssembler _insertSqlStatementAssembler = new InsertSqlStatementAssembler();
        private static readonly UpdateSqlStatementAssembler _updateSqlStatementAssembler = new UpdateSqlStatementAssembler();
        private static readonly DeleteSqlStatementAssembler _deleteSqlStatementAssembler = new DeleteSqlStatementAssembler();
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
        private static readonly CoalesceFunctionAppender _coalesceFunctionAppender = new CoalesceFunctionAppender();
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

        private IDictionary<Type, Func<IAssemblyPartAliasProvider>> aliasProviders { get; } = new Dictionary<Type, Func<IAssemblyPartAliasProvider>>();
        private IDictionary<Type, Func<IAssemblyPartAppender>> partAppenders { get; } = new Dictionary<Type, Func<IAssemblyPartAppender>>();
        private IDictionary<ExecutionContext, Func<ISqlStatementAssembler>> assemblers { get; } = new Dictionary<ExecutionContext, Func<ISqlStatementAssembler>>();
        private IDictionary<Type, Func<IValueTypeFormatter>> valueFormatters { get; } = new Dictionary<Type, Func<IValueTypeFormatter>>();

        private Func<ExecutionContext, ISqlStatementAssembler> _assemblerResolver;
        private Func<Type, IAssemblyPartAliasProvider> _aliasProviderAccessor;
        private Func<Type, IAssemblyPartAppender> _partAppenderAccessor;
        private Func<Type, IValueTypeFormatter> _valueFormatterAccessor;

        public virtual Func<ExecutionContext, ISqlStatementAssembler> AssemblerResolver
        {
            get
            {
                if (_assemblerResolver != null)
                    return _assemblerResolver;

                return _assemblerResolver = new Func<ExecutionContext, ISqlStatementAssembler>(ec => assemblers[ec]());
            }
        }

        public virtual Func<Type, IAssemblyPartAliasProvider> AliasProviderResolver
        {
            get
            {
                if (_aliasProviderAccessor != null)
                    return _aliasProviderAccessor;

                return _aliasProviderAccessor = new Func<Type, IAssemblyPartAliasProvider>(t => aliasProviders[t]());
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
                            return partAppenders[typeof(Enum)]();

                        if (typeof(FieldExpression).IsAssignableFrom(t)) //IsAssignableFrom is required as type may be DBExpressionField<int>, DBExpressionField<Guid>, etc
                        {
                            if (partAppenders.ContainsKey(t.GetType()))
                                return partAppenders[t.GetType()](); //appender configured for this specific (FieldExpression<T>) type has been registered
                            return partAppenders[typeof(FieldExpression)]();
                        }
                        if (typeof(ArithmeticExpression).IsAssignableFrom(t)) //IsAssignableFrom is required as type may be ArithmeticExpression<int>, ArithmeticExpression<Guid>, etc
                        {
                            if (partAppenders.ContainsKey(t.GetType()))
                                return partAppenders[t.GetType()](); //appender configured for this specific (ArithmeticExpression<T>) type has been registered
                            return partAppenders[typeof(ArithmeticExpression)]();
                        }
                        if (typeof(IsNullFunctionExpression).IsAssignableFrom(t)) //IsAssignableFrom is required as type may be IsNullFunctionExpression<int>, IsNullFunctionExpression<Guid>, etc
                        {
                            if (partAppenders.ContainsKey(t.GetType()))
                                return partAppenders[t.GetType()](); //appender configured for this specific (IsNullFunctionExpression<T>) type has been registered
                            return partAppenders[typeof(IsNullFunctionExpression)]();
                        }

                        return partAppenders[t]();
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

                return _valueFormatterAccessor = new Func<Type, IValueTypeFormatter>(t => valueFormatters[t]());
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
            partAppenders[typeof(T)] = () => new U();
        }

        public void RegisterPartAssembler<T>(IAssemblyPartAppender<T> assembler)
            where T : class, IAssemblyPart
        {
            partAppenders[typeof(T)] = () => assembler;
        }

        public virtual void RegisterDefaultPartAppenders()
        {
            partAppenders.Add(typeof(ExpressionSet), () => _selectSqlStatementAssembler);
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
            partAppenders.Add(typeof(CoalesceFunctionExpression), () => _coalesceFunctionAppender);
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
            partAppenders.Add(typeof(string), () => _stringAppender);
            partAppenders.Add(typeof(byte), () => _byteAppender);
            partAppenders.Add(typeof(short), () => _int16Appender);
            partAppenders.Add(typeof(int), () => _int32Appender);
            partAppenders.Add(typeof(long), () => _int64Appender);
            partAppenders.Add(typeof(bool), () => _booleanAppender);
            partAppenders.Add(typeof(decimal), () => _decimalAppender);
            partAppenders.Add(typeof(DateTime), () => _dateTimeAppender);
            partAppenders.Add(typeof(Guid), () => _guidAppender);
            partAppenders.Add(typeof(Enum), () => _enumAppender);
            partAppenders.Add(typeof(Array), () => _arrayAppender);
        }

        public virtual void RegisterAssembler<T>(ExecutionContext executionContext)
            where T : class, ISqlStatementAssembler, new()
        {
            assemblers[executionContext] = () => new T();
        }

        public virtual void RegisterAssembler<T>(ExecutionContext executionContext, T assembler)
            where T : class, ISqlStatementAssembler
        {
            assemblers[executionContext] = () => assembler;
        }

        public virtual void RegisterDefaultAssemblers()
        {
            assemblers.Add(ExecutionContext.Get, () => _selectSqlStatementAssembler);
            assemblers.Add(ExecutionContext.GetDynamic, () => _selectSqlStatementAssembler);
            assemblers.Add(ExecutionContext.GetValue, () => _selectSqlStatementAssembler);
            assemblers.Add(ExecutionContext.GetList, () => _selectAllSqlStatementAssembler);
            assemblers.Add(ExecutionContext.GetDynamicList, () => _selectAllSqlStatementAssembler);
            assemblers.Add(ExecutionContext.GetValueList, () => _selectAllSqlStatementAssembler);
            assemblers.Add(ExecutionContext.Insert, () => _insertSqlStatementAssembler);
            assemblers.Add(ExecutionContext.Update, () => _updateSqlStatementAssembler);
            assemblers.Add(ExecutionContext.Delete, () => _deleteSqlStatementAssembler);
        }

        public void RegisterValueFormatter<T, U>()
           where T : IComparable
           where U : class, IValueTypeFormatter<T>, new()
        {
            valueFormatters[typeof(T)] = () => new U();
        }

        public void RegisterValueFormatter<T>(IValueTypeFormatter<T> valueFormatter)
            where T : IComparable, IValueTypeFormatter
        {
            valueFormatters[typeof(T)] = () => valueFormatter;
        }

        public virtual void RegisterDefaultValueFormatters()
        {
            valueFormatters.Add(typeof(string), () => _valueTypeFormatter);
            valueFormatters.Add(typeof(bool), () => _valueTypeFormatter);
            valueFormatters.Add(typeof(byte), () => _valueTypeFormatter);
            valueFormatters.Add(typeof(short), () => _valueTypeFormatter);
            valueFormatters.Add(typeof(int), () => _valueTypeFormatter);
            valueFormatters.Add(typeof(long), () => _valueTypeFormatter);
            valueFormatters.Add(typeof(decimal), () => _valueTypeFormatter);
            valueFormatters.Add(typeof(DateTime), () => _valueTypeFormatter);
            valueFormatters.Add(typeof(Guid), () => _valueTypeFormatter);
            valueFormatters.Add(typeof(Enum), () => _enumValueTypeFormatter);
        }

        public void RegisterAliasProvider<T, U>()
            where T : class, IAssemblyPart
            where U : class, IAssemblyPartAliasProvider<T>, new()
        {
            aliasProviders[typeof(T)] = () => new U();
        }

        public void RegisterAliasProvider<T>(IAssemblyPartAliasProvider<T> provider)
            where T : class, IAssemblyPart
        {
            aliasProviders[typeof(T)] = () => provider;
        }

        public virtual void RegisterDefaultAliasProviders()
        {
            aliasProviders.Add(typeof(ExpressionSet), () => _selectSqlStatementAssembler);
            aliasProviders.Add(typeof(JoinExpression), () => _joinClauseAppender);
        }

        public ISqlStatementBuilder CreateSqlStatementBuilder(DbExpressionAssemblerConfiguration config, ExpressionSet expression, IAppender appender, ISqlParameterBuilder parameterBuilder)
            => new SqlStatementBuilder(config, expression, AssemblerResolver, AliasProviderResolver, PartAppenderResolver, ValueTypeFormatterResolver, appender, parameterBuilder);

        #endregion
    }
}
