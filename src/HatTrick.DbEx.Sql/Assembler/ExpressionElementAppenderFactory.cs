using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ExpressionElementAppenderFactory : IExpressionElementAppenderFactory
    {
        #region  expression appenders
        private static readonly SchemaExpressionAppender _schemaAppender = new SchemaExpressionAppender();
        private static readonly EntityExpressionAppender _entityAppender = new EntityExpressionAppender();
        private static readonly FieldExpressionAppender _fieldAppender = new FieldExpressionAppender();
        private static readonly AssignmentExpressionAppender _assignmentAppender = new AssignmentExpressionAppender();
        private static readonly AssignmentExpressionSetAppender _assignmentSetAppender = new AssignmentExpressionSetAppender();
        private static readonly SelectExpressionAppender _selectAppender = new SelectExpressionAppender();
        private static readonly SelectExpressionSetAppender _selectSetAppender = new SelectExpressionSetAppender();
        private static readonly FilterExpressionAppender _filterAppender = new FilterExpressionAppender();
        private static readonly FilterExpressionSetAppender _filterSetAppender = new FilterExpressionSetAppender();
        private static readonly JoinExpressionAppender _joinAppender = new JoinExpressionAppender();
        private static readonly JoinExpressionSetAppender _joinSetAppender = new JoinExpressionSetAppender();
        private static readonly JoinOnExpressionSetAppender _joinOnSetAppender = new JoinOnExpressionSetAppender();
        private static readonly JoinOnExpressionAppender _joinOnClauseAppender = new JoinOnExpressionAppender();
        private static readonly GroupByExpressionAppender _groupByAppender = new GroupByExpressionAppender();
        private static readonly GroupByExpressionSetAppender _groupBySetAppender = new GroupByExpressionSetAppender();
        private static readonly HavingExpressionAppender _havingClauseAppender = new HavingExpressionAppender();
        private static readonly OrderByExpressionAppender _orderByAppender = new OrderByExpressionAppender();
        private static readonly OrderByExpressionSetAppender _orderBySetAppender = new OrderByExpressionSetAppender();
        private static readonly ArithmeticExpressionAppender _arithmeticAppender = new ArithmeticExpressionAppender();
        private static readonly ExpressionMediatorAppender _expressionMediatorAppender = new ExpressionMediatorAppender();
        private static readonly CastFunctionExpressionAppender _castFunctionAppender = new CastFunctionExpressionAppender();
        private static readonly CoalesceFunctionExpressionAppender _coalesceFunctionAppender = new CoalesceFunctionExpressionAppender();
        private static readonly ConcatFunctionExpressionAppender _concatFunctionAppender = new ConcatFunctionExpressionAppender();
        private static readonly IsNullFunctionExpressionAppender _isNullFunctionAppender = new IsNullFunctionExpressionAppender();
        private static readonly AverageFunctionExpressionAppender _averageFunctionAppender = new AverageFunctionExpressionAppender();
        private static readonly MinimumFunctionExpressionAppender _minimumFunctionAppender = new MinimumFunctionExpressionAppender();
        private static readonly MaximumFunctionExpressionAppender _maximumFunctionAppender = new MaximumFunctionExpressionAppender();
        private static readonly CountFunctionExpressionAppender _countFunctionAppender = new CountFunctionExpressionAppender();
        private static readonly SumFunctionExpressionAppender _sumFunctionAppender = new SumFunctionExpressionAppender();
        private static readonly StandardDeviationFunctionExpressionAppender _standardDeviationFunctionAppender = new StandardDeviationFunctionExpressionAppender();
        private static readonly PopulationStandardDeviationFunctionExpressionAppender _populationStandardDeviationFunctionAppender = new PopulationStandardDeviationFunctionExpressionAppender();
        private static readonly VarianceFunctionExpressionAppender _varianceFunctionAppender = new VarianceFunctionExpressionAppender();
        private static readonly PopulationVarianceFunctionExpressionAppender _populationVarianceFunctionAppender = new PopulationVarianceFunctionExpressionAppender();
        private static readonly CurrentTimestampFunctionExpressionAppender _currentTimestampFunctionAppender = new CurrentTimestampFunctionExpressionAppender();
        private static readonly FloorFunctionExpressionAppender _floorFunctionAppender = new FloorFunctionExpressionAppender();
        private static readonly CeilingFunctionExpressionAppender _ceilingFunctionAppender = new CeilingFunctionExpressionAppender();
        private static readonly LiteralExpressionAppender _literalAppender = new LiteralExpressionAppender();
        private static readonly RawExpressionAppender _rawAppender = new RawExpressionAppender();
        private static readonly AliasExpressionAppender _aliasAppender = new AliasExpressionAppender();
        private static readonly InExpressionAppender _inAppender = new InExpressionAppender();
        private static readonly LikeExpressionAppender _likeAppender = new LikeExpressionAppender();
        private static readonly DbTypeExpressionAppender _dbTypeAppender = new DbTypeExpressionAppender();
        #endregion

        private readonly ConcurrentDictionary<Type, Func<IExpressionElementAppender>> _elementAppenders = new ConcurrentDictionary<Type, Func<IExpressionElementAppender>>();

        public IExpressionElementAppender CreateElementAppender(IExpressionElement element)
            => ResolveElementAppender(element.GetType());

        public void RegisterElementAppender<T, U>()
            where T : IExpressionElement
            where U : class, IExpressionElementAppender<T>, new()
            => _elementAppenders.AddOrUpdate(typeof(T), () => new U(), (t, f) => () => new U());

        public void RegisterElementAppender<T>(IExpressionElementAppender<T> appender)
            where T : IExpressionElement
            => RegisterElementAppender(() => appender);

        public void RegisterElementAppender<T>(Func<IExpressionElementAppender<T>> appenderFactory)
            where T : IExpressionElement
            => _elementAppenders.AddOrUpdate(typeof(T), appenderFactory, (t, f) => appenderFactory);

        public virtual void RegisterDefaultElementAppenders()
        {
            _elementAppenders.TryAdd(typeof(SchemaExpression), () => _schemaAppender);
            _elementAppenders.TryAdd(typeof(EntityExpression), () => _entityAppender);
            _elementAppenders.TryAdd(typeof(FieldExpression), () => _fieldAppender);
            _elementAppenders.TryAdd(typeof(AssignmentExpression), () => _assignmentAppender);
            _elementAppenders.TryAdd(typeof(AssignmentExpressionSet), () => _assignmentSetAppender);
            _elementAppenders.TryAdd(typeof(SelectExpression), () => _selectAppender);
            _elementAppenders.TryAdd(typeof(SelectExpressionSet), () => _selectSetAppender);
            _elementAppenders.TryAdd(typeof(FilterExpression), () => _filterAppender);
            _elementAppenders.TryAdd(typeof(FilterExpressionSet), () => _filterSetAppender);
            _elementAppenders.TryAdd(typeof(JoinExpression), () => _joinAppender);
            _elementAppenders.TryAdd(typeof(JoinExpressionSet), () => _joinSetAppender);
            _elementAppenders.TryAdd(typeof(JoinOnExpressionSet), () => _joinOnSetAppender);
            _elementAppenders.TryAdd(typeof(JoinOnExpression), () => _joinOnClauseAppender);
            _elementAppenders.TryAdd(typeof(GroupByExpression), () => _groupByAppender);
            _elementAppenders.TryAdd(typeof(GroupByExpressionSet), () => _groupBySetAppender);
            _elementAppenders.TryAdd(typeof(HavingExpression), () => _havingClauseAppender);
            _elementAppenders.TryAdd(typeof(OrderByExpression), () => _orderByAppender);
            _elementAppenders.TryAdd(typeof(OrderByExpressionSet), () => _orderBySetAppender);
            _elementAppenders.TryAdd(typeof(ArithmeticExpression), () => _arithmeticAppender);
            _elementAppenders.TryAdd(typeof(ExpressionMediator), () => _expressionMediatorAppender);
            _elementAppenders.TryAdd(typeof(CastFunctionExpression), () => _castFunctionAppender);
            _elementAppenders.TryAdd(typeof(CoalesceFunctionExpression), () => _coalesceFunctionAppender);
            _elementAppenders.TryAdd(typeof(ConcatFunctionExpression), () => _concatFunctionAppender);
            _elementAppenders.TryAdd(typeof(IsNullFunctionExpression), () => _isNullFunctionAppender);
            _elementAppenders.TryAdd(typeof(AverageFunctionExpression), () => _averageFunctionAppender);
            _elementAppenders.TryAdd(typeof(MinimumFunctionExpression), () => _minimumFunctionAppender);
            _elementAppenders.TryAdd(typeof(MaximumFunctionExpression), () => _maximumFunctionAppender);
            _elementAppenders.TryAdd(typeof(CountFunctionExpression), () => _countFunctionAppender);
            _elementAppenders.TryAdd(typeof(SumFunctionExpression), () => _sumFunctionAppender);
            _elementAppenders.TryAdd(typeof(StandardDeviationFunctionExpression), () => _standardDeviationFunctionAppender);
            _elementAppenders.TryAdd(typeof(PopulationStandardDeviationFunctionExpression), () => _populationStandardDeviationFunctionAppender);
            _elementAppenders.TryAdd(typeof(VarianceFunctionExpression), () => _varianceFunctionAppender);
            _elementAppenders.TryAdd(typeof(PopulationVarianceFunctionExpression), () => _populationVarianceFunctionAppender);
            _elementAppenders.TryAdd(typeof(CurrentTimestampFunctionExpression), () => _currentTimestampFunctionAppender);
            _elementAppenders.TryAdd(typeof(FloorFunctionExpression), () => _floorFunctionAppender);
            _elementAppenders.TryAdd(typeof(CeilingFunctionExpression), () => _ceilingFunctionAppender);
            _elementAppenders.TryAdd(typeof(LiteralExpression), () => _literalAppender);
            _elementAppenders.TryAdd(typeof(RawExpression), () => _rawAppender);
            _elementAppenders.TryAdd(typeof(AliasExpression), () => _aliasAppender);
            _elementAppenders.TryAdd(typeof(InExpression), () => _inAppender);
            _elementAppenders.TryAdd(typeof(LikeExpression), () => _likeAppender);
            _elementAppenders.TryAdd(typeof(DbTypeExpression), () => _dbTypeAppender);
        }

        private IExpressionElementAppender ResolveElementAppender(Type current)
        {
            var factory = ResolveElementAppender(current, current);
            return factory is object ? factory() : null;
        }

        private Func<IExpressionElementAppender> ResolveElementAppender(Type current, Type original)
        {
            if (_elementAppenders.TryGetValue(current, out Func<IExpressionElementAppender> factory))
                return factory;

            if (current.BaseType is null)
                return null;

            if (factory is null)
                factory = ResolveElementAppender(current.BaseType, original);

            if (factory is object && current == original)
                //reduce runtime recursion by "registering" the original with the found appender
                _elementAppenders.TryAdd(original, factory);

            return factory;
        }
    }
}
