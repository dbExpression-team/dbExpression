using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class InsertExpressionSet<T> : InsertExpressionSet, 
        IExpressionSet<InsertExpression>
    {
        #region interface
        public new T Entity { get; private set; }
        #endregion

        #region constructors
        private InsertExpressionSet()
        {

        }

        public InsertExpressionSet(T entity, IEnumerable<InsertExpression> fields) : base(entity as IDbEntity, fields)
        {
        }

        public InsertExpressionSet(T entity, params InsertExpression[] fields) : base(entity as IDbEntity, fields?.ToArray())
        {
        }
        #endregion

        #region to string
        public override string ToString() => $"{string.Join(", ", Expressions.Select(e => e.ToString()))}";
        #endregion
    }

}
