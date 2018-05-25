using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression
{
    public class DBUpdateDirective
    {
        #region internals
        private string _connStringName;
        private ConnectionStringSettings _connSettings;
        private DBAssignmentExpressionSet _assignments;
        #endregion

        #region constructors
        public DBUpdateDirective(string connectionStringName, params DBAssignmentExpression[] assignments)
        {
            if (string.IsNullOrEmpty(connectionStringName))
            {
                throw new ArgumentException("parameter must contain a value", nameof(connectionStringName));
            }

            _connStringName = connectionStringName;
            
            _connSettings = ConfigurationManager.ConnectionStrings[connectionStringName];

            if (_connSettings == null)
            {
                throw new ArgumentException("no connections string setting found for provided name", nameof(connectionStringName));
            }

            for (int i = 0; i < assignments.Length; i++)
            {
                _assignments &= assignments[i];
            }
        }
        #endregion

        #region into
        public UpdateMsSqlBuilder<T> From<T>(DBExpressionEntity<T> entity)
        {
            var builder = new UpdateMsSqlBuilder<T>(_connSettings, entity);
            builder.Expression &= _assignments;
            return builder;
        }
        #endregion
    }
}
