using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class DelegateQueryExpressionFactory : IQueryExpressionFactory
    {
        #region internals
        private readonly Func<Type,QueryExpression> factory;
        #endregion

        #region constructors
        public DelegateQueryExpressionFactory(Func<Type,QueryExpression> factory)
        {
            this.factory = factory ?? throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize an Expression Set Factory."); ;
        }
        #endregion

        #region methods
        public T CreateQueryExpression<T>() where T : QueryExpression, new() => factory(typeof(T)) as T;
        #endregion          
    }
}
