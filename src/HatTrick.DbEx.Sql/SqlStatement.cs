using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql
{
    public class SqlStatement
    {
        public string ExecutionCommand { get; set; }
        public DbCommandType CommandType { get; set; } = DbCommandType.SqlText;
        public IList<DbParameter> Parameters { get; set; } = new List<DbParameter>();

        public SqlStatement()
        { }

        public SqlStatement(string executionCommand, IList<DbParameter> parameters, DbCommandType commandType)
        {
            ExecutionCommand = executionCommand;
            Parameters = parameters;
            CommandType = commandType;
        }
    }
}
