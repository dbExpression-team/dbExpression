using HatTrick.DbEx.Sql.Expression;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ParameterizedFieldExpression
    {
        public DbParameter Parameter { get; set; }
        public FieldExpression Field { get; set; }

        public ParameterizedFieldExpression(DbParameter parameter, FieldExpression expression)
        {
            Parameter = parameter;
            Field = expression;
        }
    }
}
