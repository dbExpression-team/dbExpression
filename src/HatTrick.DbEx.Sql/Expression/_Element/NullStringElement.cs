namespace HatTrick.DbEx.Sql.Expression
{
#pragma warning disable IDE1006 // Naming Styles
    public interface NullStringElement : AnyNullElement
#pragma warning restore IDE1006 // Naming Styles
    {
        NullStringElement As(string alias);
    }
}
