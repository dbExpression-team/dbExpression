namespace HatTrick.DbEx.Sql
{
    public enum SqlStatementExecutionType : int
    {
        None,
        SelectOneType,
        SelectOneValue,
        SelectOneDynamic,
        SelectAllType,
        SelectAllValue,
        SelectAllDynamic,
        //GetValueTable,
        Insert,
        Update,
        Delete
    }
}
