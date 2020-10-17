using HatTrick.DbEx.Sql.Assembler;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql
{
    public class SqlStatement
    {
        public IAppender CommandTextWriter { get; set; }
        public DbCommandType CommandType { get; set; } = DbCommandType.SqlText;
        public IList<ParameterizedExpression> Parameters { get; set; } = new List<ParameterizedExpression>();

        public SqlStatement()
        { }

        public SqlStatement(IAppender commandTextWriter, IList<ParameterizedExpression> parameters, DbCommandType commandType)
        {
            CommandTextWriter = commandTextWriter;
            Parameters = parameters;
            CommandType = commandType;
        }
    }
}
