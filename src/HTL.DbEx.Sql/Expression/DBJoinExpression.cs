using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBJoinExpression : DBExpression, IDBExpression
    {
        #region internals
        private readonly DBExpressionEntity _entity;
        private readonly DBExpressionJoinType _joinType;
        private DBFilterExpression OnCondition { get; set; }
        #endregion

        #region constructors
        public DBJoinExpression(DBExpressionEntity entity, DBExpressionJoinType joinType, DBFilterExpression onCondition)
        {
            _entity = entity;
            _joinType = joinType;
            OnCondition = onCondition;
        }
        #endregion

        #region on
        public DBJoinExpression On(DBFilterExpression filter)
        {
            OnCondition = filter;
            return this;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            string expression; 
           
            if (_joinType == DBExpressionJoinType.CROSS)
            {
                expression = $"{_joinType} JOIN {_entity}";
            }
            else
            {
                expression = $"{_joinType} JOIN {_entity} ON {OnCondition}";
            }
            return expression;
        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(IList<DbParameter> parameters, SqlConnection dbService)
        {
            string expression = null;
            if (_joinType == DBExpressionJoinType.CROSS)
            {
                expression = $"CROSS JOIN {_entity}";
            }
            else
            {
                expression = $"{_joinType} JOIN {_entity} ON {OnCondition.ToParameterizedString(parameters, dbService)}";
            }
            return expression;
        }
        #endregion

        #region logical & operator
        public static DBJoinExpressionSet operator &(DBJoinExpression a, DBJoinExpression b)
        {
            if (a == null && b != null) { return new DBJoinExpressionSet(b); }
            if (a != null && b == null) { return new DBJoinExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new DBJoinExpressionSet(a, b);
        }
        #endregion
    }
    
}
