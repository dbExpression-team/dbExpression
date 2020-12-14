using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Tools.Model
{
    public class EntityPairModel
    {
        public ISqlEntityModel Entity { get; }
        public EntityExpressionModel EntityExpression { get; }
        public IList<ColumnPairModel> Items { get; } = new List<ColumnPairModel>();

        public EntityPairModel(ISqlEntityModel entity, EntityExpressionModel entityExpression)
        {
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
            EntityExpression = entityExpression ?? throw new ArgumentNullException(nameof(entityExpression));
        }

        public override string ToString()
            => $"({Entity}, {EntityExpression})";
    }
}
