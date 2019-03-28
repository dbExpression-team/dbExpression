using System;

namespace HatTrick.DbEx.Sql
{
    [Serializable]
    public class SqlFieldMetadata : ISqlFieldMetadata
    {
        public ISqlEntityMetadata Entity { get; private set; }
        public string Name { get; private set; }
        public object DbType { get; private set; }
        public int? Size { get; private set; }
        public byte? Precision { get; private set; }
        public byte? Scale { get; private set; }
        public bool IsIdentity { get; set; }

        public SqlFieldMetadata()
        { }

        public SqlFieldMetadata(ISqlEntityMetadata parent, string name, object dbType)
        {
            Entity = parent;
            Name = name;
            DbType = dbType;
        }

        public SqlFieldMetadata(ISqlEntityMetadata parent, string name, object dbType, int size)
        {
            Entity = parent;
            Name = name;
            DbType = dbType;
            Size = size;
        }

        public SqlFieldMetadata(ISqlEntityMetadata parent, string name, object dbType, byte precision, byte scale)
        {
            Entity = parent;
            Name = name;
            DbType = dbType;
            Precision = precision;
            Scale = scale;
        }
    }
}
