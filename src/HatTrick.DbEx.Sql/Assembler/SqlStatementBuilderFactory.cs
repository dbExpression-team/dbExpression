using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class SqlStatementBuilderFactory : ISqlStatementBuilderFactory
    {
        #region internal_s
        private static readonly SelectSqlStatementAssembler _selectSqlStatementAssembler = new SelectSqlStatementAssembler();
        private static readonly SelectAllSqlStatementAssembler _selectAllSqlStatementAssembler = new SelectAllSqlStatementAssembler();
        private static readonly InsertSqlStatementAssembler _insertSqlStatementAssembler = new InsertSqlStatementAssembler();
        private static readonly UpdateSqlStatementAssembler _updateSqlStatementAssembler = new UpdateSqlStatementAssembler();
        private static readonly DeleteSqlStatementAssembler _deleteSqlStatementAssembler = new DeleteSqlStatementAssembler();
        private static readonly UpdateClauseAssembler _updateClauseAssembler = new UpdateClauseAssembler();
        private static readonly InsertClauseAssembler _insertClauseAssembler = new InsertClauseAssembler();
        private static readonly SchemaAssembler _schemaAssembler = new SchemaAssembler();
        private static readonly EntityAssembler _entityAssembler = new EntityAssembler();
        private static readonly FieldAssembler _fieldAssembler = new FieldAssembler();
        private static readonly SelectClauseAssembler _selectClauseAssembler = new SelectClauseAssembler();
        private static readonly WhereClauseAssembler _whereClauseAssembler = new WhereClauseAssembler();
        private static readonly JoinClauseAssembler _joinClauseAssembler = new JoinClauseAssembler();
        private static readonly JoinOnClauseAssembler _joinOnClauseAssembler = new JoinOnClauseAssembler();
        private static readonly GroupByClauseAssembler _groupByClauseAssembler = new GroupByClauseAssembler();
        private static readonly HavingClauseAssembler _havingClauseAssembler = new HavingClauseAssembler();
        private static readonly OrderByClauseAssembler _orderByClauseAssembler = new OrderByClauseAssembler();
        private static readonly ArithmeticAssembler _arithmeticAssembler = new ArithmeticAssembler();
        private static readonly AggregateFunctionAssembler _aggregateFunctionAssembler = new AggregateFunctionAssembler();
        private static readonly StringAssembler _stringAssembler = new StringAssembler();
        private static readonly ByteAssembler _byteAssembler = new ByteAssembler();
        private static readonly Int16Assembler _int16Assembler = new Int16Assembler();
        private static readonly Int32Assembler _int32Assembler = new Int32Assembler();
        private static readonly Int64Assembler _int64Assembler = new Int64Assembler();
        private static readonly BooleanAssembler _booleanAssembler = new BooleanAssembler();
        private static readonly DecimalAssembler _decimalAssembler = new DecimalAssembler();
        private static readonly DateTimeAssembler _dateTimeAssembler = new DateTimeAssembler();
        private static readonly GuidAssembler _guidAssembler = new GuidAssembler();
        private static readonly EnumAssembler _enumAssembler = new EnumAssembler();
        private static readonly ArrayAssembler _arrayAssembler = new ArrayAssembler();
        private static readonly ValueTypeFormatter _valueTypeFormatter = new ValueTypeFormatter();
        private static readonly EnumValueTypeFormatter _enumValueTypeFormatter = new EnumValueTypeFormatter();

        private IDictionary<Type, Func<IDbExpressionAssemblyPartAssembler>> partAssemblers { get; } = new Dictionary<Type, Func<IDbExpressionAssemblyPartAssembler>>();
        private IDictionary<ExecutionContext, Func<ISqlStatementAssembler>> assemblers { get; } = new Dictionary<ExecutionContext, Func<ISqlStatementAssembler>>();
        private IDictionary<Type, Func<IValueTypeFormatter>> valueFormatters { get; } = new Dictionary<Type, Func<IValueTypeFormatter>>();

        private Func<Type, IDbExpressionAssemblyPartAssembler> partAssemblerAccessor;
        private Func<Type, IValueTypeFormatter> valueFormatterAccessor;

        public virtual Func<Type, IDbExpressionAssemblyPartAssembler> PartAssemblerResolver
        {
            get
            {
                if (partAssemblerAccessor != null)
                    return partAssemblerAccessor;

                partAssemblerAccessor = new Func<Type, IDbExpressionAssemblyPartAssembler>(t =>
                    {
                        if (t.IsEnum)
                            return partAssemblers[typeof(Enum)]();

                        if (typeof(FieldExpression).IsAssignableFrom(t)) //IsAssignableFrom is required as type may be DBExpressionField<int>, DBExpressionField<Guid>, etc
                            return partAssemblers[typeof(FieldExpression)]();

                        return partAssemblers[t]();
                    }
                );

                return partAssemblerAccessor;
            }
        }

        public virtual Func<Type, IValueTypeFormatter> ValueTypeFormatterResolver
        {
            get
            {
                if (valueFormatterAccessor != null)
                    return valueFormatterAccessor;

                return valueFormatterAccessor = new Func<Type, IValueTypeFormatter>(t => valueFormatters[t]());
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
            where T : class, IDbExpressionAssemblyPart
            where U : class, IDbExpressionAssemblyPartAssembler<T>, new()
        {
            partAssemblers[typeof(T)] = () => new U();
        }

        public void RegisterPartAssembler<T>(IDbExpressionAssemblyPartAssembler<T> assembler)
            where T : class, IDbExpressionAssemblyPart
        {
            partAssemblers[typeof(T)] = () => assembler;
        }

        public virtual void RegisterDefaultPartAssemblers()
        {
            partAssemblers.Add(typeof(ExpressionSet), () => _selectSqlStatementAssembler);
            partAssemblers.Add(typeof(AssignmentExpressionSet), () => _updateClauseAssembler);
            partAssemblers.Add(typeof(InsertExpressionSet), () => _insertClauseAssembler);
            partAssemblers.Add(typeof(SchemaExpression), () => _schemaAssembler);
            partAssemblers.Add(typeof(EntityExpression), () => _entityAssembler);
            partAssemblers.Add(typeof(FieldExpression), () => _fieldAssembler);
            partAssemblers.Add(typeof(SelectExpression), () => _selectClauseAssembler);
            partAssemblers.Add(typeof(SelectExpressionSet), () => _selectClauseAssembler);
            partAssemblers.Add(typeof(FilterExpression), () => _whereClauseAssembler);
            partAssemblers.Add(typeof(FilterExpressionSet), () => _whereClauseAssembler);
            partAssemblers.Add(typeof(JoinExpression), () => _joinClauseAssembler);
            partAssemblers.Add(typeof(JoinExpressionSet), () => _joinClauseAssembler);
            partAssemblers.Add(typeof(JoinOnExpression), () => _joinOnClauseAssembler);
            partAssemblers.Add(typeof(GroupByExpression), () => _groupByClauseAssembler);
            partAssemblers.Add(typeof(GroupByExpressionSet), () => _groupByClauseAssembler);
            partAssemblers.Add(typeof(HavingExpression), () => _havingClauseAssembler);
            partAssemblers.Add(typeof(OrderByExpression), () => _orderByClauseAssembler);
            partAssemblers.Add(typeof(OrderByExpressionSet), () => _orderByClauseAssembler);
            partAssemblers.Add(typeof(ArithmeticExpression), () => _arithmeticAssembler);
            partAssemblers.Add(typeof(AggregateFunctionExpression), () => _aggregateFunctionAssembler);
            partAssemblers.Add(typeof(string), () => _stringAssembler);
            partAssemblers.Add(typeof(byte), () => _byteAssembler);
            partAssemblers.Add(typeof(short), () => _int16Assembler);
            partAssemblers.Add(typeof(int), () => _int32Assembler);
            partAssemblers.Add(typeof(long), () => _int64Assembler);
            partAssemblers.Add(typeof(bool), () => _booleanAssembler);
            partAssemblers.Add(typeof(decimal), () => _decimalAssembler);
            partAssemblers.Add(typeof(DateTime), () => _dateTimeAssembler);
            partAssemblers.Add(typeof(Guid), () => _guidAssembler);
            partAssemblers.Add(typeof(Enum), () => _enumAssembler);
            partAssemblers.Add(typeof(Array), () => _arrayAssembler);
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

        public ISqlStatementBuilder CreateSqlStatementBuilder(DbExpressionAssemblerConfiguration config, ExpressionSet expression, ISqlParameterBuilder parameterBuilder)
            => new SqlStatementBuilder(config, expression, assemblers[expression.ExecutionContext](), PartAssemblerResolver, ValueTypeFormatterResolver, parameterBuilder);

        #endregion
    }
}
