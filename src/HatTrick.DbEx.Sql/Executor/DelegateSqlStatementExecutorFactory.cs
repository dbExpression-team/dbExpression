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
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public DelegateSqlStatementExecutorFactory(Func<ISqlStatementExecutorFactory> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            this.factory = (queryExpression) => factory()?.CreateSqlStatementExecutor(queryExpression) ?? throw new DbExpressionException("Cannot create a Sql Statement Executor: The factory returned a null value.");
        }
        #endregion

        #region methods
       public ISqlStatementExecutor CreateSqlStatementExecutor(QueryExpression queryExpression)
            => factory(queryExpression);
        #endregion
    }
}
