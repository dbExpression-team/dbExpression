using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class FieldDescriptor
    { 
        public FieldExpression Field { get; private set; }
        public ISqlFieldMetadata Metadata => (Field as ISqlMetadataProvider<ISqlFieldMetadata>).Metadata;

        public FieldDescriptor(FieldExpression field)
        {
            Field = field;
        }
    }
}
