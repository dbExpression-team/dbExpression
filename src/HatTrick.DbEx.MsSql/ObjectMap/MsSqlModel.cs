using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Data.Common;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.ObjectMap;

namespace HatTrick.DbEx.MsSql.ObjectMap
{
    public class MsSqlModel : SqlModel
    {
        #region internals
        private SqlConnection _sqlDbConnection;
        private List<string> _tableExclusions;
        private List<EntityInfo> _tableInfos;
        private List<EntityInfo> _viewInfos;
        private List<SprocInfo> _sprocInfos;
        private List<ParameterInfo> _sprocParameterInfos;
        private List<TableColumnInfo> _tableColumnInfos;
        private List<ViewColumnInfo> _viewColumnInfos;
        private List<IndexInfo> _indexInfos;
        private List<TypeCodeInfo> _typeCodeInfos;
        private List<SqlRelationship> _relationships;
        #endregion

        #region constructors
        public MsSqlModel(string connectionStringName, string[] tableExclusions = null)
        {
            if (connectionStringName == null)
            {
                throw new ArgumentException("connectionStringName");
            }
            if (connectionStringName == string.Empty)
            {
                throw new ArgumentException("Parameter must be populated with a valid connnection string name", "connectionStringName");
            }

            _sqlDbConnection = new MsSqlConnection(connectionStringName);

            _tableExclusions = tableExclusions == null ? new List<string>() : tableExclusions.ToList();

            this.Initialize();
        }

        public MsSqlModel(ConnectionStringSettings connSettings, string[] tableExclusions = null)
        {
            if (connSettings == null)
            {
                throw new ArgumentException("connSettings");
            }

            _sqlDbConnection = new MsSqlConnection(connSettings);

            _tableExclusions = tableExclusions == null ? new List<string>() : tableExclusions.ToList();

            this.Initialize();
        }
        #endregion

        #region init
        private void Initialize()
        {
            base.ConnectionStringName = _sqlDbConnection.ConnectionName;

            _tableExclusions.Add("sysdiagrams");
            _tableExclusions.Add("__RefactorLog");

            _tableInfos = new List<EntityInfo>();
            _viewInfos = new List<EntityInfo>();
            _sprocInfos = new List<SprocInfo>();
            _sprocParameterInfos = new List<ParameterInfo>();
            _tableColumnInfos = new List<TableColumnInfo>();
            _viewColumnInfos = new List<ViewColumnInfo>();
            _indexInfos = new List<IndexInfo>();
            _relationships = new List<SqlRelationship>();
            _typeCodeInfos = new List<TypeCodeInfo>();

            this.ExtractModel();
        }
        #endregion

        #region methods
        private void ExtractModel()
        {
            this.ParseModelName();
            this.BuildTableInfo();
            this.BuildViewInfo();
            this.BuildSprocInfo();
            this.BuildTypeCodeLibrary();

            if (_tableInfos.Count > 0)
            {
                this.BuildTableColumnInfo();
                this.BuildIndexInfo();
                this.BuildRelationshipInfo();
            }
            if (_viewInfos.Count > 0)
            {
                this.BuildViewColumnInfo();
            }
            if (_sprocInfos.Count > 0)
            {
                this.BuildSprocParameterInfo();
            }


            List<ColumnInfo> cols;
            List<IndexInfo> indexes;
            List<SqlRelationship> relations;
            foreach (EntityInfo ti in _tableInfos)
            {
                cols = (from c in _tableColumnInfos where c.TableId == ti.Id select c).ToList<ColumnInfo>();
                cols.Sort((c1, c2) => c1.ColumnId.CompareTo(c2.ColumnId));
                indexes = (from i in _indexInfos where i.TableId == ti.Id select i).ToList<IndexInfo>();
                relations = (from r in _relationships where r.LocalEntityId == ti.Id select r).ToList<SqlRelationship>();
                MsSqlEntity se = new MsSqlEntity(ti, cols, relations, indexes);
                base.AddEntity(se);
            }

            indexes = new List<IndexInfo>();
            relations = new List<SqlRelationship>();
            foreach (EntityInfo vi in _viewInfos)
            {
                cols = (from c in _viewColumnInfos where c.ViewId == vi.Id select c).ToList<ColumnInfo>();
                cols.Sort((c1, c2) => c1.ColumnId.CompareTo(c2.ColumnId));
                MsSqlEntity ve = new MsSqlEntity(vi, cols, relations, indexes);
                base.AddEntity(ve);
            }

            foreach (SprocInfo s in _sprocInfos)
            {
                SqlSproc sproc = new SqlSproc(s);
                List<SqlParameter> parms = _sprocParameterInfos
                                           .FindAll(spi => spi.ParentObjectId == s.Id)
                                           .ConvertAll<SqlParameter>(spi => new SqlParameter(spi));
                sproc.Parameters.AddRange(parms);
                this.Sprocs.Add(sproc);
            }

            foreach (TypeCodeInfo ti in _typeCodeInfos)
            {
                base.Enums.Add(new SqlEnumeration(ti));
            }
        }

