using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class JoinExpression : 
        IDbExpression, 
        IDbExpressionAliasProvider
    {
        #region interface
        public JoinOnExpression JoinOnExpression { get; private set; }
        public IDbExpression JoinToo { get; private set; }
        public JoinOperationExpressionOperator JoinType { get; private set; }
        private string Alias { get; set; }
        string IDbExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        public JoinExpression(IDbExpression joinToo, JoinOperationExpressionOperator joinType, JoinOnExpression onCondition, string alias)
        {
            JoinToo = joinToo ?? throw new ArgumentNullException($"{nameof(joinToo)} is required.");
            JoinType = joinType;
            JoinOnExpression = onCondition ?? throw new ArgumentNullException($"{nameof(onCondition)} is required.");
            Alias = alias;
        }
        #endregion

        #region to string
        public override string ToString() => JoinType == JoinOperationExpressionOperator.CROSS ? $"{JoinType} JOIN {JoinToo}" : $"{JoinType} JOIN {JoinToo} ON {JoinOnExpression}";
        #endregion

        #region logical & operator
        public static JoinExpressionSet operator &(JoinExpression a, JoinExpression b)
        {
            if (a == null && b != null) { return new JoinExpressionSet(b); }
            if (a != null && b == null) { return new JoinExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new JoinExpressionSet(a, b);
        }
        #endregion
    }
    
}
