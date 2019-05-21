using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public abstract class ExecutionPipeline
    {
        protected readonly DbExpressionConfiguration Config;
        protected readonly DatabaseConfiguration Database;

        protected ExecutionPipeline(
            DbExpressionConfiguration config,
            DatabaseConfiguration database
        )
        {
            Config = config ?? throw new DbExpressionConfigurationException($"DbExpressionConfiguration is required, please review and ensure the correct configuration for DbExpression.");
            Database = database ?? throw new DbExpressionConfigurationException($"Database configuration is required, please review and ensure the correct configuration for DbExpression.");
        }

        protected SqlConnection CreateConnection(ExpressionSet expression)
        {
            var connectionName = Database?.Metadata?.ConnectionName;

            try
            {
                return Database.ConnectionFactory.CreateSqlConnection(Config.ConnectionStringSettings[connectionName]);
            }
            catch (Exception e)
            {
                throw new DbExpressionException($"Could not create a connection for entity '{expression.BaseEntity}', please review and ensure the correct configuration and startup initialization for DbExpression.", e);
            }
        }
    }
}
