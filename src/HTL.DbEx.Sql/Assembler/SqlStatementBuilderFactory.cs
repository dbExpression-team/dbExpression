using HTL.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HTL.DbEx.Sql.Assembler
{
    public abstract class SqlStatementBuilderFactory : ISqlStatementBuilderFactory
    {
        #region internals
        private IDictionary<Type, Func<ISqlPartAssembler>> partAssemblers { get; } = new Dictionary<Type, Func<ISqlPartAssembler>>();
        private IDictionary<ExecutionContext, Func<ISqlStatementAssembler>> assemblers { get; } = new Dictionary<ExecutionContext, Func<ISqlStatementAssembler>>();
        private IDictionary<Type, Func<IValueTypeFormatter>> valueFormatters { get; } = new Dictionary<Type, Func<IValueTypeFormatter>>();

        private Func<Type, ISqlPartAssembler> partAssemblerAccessor;
        private Func<Type, IValueTypeFormatter> valueFormatterAccessor;

        public virtual Func<Type, ISqlPartAssembler> PartAssemblerResolver
        {
            get
            {
                if (partAssemblerAccessor != null)
                    return partAssemblerAccessor;

                partAssemblerAccessor = new Func<Type, ISqlPartAssembler>(t =>
                   typeof(DBExpressionField).IsAssignableFrom(t) //IsAssignableFrom is required as type may be DBExpressionField<int>, DBExpressionField<Guid>, etc
                        ? partAssemblers[typeof(DBExpressionField)]()
                        : partAssemblers[t]()
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

                valueFormatterAccessor = new Func<Type, IValueTypeFormatter>(t => valueFormatters[t]());

                return valueFormatterAccessor;
            }
        }
        #endregion

        #region methods
        public void RegisterPartAssembler<T, U>()
            where T : class, ISqlAssemblyPart
            where U : class, ISqlPartAssembler<T>, new()
        {
            partAssemblers[typeof(T)] = () => new U();
        }

        public void RegisterPartAssembler<T>(ISqlPartAssembler<T> assembler)
            where T : class, ISqlAssemblyPart
        {
            partAssemblers[typeof(T)] = () => assembler;
        }

        public virtual void RegisterDefaultPartAssemblers()
        {
            partAssemblers.Add(typeof(DBAssignmentExpressionSet), () => new UpdateClauseAssembler());
            partAssemblers.Add(typeof(DBInsertExpressionSet), () => new InsertClauseAssembler());
            partAssemblers.Add(typeof(DBExpressionField), () => new FieldAssembler());
            partAssemblers.Add(typeof(DBSelectExpression), () => new SelectClauseAssembler());
            partAssemblers.Add(typeof(DBSelectExpressionSet), () => new SelectClauseAssembler());
            partAssemblers.Add(typeof(DBFilterExpression), () => new FilterAssembler());
            partAssemblers.Add(typeof(DBFilterExpressionSet), () => new FilterAssembler());
            partAssemblers.Add(typeof(DBJoinExpression), () => new JoinClauseAssembler());
            partAssemblers.Add(typeof(DBJoinExpressionSet), () => new JoinClauseAssembler());
            partAssemblers.Add(typeof(DBGroupByExpression), () => new GroupByAssembler());
            partAssemblers.Add(typeof(DBGroupByExpressionSet), () => new GroupByAssembler());
            partAssemblers.Add(typeof(DBHavingExpression), () => new HavingClauseAssembler());
            partAssemblers.Add(typeof(DBOrderByExpression), () => new OrderByClauseAssembler());
            partAssemblers.Add(typeof(DBOrderByExpressionSet), () => new OrderByClauseAssembler());
            partAssemblers.Add(typeof(DBArithmeticExpression), () => new ArithmeticAssembler());
            partAssemblers.Add(typeof(string), () => new StringAssembler());
            partAssemblers.Add(typeof(DateTime), () => new DateTimeAssembler());
            partAssemblers.Add(typeof(Guid), () => new GuidAssembler());
            partAssemblers.Add(typeof(Enum), () => new EnumAssembler());
            partAssemblers.Add(typeof(Array), () => new ArrayAssembler());
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
            assemblers.Add(ExecutionContext.Get, () => new SelectSqlStatementAssembler());
            assemblers.Add(ExecutionContext.GetDynamic, () => new SelectSqlStatementAssembler());
            assemblers.Add(ExecutionContext.GetValue, () => new SelectSqlStatementAssembler());
            assemblers.Add(ExecutionContext.GetList, () => new SelectAllSqlStatementAssembler());
            assemblers.Add(ExecutionContext.GetDynamicList, () => new SelectAllSqlStatementAssembler());
            assemblers.Add(ExecutionContext.GetValueList, () => new SelectAllSqlStatementAssembler());
            assemblers.Add(ExecutionContext.Insert, () => new InsertSqlStatementAssembler());
            assemblers.Add(ExecutionContext.Update, () => new UpdateSqlStatementAssembler());
            assemblers.Add(ExecutionContext.Delete, () => new DeleteSqlStatementAssembler());
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
            valueFormatters.Add(typeof(string), () => new ValueTypeFormatter());
            valueFormatters.Add(typeof(bool), () => new ValueTypeFormatter());
            valueFormatters.Add(typeof(byte), () => new ValueTypeFormatter());
            valueFormatters.Add(typeof(short), () => new ValueTypeFormatter());
            valueFormatters.Add(typeof(int), () => new ValueTypeFormatter());
            valueFormatters.Add(typeof(long), () => new ValueTypeFormatter());
            valueFormatters.Add(typeof(decimal), () => new ValueTypeFormatter());
            valueFormatters.Add(typeof(DateTime), () => new ValueTypeFormatter());
            valueFormatters.Add(typeof(Guid), () => new ValueTypeFormatter());
            valueFormatters.Add(typeof(Enum), () => new ValueTypeFormatter());
            valueFormatters.Add(typeof(Array), () => new ValueTypeFormatter());
        }

        public ISqlStatementBuilder CreateSqlStatementBuilder(DBExpressionSet expression, ISqlParameterBuilder parameterBuilder)
            => new SqlStatementBuilder(expression, assemblers[expression.ExecutionContext](), PartAssemblerResolver, ValueTypeFormatterResolver, parameterBuilder);

        #endregion
    }
}
