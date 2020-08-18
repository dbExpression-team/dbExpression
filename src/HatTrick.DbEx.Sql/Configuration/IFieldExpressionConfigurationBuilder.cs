using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IFieldExpressionConfigurationBuilder
    {
        IFieldExpressionConfigurationContinuationBuilder<T> For<T>(FieldExpression<T> field)
            where T : IComparable;
    }
}
