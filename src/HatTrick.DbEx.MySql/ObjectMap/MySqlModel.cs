using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Data.Common;
using HTL.DbEx.Sql;
using HTL.DbEx.Sql.ObjectMap;

namespace HTL.DbEx.MySql.ObjectMap
{
    public class MySqlModel : SqlModel
    {
        #region internals
        ConnectionStringSettings _connSettings;
        private MySqlConnection _sqlDbConnection;

        private List<string> _tableExclusions;
        private List<EntityInfo> _tableInfos;
        private List<EntityInfo> _viewInfos;
        //private List<SprocInfo> _sprocInfos;
        //private List<ParameterInfo> _sprocParameterInfos;
        private List<TableColumnInfo> _tableColumnInfos;
        private List<ViewColumnInfo> _viewColumnInfos;
        private List<IndexInfo> _indexInfos;
        private List<TypeCodeInfo> _typeCodeInfos;
        private List<SqlRelationship> _relationships;
        #endregion

        #region interface
        #endregion

        #region constructors
        public MySqlModel(string connectionStringName, string[] tableExclusions = null)
        {
            if (connectionStringName == null)
            {
                throw new ArgumentException("connectionStringName");
            }
            if (connectionStringName == string.Empty)
            {
                throw new ArgumentException("Parameter must be populated with a valid connnection string name", "connectionStringName");
            }
            ConnectionStringSettings connSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
            _connSettings = connSettings;

            _sqlDbConnection = new MySqlConnection(connectionStringName);

            _tableExclusions = tableExclusions == null ? new List<string>() : tableExclusions.ToList();

            this.Initialize();
        }

        public MySqlModel(ConnectionStringSettings connSettings, string[] tableExclusions = null)
        {
            _connSettings = connSettings ?? throw new ArgumentException("connSettings");

            _sqlDbConnection = new MySqlConnection(connSettings);

            _tableExclusions = tableExclusions == null ? new List<string>() : tableExclusions.ToList();

            this.Initialize();
        }
        #endregion

        #region init
        private void Initialize()
        {
            base.ConnectionStringName = _sqlDbConnection.ConnectionName;

            _tableInfos = new List<EntityInfo>();
            _viewInfos = new List<EntityInfo>();
            _tableColumnInfos = new List<TableColumnInfo>();
            _viewColumnInfos = new List<ViewColumnInfo>();
            _indexInfos = new List<IndexInfo>();
            _relationships = new List<SqlRelationship>();
            _typeCodeInfos = new List<TypeCodeInfo>();

            if (!this.TryGetDatabaseName(out string dbName))
            {
                throw new InvalidOperationException("Could not find database name [database] or [initial catalog] in provided connection string.");
            }

            this.ExtractModel(dbName);
        }
        #endregion

        #region extract model
        private void ExtractModel(string dbName)
        {
            base.Name = dbName;

            //get tables
            this.BuildTableInfo(dbName);
            this.BuildViewInfo(dbName);

            if (_tableInfos.Count > 0)
            {
                this.BuildTableColumnInfo(dbName);
            }
            if (_viewInfos.Count > 0)
            {
                this.BuildViewColumnInfo(dbName);
            }

            List<ColumnInfo> cols;
            foreach (EntityInfo ti in _tableInfos)
            {
                cols = (from c in _tableColumnInfos where c.TableId == ti.Id select c).ToList<ColumnInfo>();
                cols.Sort((c1, c2) => c1.Ordinal.CompareTo(c2.Ordinal));
                MySqlEntity se = new MySqlEntity(ti, cols, null, null);
                base.AddEntity(se);
            }
        }
        #endregion

        #region build table info
        private void BuildTableInfo(string dbName)
        {
            string inClause = $"('{string.Join("','", _tableExclusions.ToArray())}')";
            DataTable dt;
            string sql = $"select * from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = '{dbName}' and TABLE_TYPE = 'BASE TABLE' and TABLE_NAME not in {inClause};";

            dt = _sqlDbConnection.ExecuteDataTable(sql, DbCommandType.SqlText, null);

            EntityInfo ti;
            foreach (DataRow row in dt.Rows)
            {
                ti = new EntityInfo();
                ti.Id = row["TABLE_NAME"].ToString();
                ti.SchemaOwner = row["TABLE_SCHEMA"].ToString();
                ti.Name = row["TABLE_NAME"].ToString();
                ti.EntityType = EntityType.Table;
                _tableInfos.Add(ti);
            }
        }
        #endregion

        #region build view info
        private void BuildViewInfo(string dbName)
        {
            DataTable dt;
            string sql = $"select * from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = '{dbName}' and TABLE_TYPE = 'VIEW';";

            dt = _sqlDbConnection.ExecuteDataTable(sql, DbCommandType.SqlText, null);

            EntityInfo vi;
            foreach (DataRow row in dt.Rows)
            {
                vi = new EntityInfo();
                vi.Id = row["TABLE_NAME"].ToString();
                vi.SchemaOwner = row["TABLE_SCHEMA"].ToString();
                vi.Name = row["TABLE_NAME"].ToString();
                vi.EntityType = EntityType.Table;
                _viewInfos.Add(vi);
            }
        }
        #endregion

