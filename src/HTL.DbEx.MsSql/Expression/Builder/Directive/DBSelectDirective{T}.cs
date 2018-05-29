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
    //this is used when select expression can be implied / provided by the db expression entity (base select entity)
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

    #region select [values]
    //this is used where providing an explicit select expression (select fields)
    public class SelectValueDirective<Y>
    {
        #region interface
        protected string ConnectionStringName { get; set; }

        protected ConnectionStringSettings ConnectionStringSettings { get; set; }

        protected DBSelectExpressionSet SelectSet { get; set; }
        #endregion

        #region constructors
        public SelectValueDirective(string connectionStringName, params DBExpressionField[] fields)
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

            SelectSet &= select;
        }

        public SelectValueDirective(string connectionStringName, DBSelectExpressionSet selectSet)
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
        public SelectValueMsSqlBuilder<Y> From<X>(X entity) where X : DBExpressionEntity
        {
            var builder = new SelectValueMsSqlBuilder<Y>(ConnectionStringSettings, entity as DBExpressionEntity);
            builder.Expression &= SelectSet;
            return builder;
        }
        #endregion
    }
    #endregion

    #region select many [values]
    public class SelectManyValueDirective<Y> : SelectValueDirective<Y>
    {
        #region constructors
        public SelectManyValueDirective(string connectionStringName, params DBExpressionField[] fields) : base(connectionStringName, fields)
        {
        }

        public SelectManyValueDirective(string connectionStringName, DBSelectExpression select) : base(connectionStringName, select)
        {
        }

        public SelectManyValueDirective(string connectionStringName, DBSelectExpressionSet selectSet) : base(connectionStringName, selectSet)
        {
        }
        #endregion

        #region from
        public new SelectManyValueMsSqlBuilder<Y> From<X>(X entity) where X : DBExpressionEntity
        {
            var builder = new SelectManyValueMsSqlBuilder<Y>(base.ConnectionStringSettings, entity as DBExpressionEntity);
            builder.Expression &= base.SelectSet;
            return builder;
        }
        #endregion
    }
    #endregion
}
