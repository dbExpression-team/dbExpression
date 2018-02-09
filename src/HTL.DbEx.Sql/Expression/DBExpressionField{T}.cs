namespace HTL.DbEx.Sql.Expression
{
    public class DBExpressionField<T> : DBExpressionField
    {
        #region constructors
        public DBExpressionField(DBExpressionEntity parentEntity, string name) : base(parentEntity, name)
        {
        }

        public DBExpressionField(DBExpressionEntity parentEntity, string name, int size) : base(parentEntity, name, size)
        {
        }
        #endregion

        #region in value set
        public DBFilterExpression In(params T[] value) => value != null ? new DBFilterExpression(this, value, DBFilterExpressionOperator.In) : null;
        #endregion

        #region set value
        public DBAssignmentExpression Set(T value) => new DBAssignmentExpression(this, value);
        #endregion

        #region set field
        public DBAssignmentExpression Set(DBExpressionField<T> field) => new DBAssignmentExpression(this, field);
        #endregion

        #region insert (init) value
        public DBInsertExpression Insert(T value) => new DBInsertExpression(this, value, typeof(T));
        #endregion

        #region implicit select operator
        public static implicit operator DBSelectExpression(DBExpressionField<T> field) => new DBSelectExpression(field);
        #endregion

        #region implicit group by expression operator
        public static implicit operator DBGroupByExpression(DBExpressionField<T> a) => new DBGroupByExpression(a);
        #endregion

        #region field to value relational operators
        public static DBFilterExpression operator ==(DBExpressionField<T> field, T value) => new DBFilterExpression(field, value, DBFilterExpressionOperator.Equal);

        public static DBFilterExpression operator !=(DBExpressionField<T> field, T value) => new DBFilterExpression(field, value, DBFilterExpressionOperator.NotEqual);

        public static DBFilterExpression operator <(DBExpressionField<T> field, T value) => new DBFilterExpression(field, value, DBFilterExpressionOperator.LessThan);

        public static DBFilterExpression operator <=(DBExpressionField<T> field, T value) => new DBFilterExpression(field, value, DBFilterExpressionOperator.LessThanOrEqual);

        public static DBFilterExpression operator >(DBExpressionField<T> field, T value) => new DBFilterExpression(field, value, DBFilterExpressionOperator.GreaterThan);

        public static DBFilterExpression operator >=(DBExpressionField<T> field, T value) => new DBFilterExpression(field, value, DBFilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field to field relational operators
        public static DBFilterExpression operator ==(DBExpressionField<T> a, DBExpressionField b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);

        public static DBFilterExpression operator !=(DBExpressionField<T> a, DBExpressionField b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);

        public static DBFilterExpression operator <(DBExpressionField<T> a, DBExpressionField b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);

        public static DBFilterExpression operator <=(DBExpressionField<T> a, DBExpressionField b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);

        public static DBFilterExpression operator >(DBExpressionField<T> a, DBExpressionField b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);

        public static DBFilterExpression operator >=(DBExpressionField<T> a, DBExpressionField b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field to value arithmetic operators
        public static DBArithmeticExpression operator +(DBExpressionField<T> a, T b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);

        public static DBArithmeticExpression operator -(DBExpressionField<T> a, T b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);

        public static DBArithmeticExpression operator *(DBExpressionField<T> a, T b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);

        public static DBArithmeticExpression operator /(DBExpressionField<T> a, T b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);

        public static DBArithmeticExpression operator %(DBExpressionField<T> a, T b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);
        #endregion

        #region field to field arithmetic operators
        public static DBArithmeticExpression operator +(DBArithmeticExpression a, DBExpressionField<T> b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);

        public static DBArithmeticExpression operator -(DBArithmeticExpression a, DBExpressionField<T> b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);

        public static DBArithmeticExpression operator *(DBArithmeticExpression a, DBExpressionField<T> b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);

        public static DBArithmeticExpression operator /(DBArithmeticExpression a, DBExpressionField<T> b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);

        public static DBArithmeticExpression operator %(DBArithmeticExpression a, DBExpressionField<T> b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);
        #endregion

        #region equals
        public override bool Equals(object obj) => base.Equals(obj);
        #endregion

        #region override get hash code
        public override int GetHashCode() => base.GetHashCode();
        #endregion
    }

}
