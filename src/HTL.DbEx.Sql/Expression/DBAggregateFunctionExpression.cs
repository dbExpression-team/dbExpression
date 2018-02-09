using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBAggregateFunctionExpression : DBExpression, IDBExpression
    {
        #region internals
        private readonly DBSelectExpression _select;
        private readonly DBSelectExpressionAggregateFunction _aggregateFunction;
        private readonly bool _distinct;
        #endregion

        #region interface
        #endregion

        #region constructors
        internal DBAggregateFunctionExpression(DBSelectExpression select, DBSelectExpressionAggregateFunction aggregateFunction, bool distinct = false)
        {
            _select = select;
            _aggregateFunction = aggregateFunction;
            _distinct = distinct;
        }
        #endregion

        #region as
        public DBSelectExpression As(string alias) => new DBSelectExpression(this).As(alias);
        #endregion

        #region to string
        public override string ToString() => $"{_aggregateFunction}({(_distinct ? " DISTINCT " : string.Empty)}{_select})";
        #endregion

        #region to parameterized string
        public string ToParameterizedString(IList<DbParameter> parameters, SqlConnection dbService) => $"{_aggregateFunction}({(_distinct ? " DISTINCT " : string.Empty)}{_select.ToParameterizedString(parameters, dbService)})";
        #endregion

        #region implicit select operators
        public static implicit operator DBSelectExpression(DBAggregateFunctionExpression a) => new DBSelectExpression(a);
        #endregion
    }
    
}
