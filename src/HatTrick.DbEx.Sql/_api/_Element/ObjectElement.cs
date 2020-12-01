namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface ObjectElement : AnyObjectElement
#pragma warning restore IDE1006 // Naming Styles
    {
        ObjectElement As(string alias);
    }
}
