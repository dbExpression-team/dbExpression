using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression
{
    public class DBInsertDirective<T>
    {
        #region internals
        private string _connStringName;
        private ConnectionStringSettings _connSettings;
        private T _record;
        #endregion

        #region constructors
        public DBInsertDirective(string connectionStringName, T record)
        {
            if (string.IsNullOrEmpty(connectionStringName))
            {
                throw new ArgumentException("parameter must contain a value", nameof(connectionStringName));
            }

            if (record == null)
            {
                throw new ArgumentNullException("parameter must contain a value", nameof(record));
            }

            _connStringName = connectionStringName;
            _record = record;
            _connSettings = ConfigurationManager.ConnectionStrings[connectionStringName];

            if (_connSettings == null)
            {
                throw new ArgumentException("no connections string setting found for provided name", nameof(connectionStringName));
            }
        }

        public DBInsertDirective(ConnectionStringSettings connectionStringSettings, T record)
        {
            _record = record;
            _connSettings = connectionStringSettings ?? throw new ArgumentNullException("connections string settings are required");
            _connStringName = connectionStringSettings.Name;
        }
        #endregion

        #region into
        public InsertMsSqlBuilder<T> Into(DBExpressionEntity<T> entity)
        {
            return new InsertMsSqlBuilder<T>(_connSettings, entity, _record);
        }
        #endregion
    }
}