        private void ParseModelName()
        {
            //parse catalog name from connection string...
            //ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[_connectionStringName];
            string con = _sqlDbConnection.ConnectionString;//settings.ConnectionString;
            int idx = con.IndexOf("database=") + 9;
            int idxEnd = con.IndexOf(";", idx);
            base.Name = con.Substring(idx, (idxEnd - idx));
        }

        private void BuildTableInfo()
        {
            //get data table for table info...
            DataTable tableDT;
            string sql = this.BuildTableInfoSql();
            tableDT = _sqlDbConnection.ExecuteDataTable(sql, DbCommandType.SqlText, null);

            EntityInfo ti;
            foreach (DataRow row in tableDT.Rows)
            {
                ti = new EntityInfo();
                ti.Id = row["object_id"].ToString();
                ti.SchemaOwner = row["schema_name"].ToString();
                ti.Name = row["table_name"].ToString();
                ti.EntityType = EntityType.Table;
                _tableInfos.Add(ti);
            }

            if (_tableInfos.Count > 0)
            {
                //get table extended properties
                DataTable tableExtProp;
                string propSql = this.BuildTableExtendedPropInfoSql();
                tableExtProp = _sqlDbConnection.ExecuteDataTable(propSql, DbCommandType.SqlText, null);

                string tableId;
                string propName;
                string propVal;
                foreach (DataRow row in tableExtProp.Rows)
                {
                    tableId = row["table_id"].ToString();
                    propName = row["name"].ToString();
                    propVal = row["value"].ToString();
                    EntityInfo tInfo = ((from t in _tableInfos
                                         where t.Id == tableId
                                         select t).Single() as EntityInfo);
                    tInfo.ExtendedProperties.Add(propName.ToLower(), propVal);
                }
            }
        }

        public void BuildViewInfo()
        {
            //get data table for view info...
            DataTable viewDT;
            string sql = this.BuildViewInfoSql();
            viewDT = _sqlDbConnection.ExecuteDataTable(sql, DbCommandType.SqlText, null);

            EntityInfo vi;
            foreach (DataRow row in viewDT.Rows)
            {
                vi = new EntityInfo();
                vi.Id = row["object_id"].ToString();
                vi.SchemaOwner = row["schema_name"].ToString();
                vi.Name = row["view_name"].ToString();
                vi.EntityType = EntityType.View;
                _viewInfos.Add(vi);
            }

            if (_viewInfos.Count > 0)
            {
                //get view extended properties
                DataTable viewExtProp;
                string propSql = this.BuildViewExtendedPropInfoSql();
                viewExtProp = _sqlDbConnection.ExecuteDataTable(propSql, DbCommandType.SqlText, null);

                string viewId;
                string propName;
                string propVal;
                foreach (DataRow row in viewExtProp.Rows)
                {
                    viewId = row["view_id"].ToString();
                    propName = row["name"].ToString();
                    propVal = row["value"].ToString();
                    EntityInfo vInfo = ((from v in _viewInfos
                                         where v.Id == viewId
                                         select v).Single() as EntityInfo);
                    vInfo.ExtendedProperties.Add(propName.ToLower(), propVal);
                }
            }
        }

