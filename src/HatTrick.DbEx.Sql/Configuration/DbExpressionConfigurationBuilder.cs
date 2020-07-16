using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class DbExpressionConfigurationBuilder
    {
        public static void AddDbExpression(params Action<DbExpressionRuntimeEnvironmentBuilder>[] databases)
        {
            foreach (var database in databases)
            {
                database?.Invoke(new DbExpressionRuntimeEnvironmentBuilder());
            }
        }
    }
}
