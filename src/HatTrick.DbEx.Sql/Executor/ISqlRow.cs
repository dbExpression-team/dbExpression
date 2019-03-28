namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlRow : ISqlFieldReader
    {
        int FieldCount { get; }
        int Index { get; }
    }
}
