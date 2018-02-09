namespace HTL.DbEx.Sql.Common
{
    public interface I64BitIdentityDBEntity : IIdentityDBEntity
    {
        long Id { get; set; }
    }
}
