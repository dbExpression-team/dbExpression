namespace HatTrick.DbEx.Sql.Builder
{
    public interface IBatchContinuationBuilder<TDatabase> : IBatchBuilder<TDatabase>, IBatchTerminationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {

    }
}
