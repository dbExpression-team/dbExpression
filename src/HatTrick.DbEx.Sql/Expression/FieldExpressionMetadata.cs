using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class FieldExpressionMetadata : IExpressionMetadata
    {
        public EntityExpression ParentEntity { get; private set; }
        public string Name { get; private set; }
        public int? Size { get; private set; }
        public byte? Precision { get; private set; }
        public byte? Scale { get; private set; }
        public object DbType { get; private set; }

        protected FieldExpressionMetadata(EntityExpression parent, string name, object dbType)
        {
            ParentEntity = parent;
            Name = name;
            DbType = dbType;
        }

        protected FieldExpressionMetadata(EntityExpression parent, string name, object dbType, int size)
        {
            ParentEntity = parent;
            Name = name;
            DbType = dbType;
            Size = size;
        }

        protected FieldExpressionMetadata(EntityExpression parent, string name, object dbType, byte precision, byte scale)
        {
            ParentEntity = parent;
            Name = name;
            DbType = dbType;
            Precision = precision;
            Scale = scale;
        }
    }
}
