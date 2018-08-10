using System;

namespace HTL.DbEx.Sql.Expression
{
    public class DBAggregateFunctionExpression : DBExpression
    {
        #region interface
        public (Type, object) Expression { get; private set; }
        public DBAggregateFunction AggregateFunction { get; private set; }
        public bool Distinct { get; private set; }
        #endregion

        #region constructors
        internal DBAggregateFunctionExpression(DBSelectExpression select, DBAggregateFunction aggregateFunction, bool distinct = false)
        {
            Expression = (typeof(DBSelectExpression), select);
            AggregateFunction = aggregateFunction;
            Distinct = distinct;
        }
        #endregion

        #region as
        public DBSelectExpression As(string alias) => new DBSelectExpression(this).As(alias);
        #endregion

        #region to string
        public override string ToString() => $"{AggregateFunction}({(Distinct ? " DISTINCT " : string.Empty)}{Expression.Item2})";
        #endregion

        #region implicit select operators
        public static implicit operator DBSelectExpression(DBAggregateFunctionExpression a) => new DBSelectExpression(a);
        #endregion
    }
    
}
