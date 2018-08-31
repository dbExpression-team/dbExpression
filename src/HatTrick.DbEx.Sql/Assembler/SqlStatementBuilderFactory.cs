using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class SqlStatementBuilderFactory : ISqlStatementBuilderFactory
    {
        #region internals
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
                   typeof(FieldExpression).IsAssignableFrom(t) //IsAssignableFrom is required as type may be DBExpressionField<int>, DBExpressionField<Guid>, etc
                        ? partAssemblers[typeof(FieldExpression)]()
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
            partAssemblers.Add(typeof(ExpressionSet), () => new SelectSqlStatementAssembler());
            partAssemblers.Add(typeof(AssignmentExpressionSet), () => new UpdateClauseAssembler());
            partAssemblers.Add(typeof(InsertExpressionSet), () => new InsertClauseAssembler());
            partAssemblers.Add(typeof(SchemaExpression), () => new SchemaAssembler());
            partAssemblers.Add(typeof(EntityExpression), () => new EntityAssembler());
            partAssemblers.Add(typeof(FieldExpression), () => new FieldAssembler());
            partAssemblers.Add(typeof(SelectExpression), () => new SelectClauseAssembler());
            partAssemblers.Add(typeof(SelectExpressionSet), () => new SelectClauseAssembler());
            partAssemblers.Add(typeof(WhereExpression), () => new WhereClauseAssembler());
            partAssemblers.Add(typeof(WhereExpressionSet), () => new WhereClauseAssembler());
            partAssemblers.Add(typeof(JoinExpression), () => new JoinClauseAssembler());
            partAssemblers.Add(typeof(JoinExpressionSet), () => new JoinClauseAssembler());
            partAssemblers.Add(typeof(JoinOnExpression), () => new JoinOnClauseAssembler());
            partAssemblers.Add(typeof(GroupByExpression), () => new GroupByClauseAssembler());
            partAssemblers.Add(typeof(GroupByExpressionSet), () => new GroupByClauseAssembler());
            partAssemblers.Add(typeof(HavingExpression), () => new HavingClauseAssembler());
            partAssemblers.Add(typeof(OrderByExpression), () => new OrderByClauseAssembler());
            partAssemblers.Add(typeof(OrderByExpressionSet), () => new OrderByClauseAssembler());
            partAssemblers.Add(typeof(ArithmeticExpression), () => new ArithmeticAssembler());
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

        public ISqlStatementBuilder CreateSqlStatementBuilder(ExpressionSet expression, ISqlParameterBuilder parameterBuilder)
            => new SqlStatementBuilder(expression, assemblers[expression.ExecutionContext](), PartAssemblerResolver, ValueTypeFormatterResolver, parameterBuilder);

        #endregion
    }
}
