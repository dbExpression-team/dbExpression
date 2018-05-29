using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using HTL.DbEx.Sql.Expression;
using HTL.DbEx.Sql;

namespace HTL.DbEx.MsSql.Expression
{
    #region select [entity]
    public class SelectEntityDirective<T> where T : class, IDBEntity, new()
    {
        #region interface
        protected string ConnectionStringName { get; set; }

        protected ConnectionStringSettings ConnectionStringSettings { get; set; }
        #endregion

        #region constructors
        public SelectEntityDirective(string connectionStringName)
        {
            if (string.IsNullOrEmpty(connectionStringName))
            {
                throw new ArgumentException("parameter must contain a value", nameof(connectionStringName));
            }

            ConnectionStringName = connectionStringName;
            ConnectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];

            if (ConnectionStringSettings == null)
            {
                throw new ArgumentException("no connections string setting found for provided name", nameof(connectionStringName));
            }
        }
        #endregion

        #region from
        public SelectEntityMsSqlBuilder<T> From<Y>(Y entity) where Y : IDbExpressionEntity<T>
        {
            var builder = new SelectEntityMsSqlBuilder<T>(ConnectionStringSettings, entity as DBExpressionEntity<T>);
            return builder;
        }
        #endregion
    }
    #endregion

    #region select many [entity]
    public class SelectManyEntityDirective<T> : SelectEntityDirective<T> where T : class, IDBEntity, new()
    {
        #region constructors
        public SelectManyEntityDirective(string connectionStringName) : base(connectionStringName)
        {
        }
        #endregion

        #region from
        public new SelectManyEntityMsSqlBuilder<T> From<Y>(Y entity) where Y : IDbExpressionEntity<T>
        {
            return new SelectManyEntityMsSqlBuilder<T>(base.ConnectionStringSettings, entity as DBExpressionEntity<T>);
        }
        #endregion
    }
    #endregion

    #region select [value]
    public class SelectValueDirective<Y>
    {
        #region interface
        protected string ConnectionStringName { get; set; }

        protected ConnectionStringSettings ConnectionStringSettings { get; set; }

        //protected DBSelectExpressionSet SelectSet { get; set; }
        protected DBSelectExpression Select { get; set; }
        #endregion

        #region constructors
        public SelectValueDirective(string connectionStringName, DBSelectExpression select)
        {
            if (string.IsNullOrEmpty(connectionStringName))
            {
                throw new ArgumentException("parameter must contain a value", nameof(connectionStringName));
            }

            ConnectionStringName = connectionStringName;
            ConnectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];

            if (ConnectionStringSettings == null)
            {
                throw new ArgumentException("no connections string setting found for provided name", nameof(connectionStringName));
            }

            Select = select;
        }
        #endregion

        #region from
        public SelectValueMsSqlBuilder<Y> From<X>(X entity) where X : DBExpressionEntity
        {
            var builder = new SelectValueMsSqlBuilder<Y>(ConnectionStringSettings, entity as DBExpressionEntity, Select);
            return builder;
        }
        #endregion
    }
    #endregion

    #region select many [value]
    public class SelectManyValueDirective<Y> : SelectValueDirective<Y>
    {
        #region constructors
        //public SelectManyValueDirective(string connectionStringName, params DBExpressionField[] fields) : base(connectionStringName, fields)
        //{
        //}

        public SelectManyValueDirective(string connectionStringName, DBSelectExpression select) : base(connectionStringName, select)
        {
        }

        //public SelectManyValueDirective(string connectionStringName, DBSelectExpressionSet selectSet) : base(connectionStringName, selectSet)
        //{
        //}
        #endregion

        #region from
        public new SelectManyValueMsSqlBuilder<Y> From<X>(X entity) where X : DBExpressionEntity
        {
            var builder = new SelectManyValueMsSqlBuilder<Y>(base.ConnectionStringSettings, entity as DBExpressionEntity, base.Select);
            return builder;
        }
        #endregion
    }
    #endregion

    #region select [dynamic]
    public class SelectDynamicDirective<Y>
    {
        #region interface
        protected string ConnectionStringName { get; set; }

        protected ConnectionStringSettings ConnectionStringSettings { get; set; }

        protected DBSelectExpressionSet SelectSet { get; set; }
        #endregion

        #region constructors
        public SelectDynamicDirective(string connectionStringName, params DBExpressionField[] fields)
        {
            if (string.IsNullOrEmpty(connectionStringName))
            {
                throw new ArgumentException("parameter must contain a value", nameof(connectionStringName));
            }

            ConnectionStringName = connectionStringName;
            ConnectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];

            if (ConnectionStringSettings == null)
            {
                throw new ArgumentException("no connections string setting found for provided name", nameof(connectionStringName));
            }

            for (int i = 0; i < fields.Length; i++)
            {
                SelectSet &= fields[i];
            }
        }

        public SelectDynamicDirective(string connectionStringName, DBSelectExpression select)
        {
            if (string.IsNullOrEmpty(connectionStringName))
            {
                throw new ArgumentException("parameter must contain a value", nameof(connectionStringName));
            }

            ConnectionStringName = connectionStringName;
            ConnectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];

            if (ConnectionStringSettings == null)
            {
                throw new ArgumentException("no connections string setting found for provided name", nameof(connectionStringName));
            }

            SelectSet &= select;
        }

        public SelectDynamicDirective(string connectionStringName, DBSelectExpressionSet selectSet)
        {
            if (string.IsNullOrEmpty(connectionStringName))
            {
                throw new ArgumentException("parameter must contain a value", nameof(connectionStringName));
            }

            ConnectionStringName = connectionStringName;
            ConnectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];

            if (ConnectionStringSettings == null)
            {
                throw new ArgumentException("no connections string setting found for provided name", nameof(connectionStringName));
            }

            SelectSet = selectSet;
        }
        #endregion

        #region from
        public SelectDynamicMsSqlBuilder<Y> From<X>(X entity) where X : DBExpressionEntity
        {
            var builder = new SelectDynamicMsSqlBuilder<Y>(ConnectionStringSettings, entity as DBExpressionEntity, SelectSet);
            return builder;
        }
        #endregion
    }
    #endregion

    #region select many [dynamic]
    public class SelectManyDynamicDirective<Y> : SelectDynamicDirective<Y>
    {
        #region constructors
        public SelectManyDynamicDirective(string connectionStringName, params DBExpressionField[] fields) : base(connectionStringName, fields)
        {

        }

        public SelectManyDynamicDirective(string connectionStringName, DBSelectExpression select) : base(connectionStringName, select)
        {
        }

        public SelectManyDynamicDirective(string connectionStringName, DBSelectExpressionSet selectSet) : base(connectionStringName, selectSet)
        {
        }
        #endregion

        #region from
        public new SelectManyDynamicMsSqlBuilder<Y> From<X>(X entity) where X : DBExpressionEntity
        {
            var builder = new SelectManyDynamicMsSqlBuilder<Y>(base.ConnectionStringSettings, entity as DBExpressionEntity, base.SelectSet);
            return builder;
        }
        #endregion
    }
    #endregion
}
