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
    public class SelectManyEntityMsSqlBuilder<T> : SelectMsSqlBuilder<T> where T : class, IDBEntity, new()
    {
        #region private
        private DBExpressionEntity<T> _typedEntity;
        #endregion

        #region constructors
        public SelectManyEntityMsSqlBuilder(string connectionStringName, DBExpressionEntity<T> baseEntity) : base(connectionStringName, baseEntity, ExecutionContext.GetList)
        {
            _typedEntity = baseEntity;
            base.Expression &= baseEntity.GetInclusiveSelectExpression();
        }

        public SelectManyEntityMsSqlBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity<T> baseEntity) : base(connectionStringSettings, baseEntity, ExecutionContext.GetList)
        {
            _typedEntity = baseEntity;
            base.Expression &= baseEntity.GetInclusiveSelectExpression();
        }
        #endregion

        #region execute
        public new IList<T> Execute()
        {
            Validate();

            string sql = base.SkipValue.HasValue ? base.AssembleSkipTakeRestrictedQuery() : base.AssembleQuery();

            IList<T> lst = base.GetList<T>(sql, _typedEntity.FillObject);

            return lst;
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
