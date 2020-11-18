using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class InsertFieldDescriptor : FieldDescriptor
    {
        public IExpressionElement Assignment { get; private set; }
        public InsertFieldDescriptor(FieldExpression field, IExpressionElement assignment) : base(field)
        {
            Assignment = assignment;
        }
    }
}
