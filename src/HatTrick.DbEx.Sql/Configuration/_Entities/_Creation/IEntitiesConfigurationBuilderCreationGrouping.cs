namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IEntitiesConfigurationBuilderCreationGrouping
    {
        /// <summary>
        /// Configure the factory used for creating an instance of an <see cref="IDbEntity"/> prior to mapping database values.  
        /// </summary>
        IEntityFactoryConfigurationBuilder Creation { get; }
    }
}
