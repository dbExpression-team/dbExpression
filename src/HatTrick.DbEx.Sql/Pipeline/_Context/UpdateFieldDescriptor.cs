using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class UpdateFieldDescriptor : FieldDescriptor
    {
        public IExpressionElement Assignment { get; private set; }
        public UpdateFieldDescriptor(FieldExpression field, IExpressionElement assignment) : base(field)
        {
            Assignment = assignment;
        }
    }
}
