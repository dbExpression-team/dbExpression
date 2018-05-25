using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression
{
    public class DBSelectDirective
    {
        #region internals
        private string _connStringName;
        private ConnectionStringSettings _connSettings;
        #endregion

        #region interface
        protected ConnectionStringSettings ConnectionStringSettings { get { return _connSettings; } }
        #endregion

        #region constructors
        public DBSelectDirective(string connectionStringName)
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
        public SelectMsSqlBuilder<T> From<T>(DBExpressionEntity<T> entity)
        {
            var builder = new SelectMsSqlBuilder<T>(_connSettings, entity);
            return builder;
        }
        #endregion
    }

    public class DBSelectDirective<T> : DBSelectDirective
    {
        #region internals
        private DBSelectExpressionSet _selectSet;
        #endregion

        #region constructors
        public DBSelectDirective(string connectionStringName, params DBExpressionField[] fields) : base(connectionStringName)
        {
            for (int i = 0; i < fields.Length; i++)
            {
                _selectSet &= fields[i];
            }
        }

        public DBSelectDirective(string connectionStringName, DBSelectExpression select) : base(connectionStringName)
        {
            _selectSet &= select;
        }

        public DBSelectDirective(string connectionStringName, DBSelectExpressionSet selectSet) : base(connectionStringName)
        {
            _selectSet = selectSet;
        }
        #endregion

        #region into
        public SelectMsSqlBuilder<T> From(DBExpressionEntity<T> entity)
        {
            var builder = new SelectMsSqlBuilder<T>(base.ConnectionStringSettings, entity);
            builder.Expression &= _selectSet;
            return builder;
        }
        #endregion
    }
}
