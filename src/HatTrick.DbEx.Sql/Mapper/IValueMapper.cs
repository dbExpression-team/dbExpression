using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IValueMapper : IMapper
    {
        T Map<T>(object value);
    }
}
