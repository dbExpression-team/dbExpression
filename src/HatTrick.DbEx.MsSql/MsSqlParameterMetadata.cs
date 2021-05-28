using HatTrick.DbEx.Sql;

namespace HatTrick.DbEx.MsSql
{
    public class MsSqlParameterMetadata : SqlParameterMetadata
    {
        public MsSqlParameterMetadata(ISqlStoredProcedureMetadata parent, string identifier, string name, object dbType)
            : base(parent, identifier, name, dbType)
        {
        }

        public MsSqlParameterMetadata(ISqlStoredProcedureMetadata parent, string identifier, string name, object dbType, int size)
            : base(parent, identifier, name, dbType, size)
        {
        }

        public MsSqlParameterMetadata(ISqlStoredProcedureMetadata parent, string identifier, string name, object dbType, byte precision, byte scale)
            : base(parent, identifier, name, dbType, precision, scale)
        {
        }
    }
}
