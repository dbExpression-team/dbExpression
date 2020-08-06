using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class InsertFieldDescriptor : FieldDescriptor
    {
        public ExpressionMediator Assignment { get; private set; }
        public InsertFieldDescriptor(FieldExpression field, ExpressionMediator assignment) : base(field)
        {
            Assignment = assignment;
        }
    }
}
