namespace HatTrick.DbEx.Sql.Configuration
{
    public interface ISqlStatementConfigurationBuilderAssemblyGrouping
    {
        /// <summary>
        /// Configure the factories used for assembling query expressions into sql statements.  
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders Assembly { get; }
    }
}
