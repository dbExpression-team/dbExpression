using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class AggregateFunctionExpression : DbExpression
    {
        #region interface
        public (Type, object) Expression { get; private set; }
        public AggregateFunction AggregateFunction { get; private set; }
        public bool Distinct { get; private set; }
        #endregion

        #region constructors
        internal AggregateFunctionExpression(SelectExpression select, AggregateFunction aggregateFunction, bool distinct = false)
        {
            Expression = (typeof(SelectExpression), select);
            AggregateFunction = aggregateFunction;
            Distinct = distinct;
        }
        #endregion

        #region as
        public SelectExpression As(string alias) => new SelectExpression(this).As(alias);
        #endregion

        #region to string
        public override string ToString() => $"{AggregateFunction}({(Distinct ? " DISTINCT " : string.Empty)}{Expression.Item2})";
        #endregion

        #region implicit select operators
        public static implicit operator SelectExpression(AggregateFunctionExpression a) => new SelectExpression(a);
        #endregion
    }
    
}
