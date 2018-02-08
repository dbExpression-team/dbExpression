using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBOrderByExpression : DBExpression, IDBExpression
    {
        #region interface
        private readonly object _orderExpression;
        private readonly DBOrderExpressionDirection _direction;
        #endregion

        #region constructors
        internal DBOrderByExpression(DBExpressionField field, DBOrderExpressionDirection direction)
        {
            _orderExpression = field;
            _direction = direction;
        }

        internal DBOrderByExpression(DBExpression expression, DBOrderExpressionDirection direction)
        {
            _orderExpression = expression;
            _direction = direction;
        }
        #endregion

        #region to string
        public override string ToString() => $"{_orderExpression} {_direction}";
        #endregion

        #region to parameterized string
        public string ToParameterizedString(IList<DbParameter> parameters, SqlConnection dbService)
        {
            string expression = null;
            if (_orderExpression is DBExpression)
            {
                expression = $"{(_orderExpression as IDBExpression).ToParameterizedString(parameters, dbService)} {_direction}";
            }
            else
            {
                expression = this.ToString();
            }
            return expression;
        }
        #endregion

        #region conditional & operator
        public static DBOrderByExpressionSet operator &(DBOrderByExpression a, DBOrderByExpression b) => new DBOrderByExpressionSet(a, b);
        #endregion

        #region implicit order by expression set operator
        public static implicit operator DBOrderByExpressionSet(DBOrderByExpression a) => new DBOrderByExpressionSet(a);
        #endregion
    }
    
}
