namespace HTL.DbEx.Sql.Common
{
    public interface IU32BitIdentityDBEntity : IIdentityDBEntity
    {
        uint Id { get; set; }
    }
}
