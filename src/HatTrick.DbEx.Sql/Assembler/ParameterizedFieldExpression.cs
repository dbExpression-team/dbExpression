using HatTrick.DbEx.Sql.Expression;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ParameterizedFieldExpression
    {
        public DbParameter Parameter { get; private set; }
        public FieldExpression Field { get; private set; }

        public ParameterizedFieldExpression(DbParameter parameter, FieldExpression expression)
        {
            Parameter = parameter;
            Field = expression;
        }
    }
}
