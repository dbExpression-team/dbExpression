using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql.Executor
{
    public class DelegateSqlStatementExecutorFactory : ISqlStatementExecutorFactory
    {
        #region internals
        private readonly Func<QueryExpression, ISqlStatementExecutor> factory;
        #endregion

        #region constructors
        public DelegateSqlStatementExecutorFactory(Func<QueryExpression, ISqlStatementExecutor> factory)
        {
            this.factory = factory ?? throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Sql Statement Executor."); ;
        }

        public DelegateSqlStatementExecutorFactory(Func<ISqlStatementExecutorFactory> factory)
        {
            if (factory is null)
                throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Sql Statement Executor.");

            this.factory = new Func<QueryExpression, ISqlStatementExecutor>(ex =>
            {
                var f = factory().CreateSqlStatementExecutor(ex);
                if (f is null)
                    throw new DbExpressionException("Cannot create a Sql Statement Executor: The factory returned a null value.");
                return f;
            });
        }
        #endregion

        #region methods
       public ISqlStatementExecutor CreateSqlStatementExecutor(QueryExpression set)
            => factory(set);
        #endregion
    }
}
