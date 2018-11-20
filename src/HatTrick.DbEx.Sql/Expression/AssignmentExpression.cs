using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class AssignmentExpression : DbExpression, IAssemblyPart
    {
        #region interface
        public DbExpressionPair Expression { get; private set; }
        #endregion

        #region constructors
        internal AssignmentExpression(FieldExpression field, object value)
        {
            Expression = new DbExpressionPair((typeof(FieldExpression), field), (value.GetType(), value));
        }
        #endregion

        #region to string
        public override string ToString() => $"{Expression.LeftPart} = {Expression.RightPart}";
        #endregion
        
        #region logical & operator
        public static AssignmentExpressionSet operator &(AssignmentExpression a, AssignmentExpression b) => new AssignmentExpressionSet(a, b);
        #endregion

        #region implicit assignment expression set operator
        public static implicit operator AssignmentExpressionSet(AssignmentExpression a) => new AssignmentExpressionSet(a);
        #endregion
    }
    
}
