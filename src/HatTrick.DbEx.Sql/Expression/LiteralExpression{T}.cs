using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class LiteralExpression<TValue> : LiteralExpression
    {
        public LiteralExpression(TValue value) : base(new ExpressionContainer(value == null ? (object)DBNull.Value : (object)value, value == null ? typeof(DBNull) : value.GetType()))
        {

        }

        #region equals
        public override bool Equals(object obj) => base.Equals(obj);
        #endregion

        #region override get hash code
        public override int GetHashCode() => base.GetHashCode();
        #endregion
    }
}
