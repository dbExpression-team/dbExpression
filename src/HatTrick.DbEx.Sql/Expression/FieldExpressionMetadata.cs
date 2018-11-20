using System;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class FieldExpressionMetadata : IExpressionMetadata
    {
        public EntityExpression ParentEntity { get; private set; }
        public string Name { get; private set; }
        public int? Size { get; set; }

        public FieldExpressionMetadata(EntityExpression parent, string name)
        {
            ParentEntity = parent;
            Name = name;
        }

        public FieldExpressionMetadata(EntityExpression parent, string name, int size)
        {
            ParentEntity = parent;
            Name = name;
            Size = size;
        }
    }
}
