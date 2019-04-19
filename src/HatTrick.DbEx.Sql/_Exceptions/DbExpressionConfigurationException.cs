using System;

namespace HatTrick.DbEx.Sql
{
    public class DbExpressionConfigurationException : DbExpressionException
    {
        public DbExpressionConfigurationException(string message) : base(message)
        {
        }

        public DbExpressionConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
