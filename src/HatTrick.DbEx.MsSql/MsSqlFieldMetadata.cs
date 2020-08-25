using HatTrick.DbEx.Sql;
using System.Data;

namespace HatTrick.DbEx.MsSql.Expression
{
    public class MsSqlFieldMetadata : SqlFieldMetadata
    {

        public MsSqlFieldMetadata(ISqlEntityMetadata parent, string identifier, string name, SqlDbType dbType)
            : base(parent, identifier, name, dbType)
        {
        }

        public MsSqlFieldMetadata(ISqlEntityMetadata parent, string identifier, string name, SqlDbType dbType, int size)
            : base(parent, identifier, name, dbType, size)
        {
        }

        public MsSqlFieldMetadata(ISqlEntityMetadata parent, string identifier, string name, SqlDbType dbType, byte precision, byte scale)
            : base(parent, identifier, name, dbType, precision, scale)
        {
        }
    }
}
