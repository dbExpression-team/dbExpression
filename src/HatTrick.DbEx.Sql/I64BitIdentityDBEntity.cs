
namespace HatTrick.DbEx.Sql
{
    public interface I64BitIdentityDbEntity : IIdentityDbEntity
    {
        long Id { get; set; }
    }
}