        public void BuildSprocInfo()
        {
            DataTable sprocDT;
            string sql = this.BuildSprocInfoSql();
            sprocDT = _sqlDbConnection.ExecuteDataTable(sql, DbCommandType.SqlText, null);

            SprocInfo si;
            foreach (DataRow row in sprocDT.Rows)
            {
                si = new SprocInfo();
                si.Id = row["object_id"].ToString();
                si.SchemaOwner = row["schema_name"].ToString();
                si.Name = row["sproc_name"].ToString();
                si.IsStartupSproc = (bool)row["is_startup_sproc"];
                si.EntityType = EntityType.Sproc;
                _sprocInfos.Add(si);
            }

            if (_sprocInfos.Count > 0)
            {
                //get sproc extended properties
                DataTable sprocExtProp;
                string propSql = this.BuildSprocExtendedPropInfoSql();
                sprocExtProp = _sqlDbConnection.ExecuteDataTable(propSql, DbCommandType.SqlText, null);

                string sprocId;
                string propName;
                string propVal;
                foreach (DataRow row in sprocExtProp.Rows)
                {
                    sprocId = row["sproc_id"].ToString();
                    propName = row["name"].ToString();
                    propVal = row["value"].ToString();
                    SprocInfo sInfo = ((from s in _sprocInfos
                                         where s.Id == sprocId
                                         select s).Single() as SprocInfo);
                    sInfo.ExtendedProperties.Add(propName.ToLower(), propVal);
                }
            }
        }

        private void BuildTableColumnInfo()
        {
            //get data table for table info...
            DataTable columnDT;
            string sql = this.BuildTableColumnInfoSql();
            columnDT = _sqlDbConnection.ExecuteDataTable(sql, DbCommandType.SqlText, null);

            TableColumnInfo ci;
            foreach (DataRow row in columnDT.Rows)
            {
                ci = new TableColumnInfo();
                ci.TableName = row["table_name"].ToString();
                ci.TableId = row["table_id"].ToString();
                ci.ColumnName = row["column_name"].ToString();
                ci.ColumnId = (int)row["column_id"];
                ci.IsIdentity = (bool)row["is_identity"];
                ci.DefaultObjectId = (row["default_object_id"] != DBNull.Value) ? (int?)row["default_object_id"] : null;
                ci.DefaultValueDefinition = (row["default_definition"] != DBNull.Value) ? row["default_definition"].ToString() : string.Empty;
                ci.IsNullable = (bool)row["is_nullable"];
                ci.DataType = row["data_type_name"].ToString();
                ci.CharacterMaxLength = (short)row["max_length"];
                ci.Precision = (byte)row["precision"];
                ci.Scale = (byte)row["scale"];
                ci.IsComputed = (bool)row["is_computed"];
                _tableColumnInfos.Add(ci);
            }

            //get data table for column extended properties
            DataTable columnExtProp;
            string propSql = this.BuildTableColumnExtendedPropInfoSql();
            columnExtProp = _sqlDbConnection.ExecuteDataTable(propSql, DbCommandType.SqlText, null);

            string tableId;
            int columnId;
            string propName;
            string propVal;
            foreach (DataRow row in columnExtProp.Rows)
            {
                tableId = row["table_id"].ToString(); //major_id
                columnId = (int)row["column_id"]; //minor_id
                propName = row["name"].ToString();
                propVal = row["value"].ToString();
                ColumnInfo col = ((from c in _tableColumnInfos
                                   where c.TableId == tableId && c.ColumnId == columnId
                                   select c).Single() as ColumnInfo);
                col.ExtendedProperties.Add(propName.ToLower(), propVal);
            }
        }

