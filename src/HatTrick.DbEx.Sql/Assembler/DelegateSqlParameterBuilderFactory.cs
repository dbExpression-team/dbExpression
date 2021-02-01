using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DelegateSqlParameterBuilderFactory : ISqlParameterBuilderFactory
    {
        #region internals
        private readonly Func<ISqlParameterBuilder> factory;
        #endregion

        #region constructors
        public DelegateSqlParameterBuilderFactory(Func<ISqlParameterBuilder> factory)
        {
            this.factory = factory ?? throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Sql Parameter Builder."); ;
        }

        public DelegateSqlParameterBuilderFactory(Func<ISqlParameterBuilderFactory> factory)
        {
            if (factory is null)
                throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Sql Parameter Builder.");

            this.factory = () => factory()?.CreateSqlParameterBuilder() ?? throw new DbExpressionException("Cannot create a Sql Parameter Builder: The factory returned a null value.");
        }
        #endregion

        #region methods
        public ISqlParameterBuilder CreateSqlParameterBuilder()
            => factory();
        #endregion
    }
}
