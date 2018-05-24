using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using HTL.DbEx.Utility;
using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression
{
    #region ms sql expression builder selector
    public class MsSqlExpressionBuilderSelector
    {
        #region internals
        private ConnectionStringSettings _connSettings;
        #endregion

        #region interface
        public string ConnectionStringName { get; private set; }
        #endregion

        #region constructors
        public MsSqlExpressionBuilderSelector(string connectionStringName)
        {
            if (string.IsNullOrEmpty(connectionStringName))
            {
                throw new ArgumentException("parameter must contain a value", nameof(connectionStringName));
            }

            ConnectionStringName = connectionStringName;

            _connSettings = ConfigurationManager.ConnectionStrings[connectionStringName];

            if (_connSettings == null)
            {
                throw new ArgumentException("no connections string setting found for provided name", nameof(connectionStringName));
            }
        }
        #endregion

        #region select <T>
        public IFromEntitySelector<T> Select<T>(params DBExpressionField[] fields)
        {
            DBExpressionSet set = new DBExpressionSet();
            for (int i = 0; i < fields.Length; i++)
            {
                set &= fields[i];
            }
            return  new DbExpressionEntitySelector<T>(_connSettings, set);
        }
        
        public IFromEntitySelector<T> Select<T>()
        {
            return new DbExpressionEntitySelector<T>(_connSettings);
        }

        public IFromEntitySelector<T> Select<T>(DBSelectExpression select)
        {
            DBExpressionSet set = new DBExpressionSet();
            set &= select;
            return new DbExpressionEntitySelector<T>(_connSettings, set);
        }

        public IFromEntitySelector Select()
        {
            return new DbExpressionEntitySelector(_connSettings);
        }
        #endregion

        #region update
        public IFromEntitySelector Update(params DBAssignmentExpression[] assignmentExpressions)
        {
            DBExpressionSet set = new DBExpressionSet();
            for (int i = 0; i < assignmentExpressions.Length; i++)
            {
                set &= assignmentExpressions[i];
            }
            return new DbExpressionEntitySelector(_connSettings, set);
        }
        #endregion

        #region insert <T>
        public IIntoEntitySelector<T> Insert<T>(T record)
        {
            return new DbExpressionEntitySelector<T>(_connSettings, record);
        }
        #endregion

        #region delete
        public IFromEntitySelector Delete()
        {
            return new DbExpressionEntitySelector(_connSettings);
        }
        #endregion
    }
    #endregion

    #region i from entity selector <T>
    public interface IFromEntitySelector<T>
    {
        MsSqlExpressionBuilder<T,Y> From<Y>(DBExpressionEntity<Y> from) where Y : class, new();
    }
    #endregion

    #region i from entity selector
    public interface IFromEntitySelector
    {
        MsSqlExpressionBuilder<Y,Y> From<Y>(DBExpressionEntity<Y> from) where Y : class, new();
    }
    #endregion

    #region i into entity selector <T>
    public interface IIntoEntitySelector<T>
    {
        MsSqlExpressionBuilder<T,Y> Into<Y>(DBExpressionEntity<Y> from) where Y : class, new();
    }
    #endregion

    #region db expression entity selector
    public class DbExpressionEntitySelector : IFromEntitySelector
    {
        #region interface
        protected ConnectionStringSettings ConnectionSettings { get; private set; }
        protected DBExpressionSet ExpressionSet { get; private set; }
        #endregion

        #region constructors
        public DbExpressionEntitySelector(ConnectionStringSettings connectionSettings)
        {
            ConnectionSettings = connectionSettings;
        }

        public DbExpressionEntitySelector(ConnectionStringSettings connectionSettings, DBExpressionSet expressionSet)
        {
            ConnectionSettings = connectionSettings;
            ExpressionSet = expressionSet;
        }
        #endregion

        #region from
        public MsSqlExpressionBuilder<Y, Y> From<Y>(DBExpressionEntity<Y> from) where Y : class, new()
        {
            var builder = new MsSqlExpressionBuilder<Y, Y>(ConnectionSettings, from);
            builder.Expression = this.ExpressionSet;
            return builder;
        }
        #endregion
    }
    #endregion

    #region db expression entity selector<T>
    public class DbExpressionEntitySelector<T> : DbExpressionEntitySelector, IFromEntitySelector<T>, IIntoEntitySelector<T>
    {
        #region internals
        private T _recForInsert;
        #endregion

        #region constructors
        public DbExpressionEntitySelector(ConnectionStringSettings connectionSettings) : base(connectionSettings)
        {
        }

        public DbExpressionEntitySelector(ConnectionStringSettings connectionStringSettings, DBExpressionSet expressionSet) : base(connectionStringSettings, expressionSet)
        {
        }

        public DbExpressionEntitySelector(ConnectionStringSettings connectionStringSettings, T recForInser) : base(connectionStringSettings)
        {
            _recForInsert = recForInser;
        }
        #endregion

        #region from
        public new MsSqlExpressionBuilder<T,Y> From<Y>(DBExpressionEntity<Y> from) where Y : class, new()
        {
            var builder =  new MsSqlExpressionBuilder<T,Y>(base.ConnectionSettings, from);
            builder.Expression = base.ExpressionSet;
            return builder;
        }
        #endregion

        #region into
        public new MsSqlExpressionBuilder<T, Y> Into<Y>(DBExpressionEntity<Y> from) where Y : class, new()
        {
            var builder = new MsSqlExpressionBuilder<T, Y>(base.ConnectionSettings, from);
            builder.Expression = base.ExpressionSet;
            builder.InsertRecord = _recForInsert;
            return builder;
        }
        #endregion
    }
    #endregion
}