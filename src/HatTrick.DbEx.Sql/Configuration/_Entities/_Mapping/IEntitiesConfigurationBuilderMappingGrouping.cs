
using HatTrick.DbEx.Sql.Mapper;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IEntitiesConfigurationBuilderMappingGrouping
    {
        /// <summary>
        /// Configure the factory used for creating a <see cref="IEntityMapper"/> for mapping data retreived from the target database to an entity.  
        /// </summary>
        IMapperFactoryConfigurationBuilder Mapping { get; }
    }
}
