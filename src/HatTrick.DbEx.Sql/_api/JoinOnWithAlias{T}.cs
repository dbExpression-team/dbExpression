namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface JoinOnWithAlias<TCaller>
#pragma warning restore IDE1006 // Naming Styles
    {
        JoinOn<TCaller> As(string alias);
    }
}
