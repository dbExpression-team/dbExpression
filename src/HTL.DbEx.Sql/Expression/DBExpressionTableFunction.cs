using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBExpressionTableFunction : DBExpressionEntity
    {
        #region internals
        private string _function = string.Empty;
        private object[] _arguments = { };
        #endregion

        #region interface
        public string Function
        { get { return _function; }
        }

        public object[] Arguments
        { get { return _arguments; } }
        #endregion

        #region methods
        public DBExpressionTableFunction(string schema, string tableName, string function, params object[] arguments) : base(schema, tableName)
        {
            _function = function;
            _arguments = arguments ?? new object[0];
        }

        public string ToParameterizedString(List<DbParameter> parameterList, SqlConnection dbService)
        {
            StringBuilder builder = new StringBuilder();
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

            builder.Append(") AS [" + Name + "]");

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

            builder.Append(") AS [" + Name + "]");

            return builder.ToString();
        }
        #endregion
    }
}
