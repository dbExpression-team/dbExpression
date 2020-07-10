using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public abstract class ExecutionPipeline
    {
        protected readonly DatabaseConfiguration Database;

        protected ExecutionPipeline(
            DatabaseConfiguration database
        )
        {
            Database = database ?? throw new DbExpressionConfigurationException($"Database configuration is required, please review and ensure the correct configuration for DbExpression.");
        }

        protected ISqlConnection CreateConnection(ExpressionSet expression)
        {
            try
            {
                return Database.ConnectionFactory.CreateSqlConnection();
            }
            catch (Exception e)
            {
                throw new DbExpressionException($"Could not create a connection for entity '{expression.BaseEntity}', please review and ensure the correct configuration and startup initialization for DbExpression.", e);
            }
        }        
    }
}
