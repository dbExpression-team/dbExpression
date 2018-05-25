using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace HTL.DbEx.Sql.Expression
{
    public abstract class SqlExpressionBuilder
    {
        #region internals
        private SqlConnection _sqlDbClient;
        protected readonly ConnectionStringSettings ConnectionStringSettings;

        protected bool IsDistinct { get; set; }
        protected int? TopValue { get; set; }
        protected int? SkipValue { get; set; }
        public int? LimitValue { get; set; }
        protected int? BottomValue { get; set; }
        protected bool IsValidated { get; set; }
        protected List<DbParameter> DbParams { get; } = new List<DbParameter>();
        protected ExecutionContext? CommandExecutionContext { get; set; }
        #endregion

        #region interface
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
        public SqlExpressionBuilder(string connectionStringName, DBExpressionEntity baseEntity)  : this(ConfigurationManager.ConnectionStrings[connectionStringName], baseEntity)
        {
        }

        public SqlExpressionBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity baseEntity)
        {
            ConnectionStringSettings = connectionStringSettings ?? throw new ArgumentNullException(nameof(connectionStringSettings));
            BaseEntity = baseEntity;
        }
        #endregion

        #region enlist
        public virtual SqlExpressionBuilder Enlist(SqlConnection sqlClient)
        {
            this.SqlClient = sqlClient;
            return this;
        }
        #endregion

        #region select
        public virtual SqlExpressionBuilder Select(params DBSelectExpression[] selectExpressions)
        {
            for (int i = 0; i < selectExpressions.Length; i++)
            {
                Expression &= selectExpressions[i];
            }
            return this;
        }
        #endregion

        #region distinct
        public virtual SqlExpressionBuilder Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region skip
        public virtual DBSkipDirective Skip(int count)
        {
            SkipValue = count;
            return new DBSkipDirective(this);
        }
        #endregion

        #region set fields
        public virtual SqlExpressionBuilder SetFields(params DBAssignmentExpression[] assignmentExpressions)
        {
            for (int i = 0; i < assignmentExpressions.Length; i++)
            {
                Expression &= assignmentExpressions[i];
            }
            return this;
        }
        #endregion

        #region set fields
        public virtual SqlExpressionBuilder SetFields(DBAssignmentExpressionSet assignmentExpressionSet)
        {
            Expression &= assignmentExpressionSet;
            return this;
        }
        #endregion

        #region where 
        public virtual SqlExpressionBuilder Where(DBFilterExpressionSet filter)
        {
            Expression &= filter;
            return this;
        }
        #endregion

        #region order by
        public virtual SqlExpressionBuilder OrderBy(DBOrderByExpressionSet orderBy)
        {
            Expression &= orderBy;
            return this;
        }
        #endregion

        #region group by
        public virtual SqlExpressionBuilder GroupBy(params DBGroupByExpression[] groupBy)
        {
            foreach (DBGroupByExpression g in groupBy)
            {
                Expression &= g;
            }
            return this;
        }
        #endregion

        #region having
        public virtual SqlExpressionBuilder Having(DBHavingExpression havingCondition)
        {
            Expression &= havingCondition;
            return this;
        }
        #endregion

        #region top
        public virtual SqlExpressionBuilder Top(int count)
        {
            TopValue = count;
            return this;
        }
        #endregion

        #region bottom
        public virtual SqlExpressionBuilder Bottom(int count)
        {
            BottomValue = count;
            return this;
        }
        #endregion

        #region inner join
        public virtual DBJoinDirective InnerJoin(DBExpressionEntity joinTo)
        {
            return new DBJoinDirective(this, joinTo, DBExpressionJoinType.INNER);
        }
        #endregion

        #region left join
        public virtual DBJoinDirective LeftJoin(DBExpressionEntity joinTo)
        {
            return new DBJoinDirective(this, joinTo, DBExpressionJoinType.LEFT);
        }
        #endregion

        #region right join
        public virtual DBJoinDirective RightJoin(DBExpressionEntity joinTo)
        {
            return new DBJoinDirective(this, joinTo, DBExpressionJoinType.RIGHT);
        }
        #endregion

        #region full join
        public virtual DBJoinDirective FullJoin(DBExpressionEntity joinTo)
        {
            return new DBJoinDirective(this, joinTo, DBExpressionJoinType.FULL);
        }
        #endregion

        #region assemble sql
        protected abstract string AssembleSql();
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
                    //if (BaseEntity.SelectExpressionProvider == null)
                    //{
                    //    throw new InvalidOperationException("No 'MasterSelectExpressionProvider' was provided.  A 'MasterSelectExpressionProvider' delegate is required within the 'Get' execution context.");
                    //}
                    break;
                case ExecutionContext.GetDynamic:
                    //if (Expression.Select == null && BaseEntity.SelectExpressionProvider == null)
                    //{
                    //    throw new InvalidOperationException("No 'MasterSelectExpressionProvider' was provided.  A 'MasterSelectExpressionProvider' delegate is required within the 'GetDynamic' execution context for queries which do not have an explicit select expression set.");
                    //}
                    break;
                case ExecutionContext.GetList:
                    if (Expression.Select != null)
                    {
                        throw new InvalidOperationException("An attempt to set a 'Select Expression' within a 'GetList' execution context failed.  'GetList' returns a List where T is a fully loaded business object and does not allow a consumer to specify specific fields for selection.  Try using 'GetValueTable'.");
                    }
                    //if (BaseEntity.SelectExpressionProvider == null)
                    //{
                    //    throw new InvalidOperationException("No 'MasterSelectExpressionProvider' was provided during construction of this expression builder.  A 'MasterSelectExpressionProvider' delegate is required within the 'GetList' execution context.");
                    //}
                    break;
                case ExecutionContext.GetDynamicList:
                    //if (Expression.Select == null && BaseEntity.SelectExpressionProvider == null)
                    //{
                    //    throw new InvalidOperationException("No 'MasterSelectExpressionProvider' was provided during construction of this expression builder.  A 'MasterSelectExpressionProvider' delegate is required within the 'GetDynamic' execution context for queries which do not have an explicit select expression set.");
                    //}
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
                    //if (BaseEntity.InsertExpressionProvider == null)
                    //{
                    //    throw new InvalidOperationException("No 'InsertExpressionProvider<T>' was provided.  A 'MasterSelectExpressionProvider' delegate is required within the 'Get' execution context.");
                    //}
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

        #region get T
        public virtual T Get<T>(Action<T, object[]> fill) where T : class, new()
        {
            CommandExecutionContext = ExecutionContext.Get;
            //TODO: Jrod, in validation throw exception if select expression is null...
            //it is concrete impl responsibility to get the inclusive select expression as we DO NOT have typed DbExpressionEntity at this level...
            this.ValidateExpression();

            //Expression.ClearSelect();
            //Expression &= BaseEntity.GetInclusiveSelectExpression();

            string sql = this.AssembleSql();

            T obj = this.SqlClient.ExecuteObject<T>(sql, DbCommandType.SqlText, DbParams, fill);
            return obj;
        }
        #endregion

        #region get list <T>
        public virtual IList<T> GetList<T>(Action<T, object[]> fill) where T : class, new()
        {
            CommandExecutionContext = ExecutionContext.GetList;
            //TODO: Jrod, in validation throw exception if select expression is null...
            //it is concrete impl responsibility to get the inclusive select expression as we DO NOT have typed DbExpressionEntity at this level...
            this.ValidateExpression();

            //Expression.ClearSelect();
            //Expression &= BaseEntity.GetInclusiveSelectExpression();

            string sql = this.AssembleSql();

            IList<T> lst = this.SqlClient.ExecuteObjectList<T>(sql, DbCommandType.SqlText, DbParams, fill);

            return lst;
        }
        #endregion

        #region get dynamic
        public virtual dynamic GetDynamic()
        {
            CommandExecutionContext = ExecutionContext.GetDynamic;
            //TODO: Jrod, in validation throw exception if select expression is null...
            //it is concrete impl responsibility to get the inclusive select expression as we DO NOT have typed DbExpressionEntity at this level...
            this.ValidateExpression();

            //if (Expression.Select == null)
            //{
            //    Expression &= BaseEntity.GetInclusiveSelectExpression();
            //}

            string sql = this.AssembleSql();

            var obj = this.SqlClient.ExecuteDynamic(sql, DbCommandType.SqlText, DbParams);
            return obj;
        }
        #endregion

        #region get dynamic list
        public virtual IList<dynamic> GetDynamicList()
        {
            CommandExecutionContext = ExecutionContext.GetDynamicList;
            //TODO: Jrod, in validation throw exception if select expression is null...
            //it is concrete impl responsibility to get the inclusive select expression as we DO NOT have typed DbExpressionEntity at this level...
            this.ValidateExpression();

            //if (Expression.Select == null)
            //{
            //    Expression &= BaseEntity.GetInclusiveSelectExpression();
            //}

            string sql = this.AssembleSql();

            IList<dynamic> lst = this.SqlClient.ExecuteDynamicList(sql, DbCommandType.SqlText, DbParams);

            return lst;
        }
        #endregion

        #region get value list <Y>
        public virtual IList<Y> GetValueList<Y>(DBSelectExpression select)
        {
            CommandExecutionContext = ExecutionContext.GetValueList;
            this.ValidateExpression();

            Expression.ClearSelect();
            Expression &= select;

            string sql = this.AssembleSql();

            IList<Y> lst = this.SqlClient.ExecuteValueList<Y>(sql, DbCommandType.SqlText, DbParams);

            return lst;
        }

        public virtual IList<Y> GetValueList<Y>(DBExpressionField<Y> field)
        {
            return this.GetValueList<Y>(new DBSelectExpression(field));
        }
        #endregion

        #region get value
        public virtual Y GetValue<Y>(DBSelectExpression select)
        {
            CommandExecutionContext = ExecutionContext.GetValue;
            this.ValidateExpression();

            Expression.ClearSelect();
            Expression &= select;

            string sql = this.AssembleSql();

            object val = this.SqlClient.ExecuteScalar(sql, DbCommandType.SqlText, DbParams);

            return (val == null) ? default(Y) : (Y)val;
        }

        public virtual Y GetValue<Y>(DBExpressionField<Y> field)
        {
            return this.GetValue<Y>(new DBSelectExpression(field));
        }
        #endregion

        #region get value table
        public virtual DataTable GetValueTable()
        {
            CommandExecutionContext = ExecutionContext.GetValueTable;
            this.ValidateExpression();

            string sql = this.AssembleSql();

            DataTable dt = this.SqlClient.ExecuteDataTable(sql, DbCommandType.SqlText, DbParams);

            return dt;
        }
        #endregion

        #region insert
        public virtual void Insert<T>(T record)
        {
            CommandExecutionContext = ExecutionContext.Insert;
            //TODO: Jrod, in validation throw exception if insert expression is null...
            //it is concrete impl responsibility to get the inclusive insert expression as we DO NOT have typed DbExpressionEntity at this level...
            this.ValidateExpression();

            //Expression &= BaseEntity.GetInclusiveInsertExpression(obj);

            bool isIdentity = (record is IIdentityDBEntity);
            string sql = this.AssembleSql();
            if (isIdentity)
            {
                object o = this.SqlClient.ExecuteScalar(sql, DbCommandType.SqlText, DbParams);

                I32BitIdentityDBEntity identity32 = (record as I32BitIdentityDBEntity);
                if (identity32 != null)
                {
                    identity32.Id = Convert.ToInt32(o);
                }
                else
                {
                    I64BitIdentityDBEntity identity64 = (record as I64BitIdentityDBEntity);
                    if (identity64 != null)
                    {
                        identity64.Id = Convert.ToInt64(o);
                    }
                    else
                    {
                        IU32BitIdentityDBEntity uIdentity32 = (record as IU32BitIdentityDBEntity);
                        if (uIdentity32 != null)
                        {
                            uIdentity32.Id = Convert.ToUInt32(o);
                        }
                        else //must be u 64 bit identity
                        {
                            (record as IU64BitIdentityDBEntity).Id = Convert.ToUInt64(o);
                        }
                    }

                }
            }
            else
            {
                this.SqlClient.Execute(sql, DbCommandType.SqlText, DbParams);
            }
        }
        #endregion

        #region update
        public virtual void Update()
        {
            CommandExecutionContext = ExecutionContext.Update;
            this.ValidateExpression();

            string sql = this.AssembleSql();

            this.SqlClient.Execute(sql, DbCommandType.SqlText, DbParams);
        }
        #endregion

        #region delete
        public virtual void Delete()
        {
            CommandExecutionContext = ExecutionContext.Delete;
            this.ValidateExpression();

            string sql = this.AssembleSql();

            this.SqlClient.Execute(sql, DbCommandType.SqlText, DbParams);
        }
        #endregion

        #region get sql connection
        protected abstract SqlConnection GetSqlConnection();
        #endregion

        #region contained enums
        public enum ExecutionContext : int
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
