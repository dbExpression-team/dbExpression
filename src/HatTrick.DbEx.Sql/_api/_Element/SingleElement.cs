namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SingleElement : AnyElement
#pragma warning restore IDE1006 // Naming Styles
    {
        SingleElement As(string alias);
    }
}
