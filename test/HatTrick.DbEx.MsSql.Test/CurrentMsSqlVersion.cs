namespace HatTrick.DbEx.MsSql.Test
{
    public class CurrentMsSqlVersion
    {
        public int Version => ConfigurationProvider.MsSqlVersion ?? 2019;
    }
}
