using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Configuration.Syntax
{
    public interface IRuntimeSqlDatabaseQueryExpressionConfigurationBuilder
    { 
        void UseThisToCreateNewQueryExpressions(IQueryExpressionFactory factory);

        void UseThisToCreateNewQueryExpressions<T>()
            where T : class, IQueryExpressionFactory, new();

        void UseThisToGetAFactoryToCreateNewQueryExpressions<T>(Func<T> factory)
            where T : QueryExpression, new();
    }
}
