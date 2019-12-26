using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql.Executor
{
    public class DelegateSqlStatementExecutorFactory : ISqlStatementExecutorFactory
    {
        #region internals
        private readonly Func<ExpressionSet, ISqlStatementExecutor> factory;
        #endregion

        #region constructors
        public DelegateSqlStatementExecutorFactory(Func<ExpressionSet, ISqlStatementExecutor> factory)
        {
            this.factory = factory ?? throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Sql Statement Executor."); ;
        }

        public DelegateSqlStatementExecutorFactory(Func<ISqlStatementExecutorFactory> factory)
        {
            if (factory == null)
                throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Sql Statement Executor.");

            this.factory = new Func<ExpressionSet, ISqlStatementExecutor>(ex =>
            {
                var f = factory().CreateSqlStatementExecutor(ex);
                if (f == null)
                    throw new DbExpressionException("Cannot create a Sql Statement Executor: The factory returned a null value.");
                return f;
            });
        }
        #endregion

        #region methods
       public ISqlStatementExecutor CreateSqlStatementExecutor(ExpressionSet set)
            => factory(set);
        #endregion
    }
}
