namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectValuesSkipContinuation<TValue> :
#pragma warning restore IDE1006 // Naming Styles
        Limit<SelectValuesOrderByContinuation<TValue>>,
        SelectValuesTermination<TValue>
    {
    }
}
