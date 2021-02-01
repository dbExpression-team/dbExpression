using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class EntitiesConfigurationBuilderGrouping : IEntitiesConfigurationBuilderGrouping
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        private IMapperFactoryConfigurationBuilder _mapper;
        private IEntityFactoryConfigurationBuilder _entity;
        #endregion

        #region interface
        public IEntityFactoryConfigurationBuilder Creation => _entity ?? (_entity = new EntityFactoryConfigurationBuilder(this, configuration));
        public IMapperFactoryConfigurationBuilder Mapping => _mapper ?? (_mapper = new MapperFactoryConfigurationBuilder(this, configuration));
        #endregion

        #region constructors
        public EntitiesConfigurationBuilderGrouping(RuntimeSqlDatabaseConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.");
        }
        #endregion

    }
}
