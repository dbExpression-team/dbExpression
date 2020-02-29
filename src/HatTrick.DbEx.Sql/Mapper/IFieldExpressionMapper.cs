using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IFieldExpressionMapper
    {
        void MapField(IDbEntity entity, FieldExpression field, object value, IValueMapper mapper);
    }
}

