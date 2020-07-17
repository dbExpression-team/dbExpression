using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class InsertedEntityPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        private IMapperFactory MapperFactory { get; set; }

        public IDbEntity InsertedEntity => Expression.Instance;

        public InsertedEntityPipelineExecutionContext(ExpressionSet expression, IMapperFactory mapperFactory)
            : base(expression)
        {
            MapperFactory = mapperFactory ?? throw new ArgumentNullException($"{nameof(mapperFactory)} is required.");
        }

        public void SetPropertyValue<TValue>(FieldExpression field, object value)
        {
            if (field is null)
                throw new ArgumentNullException($"An instance of {nameof(field)} is required to set a property value.");
            var mapper = MapperFactory.CreateValueMapper();
            var entity = (field as IDbExpressionProvider<EntityExpression>).Expression;
            (entity as IFieldExpressionMapper).MapField(InsertedEntity, field, value, mapper);
        }
    }
}
