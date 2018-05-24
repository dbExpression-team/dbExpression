using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using HTL.DbEx.Utility;
using System.Configuration;
using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression
{
    #region ms sql expression builder selector
    public class MsSqlExpressionBuilderSelector
    {
        public IFromEntitySelector<T> Select<T>(params DBExpressionField[] fields)
        {
            return new EntitySelector<T>();
        }

        public IFromEntitySelector<T> Select<T>()
        {
            return new EntitySelector<T>();
        }

        public IFromEntitySelector Update()
        {
            return new EntitySelector();
        }

        public IIntoEntitySelector<T> Insert<T>(T record)
        {
            return new EntitySelector<T>();
        }

        public IFromEntitySelector Delete()
        {
            return new EntitySelector();
        }
    }
    #endregion

    #region i from entity selector
    public interface IFromEntitySelector<T>
    {
        MsSqlExpressionBuilder<T,Y> From<Y>(DBExpressionEntity<Y> from) where Y : class, new();
    }
    #endregion

    #region ifrom entity selector <T>
    public interface IFromEntitySelector
    {
        MsSqlExpressionBuilder<Y,Y> From<Y>(DBExpressionEntity<Y> from) where Y : class, new();
    }
    #endregion

    #region I into entity selector <T>
    public interface IIntoEntitySelector<T>
    {
        MsSqlExpressionBuilder<T,Y> Into<Y>(DBExpressionEntity<Y> from) where Y : class, new();
    }
    #endregion

    #region entity selector <T>
    public class EntitySelector<T> : IFromEntitySelector<T>, IIntoEntitySelector<T>
    {
        public MsSqlExpressionBuilder<T,Y> From<Y>(DBExpressionEntity<Y> from) where Y : class, new()
        {
            return new MsSqlExpressionBuilder<T,Y>(new ConnectionStringSettings("", "", ""), null);
        }

        public MsSqlExpressionBuilder<T, Y> Into<Y>(DBExpressionEntity<Y> from) where Y : class, new()
        {
            return new MsSqlExpressionBuilder<T, Y>(new ConnectionStringSettings("", "", ""), null);
        }
    }
    #endregion

    #region entity selector
    public class EntitySelector : IFromEntitySelector
    {
        public MsSqlExpressionBuilder<Y,Y> From<Y>(DBExpressionEntity<Y> from) where Y : class, new()
        {
            return new MsSqlExpressionBuilder<Y,Y>(new ConnectionStringSettings("", "", ""), null);
        }
    }
    #endregion
}
