using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression
{
    public class DBDeleteDirective
    {
        #region internals
        private string _connStringName;
        private ConnectionStringSettings _connSettings;
        #endregion

        #region constructors
        public DBDeleteDirective(string connectionStringName)
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
        }
        #endregion

        #region into
        public DeleteMsSqlBuilder<T> From<T>(DBExpressionEntity<T> entity)
        {
            var builder = new DeleteMsSqlBuilder<T>(_connSettings, entity);
            return builder;
        }
        #endregion
    }
}
