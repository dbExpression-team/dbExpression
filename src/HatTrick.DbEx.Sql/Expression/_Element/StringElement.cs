namespace HatTrick.DbEx.Sql.Expression
{
#pragma warning disable IDE1006 // Naming Styles
    public interface StringElement : AnyNonNullElement
#pragma warning restore IDE1006 // Naming Styles
    {
        StringElement As(string alias);
    }
}