        private void BuildViewColumnInfo()
        {
            //get data table for view info...
            DataTable columnDT;
            string sql = this.BuildViewColumnInfoSql();
            columnDT = _sqlDbConnection.ExecuteDataTable(sql, DbCommandType.SqlText, null);

            ViewColumnInfo ci;
            foreach (DataRow row in columnDT.Rows)
            {
                ci = new ViewColumnInfo();
                ci.ViewName = row["view_name"].ToString();
                ci.ViewId = row["view_id"].ToString();
                ci.ColumnName = row["column_name"].ToString();
                ci.ColumnId = (int)row["column_id"];
                ci.IsNullable = (bool)row["is_nullable"];
                ci.DataType = row["data_type_name"].ToString();
                ci.CharacterMaxLength = (short)row["max_length"];
                ci.Precision = (byte)row["precision"];
                ci.Scale = (byte)row["scale"];
                _viewColumnInfos.Add(ci);
            }

            //get data table for column extended properties
            DataTable columnExtProp;
            string propSql = this.BuildViewColumnExtendedPropInfoSql();
            columnExtProp = _sqlDbConnection.ExecuteDataTable(propSql, DbCommandType.SqlText, null);

            string viewId;
            int columnId;
            string propName;
            string propVal;
            foreach (DataRow row in columnExtProp.Rows)
            {
                viewId = row["view_id"].ToString(); //major_id
                columnId = (int)row["column_id"]; //minor_id
                propName = row["name"].ToString();
                propVal = row["value"].ToString();
                ColumnInfo col = ((from c in _viewColumnInfos
                                   where c.ViewId == viewId && c.ColumnId == columnId
                                   select c).Single() as ColumnInfo);
                col.ExtendedProperties.Add(propName.ToLower(), propVal);
            }
        }

        private void BuildSprocParameterInfo()
        {
            //get data table for view info...
            DataTable parameterDT;
            string sql = this.BuildSprocParameterInfoSql();
            parameterDT = _sqlDbConnection.ExecuteDataTable(sql, DbCommandType.SqlText, null);

            ParameterInfo pi;
            foreach (DataRow row in parameterDT.Rows)
            {
                pi = new ParameterInfo();
                pi.ParentObjectName = row["sproc_name"].ToString();
                pi.ParentObjectId = row["sproc_id"].ToString();
                pi.Name = row["parameter_name"].ToString();
                pi.DataType = row["data_type_name"].ToString();
                pi.MaxLength = (short)row["max_length"];
                pi.Precision = (byte)row["precision"];
                pi.Scale = (byte)row["scale"];
                pi.ParameterId = (int)row["parameter_id"];
                pi.IsOutputParameter = (bool)row["is_output"];
                _sprocParameterInfos.Add(pi);
            }

            //get data table for column extended properties
            DataTable sprocExtProp;
            string propSql = this.BuildSprocParameterExtendedPropInfoSql();
            sprocExtProp = _sqlDbConnection.ExecuteDataTable(propSql, DbCommandType.SqlText, null);

            string sprocId;
            int parameterId;
            string propName;
            string propVal;
            foreach (DataRow row in sprocExtProp.Rows)
            {
                sprocId = row["sproc_id"].ToString(); //major_id
                parameterId = (int)row["parameter_id"]; //minor_id
                propName = row["name"].ToString();
                propVal = row["value"].ToString();
                ParameterInfo param = ((from p in _sprocParameterInfos
                                   where p.ParentObjectId == sprocId && p.ParameterId == parameterId
                                   select p).Single() as ParameterInfo);
                param.ExtendedProperties.Add(propName.ToLower(), propVal);
            }
        }

        private void BuildIndexInfo()
        {
            //get data table for index info...
            DataTable indexDT;
            string sql = this.BuildIndexInfoSql();
            indexDT = _sqlDbConnection.ExecuteDataTable(sql, DbCommandType.SqlText, null);

            IndexInfo ii;
            foreach (DataRow row in indexDT.Rows)
            {
                ii = new IndexInfo();
                ii.IndexName = row["index_name"].ToString();
                ii.IndexId = string.Concat(row["table_id"].ToString(), "_", row["index_id"].ToString());
                ii.TableName = row["table_name"].ToString();
                ii.TableId = row["table_id"].ToString();
                ii.ColumnName = row["column_name"].ToString();
                ii.ColumnId = (int)row["column_id"];
                ii.IndexTypeCode = (byte)row["index_type_code"];
                ii.IsUnique = (bool)row["is_unique"];
                ii.IsDescendingKey = (bool)row["is_descending_key"];
                ii.ColumnOrdinal = (byte)row["key_ordinal"];
                ii.IsPrimaryKey = (bool)row["is_primary_key"];
                ii.IsIncludeColumn = (bool)row["is_included_column"];
                _indexInfos.Add(ii);
            }
        }

