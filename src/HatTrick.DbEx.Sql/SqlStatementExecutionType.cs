namespace HatTrick.DbEx.Sql
{
    public enum SqlStatementExecutionType : int
    {
        None,
        SelectOneType,
        SelectOneValue,
        SelectOneDynamic,
        SelectManyType,
        SelectManyValue,
        SelectManyDynamic,
        //GetValueTable,
        Insert,
        Update,
        Delete
    }
}
