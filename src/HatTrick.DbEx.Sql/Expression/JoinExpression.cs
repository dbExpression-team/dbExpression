using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class JoinExpression : 
        IExpressionElement, 
        IExpressionAliasProvider
    {
        #region interface
        public AnyJoinOnClause JoinOnExpression { get; private set; }
        public IExpressionElement JoinToo { get; private set; }
        public JoinOperationExpressionOperator JoinType { get; private set; }
        private string Alias { get; set; }
        string IExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        public JoinExpression(IExpressionElement joinToo, JoinOperationExpressionOperator joinType, AnyJoinOnClause onCondition)
            : this(joinToo, joinType, onCondition, null)
        {

        }

        protected JoinExpression(IExpressionElement joinToo, JoinOperationExpressionOperator joinType, AnyJoinOnClause onCondition, string alias)
        {
            JoinToo = joinToo ?? throw new ArgumentNullException(nameof(joinToo));
            JoinType = joinType;
            JoinOnExpression = onCondition ?? throw new ArgumentNullException(nameof(onCondition));
            Alias = alias;
        }
        #endregion

        #region as
        public JoinExpression As(string alias)
            => new JoinExpression(this.JoinToo, this.JoinType, this.JoinOnExpression, alias);
        #endregion

        #region to string
        public override string ToString() => JoinType == JoinOperationExpressionOperator.CROSS ? $"{JoinType} JOIN {JoinToo}" : $"{JoinType} JOIN {JoinToo} ON {JoinOnExpression}";
        #endregion

        #region logical & operator
        public static JoinExpressionSet operator &(JoinExpression a, JoinExpression b)
        {
            if (a is null && b is object) { return new JoinExpressionSet(b); }
            if (a is object && b is null) { return new JoinExpressionSet(a); }
            if (a is null && b is null) { return null; }

            return new JoinExpressionSet(a, b);
        }
        #endregion
    }
    
}
