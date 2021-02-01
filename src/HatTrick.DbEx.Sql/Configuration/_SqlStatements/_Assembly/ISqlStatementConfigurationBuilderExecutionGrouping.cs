namespace HatTrick.DbEx.Sql.Configuration
{
    public interface ISqlStatementConfigurationBuilderExecutionGrouping
    {
        /// <summary>
        /// Configure the factories used for executing sql statements.  
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders Execution { get; }
    }
}
