using System;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ParameterizedExpression
    {
        public Type DeclaredType { get; private set; }
        public DbParameter Parameter { get; private set; }
        public ISqlFieldMetadata Metadata { get; private set; }

        public ParameterizedExpression(Type declaredType, DbParameter parameter, ISqlFieldMetadata metadata)
        {
            DeclaredType = declaredType;
            Parameter = parameter;
            Metadata = metadata;
        }
    }
}
