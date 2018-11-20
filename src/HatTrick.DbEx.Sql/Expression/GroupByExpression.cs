using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class GroupByExpression : DbExpression, IAssemblyPart
    {
        #region internals
        public (Type,object) Expression { get; private set; }
        #endregion

        #region constructors
        internal GroupByExpression(FieldExpression field)
        {
            Expression = (typeof(FieldExpression),field);
        }

        internal GroupByExpression(SelectExpression expression)
        {
            Expression = (typeof(SelectExpression), expression);
        }
        #endregion

        #region to string
        public override string ToString() => Expression.Item2.ToString();
        #endregion

        #region conditional & operator
        public static GroupByExpressionSet operator &(GroupByExpression a, GroupByExpression b) => new GroupByExpressionSet(a, b);
        #endregion

        #region implicit group by expression set operator
        public static implicit operator GroupByExpressionSet(GroupByExpression a) => new GroupByExpressionSet(a);
        #endregion
    }
    
}
