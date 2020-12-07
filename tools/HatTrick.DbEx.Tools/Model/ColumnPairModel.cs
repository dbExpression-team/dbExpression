using System;

namespace HatTrick.DbEx.Tools.Model
{
    public class ColumnPairModel
    {
        public ColumnModel Column { get; }
        public FieldExpressionModel FieldExpression { get; }

        public ColumnPairModel(ColumnModel schema, FieldExpressionModel fieldExpression)
        {
            Column = schema ?? throw new ArgumentNullException(nameof(schema));
            FieldExpression = fieldExpression ?? throw new ArgumentNullException(nameof(fieldExpression));
        }
    }
}
