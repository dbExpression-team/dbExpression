namespace HatTrick.DbEx.Sql
{
    public enum ExecutionContext : int
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
