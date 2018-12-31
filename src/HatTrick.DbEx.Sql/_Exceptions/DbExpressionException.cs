using System;

namespace HatTrick.DbEx.Sql
{
    public class DbExpressionException : Exception
    {
        public DbExpressionException(string message) : base(message)
        {
        }

        public DbExpressionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
