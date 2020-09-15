using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ParameterizedFieldExpression
    {
        public Type DeclaredType { get; private set; }
        public DbParameter Parameter { get; private set; }
        public FieldExpression Field { get; private set; }
        public ISqlFieldMetadata Metadata { get; private set; }

        public ParameterizedFieldExpression(Type declaredType, DbParameter parameter, FieldExpression expression, ISqlFieldMetadata metadata)
        {
            DeclaredType = declaredType;
            Parameter = parameter;
            Field = expression;
            Metadata = metadata;
        }
    }
}
