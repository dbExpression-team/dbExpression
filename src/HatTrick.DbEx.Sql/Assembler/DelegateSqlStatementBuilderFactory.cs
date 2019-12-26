using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DelegateSqlStatementBuilderFactory : ISqlStatementBuilderFactory
    {
        #region internals
        private readonly Func<DbExpressionAssemblerConfiguration, ExpressionSet, IAppender, ISqlParameterBuilder, ISqlStatementBuilder> factory;
        #endregion

        #region constructors
        public DelegateSqlStatementBuilderFactory(Func<DbExpressionAssemblerConfiguration, ExpressionSet, IAppender, ISqlParameterBuilder, ISqlStatementBuilder> factory)
        {
            this.factory = factory ?? throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Sql Statement Builder."); ;
        }

        public DelegateSqlStatementBuilderFactory(Func<ISqlStatementBuilderFactory> factory)
        {
            if (factory == null)
                throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Sql Statement Builder.");

            this.factory = new Func<DbExpressionAssemblerConfiguration, ExpressionSet, IAppender, ISqlParameterBuilder, ISqlStatementBuilder>((c, s, a, p) =>
            {
                var f = factory().CreateSqlStatementBuilder(c, s, a, p);
                if (f == null)
                    throw new DbExpressionException("Cannot create a Sql Statement Builder: The factory returned a null value.");
                return f;
            });
        }
        #endregion

        #region methods
        public ISqlStatementBuilder CreateSqlStatementBuilder(DbExpressionAssemblerConfiguration config, ExpressionSet expression, IAppender appender, ISqlParameterBuilder parameterBuilder)
            => factory(config, expression, appender, parameterBuilder);
        #endregion
    }
}
