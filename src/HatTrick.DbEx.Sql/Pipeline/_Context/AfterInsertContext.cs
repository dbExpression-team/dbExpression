using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterInsertContext : IPipelineExecutionContext
    {
        private ExpressionSet ExpressionSet { get; set; }
        private ISqlParameterBuilder ParameterBuilder { get; set; }
        public FilteredFields InsertFields { get; private set; }
        public AllFields AllFields { get; private set; }
        public ISqlEntityMetadata BaseEntityMetadata => ExpressionSet.BaseEntity as ISqlEntityMetadata;

        public InsertedEntity Entity { get; private set; }
        public IEnumerable<ParameterizedFieldExpression> Parameters => ParameterBuilder.Parameters.ToList().AsReadOnly();

        public AfterInsertContext(ExpressionSet expressionSet, ISqlParameterBuilder parameterBuilder, IMapperFactory mapperFactory)
        {
            ExpressionSet = expressionSet;
            ParameterBuilder = parameterBuilder;
            InsertFields = new FilteredFields(expressionSet, SqlStatementExecutionType.Insert);
            AllFields = new AllFields(expressionSet, SqlStatementExecutionType.Insert);
            Entity = new InsertedEntity(expressionSet, mapperFactory);
        }

        public class InsertedEntity
        {
            private ExpressionSet ExpressionSet { get; set; }
            private IMapperFactory MapperFactory { get; set; }

            public IDbEntity Instance => ExpressionSet.Instance;

            public InsertedEntity(ExpressionSet expressionSet, IMapperFactory mapperFactory)
            {
                ExpressionSet = expressionSet;
                MapperFactory = mapperFactory;
            }

            public void SetPropertyValue<TValue>(ISqlFieldMetadata metadata, object value)
            {
                var field = (ExpressionSet.BaseEntity as IDbExpressionListProvider<FieldExpression>).Expressions.FirstOrDefault(f => (f as IDbExpressionMetadataProvider<ISqlFieldMetadata>).Metadata == metadata);
                var mapper = MapperFactory.CreateValueMapper();
                TValue mapped = mapper.Map<TValue>(field, new Field(0, metadata.Name, value));
                field.Map(Instance, mapped);
            }

            public void SetPropertyValue<TValue>(FieldExpression field, object value)
            {
                var metadata = (field as IDbExpressionMetadataProvider<ISqlFieldMetadata>).Metadata;
                var mapper = MapperFactory.CreateValueMapper();
                TValue mapped = mapper.Map<TValue>(field, new Field(0, metadata.Name, value));
                field.Map(Instance, mapped);
            }

            public void SetPropertyValue<TEntity, TValue>(FieldExpression<TEntity, TValue> field, object value)
                where TEntity : IDbEntity
            {
                var metadata = (field as IDbExpressionMetadataProvider<ISqlFieldMetadata>).Metadata;
                var mapper = MapperFactory.CreateValueMapper();
                TValue mapped = mapper.Map<TValue>(field, new Field(0, metadata.Name, value));
                field.Map(Instance, mapped);
            }

            public void SetPropertyValue<TEntity, TValue>(NullableFieldExpression<TEntity, TValue> field, object value)
                where TEntity : IDbEntity
                where TValue : struct, IComparable
            {
                var metadata = (field as IDbExpressionMetadataProvider<ISqlFieldMetadata>).Metadata;
                var mapper = MapperFactory.CreateValueMapper();
                TValue mapped = mapper.Map<TValue>(field, new Field(0, metadata.Name, value));
                field.Map(Instance, mapped);
            }
        }
    }
}
