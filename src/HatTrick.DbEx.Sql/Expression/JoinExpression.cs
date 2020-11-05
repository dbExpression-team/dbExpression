using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class JoinExpression : 
        IExpression, 
        IExpressionAliasProvider
    {
        #region interface
        public JoinOnExpressionSet JoinOnExpression { get; private set; }
        public IExpression JoinToo { get; private set; }
        public JoinOperationExpressionOperator JoinType { get; private set; }
        private string Alias { get; set; }
        string IExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        public JoinExpression(IExpression joinToo, JoinOperationExpressionOperator joinType, JoinOnExpression onCondition, string alias)
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
            if (a is null && b is object) { return new JoinExpressionSet(b); }
            if (a is object && b is null) { return new JoinExpressionSet(a); }
            if (a is null && b is null) { return null; }

            return new JoinExpressionSet(a, b);
        }
        #endregion
    }
    
}
