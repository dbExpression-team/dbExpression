using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class UpdateFieldDescriptor : FieldDescriptor
    {
        public ExpressionMediator Assignment { get; private set; }
        public UpdateFieldDescriptor(FieldExpression field, ExpressionMediator assignment) : base(field)
        {
            Assignment = assignment;
        }
    }
}