        private void BuildRelationshipInfo()
        {
            //get data table for relationship info...
            DataTable relationshipDT;
            string sql = this.BuildRelationshipsSql();
            relationshipDT = _sqlDbConnection.ExecuteDataTable(sql, DbCommandType.SqlText, null);

            SqlRelationship r;
            foreach (DataRow row in relationshipDT.Rows)
            {
                r = new SqlRelationship();
                r.Name = row["Relationship"].ToString();
                r.LocalEntityId = row["BaseEntityId"].ToString();
                r.LocalEntity = row["BaseEntity"].ToString();
                r.LocalField = row["BaseField"].ToString();
                r.ReferencedEntityId = row["ReferencedEntityId"].ToString();
                r.ReferencedEntity = row["ReferencedEntity"].ToString();
                r.ReferencedField = row["ReferencedField"].ToString();
                _relationships.Add(r);
            }
        }

        private void BuildTypeCodeLibrary()
        {
            //get data table for table info...
            DataTable typeCodeDT;
            string sql = this.BuildTypeCodeInfoSql();

            try
            {
                typeCodeDT = _sqlDbConnection.ExecuteDataTable(sql, DbCommandType.SqlText, null);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return;
            }

            //List<TypeCodeInfo> typeCodeDefList = new List<TypeCodeInfo>();
            string currentName = null;
            TypeCodeInfo typeCodeInfo = null;
            TypeCodeItemInfo typeCodeItm = null;
            foreach (DataRow row in typeCodeDT.Rows)
            {
                if (currentName == null || currentName != row["Name"].ToString())
                {
                    currentName = row["Name"].ToString();
                    typeCodeInfo = new TypeCodeInfo();
                    typeCodeInfo.Name = currentName;
                    _typeCodeInfos.Add(typeCodeInfo);
                }
                typeCodeItm = new TypeCodeItemInfo();
                typeCodeItm.Key = row["Key"].ToString();
                typeCodeItm.Value = row["Value"].ToString(); ;
                typeCodeItm.FriendlyName = row["FriendlyName"].ToString();
                typeCodeItm.Description = row["Description"].ToString();
                typeCodeInfo.TypeCodeItems.Add(typeCodeItm);
            }
        }

