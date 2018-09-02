using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class AssignmentExpression : DbExpression
    {
        #region interface
        public (Type,object) Expression { get; private set; }
        public (Type, object) Value => ((DbExpressionPair)Expression.Item2).RightPart;
        #endregion

        #region constructors
        internal AssignmentExpression(FieldExpression field, object value)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((typeof(FieldExpression), field), (value.GetType(), value)));
        }
        #endregion

        #region to string
        public override string ToString() => $"{Expression.Item2} = {Value.Item2}";
        #endregion
        
        #region logical & operator
        public static AssignmentExpressionSet operator &(AssignmentExpression a, AssignmentExpression b) => new AssignmentExpressionSet(a, b);
        #endregion

        #region implicit assignment expression set operator
        public static implicit operator AssignmentExpressionSet(AssignmentExpression a) => new AssignmentExpressionSet(a);
        #endregion
    }
    
}
