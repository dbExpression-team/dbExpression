using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IValueMapper
    {
        T Map<T>(FieldExpression fieldExpression, ISqlField sqlField);
    }
}
