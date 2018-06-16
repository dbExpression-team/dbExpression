using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBExpressionTableFunction : DBExpressionEntity
    {
        #region interface
        public string Function { get; } = string.Empty;

        public object[] Arguments { get; } = { };
        #endregion

        #region methods
        //TODO: JRod/GWG need to provide correct providers
        public DBExpressionTableFunction(string schema, string tableName, string function, params object[] arguments) : base(schema, tableName)
        {
            Function = function;
            Arguments = arguments ?? new object[0];
        }

        public string ToParameterizedString(List<DbParameter> parameterList, SqlConnection dbService)
        {
            var builder = new StringBuilder();
            builder.Append(Function + "(");

            for (int i = 0; i < Arguments.Length; i++)
            {
                if (i > 0) builder.Append(",");

                if (Arguments[i] is DBExpressionField)
                {
                    builder.Append(Arguments[i]);
                }
                else
                {
                    parameterList.Add(dbService.GetDbParameter("@P" + (parameterList.Count + 1), this.Arguments[i]));
                    builder.Append("@P" + parameterList.Count);
                }
            }

            builder.Append(") AS [" + EntityName + "]");

            return builder.ToString();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Function + "(");

            for (int i = 0; i < Arguments.Length; i++)
            {
                if (i > 0) builder.Append(",");
                builder.Append(Arguments[i]);
            }

            builder.Append(") AS [" + EntityName + "]");

            return builder.ToString();
        }
        #endregion
    }
}
