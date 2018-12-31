namespace HatTrick.DbEx.Sql
{
    public enum SqlStatementExecutionType : int
    {
        None,
        Get,
        GetDynamic,
        GetList,
        GetDynamicList,
        GetValueList,
        GetValue,
        GetValueTable,
        Insert,
        Update,
        Delete
    }
}