        private string BuildTableInfoSql()
        {
            string exclusionClause = string.Empty;
            string inClause = string.Empty;

            if (_tableExclusions.Count > 0)
            {
                inClause = "('" + string.Join("','", _tableExclusions.ToArray()) + "')";
                exclusionClause = "AND sys.objects.name NOT IN " + inClause;
            }

            string sql;
            sql = string.Format(@"SELECT 
                                sys.objects.name as table_name, 
                                sys.objects.object_id,
                                sys.schemas.name as schema_name
                                FROM sys.objects
                                INNER JOIN sys.schemas on sys.objects.schema_id = sys.schemas.schema_id
                                WHERE type = 'U'{0} order by table_name;", exclusionClause);

            return sql;
        }

        private string BuildViewInfoSql()
        {
            string sql;
            sql = @"SELECT 
                        sys.objects.name as view_name, 
                        sys.objects.object_id,
                        sys.schemas.name as schema_name
                        FROM sys.objects
                        INNER JOIN sys.schemas on sys.objects.schema_id = sys.schemas.schema_id
                        WHERE type = 'V' order by view_name;";

            return sql;
        }

        private string BuildSprocInfoSql()
        {
            string sql;
            sql = @"SELECT 
	                    sys.objects.name as sproc_name, 
	                    sys.objects.object_id,
	                    sys.schemas.name as schema_name,
	                    sys.procedures.is_auto_executed as is_startup_sproc
                    FROM sys.objects
                    INNER JOIN sys.schemas on sys.objects.schema_id = sys.schemas.schema_id
                    INNER JOIN sys.procedures on sys.procedures.object_id = sys.objects.object_id
                    WHERE sys.objects.type = 'P' order by sproc_name;";

            return sql;
        }

        private string BuildTableExtendedPropInfoSql()
        {
            List<string> tableIdList = (from t in _tableInfos select t.Id).ToList<string>();
            string sql;
            sql = string.Format(@"SELECT 
                    major_id as table_id,
                    name,
                    value
                    FROM sys.extended_properties 
                    WHERE major_id in ({0}) 
                    AND minor_id = 0;", string.Join(",", tableIdList.ToArray()));

            return sql;
        }

        private string BuildViewExtendedPropInfoSql()
        {
            List<string> viewIdList = (from v in _viewInfos select v.Id).ToList<string>();
            string sql;
            sql = string.Format(@"SELECT 
                    major_id as view_id,
                    name,
                    value
                    FROM sys.extended_properties 
                    WHERE major_id in ({0}) 
                    AND minor_id = 0;", string.Join(",", viewIdList.ToArray()));

            return sql;
        }

        private string BuildSprocExtendedPropInfoSql()
        {
            List<string> sprocIdList = (from s in _sprocInfos select s.Id).ToList<string>();
            string sql;
            sql = string.Format(@"SELECT 
                    major_id as sproc_id,
                    name,
                    value
                    FROM sys.extended_properties 
                    WHERE major_id in ({0}) 
                    AND minor_id = 0;", string.Join(",", sprocIdList.ToArray()));

            return sql;
        }

        private string BuildTableColumnInfoSql()
        {
            List<string> tableIdList = (from t in _tableInfos select t.Id).ToList<string>();
            string sql;
            sql = string.Format(@"SELECT
                                sys.objects.name as table_name, 
                                sys.objects.object_id as table_id,
                                sys.columns.name as column_name, 
                                sys.columns.column_id,
                                sys.columns.is_identity, 
                                sys.columns.default_object_id,
                                sys.default_constraints.definition as default_definition, 
                                sys.columns.is_nullable,
                                sys.types.name as data_type_name,
                                sys.columns.max_length,
                                sys.columns.scale,
                                sys.columns.precision,
                                sys.columns.is_computed
                                FROM sys.columns
                                INNER JOIN sys.objects ON sys.objects.object_id = sys.columns.object_id
                                INNER JOIN sys.types ON sys.columns.user_type_id = sys.types.user_type_id
                                LEFT OUTER JOIN sys.default_constraints ON sys.columns.default_object_id = sys.default_constraints.object_id
                                WHERE sys.objects.type = 'U'
                                AND sys.objects.object_id IN ('{0}');", string.Join("','", tableIdList.ToArray()));

            return sql;
        }

        private string BuildViewColumnInfoSql()
        {
             List<string> viewIdList = (from v in _viewInfos select v.Id).ToList<string>();
            string sql;
            sql = string.Format(@"SELECT
                                    sys.objects.name as view_name, 
                                    sys.objects.object_id as view_id,
                                    sys.columns.name as column_name, 
                                    sys.columns.column_id,
                                    sys.columns.is_nullable,
                                    sys.types.name as data_type_name,
                                    sys.columns.max_length,
                                    sys.columns.scale,
                                    sys.columns.precision
                                    FROM sys.columns
                                    INNER JOIN sys.objects ON sys.objects.object_id = sys.columns.object_id
                                    INNER JOIN sys.types ON sys.columns.user_type_id = sys.types.user_type_id
                                    WHERE sys.objects.type = 'V'
                                    AND sys.objects.object_id IN ('{0}');", string.Join("','", viewIdList.ToArray()));
            return sql;
        }

        private string BuildSprocParameterInfoSql()
        {
            List<string> sprocIdList = (from s in _sprocInfos select s.Id).ToList<string>();

            string sql;
            sql = string.Format(@"SELECT
                sys.objects.name as sproc_name, 
                sys.objects.object_id as sproc_id,
                sys.parameters.name as parameter_name, 
                sys.parameters.parameter_id,
                /*sys.parameters.is_nullable,*/
                sys.types.name as data_type_name,
                sys.parameters.max_length,
                sys.parameters.scale,
                sys.parameters.precision,
                sys.parameters.is_output
            FROM sys.parameters
            INNER JOIN sys.objects ON sys.objects.object_id = sys.parameters.object_id
            INNER JOIN sys.types ON sys.parameters.user_type_id = sys.types.user_type_id
            WHERE sys.objects.type = 'P'
            AND sys.objects.object_id IN ({0});", string.Join(",", sprocIdList.ToArray()));

            return sql;
        }

        private string BuildTableColumnExtendedPropInfoSql()
        {
            List<string> tableIdList = (from t in _tableInfos select t.Id).ToList<string>();
            string sql;

            sql = string.Format(@"SELECT 
                    major_id as table_id, 
                    minor_id as column_id,
                    name,
                    value 
                    FROM sys.extended_properties
                    WHERE major_id IN ({0}) 
                    AND minor_id > 0;", string.Join(",", tableIdList.ToArray()));

            return sql;
        }

        private string BuildViewColumnExtendedPropInfoSql()
        {
            List<string> viewIdList = (from v in _viewInfos select v.Id).ToList<string>();
            string sql;

            sql = string.Format(@"SELECT 
                    major_id view_id, 
                    minor_id as column_id,
                    name,
                    value 
                    FROM sys.extended_properties
                    WHERE major_id IN ({0}) 
                    AND minor_id > 0;", string.Join(",", viewIdList.ToArray()));

            return sql;
        }

        private string BuildSprocParameterExtendedPropInfoSql()
        {
            List<string> sprocIdList = (from s in _sprocInfos select s.Id).ToList<string>();
            string sql;

            sql = string.Format(@"SELECT 
                    major_id sproc_id, 
                    minor_id as parameter_id,
                    name,
                    value 
                    FROM sys.extended_properties
                    WHERE major_id IN ({0}) 
                    AND minor_id > 0;", string.Join(",", sprocIdList.ToArray()));

            return sql;
        }

        private string BuildIndexInfoSql()
        {
            List<string> tableIdList = (from t in _tableInfos select t.Id).ToList<string>();

            string sql;
            sql = string.Format(@"SELECT
                    sys.indexes.name as index_name,
                    sys.indexes.index_id,
                    sys.objects.name as table_name,
                    sys.index_columns.object_id as table_id,
                    sys.columns.name as column_name,
                    sys.index_columns.column_id,
                    sys.indexes.type as index_type_code,
                    sys.indexes.is_unique,
                    sys.index_columns.is_descending_key,
                    sys.index_columns.key_ordinal,
                    sys.indexes.is_primary_key,
                    sys.index_columns.is_included_column
                    FROM
                    sys.index_columns
                    INNER JOIN sys.objects ON sys.index_columns.object_id = sys.objects.object_id
                    INNER JOIN sys.columns ON sys.columns.object_id = sys.index_columns.object_id AND sys.index_columns.column_id = sys.columns.column_id
                    INNER JOIN sys.indexes ON sys.indexes.object_id = sys.index_columns.object_id AND sys.indexes.index_id = sys.index_columns.index_id
                    WHERE sys.indexes.type IN (1,2) AND sys.columns.object_id IN ('{0}');", 
                    string.Join("','", tableIdList.ToArray())); ;
            return sql;
        }

        private string BuildRelationshipsSql()
        {
            List<string> tableIdList = (from t in _tableInfos select t.Id).ToList<string>();

            string sql;
            sql = string.Format(@"SELECT 
            Relationship.name AS Relationship,
            BaseEntity.object_id as BaseEntityId,
            BaseEntity.name AS BaseEntity ,
            BaseField.name as BaseField,
            ReferencedEntity.object_id as ReferencedEntityId,
            ReferencedEntity.name as ReferencedEntity,
            ReferencedField.name as ReferencedField
            FROM sys.foreign_key_columns AS fkc
            INNER JOIN sys.objects As Relationship ON (Relationship.object_id = fkc.constraint_object_id)
            INNER JOIN sys.objects AS BaseEntity ON (fkc.parent_object_id = BaseEntity.object_id)
            INNER JOIN sys.columns As BaseField ON (fkc.parent_object_id = BaseField.object_id AND fkc.parent_column_id = BaseField.column_id)
            INNER JOIN sys.objects AS ReferencedEntity ON (fkc.referenced_object_id = ReferencedEntity.object_id)
            INNER JOIN sys.columns As ReferencedField ON (fkc.referenced_object_id = ReferencedField.object_id AND fkc.referenced_column_id = ReferencedField.column_id)
            WHERE fkc.parent_object_id IN ('{0}');", string.Join("','", tableIdList.ToArray()));
            return sql;
        }

        private string BuildTypeCodeInfoSql()
        {
            string sql = "SELECT * FROM TypeCode;";
            return sql;
        }
        #endregion

        #region try get database name
        public bool TryGetDatabaseName(out string dbName)
        {
            dbName = null;
            DbConnectionStringBuilder connBuilder = new DbConnectionStringBuilder();
            connBuilder.ConnectionString = _sqlDbConnection.ConnectionString;
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
