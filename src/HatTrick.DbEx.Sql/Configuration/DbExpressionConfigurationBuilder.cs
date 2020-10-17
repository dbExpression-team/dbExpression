using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public abstract class DbExpressionConfigurationBuilder
    {
        protected void ConfigureRuntimeEnvironment(params Action<RuntimeEnvironmentBuilder>[] databases)
        {
            foreach (var database in databases)
            {
                database?.Invoke(new RuntimeEnvironmentBuilder());
            }
        }
    }
}
