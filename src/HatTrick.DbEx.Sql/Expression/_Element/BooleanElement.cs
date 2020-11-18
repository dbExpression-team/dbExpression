namespace HatTrick.DbEx.Sql.Expression
{
#pragma warning disable IDE1006 // Naming Styles
    public interface BooleanElement : AnyNonNullElement
#pragma warning restore IDE1006 // Naming Styles
    {
        BooleanElement As(string alias);
    }

}
