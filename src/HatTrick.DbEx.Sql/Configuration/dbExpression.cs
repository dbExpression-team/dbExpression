using System;

namespace HatTrick.DbEx.Sql.Configuration
{
#pragma warning disable IDE1006 // Naming Styles
    public class dbExpression : RuntimeSqlDatabaseConfigurationBuilder, IDbExpressionConfigurationBuilder
#pragma warning restore IDE1006 // Naming Styles
    {
        public static void Configure(params Action<IDbExpressionConfigurationBuilder>[] databases)
        {
            foreach (var database in databases)
            {
                database?.Invoke(new dbExpression());
            }
        }

        private dbExpression()
        {

        }
    }
}
