using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public interface ISkipBuilder<T, U>
        where U : IBuilder<T>
    {
        U Skip(int skip);
    }
}
