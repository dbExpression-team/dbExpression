using System;

namespace HatTrick.DbEx.Sql.Configuration
{
#pragma warning disable IDE1006 // Naming Styles
    public class dbExpression : DbExpressionConfigurationBuilder
#pragma warning restore IDE1006 // Naming Styles
    {
        public static void ConfigureRuntime(params Action<RuntimeEnvironmentBuilder>[] databases)
            => new dbExpression().ConfigureRuntimeEnvironment(databases);
    }
}
