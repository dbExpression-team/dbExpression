namespace HTL.DbEx.Sql.Common
{
    public interface IU64BitIdentityDBEntity : IIdentityDBEntity
    {
        ulong Id { get; set; }
    }
}
