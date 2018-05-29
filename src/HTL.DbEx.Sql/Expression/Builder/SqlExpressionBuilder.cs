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
        protected List<DbParameter> DbParams { get; } = new List<DbParameter>();
        #endregion

        #region interface
        public ExecutionContext Context { get; private set; }

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
        public SqlExpressionBuilder(string connectionStringName, DBExpressionEntity baseEntity, ExecutionContext context)  : this(ConfigurationManager.ConnectionStrings[connectionStringName], baseEntity, context)
        {
        }

        public SqlExpressionBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity baseEntity, ExecutionContext context)
        {
            ConnectionStringSettings = connectionStringSettings ?? throw new ArgumentNullException(nameof(connectionStringSettings));
            BaseEntity = baseEntity;
            Context = context;
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
        public virtual DBJoinDirective FullJoin(DBExpressionEntity joinTo) => new DBJoinDirective(this, joinTo, DBExpressionJoinType.FULL);
        #endregion

        #region validate
        protected virtual void Validate()
        {
            if (Context == ExecutionContext.None)
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

            switch (Context)
            {
                case ExecutionContext.Get:
                case ExecutionContext.GetDynamic:
                case ExecutionContext.GetList:
                case ExecutionContext.GetDynamicList:
                case ExecutionContext.GetValueList:
                case ExecutionContext.GetValue:
                case ExecutionContext.GetValueTable:
                case ExecutionContext.Insert:
                case ExecutionContext.Update:
                case ExecutionContext.Delete:
                    break;
                default:
                    throw new InvalidOperationException("encountered unknown execution context");
            }
        }
        #endregion

        #region get T
        public virtual T Get<T>(string sql, Action<T, object[]> fill) where T : class, new()
        {
            //ExecutionContext = ExecutionContext.Get;
            //TODO: Jrod, in validation throw exception if select expression is null...
            //it is concrete impl responsibility to get the inclusive select expression as we DO NOT have typed DbExpressionEntity at this level...
            //this.ValidateExpression();

            //Expression.ClearSelect();
            //Expression &= BaseEntity.GetInclusiveSelectExpression();

            //string sql = this.AssembleSql();

            T obj = this.SqlClient.ExecuteObject<T>(sql, DbCommandType.SqlText, DbParams, fill);
            return obj;
        }
        #endregion

        #region get list <T>
        public virtual IList<T> GetList<T>(string sql, Action<T, object[]> fill) where T : class, new()
        {
            //ExecutionContext = ExecutionContext.GetList;
            //TODO: Jrod, in validation throw exception if select expression is null...
            //it is concrete impl responsibility to get the inclusive select expression as we DO NOT have typed DbExpressionEntity at this level...
            //this.ValidateExpression();

            //Expression.ClearSelect();
            //Expression &= BaseEntity.GetInclusiveSelectExpression();

            //string sql = this.AssembleSql();

            IList<T> lst = this.SqlClient.ExecuteObjectList<T>(sql, DbCommandType.SqlText, DbParams, fill);

            return lst;
        }
        #endregion

        #region get dynamic
        protected virtual dynamic GetDynamic(string sql)
        {
            //ExecutionContext = ExecutionContext.GetDynamic;
            //TODO: Jrod, in validation throw exception if select expression is null...
            //it is concrete impl responsibility to get the inclusive select expression as we DO NOT have typed DbExpressionEntity at this level...
            //this.ValidateExpression();

            //if (Expression.Select == null)
            //{
            //    Expression &= BaseEntity.GetInclusiveSelectExpression();
            //}

            //string sql = this.AssembleSql();

            var obj = this.SqlClient.ExecuteDynamic(sql, DbCommandType.SqlText, DbParams);
            return obj;
        }
        #endregion

        #region get dynamic list
        protected virtual IList<dynamic> GetDynamicList(string sql)
        {
            //ExecutionContext = ExecutionContext.GetDynamicList;
            //TODO: Jrod, in validation throw exception if select expression is null...
            //it is concrete impl responsibility to get the inclusive select expression as we DO NOT have typed DbExpressionEntity at this level...
            //this.ValidateExpression();

            //if (Expression.Select == null)
            //{
            //    Expression &= BaseEntity.GetInclusiveSelectExpression();
            //}

            //string sql = this.AssembleSql();

            IList<dynamic> lst = this.SqlClient.ExecuteDynamicList(sql, DbCommandType.SqlText, DbParams);

            return lst;
        }
        #endregion

        #region get value list <Y>
        protected virtual IList<Y> GetValueList<Y>(string sql/*DBSelectExpression select*/)
        {
            //ExecutionContext = ExecutionContext.GetValueList;
            //this.ValidateExpression();

            //Expression.ClearSelect();
            //Expression &= select;

            //string sql = this.AssembleSql();

            IList<Y> lst = this.SqlClient.ExecuteValueList<Y>(sql, DbCommandType.SqlText, DbParams);

            return lst;
        }
        #endregion

        #region get value
        protected virtual Y GetValue<Y>(string sql /*DBSelectExpression select*/)
        {
            //ExecutionContext = ExecutionContext.GetValue;
            //this.ValidateExpression();

            //Expression.ClearSelect();
            //Expression &= select;

            //string sql = this.AssembleSql();

            object val = this.SqlClient.ExecuteScalar(sql, DbCommandType.SqlText, DbParams);

            return (val == null) ? default(Y) : (Y)val;
        }
        #endregion

        #region get value table
        protected virtual DataTable GetValueTable(string sql)
        {
            //ExecutionContext = ExecutionContext.GetValueTable;
            //this.ValidateExpression();

            //string sql = this.AssembleSql();

            DataTable dt = this.SqlClient.ExecuteDataTable(sql, DbCommandType.SqlText, DbParams);

            return dt;
        }
        #endregion

        #region insert
        protected virtual void Insert(string sql)
        {
            this.SqlClient.Execute(sql, DbCommandType.SqlText, DbParams);
        }

        protected virtual void Insert(string sql, I32BitIdentityDBEntity identity32)
        {
            object o = this.SqlClient.ExecuteScalar(sql, DbCommandType.SqlText, DbParams);

            identity32.Id = Convert.ToInt32(o);
        }

        protected virtual void Insert(string sql, I64BitIdentityDBEntity identity64)
        {
            object o = this.SqlClient.ExecuteScalar(sql, DbCommandType.SqlText, DbParams);

            identity64.Id = Convert.ToInt64(o);
        }
        #endregion

        #region update
        protected virtual void Update(string sql)
        {
            //ExecutionContext = ExecutionContext.Update;
            //this.ValidateExpression();

            //string sql = this.AssembleSql();

            this.SqlClient.Execute(sql, DbCommandType.SqlText, DbParams);
        }
        #endregion

        #region delete
        protected virtual void Delete(string sql)
        {
            //ExecutionContext = ExecutionContext.Delete;
            //this.ValidateExpression();

            //string sql = this.AssembleSql();

            this.SqlClient.Execute(sql, DbCommandType.SqlText, DbParams);
        }
        #endregion

        #region get sql connection
        protected abstract SqlConnection GetSqlConnection();
        #endregion
    }

    #region contained enums
    public enum ExecutionContext : int
    {
        None,
        Get,
        GetDynamic,
        GetList,
        GetDynamicList,
        GetValueList,
        GetValue,
        GetValueTable,
        Insert,
        Update,
        Delete
    }
    #endregion
}
