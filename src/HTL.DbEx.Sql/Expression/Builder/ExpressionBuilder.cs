using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace HTL.DbEx.Sql.Expression
{
    public abstract class SqlExpressionBuilder<T> where T : new()
    {
        #region internals
        protected DBExpressionSet _set;
        protected DBExpressionEntity _baseEntity;
        protected bool _isIdentityEntity;
        protected bool _isDistinct;
        protected int? _top;
        protected int? _bottom;
        protected int? _skip;
        protected int? _limit;
        protected bool _getTotalCount;
        protected int? _totalCount;
        protected ExecutionContext? _execContext;
        protected bool _isValidated;
        protected SelectExpressionProvider _selectExprProvider;
        protected InsertExpressionProvider<T> _insertExpressionProvider;
        protected FillObjectCallback<T> _fillCallback;
        //protected string _connectionStringName;
        protected ConnectionStringSettings _connectionStringSettings;
        protected List<DbParameter> _dbParams;
        protected SqlConnection _sqlDbClient;
        #endregion

        #region interface properties
        public DBExpressionEntity BaseEntity
        { get { return _baseEntity; } }

        public DBExpressionSet Expression
        {
            get { return _set; }
            set { _set = value; }
        }

        protected ExecutionContext? CommandExecutionContext
        {
            get { return _execContext; }
            set { _execContext = value; }
        }

        internal int? Limit
        {
            get { return _limit; }
            set { _limit = value; }
        }

        public SqlConnection SqlClient
        {
            get
            {
                return (_sqlDbClient == null) ? _sqlDbClient = this.GetSqlConnection() : _sqlDbClient;
            }
            private set
            {
                if (_sqlDbClient != null) { throw new InvalidOperationException("SqlDbClient is already initialized.  The Expression builder can only be enlisted with a SqlDbClient one time."); }
                _sqlDbClient = value;
            }
        }
        #endregion

        #region constructors
        public SqlExpressionBuilder(string connectionStringName, DBExpressionEntity baseEntity) 
             : this(ConfigurationManager.ConnectionStrings[connectionStringName], baseEntity)
        {
            //_connectionStringName = connectionStringName;
            //_baseEntity = baseEntity;
            //_dbParams = new List<DbParameter>();
            //_set = new DBExpressionSet();
        }

        public SqlExpressionBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity baseEntity)
        {
            if (connectionStringSettings == null)
            {
                throw new ArgumentNullException(nameof(connectionStringSettings));
            }

            _connectionStringSettings = connectionStringSettings;
            //_connectionStringName = _connectionStringSettings.Name;
            _baseEntity = baseEntity;
            _dbParams = new List<DbParameter>();
            _set = new DBExpressionSet();
        }
        #endregion

        #region with select expression provider
        public SqlExpressionBuilder<T> WithSelectExpressionProvider(SelectExpressionProvider selectExpressionProvider)
        {
            _selectExprProvider = selectExpressionProvider;
            return this;
        }
        #endregion

        #region with fill callback
        public SqlExpressionBuilder<T> WithFillCallback(FillObjectCallback<T> fillCallback)
        {
            _fillCallback = fillCallback;
            return this;
        }
        #endregion

        #region with insert expression provider
        public SqlExpressionBuilder<T> WithInsertExpressionProvider(InsertExpressionProvider<T> insertExpressionProvider)
        {
            _insertExpressionProvider = insertExpressionProvider;
            return this;
        }
        #endregion

        #region query build methods
        public virtual SqlExpressionBuilder<T> Enlist(SqlConnection sqlClient)
        {
            this.SqlClient = sqlClient;
            return this;
        }

        public virtual SqlExpressionBuilder<T> Select(params DBSelectExpression[] selectExpressions)
        {
            for (int i = 0; i < selectExpressions.Length; i++)
            {
                _set &= selectExpressions[i];
            }
            return this;
        }

        public virtual SqlExpressionBuilder<T> Select(DBSelectExpressionSet selectExpressionSet)
        {
            _set &= selectExpressionSet;
            return this;
        }

        public virtual SqlExpressionBuilder<T> Distinct()
        {
            _isDistinct = true;
            return this;
        }

        public virtual SqlExpressionBuilder<T> SetFields(params DBAssignmentExpression[] assignmentExpressions)
        {
            for (int i = 0; i < assignmentExpressions.Length; i++)
            {
                _set &= assignmentExpressions[i];
            }
            return this;
        }

        public virtual SqlExpressionBuilder<T> SetFields(DBAssignmentExpressionSet assignmentExpressionSet)
        {
            _set &= assignmentExpressionSet;
            return this;
        }

        public virtual SqlExpressionBuilder<T> Where(DBFilterExpressionSet filter)
        {
            _set &= filter;
            return this;
        }

        public virtual SqlExpressionBuilder<T> OrderBy(DBOrderByExpressionSet orderBy)
        {
            _set &= orderBy;
            return this;
        }

        public virtual SqlExpressionBuilder<T> GroupBy(params DBGroupByExpression[] groupBy)
        {
            foreach (DBGroupByExpression g in groupBy)
            {
                _set &= g;
            }
            return this;
        }

        public virtual SqlExpressionBuilder<T> Having(DBHavingExpression havingCondition)
        {
            _set &= havingCondition;
            return this;
        }

        public virtual SqlExpressionBuilder<T> Top(int count)
        {
            _top = count;
            return this;
        }

        public virtual SqlExpressionBuilder<T> Bottom(int count)
        {
            _bottom = count;
            return this;
        }

        public virtual DBSkipDirective<T> Skip(int count)
        {
            _skip = count;
            return new DBSkipDirective<T>(this);
        }

        public virtual DBJoinDirective<T> InnerJoin(DBExpressionEntity joinTo)
        {
            return new DBJoinDirective<T>(this, joinTo, DBExpressionJoinType.INNER);
        }

        public virtual DBJoinDirective<T> LeftJoin(DBExpressionEntity joinTo)
        {
            return new DBJoinDirective<T>(this, joinTo, DBExpressionJoinType.LEFT);
        }

        public virtual DBJoinDirective<T> RightJoin(DBExpressionEntity joinTo)
        {
            return new DBJoinDirective<T>(this, joinTo, DBExpressionJoinType.RIGHT);
        }

        public virtual DBJoinDirective<T> FullJoin(DBExpressionEntity joinTo)
        {
            return new DBJoinDirective<T>(this, joinTo, DBExpressionJoinType.FULL);
        }

        //TODO: Cross join does not have any condition, chanage to not return join directive, JRod...
        public virtual DBJoinDirective<T> CrossJoin(DBExpressionEntity joinTo)
        {
            throw new NotImplementedException();
            //return new DBJoinDirective<T>(this, joinTo, DBExpressionJoinType.CROSS);
        }
        #endregion

        #region execution methods
        public T Get()
        {
            _execContext = ExecutionContext.Get;
            this.ValidateExpression();

            _set.ClearSelect();
            _set &= _selectExprProvider.Invoke();

            string sql = this.AssembleSql();

            T obj = this.SqlClient.ExecuteObject<T>(sql, DbCommandType.SqlText, _dbParams, _fillCallback);
            return obj;
        }

        public dynamic GetDynamic()
        {
            _execContext = ExecutionContext.GetDynamic;
            this.ValidateExpression();

            if (_set.Select == null)
            {
                _set &= _selectExprProvider.Invoke();
            }

            string sql = this.AssembleSql();

            var obj = this.SqlClient.ExecuteDynamic(sql, DbCommandType.SqlText, _dbParams);
            return obj;
        }

        public List<T> GetList(out int resultSetCount)
        {
            _totalCount = null;
            _getTotalCount = true;
            List<T> tmp = this.GetList();
            resultSetCount = _totalCount ?? -1;
            return tmp;
        }

        public List<T> GetList()
        {
            _execContext = ExecutionContext.GetList;
            this.ValidateExpression();

            _set.ClearSelect();
            _set &= _selectExprProvider.Invoke();

            string sql = this.AssembleSql();

            List<T> lst = this.SqlClient.ExecuteObjectList<T>(sql, DbCommandType.SqlText, _dbParams, _fillCallback);

            if (_getTotalCount)
            {
                _totalCount = this.ResolveResultSetCount();
            }

            return lst;
        }

        public List<dynamic> GetDynamicList(out int resultSetCount)
        {
            _totalCount = null;
            _getTotalCount = true;
            List<dynamic> tmp = this.GetDynamicList();
            resultSetCount = _totalCount ?? -1;
            return tmp;
        }

        public List<dynamic> GetDynamicList()
        {
            _execContext = ExecutionContext.GetDynamicList;
            this.ValidateExpression();

            if (_set.Select == null)
            {
                _set &= _selectExprProvider.Invoke();
            }

            string sql = this.AssembleSql();

            List<dynamic> lst = this.SqlClient.ExecuteDynamicList(sql, DbCommandType.SqlText, _dbParams);

            if (_getTotalCount)
            {
                _totalCount = this.ResolveResultSetCount();
            }

            return lst;
        }

        public List<Y> GetValueList<Y>(DBSelectExpression select, out int resultSetCount)
        {
            _totalCount = null;
            _getTotalCount = true;
            List<Y> tmp = this.GetValueList<Y>(select);
            resultSetCount = _totalCount ?? -1;
            return tmp;
        }

        public List<Y> GetValueList<Y>(DBSelectExpression select)
        {
            _execContext = ExecutionContext.GetValueList;
            this.ValidateExpression();

            _set.ClearSelect();
            _set &= select;

            string sql = this.AssembleSql();

            List<Y> lst = this.SqlClient.ExecuteValueList<Y>(sql, DbCommandType.SqlText, _dbParams);

            if (_getTotalCount)
            {
                _totalCount = this.ResolveResultSetCount();
            }

            return lst;
        }

        public List<Y> GetValueList<Y>(DBExpressionField<Y> field)
        {
            return this.GetValueList<Y>(new DBSelectExpression(field));
        }

        public List<Y> GetValueList<Y>(DBExpressionField<Y> field, out int resultSetCount)
        {
            return this.GetValueList<Y>(new DBSelectExpression(field), out resultSetCount);
        }

        public Y GetValue<Y>(DBSelectExpression select)
        {
            _execContext = ExecutionContext.GetValue;
            this.ValidateExpression();

            _set.ClearSelect();
            _set &= select;

            string sql = this.AssembleSql();

            object val = this.SqlClient.ExecuteScalar(sql, DbCommandType.SqlText, _dbParams);

            return (val == null) ? default(Y) : (Y)val;
        }

        public Y GetValue<Y>(DBExpressionField<Y> field)
        {
            return this.GetValue<Y>(new DBSelectExpression(field));
        }

        public DataTable GetValueTable(out int resultSetCount)
        {
            _totalCount = null;
            _getTotalCount = true;
            DataTable tmp = this.GetValueTable();
            resultSetCount = _totalCount ?? -1;
            return tmp;
        }

        public DataTable GetValueTable()
        {
            _execContext = ExecutionContext.GetValueTable;
            this.ValidateExpression();

            string sql = this.AssembleSql();

            DataTable dt = this.SqlClient.ExecuteDataTable(sql, DbCommandType.SqlText, _dbParams);

            if (_getTotalCount)
            {
                _totalCount = this.ResolveResultSetCount();
            }

            return dt;
        }

        public void Insert(T obj)
        {
            _execContext = ExecutionContext.Insert;
            this.ValidateExpression();

            if (_insertExpressionProvider != null)
            {
                _set &= _insertExpressionProvider(obj);
            }

            _isIdentityEntity = (obj is IIdentityDBEntity);
            string sql = this.AssembleSql();
            if (_isIdentityEntity)
            {
                object o = this.SqlClient.ExecuteScalar(sql, DbCommandType.SqlText, _dbParams);

                I32BitIdentityDBEntity identity32 = (obj as I32BitIdentityDBEntity);
                if (identity32 != null)
                {
                    identity32.Id = Convert.ToInt32(o);
                }
                else
                {
                    I64BitIdentityDBEntity identity64 = (obj as I64BitIdentityDBEntity);
                    if (identity64 != null)
                    {
                        identity64.Id = Convert.ToInt64(o);
                    }
                    else
                    {
                        IU32BitIdentityDBEntity uIdentity32 = (obj as IU32BitIdentityDBEntity);
                        if (uIdentity32 != null)
                        {
                            uIdentity32.Id = Convert.ToUInt32(o);
                        }
                        else //must be u 64 bit identity
                        {
                            (obj as IU64BitIdentityDBEntity).Id = Convert.ToUInt64(o);
                        }
                    }

                }
            }
            else
            {
                this.SqlClient.Execute(sql, DbCommandType.SqlText, _dbParams);
            }
        }

        public void Update(out int affectedRecordCount)
        {
            _totalCount = null;
            _getTotalCount = true;
            this.Update();
            affectedRecordCount = _totalCount ?? -1;
        }

        public void Update()
        {
            _execContext = ExecutionContext.Update;
            this.ValidateExpression();

            string sql = this.AssembleSql();

            this.SqlClient.Execute(sql, DbCommandType.SqlText, _dbParams);

            if (_getTotalCount)
            {
                _totalCount = this.ResolveAffectedRecordCount();
            }
        }

        public void Delete(out int affectedRecordCount)
        {
            _totalCount = null;
            _getTotalCount = true;
            this.Delete();
            affectedRecordCount = _totalCount ?? -1;
        }

        public void Delete()
        {
            _execContext = ExecutionContext.Delete;
            this.ValidateExpression();

            string sql = this.AssembleSql();

            this.SqlClient.Execute(sql, DbCommandType.SqlText, _dbParams);

            if (_getTotalCount)
            {
                _totalCount = this.ResolveAffectedRecordCount();
            }
        }
        #endregion

        #region assemble sql
        protected abstract string AssembleSql();
        #endregion

        #region resolve result set count
        protected abstract int ResolveResultSetCount();
        #endregion

        #region resolve affected record count
        protected abstract int ResolveAffectedRecordCount();
        #endregion

        #region expression validation
        protected virtual void ValidateExpression()
        {
            //Only do validation 1 time to ensure any concrete classes can call validate, then make
            //adjustments without future validation conflicts...
            if (_isValidated) { return; }

            if (!_execContext.HasValue)
            {
                throw new InvalidOperationException("ExecutionContext was not set for the data service execution request.  Concrete classes that override execution methods must set 'CommandExecutionContext' prior to calling 'ValidateExpression'.");
            }

            if (_top.HasValue && _bottom.HasValue)
            {
                throw new InvalidOperationException("Cannot perform the 'Top' and 'Bottom' expressions in the same query.");
            }
            if (_top.HasValue && _skip.HasValue)
            {
                throw new InvalidOperationException("Cannot perform the 'Top' and 'Skip/Take' expressions in the same query.");
            }
            if (_bottom.HasValue && _skip.HasValue)
            {
                throw new InvalidOperationException("Cannot perform the 'Bottom' and 'Skip/Take' expressions in the same query.");
            }
            if ((_bottom.HasValue || _skip.HasValue) && (_set.OrderBy == null))
            {
                throw new InvalidOperationException("Cannot perform the 'Bottom' or 'Skip/Take' expressions without specifying an 'OrderBy' clause.  This query utilizes a sql ranking function 'Row_Number', which requires an OrderBy clause.");
            }

            switch (_execContext.Value)
            {
                case ExecutionContext.Get:
                    if (_set.Select != null)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Select Expression' within a 'Get' execution context failed.  'Get' returns 1 fully loaded business object and does not allow a consumer to specify specific fields for selection.");
                    }
                    if (_selectExprProvider == null)
                    {
                        throw new InvalidOperationException("No 'MasterSelectExpressionProvider' was provided.  A 'MasterSelectExpressionProvider' delegate is required within the 'Get' execution context.");
                    }
                    break;
                case ExecutionContext.GetDynamic:
                    if (_set.Select == null && _selectExprProvider == null)
                    {
                        throw new InvalidOperationException("No 'MasterSelectExpressionProvider' was provided.  A 'MasterSelectExpressionProvider' delegate is required within the 'GetDynamic' execution context for queries which do not have an explicit select expression set.");
                    }
                    break;
                case ExecutionContext.GetList:
                    if (_set.Select != null)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Select Expression' within a 'GetList' execution context failed.  'GetList' returns a List where T is a fully loaded business object and does not allow a consumer to specify specific fields for selection.  Try using 'GetValueTable'.");
                    }
                    if (_selectExprProvider == null)
                    {
                        throw new InvalidOperationException("No 'MasterSelectExpressionProvider' was provided during construction of this expression builder.  A 'MasterSelectExpressionProvider' delegate is required within the 'GetList' execution context.");
                    }
                    break;
                case ExecutionContext.GetDynamicList:
                    if (_set.Select == null && _selectExprProvider == null)
                    {
                        throw new InvalidOperationException("No 'MasterSelectExpressionProvider' was provided during construction of this expression builder.  A 'MasterSelectExpressionProvider' delegate is required within the 'GetDynamic' execution context for queries which do not have an explicit select expression set.");
                    }
                    break;
                case ExecutionContext.GetValueList:
                    if (_set.Select != null)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Select Expression' within a 'GetValueList' execution context failed.  'GetValueList' returns a List for the field specified in parameter 'field' and does not allow a consumer to specify specific fields for selection.");
                    }
                    break;
                case ExecutionContext.GetValue:
                    if (_skip.HasValue && _limit.Value > 1)
                    {
                        throw new InvalidOperationException("An attempt to execute a Skip/Take expression within a 'GetValue' execution context failed.  'GetValue' returns only a single value and the Take declaration was > 1.");
                    }
                    if (_set.Select != null)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Select Expression' within a 'GetValue' execution context failed.  'GetValue' returns a single value that represents the field specified in parameter 'field' and does not allow a consumer to specify specific fields for selection.");
                    }
                    break;
                case ExecutionContext.GetValueTable:
                    if (_set.Select == null)
                    {
                        throw new InvalidOperationException("An attempt to execute an empty/null 'Select Expression' within a 'GetValueTable' execution context failed.  'GetValueTable' returns a DataTable represening the 'Select Expression' executed.  The 'Select Expression' must be specified.");
                    }
                    break;
                case ExecutionContext.Insert:
                    if (_insertExpressionProvider == null)
                    {
                        throw new InvalidOperationException("No 'InsertExpressionProvider<T>' was provided.  A 'MasterSelectExpressionProvider' delegate is required within the 'Get' execution context.");
                    }
                    break;
                case ExecutionContext.Update:
                    if (_set.Assign == null)
                    {
                        throw new InvalidOperationException("An attempt to execute an empty/null 'Assignmnet Expression' within an 'Update' execution context failed.  'Update' requires a valid 'Assignment Expression'.");
                    }
                    if (_set.OrderBy != null)
                    {
                        throw new InvalidOperationException("An attempt to set an 'Order Expression' within an 'Update' execution context failed.  An 'Order Expression' cannot be applied to an 'Update' execution request.");
                    }
                    if (_set.GroupBy != null)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Group By Expression' within an 'Update' execution context failed.  A 'Group By Expression' cannot be applied to an 'Update' execution request.");
                    }
                    if (_set.GroupBy != null)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Select Expression' within an 'Update' execution context failed.  A 'Select Expression' cannot be applied to an 'Update' execution request.");
                    }
                    if (_skip.HasValue)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Skip/Take' Expression' within an 'Update' execution context failed.  A 'Skip/Take Expression' cannot be applied to an 'Update' execution request.");
                    }
                    break;
                case ExecutionContext.Delete:
                    if (_set.Assign != null)
                    {
                        throw new InvalidOperationException("An attempt to set an 'Assignment Expression' within a 'Delete' execution context failed.  'Delete' does not allow a consumer to specify any fields for assignment.");
                    }
                    if (_set.OrderBy != null)
                    {
                        throw new InvalidOperationException("An attempt to set an 'Order Expression' within a 'Delete' execution context failed.  An 'Order Expression' cannot be applied to a 'Delete' execution request.");
                    }
                    if (_set.GroupBy != null)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Group By Expression' within a 'Delete' execution context failed.  An 'Group By Expression' cannot be applied to a 'Delete' execution request.");
                    }
                    if (_set.Select != null)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Select Expression' within a 'Delete' execution context failed.  A 'Select Expression' cannot be applied to a 'Delete' execution request.");
                    }
                    if (_skip.HasValue)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Skip/Take' Expression' within a 'Delete' execution context failed.  A 'Skip/Take Expression' cannot be applied to a 'Delete' execution request.");
                    }
                    break;
                default:
                    throw new InvalidOperationException("ExecutionContext could not be determined for the data service execution request.");
            }

            _isValidated = true;
        }
        #endregion

        #region get sql connection
        protected abstract SqlConnection GetSqlConnection();
        #endregion

        #region utility methods
        public abstract string ToGetSql();

        public abstract string ToGetListSql();

        public abstract string ToGetValueListSql<Y>(DBSelectExpression field);

        public abstract string ToGetValueSql<Y>(DBSelectExpression field);

        public abstract string ToGetValueTableSql();

        public abstract string ToInsertSql(T obj);

        public abstract string ToUpdateSql();

        public abstract string ToDeleteSql();
        #endregion

        #region contained enums
        protected enum ExecutionContext : int
        {
            Get,
            GetDynamic,
            GetList,
            GetDynamicList,
            GetValueList,
            GetValue,
            GetValueTable,
            //InsertParams,
            Insert,
            Update,
            Delete
        }
        #endregion
    }
}
