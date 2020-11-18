namespace HatTrick.DbEx.Sql.Expression
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SingleElement : AnyNonNullElement
#pragma warning restore IDE1006 // Naming Styles
    {
        SingleElement As(string alias);
    }
}
