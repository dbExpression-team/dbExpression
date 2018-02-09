using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBFilterExpressionSet : DBExpression, IDBExpression
    {
        #region interface
        private readonly object _leftArg;
        private readonly object _rightArg;
        private readonly DBConditionalExpressionOperator _conditionalOperator;
        private bool Negate { get; set; }
        #endregion

        #region constructors
        internal DBFilterExpressionSet(DBFilterExpression singleFilter)
        {
            this._rightArg = singleFilter;
        }

        internal DBFilterExpressionSet(DBFilterExpression leftArg, DBFilterExpression rightArg, DBConditionalExpressionOperator conditinalOperator)
        {
            _leftArg = leftArg;
            _rightArg = rightArg;
            _conditionalOperator = conditinalOperator;
        }

        internal DBFilterExpressionSet(DBFilterExpressionSet leftArg, DBFilterExpression rightArg, DBConditionalExpressionOperator conditinalOperator)
        {
            _leftArg = leftArg;
            _rightArg = rightArg;
            _conditionalOperator = conditinalOperator;
        }

        internal DBFilterExpressionSet(DBFilterExpressionSet leftArg, DBFilterExpressionSet rightArg, DBConditionalExpressionOperator conditinalOperator)
        {
            _leftArg = leftArg;
            _rightArg = rightArg;
            _conditionalOperator = conditinalOperator;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            string left = (_leftArg == null) ? string.Empty : _leftArg.ToString();
            string right = _rightArg.ToString();
            string expression = null;

            if (_leftArg != null)
            {
                if (_conditionalOperator == DBConditionalExpressionOperator.And)
                {
                    if (left != null)
                    {
                        expression = $"({left} AND {right})";
                    }
                    else
                    {
                        expression = right;
                    }
                }
                else if (_conditionalOperator == DBConditionalExpressionOperator.Or)
                {
                    expression = $"({left} OR {right})";
                }
            }
            else
            {
                expression = right;
            }
            return (Negate) ? $"NOT ({expression})" : expression;
        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(IList<DbParameter> parameters, SqlConnection dbService)
        {
            string left = (_leftArg == null) ? string.Empty : (_leftArg as IDBExpression).ToParameterizedString(parameters, dbService);
            string right = (_rightArg as IDBExpression).ToParameterizedString(parameters, dbService);

            string expression = null;
            if (_leftArg != null)
            {
                if (_conditionalOperator == DBConditionalExpressionOperator.And)
                {
                    if (left != null)
                    {
                        expression = $"({left} AND {right})";
                    }
                    else
                    {
                        expression = right;
                    }
                }
                else if (_conditionalOperator == DBConditionalExpressionOperator.Or)
                {
                    expression = $"({left} OR {right})";
                }
            }
            else
            {
                expression = right;
            }
            return (Negate) ? $"NOT ({expression})" : expression;
        }
        #endregion

        #region conditional &, | operators
        public static DBFilterExpressionSet operator &(DBFilterExpressionSet a, DBFilterExpression b)
        {
            if (a == null && b != null) { return new DBFilterExpressionSet(b); }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new DBFilterExpressionSet(a, b, DBConditionalExpressionOperator.And);
        }

        public static DBFilterExpressionSet operator &(DBFilterExpressionSet a, DBFilterExpressionSet b)
        {
            if (a == null && b != null) { return b; }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new DBFilterExpressionSet(a, b, DBConditionalExpressionOperator.And);
        }

        public static DBFilterExpressionSet operator |(DBFilterExpressionSet a, DBFilterExpression b)
        {
            if (a == null && b != null) { return new DBFilterExpressionSet(b); }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new DBFilterExpressionSet(a, b, DBConditionalExpressionOperator.Or);
        }

        public static DBFilterExpressionSet operator |(DBFilterExpressionSet a, DBFilterExpressionSet b)
        {
            if (a == null && b != null) { return b; }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new DBFilterExpressionSet(a, b, DBConditionalExpressionOperator.Or);
        }
        #endregion

        #region implicit having expression set operator
        public static implicit operator DBHavingExpression(DBFilterExpressionSet a) => new DBHavingExpression(a);
        #endregion

        #region negation operator
        public static DBFilterExpressionSet operator !(DBFilterExpressionSet filter)
        {
            if (filter != null) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }
    
}
