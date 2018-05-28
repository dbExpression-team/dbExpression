﻿using System;
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
    public class SelectEntityMsSqlBuilder<T> : SelectMsSqlBuilder<T> where T :  class, IDBEntity, new()
    {
        #region private
        private DBExpressionEntity<T> _typedEntity;
        #endregion

        #region constructors
        public SelectEntityMsSqlBuilder(string connectionStringName, DBExpressionEntity<T> baseEntity) : base(connectionStringName, baseEntity, ExecutionContext.Get)
        {
            _typedEntity = baseEntity;
            base.Expression &= baseEntity.GetInclusiveSelectExpression();
        }

        public SelectEntityMsSqlBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity<T> baseEntity) : base(connectionStringSettings, baseEntity, ExecutionContext.Get)
        {
            _typedEntity = baseEntity;
            base.Expression &= baseEntity.GetInclusiveSelectExpression();
        }
        #endregion

        #region execute
        public new T Execute()
        {
            Validate();

            string sql = base.SkipValue.HasValue ? base.AssembleSkipTakeRestrictedQuery() : base.AssembleQuery();

            T obj = base.Get<T>(sql, _typedEntity.FillObject);

            return obj;
        }
        #endregion

        #region validate
        protected override void Validate()
        {
            base.Validate();
        }
        #endregion
    }
}
