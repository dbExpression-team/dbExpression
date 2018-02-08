using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace HTL.DbEx.Sql.Expression
{
    public abstract class SqlExpressionBuilder<T> where T : new()
    {
        #region internals
        private SqlConnection _sqlDbClient;
        protected readonly ConnectionStringSettings ConnectionStringSettings;

        protected bool IsIdentityEntity { get; private set; }
        protected bool IsDistinct { get; private set; }
        protected int? TopValue { get; private set; }
        protected int? BottomValue { get; private set; }
        protected int? SkipValue { get; private set; }
        protected bool GetTotalCount { get; private set; }
        protected int? TotalCountValue { get; private set; }
        protected bool IsValidated { get; private set; }
        //protected string _connectionStringName;
        protected SelectExpressionProvider SelectExpressionProvider { get; private set; }
        protected InsertExpressionProvider<T> InsertExpressionProvider { get; private set; }
        protected FillObjectCallback<T> FillObjectCallback { get; private set; }
        protected List<DbParameter> DbParams { get; } = new List<DbParameter>();
        protected ExecutionContext? CommandExecutionContext { get; set; }
        public int? LimitValue { get; internal set; }
        #endregion

        #region interface properties
        public DBExpressionEntity BaseEntity { get; protected set; }

        public DBExpressionSet Expression { get; set; } = new DBExpressionSet();

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
        }

        public SqlExpressionBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity baseEntity)
        {
            ConnectionStringSettings = connectionStringSettings ?? throw new ArgumentNullException(nameof(connectionStringSettings));
            BaseEntity = baseEntity;
        }
        #endregion

        #region with select expression provider
        public SqlExpressionBuilder<T> WithSelectExpressionProvider(SelectExpressionProvider selectExpressionProvider)
        {
            SelectExpressionProvider = selectExpressionProvider;
            return this;
        }
        #endregion

        #region with fill callback
        public SqlExpressionBuilder<T> WithFillCallback(FillObjectCallback<T> fillCallback)
        {
            FillObjectCallback = fillCallback;
            return this;
        }
        #endregion

        #region with insert expression provider
        public SqlExpressionBuilder<T> WithInsertExpressionProvider(InsertExpressionProvider<T> insertExpressionProvider)
        {
            InsertExpressionProvider = insertExpressionProvider;
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
                Expression &= selectExpressions[i];
            }
            return this;
        }

        public virtual SqlExpressionBuilder<T> Select(DBSelectExpressionSet selectExpressionSet)
        {
            Expression &= selectExpressionSet;
            return this;
        }

        public virtual SqlExpressionBuilder<T> Distinct()
        {
            IsDistinct = true;
            return this;
        }

        public virtual SqlExpressionBuilder<T> SetFields(params DBAssignmentExpression[] assignmentExpressions)
        {
            for (int i = 0; i < assignmentExpressions.Length; i++)
            {
                Expression &= assignmentExpressions[i];
            }
            return this;
        }

        public virtual SqlExpressionBuilder<T> SetFields(DBAssignmentExpressionSet assignmentExpressionSet)
        {
            Expression &= assignmentExpressionSet;
            return this;
        }

        public virtual SqlExpressionBuilder<T> Where(DBFilterExpressionSet filter)
        {
            Expression &= filter;
            return this;
        }

        public virtual SqlExpressionBuilder<T> OrderBy(DBOrderByExpressionSet orderBy)
        {
            Expression &= orderBy;
            return this;
        }

        public virtual SqlExpressionBuilder<T> GroupBy(params DBGroupByExpression[] groupBy)
        {
            foreach (DBGroupByExpression g in groupBy)
            {
                Expression &= g;
            }
            return this;
        }

        public virtual SqlExpressionBuilder<T> Having(DBHavingExpression havingCondition)
        {
            Expression &= havingCondition;
            return this;
        }

        public virtual SqlExpressionBuilder<T> Top(int count)
        {
            TopValue = count;
            return this;
        }

        public virtual SqlExpressionBuilder<T> Bottom(int count)
        {
            BottomValue = count;
            return this;
        }

        public virtual DBSkipDirective<T> Skip(int count)
        {
            SkipValue = count;
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
            CommandExecutionContext = ExecutionContext.Get;
            this.ValidateExpression();

            Expression.ClearSelect();
            Expression &= SelectExpressionProvider.Invoke();

            string sql = this.AssembleSql();

            T obj = this.SqlClient.ExecuteObject<T>(sql, DbCommandType.SqlText, DbParams, FillObjectCallback);
            return obj;
        }

        public dynamic GetDynamic()
        {
            CommandExecutionContext = ExecutionContext.GetDynamic;
            this.ValidateExpression();

            if (Expression.Select == null)
            {
                Expression &= SelectExpressionProvider.Invoke();
            }

            string sql = this.AssembleSql();

            var obj = this.SqlClient.ExecuteDynamic(sql, DbCommandType.SqlText, DbParams);
            return obj;
        }

        public IList<T> GetList(out int resultSetCount)
        {
            TotalCountValue = null;
            GetTotalCount = true;
            IList<T> tmp = this.GetList();
            resultSetCount = TotalCountValue ?? -1;
            return tmp;
        }

        public IList<T> GetList()
        {
            CommandExecutionContext = ExecutionContext.GetList;
            this.ValidateExpression();

            Expression.ClearSelect();
            Expression &= SelectExpressionProvider.Invoke();

            string sql = this.AssembleSql();

            IList<T> lst = this.SqlClient.ExecuteObjectList<T>(sql, DbCommandType.SqlText, DbParams, FillObjectCallback);

            if (GetTotalCount)
            {
                TotalCountValue = this.ResolveResultSetCount();
            }

            return lst;
        }

        public IList<dynamic> GetDynamicList(out int resultSetCount)
        {
            TotalCountValue = null;
            GetTotalCount = true;
            IList<dynamic> tmp = this.GetDynamicList();
            resultSetCount = TotalCountValue ?? -1;
            return tmp;
        }

        public IList<dynamic> GetDynamicList()
        {
            CommandExecutionContext = ExecutionContext.GetDynamicList;
            this.ValidateExpression();

            if (Expression.Select == null)
            {
                Expression &= SelectExpressionProvider.Invoke();
            }

            string sql = this.AssembleSql();

            IList<dynamic> lst = this.SqlClient.ExecuteDynamicList(sql, DbCommandType.SqlText, DbParams);

            if (GetTotalCount)
            {
                TotalCountValue = this.ResolveResultSetCount();
            }

            return lst;
        }

        public IList<Y> GetValueList<Y>(DBSelectExpression select, out int resultSetCount)
        {
            TotalCountValue = null;
            GetTotalCount = true;
            IList<Y> tmp = this.GetValueList<Y>(select);
            resultSetCount = TotalCountValue ?? -1;
            return tmp;
        }

        public IList<Y> GetValueList<Y>(DBSelectExpression select)
        {
            CommandExecutionContext = ExecutionContext.GetValueList;
            this.ValidateExpression();

            Expression.ClearSelect();
            Expression &= select;

            string sql = this.AssembleSql();

            IList<Y> lst = this.SqlClient.ExecuteValueList<Y>(sql, DbCommandType.SqlText, DbParams);

            if (GetTotalCount)
            {
                TotalCountValue = this.ResolveResultSetCount();
            }

            return lst;
        }

        public IList<Y> GetValueList<Y>(DBExpressionField<Y> field)
        {
            return this.GetValueList<Y>(new DBSelectExpression(field));
        }

        public IList<Y> GetValueList<Y>(DBExpressionField<Y> field, out int resultSetCount)
        {
            return this.GetValueList<Y>(new DBSelectExpression(field), out resultSetCount);
        }

        public Y GetValue<Y>(DBSelectExpression select)
        {
            CommandExecutionContext = ExecutionContext.GetValue;
            this.ValidateExpression();

            Expression.ClearSelect();
            Expression &= select;

            string sql = this.AssembleSql();

            object val = this.SqlClient.ExecuteScalar(sql, DbCommandType.SqlText, DbParams);

            return (val == null) ? default(Y) : (Y)val;
        }

        public Y GetValue<Y>(DBExpressionField<Y> field)
        {
            return this.GetValue<Y>(new DBSelectExpression(field));
        }

        public DataTable GetValueTable(out int resultSetCount)
        {
            TotalCountValue = null;
            GetTotalCount = true;
            DataTable tmp = this.GetValueTable();
            resultSetCount = TotalCountValue ?? -1;
            return tmp;
        }

        public DataTable GetValueTable()
        {
            CommandExecutionContext = ExecutionContext.GetValueTable;
            this.ValidateExpression();

            string sql = this.AssembleSql();

            DataTable dt = this.SqlClient.ExecuteDataTable(sql, DbCommandType.SqlText, DbParams);

            if (GetTotalCount)
            {
                TotalCountValue = this.ResolveResultSetCount();
            }

            return dt;
        }

        public void Insert(T obj)
        {
            CommandExecutionContext = ExecutionContext.Insert;
            this.ValidateExpression();

            if (InsertExpressionProvider != null)
            {
                Expression &= InsertExpressionProvider(obj);
            }

            IsIdentityEntity = (obj is IIdentityDBEntity);
            string sql = this.AssembleSql();
            if (IsIdentityEntity)
            {
                object o = this.SqlClient.ExecuteScalar(sql, DbCommandType.SqlText, DbParams);

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
                this.SqlClient.Execute(sql, DbCommandType.SqlText, DbParams);
            }
        }

        public void Update(out int affectedRecordCount)
        {
            TotalCountValue = null;
            GetTotalCount = true;
            this.Update();
            affectedRecordCount = TotalCountValue ?? -1;
        }

        public void Update()
        {
            CommandExecutionContext = ExecutionContext.Update;
            this.ValidateExpression();

            string sql = this.AssembleSql();

            this.SqlClient.Execute(sql, DbCommandType.SqlText, DbParams);

            if (GetTotalCount)
            {
                TotalCountValue = this.ResolveAffectedRecordCount();
            }
        }

        public void Delete(out int affectedRecordCount)
        {
            TotalCountValue = null;
            GetTotalCount = true;
            this.Delete();
            affectedRecordCount = TotalCountValue ?? -1;
        }

        public void Delete()
        {
            CommandExecutionContext = ExecutionContext.Delete;
            this.ValidateExpression();

            string sql = this.AssembleSql();

            this.SqlClient.Execute(sql, DbCommandType.SqlText, DbParams);

            if (GetTotalCount)
            {
                TotalCountValue = this.ResolveAffectedRecordCount();
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
            if (IsValidated) { return; }

            if (!CommandExecutionContext.HasValue)
            {
                throw new InvalidOperationException("ExecutionContext was not set for the data service execution request.  Concrete classes that override execution methods must set 'CommandExecutionContext' prior to calling 'ValidateExpression'.");
            }

            if (TopValue.HasValue && BottomValue.HasValue)
            {
                throw new InvalidOperationException("Cannot perform the 'Top' and 'Bottom' expressions in the same query.");
            }
            if (TopValue.HasValue && SkipValue.HasValue)
            {
                throw new InvalidOperationException("Cannot perform the 'Top' and 'Skip/Take' expressions in the same query.");
            }
            if (BottomValue.HasValue && SkipValue.HasValue)
            {
                throw new InvalidOperationException("Cannot perform the 'Bottom' and 'Skip/Take' expressions in the same query.");
            }
            if ((BottomValue.HasValue || SkipValue.HasValue) && (Expression.OrderBy == null))
            {
                throw new InvalidOperationException("Cannot perform the 'Bottom' or 'Skip/Take' expressions without specifying an 'OrderBy' clause.  This query utilizes a sql ranking function 'Row_Number', which requires an OrderBy clause.");
            }

            switch (CommandExecutionContext.Value)
            {
                case ExecutionContext.Get:
                    if (Expression.Select != null)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Select Expression' within a 'Get' execution context failed.  'Get' returns 1 fully loaded business object and does not allow a consumer to specify specific fields for selection.");
                    }
                    if (SelectExpressionProvider == null)
                    {
                        throw new InvalidOperationException("No 'MasterSelectExpressionProvider' was provided.  A 'MasterSelectExpressionProvider' delegate is required within the 'Get' execution context.");
                    }
                    break;
                case ExecutionContext.GetDynamic:
                    if (Expression.Select == null && SelectExpressionProvider == null)
                    {
                        throw new InvalidOperationException("No 'MasterSelectExpressionProvider' was provided.  A 'MasterSelectExpressionProvider' delegate is required within the 'GetDynamic' execution context for queries which do not have an explicit select expression set.");
                    }
                    break;
                case ExecutionContext.GetList:
                    if (Expression.Select != null)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Select Expression' within a 'GetList' execution context failed.  'GetList' returns a List where T is a fully loaded business object and does not allow a consumer to specify specific fields for selection.  Try using 'GetValueTable'.");
                    }
                    if (SelectExpressionProvider == null)
                    {
                        throw new InvalidOperationException("No 'MasterSelectExpressionProvider' was provided during construction of this expression builder.  A 'MasterSelectExpressionProvider' delegate is required within the 'GetList' execution context.");
                    }
                    break;
                case ExecutionContext.GetDynamicList:
                    if (Expression.Select == null && SelectExpressionProvider == null)
                    {
                        throw new InvalidOperationException("No 'MasterSelectExpressionProvider' was provided during construction of this expression builder.  A 'MasterSelectExpressionProvider' delegate is required within the 'GetDynamic' execution context for queries which do not have an explicit select expression set.");
                    }
                    break;
                case ExecutionContext.GetValueList:
                    if (Expression.Select != null)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Select Expression' within a 'GetValueList' execution context failed.  'GetValueList' returns a List for the field specified in parameter 'field' and does not allow a consumer to specify specific fields for selection.");
                    }
                    break;
                case ExecutionContext.GetValue:
                    if (SkipValue.HasValue && LimitValue.Value > 1)
                    {
                        throw new InvalidOperationException("An attempt to execute a Skip/Take expression within a 'GetValue' execution context failed.  'GetValue' returns only a single value and the Take declaration was > 1.");
                    }
                    if (Expression.Select != null)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Select Expression' within a 'GetValue' execution context failed.  'GetValue' returns a single value that represents the field specified in parameter 'field' and does not allow a consumer to specify specific fields for selection.");
                    }
                    break;
                case ExecutionContext.GetValueTable:
                    if (Expression.Select == null)
                    {
                        throw new InvalidOperationException("An attempt to execute an empty/null 'Select Expression' within a 'GetValueTable' execution context failed.  'GetValueTable' returns a DataTable represening the 'Select Expression' executed.  The 'Select Expression' must be specified.");
                    }
                    break;
                case ExecutionContext.Insert:
                    if (InsertExpressionProvider == null)
                    {
                        throw new InvalidOperationException("No 'InsertExpressionProvider<T>' was provided.  A 'MasterSelectExpressionProvider' delegate is required within the 'Get' execution context.");
                    }
                    break;
                case ExecutionContext.Update:
                    if (Expression.Assign == null)
                    {
                        throw new InvalidOperationException("An attempt to execute an empty/null 'Assignmnet Expression' within an 'Update' execution context failed.  'Update' requires a valid 'Assignment Expression'.");
                    }
                    if (Expression.OrderBy != null)
                    {
                        throw new InvalidOperationException("An attempt to set an 'Order Expression' within an 'Update' execution context failed.  An 'Order Expression' cannot be applied to an 'Update' execution request.");
                    }
                    if (Expression.GroupBy != null)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Group By Expression' within an 'Update' execution context failed.  A 'Group By Expression' cannot be applied to an 'Update' execution request.");
                    }
                    if (Expression.GroupBy != null)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Select Expression' within an 'Update' execution context failed.  A 'Select Expression' cannot be applied to an 'Update' execution request.");
                    }
                    if (SkipValue.HasValue)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Skip/Take' Expression' within an 'Update' execution context failed.  A 'Skip/Take Expression' cannot be applied to an 'Update' execution request.");
                    }
                    break;
                case ExecutionContext.Delete:
                    if (Expression.Assign != null)
                    {
                        throw new InvalidOperationException("An attempt to set an 'Assignment Expression' within a 'Delete' execution context failed.  'Delete' does not allow a consumer to specify any fields for assignment.");
                    }
                    if (Expression.OrderBy != null)
                    {
                        throw new InvalidOperationException("An attempt to set an 'Order Expression' within a 'Delete' execution context failed.  An 'Order Expression' cannot be applied to a 'Delete' execution request.");
                    }
                    if (Expression.GroupBy != null)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Group By Expression' within a 'Delete' execution context failed.  An 'Group By Expression' cannot be applied to a 'Delete' execution request.");
                    }
                    if (Expression.Select != null)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Select Expression' within a 'Delete' execution context failed.  A 'Select Expression' cannot be applied to a 'Delete' execution request.");
                    }
                    if (SkipValue.HasValue)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Skip/Take' Expression' within a 'Delete' execution context failed.  A 'Skip/Take Expression' cannot be applied to a 'Delete' execution request.");
                    }
                    break;
                default:
                    throw new InvalidOperationException("ExecutionContext could not be determined for the data service execution request.");
            }

            IsValidated = true;
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