        #region build table column info
        private void BuildTableColumnInfo(string dbName)
        {
            //get data table for table info...
            DataTable dt;
            string[] names = _tableInfos.ConvertAll(t => $"'{t.Name}',").ToArray();
            names[names.Length - 1] = names[names.Length - 1].TrimEnd(',');

            string sql = $"select * from information_schema.COLUMNS where TABLE_SCHEMA = '{dbName}' and TABLE_NAME in ({string.Join(" ", names)});";
            dt = _sqlDbConnection.ExecuteDataTable(sql, DbCommandType.SqlText, null);

            TableColumnInfo ci;
            foreach (DataRow row in dt.Rows)
            {
                ci = new TableColumnInfo();
                ci.TableId = row["TABLE_NAME"].ToString();
                ci.TableName = row["TABLE_NAME"].ToString();
                ci.ColumnName = row["COLUMN_NAME"].ToString();
                ci.Ordinal = Convert.ToInt32((ulong)row["ORDINAL_POSITION"]);
                ci.IsIdentity = (row["EXTRA"] != DBNull.Value) ? row["EXTRA"].ToString().ToLower() == "auto_increment" : false;
                ci.DefaultValueDefinition = (row["COLUMN_DEFAULT"] != DBNull.Value) ? row["COLUMN_DEFAULT"].ToString() : string.Empty;
                ci.IsNullable = row["IS_NULLABLE"].ToString().ToLower() == "yes";
                ci.DataType = row["DATA_TYPE"].ToString();
                if (row["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value)
                {
                    ulong ul = (ulong)row["CHARACTER_MAXIMUM_LENGTH"];
                    if (ul > Int32.MaxValue)
                    {
                        ci.CharacterMaxLength = Int32.MaxValue;
                    }
                    else
                    {
                        ci.CharacterMaxLength = Convert.ToInt32((ulong)row["CHARACTER_MAXIMUM_LENGTH"]);
                    }
                }
                if (row["NUMERIC_PRECISION"] != DBNull.Value)
                {
                    ci.Precision = Convert.ToByte((ulong)row["NUMERIC_PRECISION"]);
                }
                if (row["NUMERIC_SCALE"] != DBNull.Value)
                {
                    ci.Scale = Convert.ToByte((ulong)row["NUMERIC_SCALE"]);
                }
                ci.IsPrimaryKey = (row["COLUMN_KEY"] != DBNull.Value) ? row["COLUMN_KEY"].ToString().ToLower() == "pri" : false;
                ci.UnSigned = (row["COLUMN_TYPE"] != DBNull.Value) ? row["COLUMN_TYPE"].ToString().ToLower().EndsWith("unsigned") : false;
                _tableColumnInfos.Add(ci);
            }
        }
        #endregion

        #region build view column info
        private void BuildViewColumnInfo(string dbName)
        {
            //get data table for table info...
            DataTable dt;
            string[] names = _viewInfos.ConvertAll<string>(v => $"'{v.Name}',").ToArray();
            names[names.Length - 1] = names[names.Length - 1].TrimEnd(',');

            string sql = $"select * from information_schema.COLUMNS where TABLE_SCHEMA = '{dbName}' and TABLE_NAME in ({string.Join(" ", names)});";
            dt = _sqlDbConnection.ExecuteDataTable(sql, DbCommandType.SqlText, null);

            ViewColumnInfo ci;
            foreach (DataRow row in dt.Rows)
            {
                ci = new ViewColumnInfo();
                ci.ViewName = row["TABLE_NAME"].ToString();
                ci.ColumnName = row["COLUMN_NAME"].ToString();
                ci.Ordinal = Convert.ToInt32((ulong)row["ORDINAL_POSITION"]);
                ci.IsIdentity = (row["EXTRA"] != DBNull.Value) ? row["EXTRA"].ToString().ToLower() == "auto_increment" : false;
                ci.DefaultValueDefinition = (row["COLUMN_DEFAULT"] != DBNull.Value) ? row["COLUMN_DEFAULT"].ToString() : string.Empty;
                ci.IsNullable = row["IS_NULLABLE"].ToString().ToLower() == "yes";
                ci.DataType = row["DATA_TYPE"].ToString();
                if (row["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value)
                {
                    ulong ul = (ulong)row["CHARACTER_MAXIMUM_LENGTH"];
                    if (ul > Int32.MaxValue)
                    {
                        ci.CharacterMaxLength = Int32.MaxValue;
                    }
                    else
                    {
                        ci.CharacterMaxLength = Convert.ToInt32((ulong)row["CHARACTER_MAXIMUM_LENGTH"]);
                    }
                }
                if (row["NUMERIC_PRECISION"] != DBNull.Value)
                {
                    ci.Precision = Convert.ToByte((ulong)row["NUMERIC_PRECISION"]);
                }
                if (row["NUMERIC_SCALE"] != DBNull.Value)
                {
                    ci.Scale = Convert.ToByte((ulong)row["NUMERIC_SCALE"]);
                }
                ci.IsPrimaryKey = (row["COLUMN_KEY"] != DBNull.Value) ? row["COLUMN_KEY"].ToString().ToLower() == "pri" : false;
                ci.UnSigned = (row["COLUMN_TYPE"] != DBNull.Value) ? row["COLUMN_TYPE"].ToString().ToLower().EndsWith("unsigned") : false;
                _viewColumnInfos.Add(ci);
            }
        }
        #endregion

        #region try get database name
        public bool TryGetDatabaseName(out string dbName)
        {
            dbName = null;

            var connBuilder = new DbConnectionStringBuilder();
            connBuilder.ConnectionString = _connSettings.ConnectionString;
            string keyward = "database";
            RETRY:
            try
            {
                dbName = (string)connBuilder[keyward];
            }
            catch
            {
                if (keyward == "database")
                {
                    keyward = "initial catalog";
                    goto RETRY;
                }
            }

            return (dbName != null);
        }
        #endregion
    }
}