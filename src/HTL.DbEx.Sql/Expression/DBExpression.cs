using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    #region entity
    //TODO: JRod, need to add schema to the entity name...
    public class DBExpressionEntity
    {
        #region internals
        #endregion

        #region interface
        public virtual string Schema
        { get; private set; }

        public virtual string Name
        { get; private set; }

        public virtual string AliasName
        { get; protected set; }

        public bool IsAliased
        { get; protected set; }

        public bool IsCorrelated
        { get; protected set; }
        #endregion

        #region constructors
        public DBExpressionEntity(string schema, string name)
        {
            this.Schema = schema;
            this.Name = name;
        }
        #endregion

        #region as
        public DBExpressionEntity As(string alias)
        {
            return new DBExpressionEntity(this.Schema, this.Name) { AliasName = alias, IsAliased = true };
        }
        #endregion

        #region correlate
        public DBExpressionEntity Correlate(string name)
        {
            return new DBExpressionEntity(this.Schema, this.Name) { AliasName = name, IsCorrelated = true };
        }
        #endregion

        #region join
        public DBJoinExpression Join(DBExpressionJoinType joinType, DBFilterExpression joinCondition)
        {
            return new DBJoinExpression(this, joinType, joinCondition);
        }
        #endregion

        #region to string
        public override string ToString()
        {
            if (this.IsCorrelated)
            {
                return this.AliasName;
            }
            else
            {
                return this.ToString("[s].[e]");
            }
        }

        public string ToString(string format)
        {
            if (this.IsCorrelated) { throw new InvalidOperationException("Correlated entities cannot be converted to string with a formatter."); }

            string val = null;
            switch (format)
            {
                case "e":
                    val = this.Name;
                    break;
                case "s.e":
                    val = this.Schema + "." + this.Name;
                    break;
                case "[e]":
                    val = "[" + this.Name + "]";
                    break;
                case "[s.e]":
                    val = "[" + this.Schema + "." + this.Name + "]";
                    break;
                case "[s].[e]":
                    val = "[" + this.Schema + "].[" + this.Name + "]";
                    break;
                default:
                    throw new ArgumentException("encountered unknown format string");
            }

            if (this.IsAliased)
            {
                val += " AS " + this.AliasName;
            }

            return val;
        }
        #endregion
    }
    #endregion

    #region field
    public class DBExpressionField
    {
        #region interface
        public DBExpressionEntity ParentEntity
        { get; protected set; }

        public string Name
        { get; private set; }

        public int? Size
        { get; private set; }

        public DBFilterExpression IsNull
        { get { return new DBFilterExpression(this, null, DBFilterExpressionOperator.Equal); } }

        public DBOrderByExpression Asc
        { get { return new DBOrderByExpression(this, DBOrderExpressionDirection.ASC); } }

        public DBOrderByExpression Desc
        { get { return new DBOrderByExpression(this, DBOrderExpressionDirection.DESC); } }
        #endregion

        #region constructors
        internal DBExpressionField(DBExpressionEntity parentEntity, string name, int size) : this(parentEntity, name)
        {
            this.Size = size;
        }

        internal DBExpressionField(DBExpressionEntity parentEntity, string name)
        {
            this.ParentEntity = parentEntity;
            this.Name = name;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            return this.ParentEntity.ToString() + ".[" + this.Name + "]";
        }

        public string ToString(string format)
        {
            switch (format)
            {
                case "f":
                    return this.Name;
                case "[f]":
                    return "[" + this.Name + "]";
                case "e.f":
                    return this.ToString();
                case "s.e.f":
                    return this.ParentEntity.ToString("s.e") + "." + this.Name;
                case "[s].[e].[f]":
                    return this.ParentEntity.ToString("[s].[e]") + ".[" + this.Name + "]";
                case "[s.e.f]":
                    return "[" + this.ParentEntity.ToString("s.e") + "." + this.Name + "]";
                default:
                    throw new ArgumentException("encountered unknown format string: " + format + " valid formats are 'e','f','[e]','[f]','e.f','[e].[f]'", "format");
            }
        }
        #endregion

        #region as
        public DBSelectExpression As(string alias)
        {
            return new DBSelectExpression(this).As(alias);
        }
        #endregion

        #region like
        public DBFilterExpression Like(string phrase)
        {
            return new DBFilterExpression(this, phrase, DBFilterExpressionOperator.Like);
        }
        #endregion

        #region set field
        public DBAssignmentExpression Set(DBExpression expression)
        {
            return new DBAssignmentExpression(this, expression);
        }
        #endregion

        #region aggregate functions
        public DBSelectExpression Avg(bool distinct = false)
        {
            return new DBAggregateFunctionExpression(this, DBSelectExpressionAggregateFunction.AVG, distinct);
        }

        public DBSelectExpression Min(bool distinct = false)
        {
            return new DBAggregateFunctionExpression(this, DBSelectExpressionAggregateFunction.MIN, distinct);
        }

        public DBSelectExpression Max(bool distinct = false)
        {
            return new DBAggregateFunctionExpression(this, DBSelectExpressionAggregateFunction.MAX, distinct);
        }

        public DBSelectExpression Sum(bool distinct = false)
        {
            return new DBAggregateFunctionExpression(this, DBSelectExpressionAggregateFunction.SUM, distinct);
        }

        public DBSelectExpression Count(bool distinct = false)
        {
            return new DBAggregateFunctionExpression(this, DBSelectExpressionAggregateFunction.COUNT, distinct);
        }
        #endregion

        #region implicit select operator
        public static implicit operator DBSelectExpression(DBExpressionField field)
        {
            return new DBSelectExpression(field);
        }
        #endregion

        #region field to expression relational operators
        public static DBFilterExpression operator ==(DBExpressionField a, DBExpression b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);
        }

        public static DBFilterExpression operator !=(DBExpressionField a, DBExpression b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);
        }

        public static DBFilterExpression operator <(DBExpressionField a, DBExpression b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);
        }

        public static DBFilterExpression operator <=(DBExpressionField a, DBExpression b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);
        }

        public static DBFilterExpression operator >(DBExpressionField a, DBExpression b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);
        }

        public static DBFilterExpression operator >=(DBExpressionField a, DBExpression b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);
        }
        #endregion

        #region field to field arithmetic operators
        public static DBArithmeticExpression operator +(DBExpressionField a, DBExpressionField b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);
        }
        public static DBArithmeticExpression operator -(DBExpressionField a, DBExpressionField b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);
        }
        public static DBArithmeticExpression operator *(DBExpressionField a, DBExpressionField b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);
        }
        public static DBArithmeticExpression operator /(DBExpressionField a, DBExpressionField b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);
        }
        public static DBArithmeticExpression operator %(DBExpressionField a, DBExpressionField b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);
        }
        #endregion

        #region field to arithmetic expression arithmetic operators
        public static DBArithmeticExpression operator +(DBExpressionField a, DBArithmeticExpression b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);
        }
        public static DBArithmeticExpression operator -(DBExpressionField a, DBArithmeticExpression b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);
        }
        public static DBArithmeticExpression operator *(DBExpressionField a, DBArithmeticExpression b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);
        }
        public static DBArithmeticExpression operator /(DBExpressionField a, DBArithmeticExpression b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);
        }
        public static DBArithmeticExpression operator %(DBExpressionField a, DBArithmeticExpression b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);
        }
        #endregion

        #region conditional & operator
        public static DBSelectExpressionSet operator &(DBExpressionField a, DBExpressionField b)
        {
            return new DBSelectExpressionSet(a, b);
        }
        #endregion

        #region equals
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        #endregion

        #region override get hash code
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
    #endregion

    #region field T
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
        public DBFilterExpression In(params T[] value)
        {
            if (value != null)
            {
                return new DBFilterExpression(this, value, DBFilterExpressionOperator.In);
            }
            return null;
        }
        #endregion

        #region set value
        public DBAssignmentExpression Set(T value)
        {
            return new DBAssignmentExpression(this, value);
        }
        #endregion

        #region set field
        public DBAssignmentExpression Set(DBExpressionField<T> field)
        {
            return new DBAssignmentExpression(this, field);
        }
        #endregion

        #region insert (init) value
        public DBInsertExpression Insert(T value)
        {
            return new DBInsertExpression(this, value, typeof(T));
        }
        #endregion

        #region implicit select operator
        public static implicit operator DBSelectExpression(DBExpressionField<T> field)
        {
            return new DBSelectExpression(field);
        }
        #endregion

        #region implicit group by expression operator
        public static implicit operator DBGroupByExpression(DBExpressionField<T> a)
        {
            return new DBGroupByExpression(a);
        }
        #endregion

        #region field to value relational operators
        public static DBFilterExpression operator ==(DBExpressionField<T> field, T value)
        {
            return new DBFilterExpression(field, value, DBFilterExpressionOperator.Equal);
        }

        public static DBFilterExpression operator !=(DBExpressionField<T> field, T value)
        {
            return new DBFilterExpression(field, value, DBFilterExpressionOperator.NotEqual);
        }

        public static DBFilterExpression operator <(DBExpressionField<T> field, T value)
        {
            return new DBFilterExpression(field, value, DBFilterExpressionOperator.LessThan);
        }

        public static DBFilterExpression operator <=(DBExpressionField<T> field, T value)
        {
            return new DBFilterExpression(field, value, DBFilterExpressionOperator.LessThanOrEqual);
        }

        public static DBFilterExpression operator >(DBExpressionField<T> field, T value)
        {
            return new DBFilterExpression(field, value, DBFilterExpressionOperator.GreaterThan);
        }

        public static DBFilterExpression operator >=(DBExpressionField<T> field, T value)
        {
            return new DBFilterExpression(field, value, DBFilterExpressionOperator.GreaterThanOrEqual);
        }
        #endregion

        #region field to field relational operators
        public static DBFilterExpression operator ==(DBExpressionField<T> a, DBExpressionField b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);
        }

        public static DBFilterExpression operator !=(DBExpressionField<T> a, DBExpressionField b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);
        }

        public static DBFilterExpression operator <(DBExpressionField<T> a, DBExpressionField b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);
        }

        public static DBFilterExpression operator <=(DBExpressionField<T> a, DBExpressionField b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);
        }

        public static DBFilterExpression operator >(DBExpressionField<T> a, DBExpressionField b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);
        }

        public static DBFilterExpression operator >=(DBExpressionField<T> a, DBExpressionField b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);
        }
        #endregion

        #region field to value arithmetic operators
        public static DBArithmeticExpression operator +(DBExpressionField<T> a, T b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);
        }

        public static DBArithmeticExpression operator -(DBExpressionField<T> a, T b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);
        }

        public static DBArithmeticExpression operator *(DBExpressionField<T> a, T b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);
        }

        public static DBArithmeticExpression operator /(DBExpressionField<T> a, T b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);
        }

        public static DBArithmeticExpression operator %(DBExpressionField<T> a, T b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);
        }
        #endregion

        #region field to field arithmetic operators
        public static DBArithmeticExpression operator +(DBArithmeticExpression a, DBExpressionField<T> b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);
        }

        public static DBArithmeticExpression operator -(DBArithmeticExpression a, DBExpressionField<T> b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);
        }

        public static DBArithmeticExpression operator *(DBArithmeticExpression a, DBExpressionField<T> b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);
        }

        public static DBArithmeticExpression operator /(DBArithmeticExpression a, DBExpressionField<T> b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);
        }

        public static DBArithmeticExpression operator %(DBArithmeticExpression a, DBExpressionField<T> b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);
        }
        #endregion

        #region equals
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        #endregion

        #region override get hash code
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
    #endregion

    #region i expression
    public interface IDBExpression
    {
        string  ToParameterizedString(List<DbParameter> parameters, SqlConnection dbService);
    }
    #endregion

    #region expresssion
    public class DBExpression
    {
        #region internals
        #endregion

        #region interface
        #endregion
        
        #region constructors
        internal DBExpression()
        {
        }
        #endregion

        #region to string
        public override string ToString()
        {
 	        return base.ToString();
        }
        #endregion
    }
    #endregion

    #region insert expression
    public class DBInsertExpression : DBExpression
    {
        #region internals
        DBExpressionField _field;
        object _value;
        Type _type;
        #endregion

        #region interface
        public DBExpressionField Field
        { get { return _field; } }

        public object Value
        { get { return _value; } }

        public Type Type
        { get { return _type; } }
        #endregion

        #region constructors
        public DBInsertExpression(DBExpressionField field, object value, Type type)
        {
            _field = field;
            _value = value;
            _type = type;
        }
        #endregion

        #region logical & operator
        public static DBInsertExpressionSet operator &(DBInsertExpression a, DBInsertExpression b)
        {
            return new DBInsertExpressionSet(a, b);
        }
        #endregion

        #region implicit insert expression set operator
        public static implicit operator DBInsertExpressionSet(DBInsertExpression a)
        {
            return new DBInsertExpressionSet(a);
        }
        #endregion
    }
    #endregion

    #region insert expression set
    public class DBInsertExpressionSet : DBExpression, IDBExpression
    {
        #region internals
        List<DBInsertExpression> _inserts;
        #endregion

        #region constructors
        public DBInsertExpressionSet()
        {
            _inserts = new List<DBInsertExpression>();
        }

        public DBInsertExpressionSet(DBInsertExpression a)
        {
            _inserts = new List<DBInsertExpression>();
            _inserts.Add(a);
        }

        public DBInsertExpressionSet(DBInsertExpression a, DBInsertExpression b)
        {
            _inserts = new List<DBInsertExpression>();
            _inserts.Add(a);
            _inserts.Add(b);

        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(List<DbParameter> parameters, SqlConnection dbService)
        {
            string[] cols = new string[_inserts.Count];
            string[] parms = new string[_inserts.Count];
            for (int i = 0; i < _inserts.Count; i++)
			{
                cols[i] = _inserts[i].Field.ToString();
                parms[i] = "@I" + (i + 1);

                parameters.Add(dbService.GetDbParameter(parms[i], _inserts[i].Value, _inserts[i].Type, _inserts[i].Field.Size));
            }

            string expr = string.Concat("(", string.Join(", ", cols), ") VALUES (", string.Join(", ", parms), ")");
            return expr;
        }
        #endregion

        #region logical & operator
        public static DBInsertExpressionSet operator &(DBInsertExpressionSet aSet, DBInsertExpression b)
        {
            if (aSet == null)
            {
                aSet = new DBInsertExpressionSet(b);
            }
            else
            {
                aSet._inserts.Add(b);
            }
            return aSet;
        }

        public static DBInsertExpressionSet operator &(DBInsertExpressionSet aSet, DBInsertExpressionSet bSet)
        {
            if (aSet == null)
            {
                aSet = new DBInsertExpressionSet();
            }
            aSet._inserts.AddRange(bSet._inserts);
            return aSet;
        }
        #endregion
    }

    #endregion

    #region select expression
    public class DBSelectExpression : DBExpression, IDBExpression
    {
        #region internals
        private object _expressionRoot;
        private string _alias;
        #endregion

        #region interface
        public bool IsDistinct
        { get; private set; }
        #endregion

        #region constructors
        public DBSelectExpression(DBExpressionField field)
        {
            _expressionRoot = field;
        }

        public DBSelectExpression(DBArithmeticExpression arithmeticExpression)
        {
            _expressionRoot = arithmeticExpression;
        }

        public DBSelectExpression(DBAggregateFunctionExpression aggregateFunctionExpression)
        {
            _expressionRoot = aggregateFunctionExpression;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            return _expressionRoot.ToString() + ((_alias == null) ? string.Empty : (" AS " + _alias));
        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(List<DbParameter> parameters, SqlConnection dbService)
        {
            string expression = null;
            if (_expressionRoot is IDBExpression)
            {
                expression = (_expressionRoot as IDBExpression).ToParameterizedString(parameters, dbService);
            }
            else
            {
                expression = _expressionRoot.ToString();
            }
            return (_alias != null) ? expression + " AS " + _alias : expression;
        }
        #endregion

        #region as
        public virtual DBSelectExpression As(string alias)
        {
            this._alias = alias;
            return this;
        }
        #endregion

        #region select to select arithmetic operators
        public static DBArithmeticExpression operator +(DBSelectExpression a, DBSelectExpression b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);
        }
        public static DBArithmeticExpression operator -(DBSelectExpression a, DBSelectExpression b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);
        }
        public static DBArithmeticExpression operator *(DBSelectExpression a, DBSelectExpression b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);
        }
        public static DBArithmeticExpression operator /(DBSelectExpression a, DBSelectExpression b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);
        }
        public static DBArithmeticExpression operator %(DBSelectExpression a, DBSelectExpression b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);
        }
        #endregion

        #region select to value relational operators
        public static DBFilterExpression operator ==(DBSelectExpression a, string b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);
        }
        public static DBFilterExpression operator ==(DBSelectExpression a, decimal b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);
        }
        public static DBFilterExpression operator ==(DBSelectExpression a, double b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);
        }
        public static DBFilterExpression operator ==(DBSelectExpression a, int b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);
        }
        public static DBFilterExpression operator ==(DBSelectExpression a, long b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);
        }

        public static DBFilterExpression operator !=(DBSelectExpression a, string b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);
        }
        public static DBFilterExpression operator !=(DBSelectExpression a, decimal b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);
        }
        public static DBFilterExpression operator !=(DBSelectExpression a, double b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);
        }
        public static DBFilterExpression operator !=(DBSelectExpression a, int b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);
        }
        public static DBFilterExpression operator !=(DBSelectExpression a, long b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);
        }

        public static DBFilterExpression operator <(DBSelectExpression a, decimal b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);
        }
        public static DBFilterExpression operator <(DBSelectExpression a, double b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);
        }
        public static DBFilterExpression operator <(DBSelectExpression a, int b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);
        }
        public static DBFilterExpression operator <(DBSelectExpression a, long b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);
        }

        public static DBFilterExpression operator <=(DBSelectExpression a, decimal b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);
        }
        public static DBFilterExpression operator <=(DBSelectExpression a, double b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);
        }
        public static DBFilterExpression operator <=(DBSelectExpression a, int b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);
        }
        public static DBFilterExpression operator <=(DBSelectExpression a, long b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);
        }

        public static DBFilterExpression operator >(DBSelectExpression a, decimal b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);
        }
        public static DBFilterExpression operator >(DBSelectExpression a, double b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);
        }
        public static DBFilterExpression operator >(DBSelectExpression a, int b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);
        }
        public static DBFilterExpression operator >(DBSelectExpression a, long b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);
        }

        public static DBFilterExpression operator >=(DBSelectExpression a, decimal b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);
        }
        public static DBFilterExpression operator >=(DBSelectExpression a, double b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);
        }
        public static DBFilterExpression operator >=(DBSelectExpression a, int b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);
        }
        public static DBFilterExpression operator >=(DBSelectExpression a, long b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);
        }
        #endregion

        #region select to select relational operators
        public static DBFilterExpression operator ==(DBSelectExpression a, DBSelectExpression b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);
        }

        public static DBFilterExpression operator !=(DBSelectExpression a, DBSelectExpression b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);
        }

        public static DBFilterExpression operator <(DBSelectExpression a, DBSelectExpression b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);
        }

        public static DBFilterExpression operator <=(DBSelectExpression a, DBSelectExpression b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);
        }

        public static DBFilterExpression operator >(DBSelectExpression a, DBSelectExpression b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);
        }

        public static DBFilterExpression operator >=(DBSelectExpression a, DBSelectExpression b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);
        }
        #endregion

        #region logical & operator
        public static DBSelectExpressionSet operator &(DBSelectExpression a, DBSelectExpression b)
        {
            return new DBSelectExpressionSet(a, b);
        }
        #endregion

        #region implicit select expression set operator
        public static implicit operator DBSelectExpressionSet(DBSelectExpression a)
        {
            return new DBSelectExpressionSet(a);
        }
        #endregion

        #region implicit group by expression operator
        public static implicit operator DBGroupByExpression(DBSelectExpression a)
        {
            return new DBGroupByExpression(a);
        }
        #endregion

        #region equals
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        #endregion

        #region override get hash code
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
    #endregion

    #region select expression set
    public class DBSelectExpressionSet : DBExpression, IDBExpression
    {
        #region internals
        private List<DBSelectExpression> _selectItems;
        #endregion

        #region constructors
        internal DBSelectExpressionSet()
        {
            _selectItems = new List<DBSelectExpression>();
        }

        internal DBSelectExpressionSet(DBSelectExpression a)
        {
            _selectItems = new List<DBSelectExpression>();
            _selectItems.Add(a);
        }

        internal DBSelectExpressionSet(DBSelectExpression a, DBSelectExpression b)
        {
            _selectItems = new List<DBSelectExpression>();
            _selectItems.Add(a);
            _selectItems.Add(b);
        }
        #endregion

        #region to string
        public override string ToString()
        {
            return string.Join(", ", _selectItems.ConvertAll<string>(s => s.ToString()));
        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(List<DbParameter> parameters, SqlConnection dbService)
        {
            return string.Join(", ", _selectItems.ConvertAll<string>(s => s.ToParameterizedString(parameters, dbService)));
        }
        #endregion

        #region logical & operator
        public static DBSelectExpressionSet operator &(DBSelectExpressionSet aSet, DBSelectExpression b)
        {
            if (aSet == null)
            {
                aSet = new DBSelectExpressionSet(b);
            }
            else
            {
                aSet._selectItems.Add(b);
            }
            return aSet;
        }

        public static DBSelectExpressionSet operator &(DBSelectExpressionSet aSet, DBSelectExpressionSet bSet)
        {
            if (aSet == null)
            {
                aSet = new DBSelectExpressionSet();
            }
            aSet._selectItems.AddRange(bSet._selectItems);
            return aSet;
        }
        #endregion
    }
    #endregion

    #region aggregate function expression
    public class DBAggregateFunctionExpression : DBExpression, IDBExpression
    {
        #region internals
        private DBSelectExpression _select;
        private DBSelectExpressionAggregateFunction _aggregateFunction;
        private bool _distinct;
        #endregion

        #region interface
        #endregion

        #region constructors
        internal DBAggregateFunctionExpression(DBSelectExpression select, DBSelectExpressionAggregateFunction aggregateFunction, bool distinct = false)
        {
            _select = select;
            _aggregateFunction = aggregateFunction;
            _distinct = distinct;
        }
        #endregion

        #region as
        public DBSelectExpression As(string alias)
        {
            return new DBSelectExpression(this).As(alias);
        }
        #endregion

        #region to string
        public override string ToString()
        {
            string expression = null;
            expression =  _aggregateFunction + "(" + ((_distinct) ? " DISTINCT " : string.Empty) + _select.ToString() + ")";
            return expression;
        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(List<DbParameter> parameters, SqlConnection dbService)
        {
            string expression;
            expression = _aggregateFunction + "(" + ((_distinct) ? " DISTINCT " : string.Empty) + _select.ToParameterizedString(parameters, dbService) + ")";
            return expression;
        }
        #endregion

        #region implicit select operators
        public static implicit operator DBSelectExpression(DBAggregateFunctionExpression a)
        {
            return new DBSelectExpression(a);
        }
        #endregion
    }
    #endregion

    #region arithmetic expression
    public class DBArithmeticExpression : DBExpression, IDBExpression
    {
        #region internals
        private object _leftOperand;
        private object _rightOperand;
        private DBArithmeticExpressionOperator _arithmeticOperator;

        private string[] _operatorStrings = { " + ", " - ", " * ", " / ", " % " };
        #endregion

        #region interface
        #endregion

        #region constructors
        internal DBArithmeticExpression(object leftOperand, object rightOperand, DBArithmeticExpressionOperator arithmeticOperator)
        {
            _leftOperand = leftOperand;
            _rightOperand = rightOperand;
            _arithmeticOperator = arithmeticOperator;
        }
        #endregion

        #region aggregate functions
        public DBSelectExpression Avg(bool distinct = false)
        {
            return new DBAggregateFunctionExpression(this, DBSelectExpressionAggregateFunction.AVG, distinct);
        }

        public DBSelectExpression Min(bool distinct = false)
        {
            return new DBAggregateFunctionExpression(this, DBSelectExpressionAggregateFunction.MIN, distinct);
        }

        public DBSelectExpression Max(bool distinct = false)
        {
            return new DBAggregateFunctionExpression(this, DBSelectExpressionAggregateFunction.MAX, distinct);
        }

        public DBSelectExpression Sum(bool distinct = false)
        {
            return new DBAggregateFunctionExpression(this, DBSelectExpressionAggregateFunction.SUM, distinct);
        }

        public DBSelectExpression Count(bool distinct = false)
        {
            return new DBAggregateFunctionExpression(this, DBSelectExpressionAggregateFunction.COUNT, distinct);
        }
        #endregion

        #region to string
        public override string ToString()
        {
            string expression = null;
            expression =  "(" + this.FormatOperand(_leftOperand) + _operatorStrings[(int)_arithmeticOperator] + this.FormatOperand(_rightOperand) + ")";
            //return (_alias != null) ? expression + " AS " + _alias : expression;
            return expression;
        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(List<DbParameter> parameters, SqlConnection dbService)
        {
            string expression = null;
            string left = null;
            string right  = null;

            if (_leftOperand is string)
            {
                string paramName = "@AR" + (parameters.Count + 1);
                left = paramName;
                parameters.Add(dbService.GetDbParameter(paramName, _leftOperand, _leftOperand.GetType()));
            }
            else if (_leftOperand is IDBExpression)
            {
                left = (_leftOperand as IDBExpression).ToParameterizedString(parameters, dbService);
            }
            else if (_leftOperand is DBExpressionField)
            {
                left = _leftOperand.ToString();
            }
            else
            {
                left = _leftOperand.ToString();
            }


            if (_rightOperand is string)
            {
                string paramName = "@AR" + (parameters.Count + 1);
                right = paramName;
                parameters.Add(dbService.GetDbParameter(paramName, _rightOperand, _rightOperand.GetType()));
            }
            else if (_rightOperand is IDBExpression)
            {
                right = (_rightOperand as IDBExpression).ToParameterizedString(parameters, dbService);
            }
            else if ((_rightOperand is DBExpressionField))
            {
                right = _rightOperand.ToString();
            }
            else
            {
                right = _rightOperand.ToString();
            }

            expression = "(" + left + _operatorStrings[(int)_arithmeticOperator] + right + ")";

            return expression;
        }
        #endregion

        #region format operand
        private string FormatOperand(object operand)
        {
            if (operand is string)
            {
                return "'" + ((string)operand).Replace("'", "''") + "'";
            }
            else
            {
                return operand.ToString();
            }
        }
        #endregion

        #region as
        public DBSelectExpression As(string alias)
        {
            return new DBSelectExpression(this).As(alias);
        }
        #endregion

        #region implicit select expression operator
        public static implicit operator DBSelectExpression(DBArithmeticExpression a)
        {
            return new DBSelectExpression(a);
        }
        #endregion

        #region implicit group by expression operator
        public static implicit operator DBGroupByExpression(DBArithmeticExpression a)
        {
            return new DBGroupByExpression(a);
        }
        #endregion

        #region arithmetic expression to value operators arithmetic operators
        public static DBArithmeticExpression operator +(DBArithmeticExpression a, string b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);
        }
        public static DBArithmeticExpression operator +(DBArithmeticExpression a, decimal b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);
        }
        public static DBArithmeticExpression operator +(DBArithmeticExpression a, double b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);
        }
        public static DBArithmeticExpression operator +(DBArithmeticExpression a, int b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);
        }
        public static DBArithmeticExpression operator +(DBArithmeticExpression a, long b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);
        }

        public static DBArithmeticExpression operator -(DBArithmeticExpression a, decimal b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);
        }
        public static DBArithmeticExpression operator -(DBArithmeticExpression a, double b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);
        }
        public static DBArithmeticExpression operator -(DBArithmeticExpression a, int b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);
        }
        public static DBArithmeticExpression operator -(DBArithmeticExpression a, long b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);
        }

        public static DBArithmeticExpression operator *(DBArithmeticExpression a, decimal b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);
        }
        public static DBArithmeticExpression operator *(DBArithmeticExpression a, double b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);
        }
        public static DBArithmeticExpression operator *(DBArithmeticExpression a, int b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);
        }
        public static DBArithmeticExpression operator *(DBArithmeticExpression a, long b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);
        }

        public static DBArithmeticExpression operator /(DBArithmeticExpression a, decimal b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);
        }
        public static DBArithmeticExpression operator /(DBArithmeticExpression a, double b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);
        }
        public static DBArithmeticExpression operator /(DBArithmeticExpression a, int b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);
        }
        public static DBArithmeticExpression operator /(DBArithmeticExpression a, long b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);
        }

        public static DBArithmeticExpression operator %(DBArithmeticExpression a, decimal b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);
        }
        public static DBArithmeticExpression operator %(DBArithmeticExpression a, double b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);
        }
        public static DBArithmeticExpression operator %(DBArithmeticExpression a, int b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);
        }
        public static DBArithmeticExpression operator %(DBArithmeticExpression a, long b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);
        }
        #endregion

        #region arithmetic expression to expression relational operators
        public static DBFilterExpression operator ==(DBArithmeticExpression a, DBExpression b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);
        }

        public static DBFilterExpression operator !=(DBArithmeticExpression a, DBExpression b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);
        }

        public static DBFilterExpression operator <(DBArithmeticExpression a, DBExpression b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);
        }

        public static DBFilterExpression operator <=(DBArithmeticExpression a, DBExpression b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);
        }

        public static DBFilterExpression operator >(DBArithmeticExpression a, DBExpression b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);
        }

        public static DBFilterExpression operator >=(DBArithmeticExpression a, DBExpression b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);
        }
        #endregion

        #region arithmetic to value relational operators
        public static DBFilterExpression operator ==(DBArithmeticExpression a, string b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);
        }
        public static DBFilterExpression operator ==(DBArithmeticExpression a, decimal b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);
        }
        public static DBFilterExpression operator ==(DBArithmeticExpression a, double b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);
        }
        public static DBFilterExpression operator ==(DBArithmeticExpression a, int b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);
        }
        public static DBFilterExpression operator ==(DBArithmeticExpression a, long b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);
        }

        public static DBFilterExpression operator !=(DBArithmeticExpression a, string b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);
        }
        public static DBFilterExpression operator !=(DBArithmeticExpression a, decimal b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);
        }
        public static DBFilterExpression operator !=(DBArithmeticExpression a, double b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);
        }
        public static DBFilterExpression operator !=(DBArithmeticExpression a, int b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);
        }
        public static DBFilterExpression operator !=(DBArithmeticExpression a, long b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);
        }

        public static DBFilterExpression operator <(DBArithmeticExpression a, decimal b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);
        }
        public static DBFilterExpression operator <(DBArithmeticExpression a, double b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);
        }
        public static DBFilterExpression operator <(DBArithmeticExpression a, int b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);
        }
        public static DBFilterExpression operator <(DBArithmeticExpression a, long b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);
        }

        public static DBFilterExpression operator <=(DBArithmeticExpression a, decimal b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);
        }
        public static DBFilterExpression operator <=(DBArithmeticExpression a, double b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);
        }
        public static DBFilterExpression operator <=(DBArithmeticExpression a, int b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);
        }
        public static DBFilterExpression operator <=(DBArithmeticExpression a, long b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);
        }

        public static DBFilterExpression operator >(DBArithmeticExpression a, decimal b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);
        }
        public static DBFilterExpression operator >(DBArithmeticExpression a, double b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);
        }
        public static DBFilterExpression operator >(DBArithmeticExpression a, int b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);
        }
        public static DBFilterExpression operator >(DBArithmeticExpression a, long b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);
        }

        public static DBFilterExpression operator >=(DBArithmeticExpression a, decimal b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);
        }
        public static DBFilterExpression operator >=(DBArithmeticExpression a, double b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);
        }
        public static DBFilterExpression operator >=(DBArithmeticExpression a, int b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);
        }
        public static DBFilterExpression operator >=(DBArithmeticExpression a, long b)
        {
            return new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);
        }
        #endregion

        #region arithmetic expression to arithmetic expression operators
        public static DBArithmeticExpression operator +(DBArithmeticExpression a, DBArithmeticExpression b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);
        }
        public static DBArithmeticExpression operator -(DBArithmeticExpression a, DBArithmeticExpression b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);
        }
        public static DBArithmeticExpression operator *(DBArithmeticExpression a, DBArithmeticExpression b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);
        }
        public static DBArithmeticExpression operator /(DBArithmeticExpression a, DBArithmeticExpression b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);
        }
        public static DBArithmeticExpression operator %(DBArithmeticExpression a, DBArithmeticExpression b)
        {
            return new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);
        }
        #endregion

        #region equals
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        #endregion

        #region override get hash code
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
    #endregion

    #region assignment expresssion
    public class DBAssignmentExpression : DBExpression, IDBExpression
    {
        #region internals
        private DBExpressionField _field;
        private object _value;
        #endregion

        #region interface
        public DBExpressionField Field
        { get; private set; }

        public object Value
        { get; private set; }
        #endregion

        #region constructors
        internal DBAssignmentExpression(DBExpressionField field, object value)
        {
            _field = field;
            _value = value;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            return _field.ToString() + " = " + this.FormatArgument(_value);
        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(List<DbParameter> parameters, SqlConnection dbService)
        {
            string expression = null;
            if (_value is IDBExpression)
            {
                expression = _field.ToString() + " = " + (_value as IDBExpression).ToParameterizedString(parameters, dbService);
            }
            else if (_value is DBExpressionField)
            {
                expression = _field.ToString() + " = " + _value.ToString();
            }
            else
            {
                string paramName = "@A" + (parameters.Count + 1);
                expression = _field.ToString() + " = " + paramName;
                if (_value == null)
                {
                    parameters.Add(dbService.GetDbParameter(paramName, _value));
                }
                else
                {
                    parameters.Add(dbService.GetDbParameter(paramName, _value, _value.GetType(), _field.Size));
                }
            }
            return expression;
        }
        #endregion

        #region format argument
        private string FormatArgument(object argument)
        {
            if (argument is string)
            {
                return (argument == null) ? "NULL" : ("'" + ((string)argument).Replace("'", "''") + "'");
            }
            if (argument is DateTime || argument is Guid)
            {
                return "'" + argument + "'";
            }
            else if (argument != null)
            {
                return argument.ToString();
            }

            return "NULL";
        }
        #endregion

        #region logical & operator
        public static DBAssignmentExpressionSet operator &(DBAssignmentExpression a, DBAssignmentExpression b)
        {
            return new DBAssignmentExpressionSet(a, b);
        }
        #endregion

        #region implicit assignment expression set operator
        public static implicit operator DBAssignmentExpressionSet(DBAssignmentExpression a)
        {
            return new DBAssignmentExpressionSet(a);
        }
        #endregion
    }
    #endregion

    #region assignment expression set
    public class DBAssignmentExpressionSet : DBExpression, IDBExpression
    {
        #region internals
        private List<DBAssignmentExpression> _assignments;
        #endregion

        #region constructors
        internal DBAssignmentExpressionSet()
        {
            _assignments = new List<DBAssignmentExpression>();
        }

        internal DBAssignmentExpressionSet(DBAssignmentExpression a1)
        {
            _assignments = new List<DBAssignmentExpression>();
            _assignments.Add(a1);
        }

        internal DBAssignmentExpressionSet(DBAssignmentExpression a1, DBAssignmentExpression a2)
        {
            _assignments = new List<DBAssignmentExpression>();
            _assignments.Add(a1);
            _assignments.Add(a2);
        }
        #endregion

        #region to string
        public override string ToString()
        {
            return string.Join(", ", _assignments.ConvertAll<string>(a => a.ToString()));
        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(List<DbParameter> parameters, SqlConnection dbService)
        {
            return string.Join(", ", _assignments.ConvertAll<string>(a => a.ToParameterizedString(parameters, dbService)));
        }
        #endregion

        #region logical & operator
        public static DBAssignmentExpressionSet operator &(DBAssignmentExpressionSet aSet, DBAssignmentExpression b)
        {
            if (aSet == null)
            {
                aSet = new DBAssignmentExpressionSet(b);
            }
            else
            {
                aSet._assignments.Add(b);
            }
            return aSet;
        }

        public static DBAssignmentExpressionSet operator &(DBAssignmentExpressionSet aSet, DBAssignmentExpressionSet bSet)
        {
            if (aSet == null)
            {
                aSet = new DBAssignmentExpressionSet();
            }
            aSet._assignments.AddRange(bSet._assignments);
            return aSet;
        }
        #endregion
    }
    #endregion

    #region filter expression
    public class DBFilterExpression : DBExpression, IDBExpression
    {
        #region interface
        private object _leftArg;
        private object _rightArg;
        private DBFilterExpressionOperator _expressionOperator;
        private bool _negate;

        //TODO: JRod, remove this and cache some static based on enum attributes to avoid out of sync issues moving forward...
        private static string[] _operatorStrings = new string[] { " = ", " <> ", " < ", " <= ", " > ", " >= ", " LIKE ", " IN " };
        #endregion

        #region constructors
        internal DBFilterExpression(object leftArg, object rightArg, DBFilterExpressionOperator expressionOperator)
        {
            _leftArg = leftArg;
            _rightArg = rightArg;
            _expressionOperator = expressionOperator;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            string expression = null;
            if (_rightArg != null)
            {
                expression = (this.FormatArgument(_leftArg) + _operatorStrings[(int)_expressionOperator] + this.FormatArgument(_rightArg));
            }
            else
            {
                switch (_expressionOperator)
                {
                    case DBFilterExpressionOperator.Equal:
                        expression = this.FormatArgument(_leftArg) + " IS NULL";
                        break;
                    case DBFilterExpressionOperator.NotEqual:
                        expression = this.FormatArgument(_leftArg) + " IS NOT NULL";
                        break;
                    default:
                        throw new ArgumentException("Operator " + _expressionOperator + " invalid with null arguments");
                }
            }

            if (expression == null) { expression = "0=0"; }

            return (_negate) ? (" NOT (" + expression + ")") : expression;
        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(List<DbParameter> parameters, SqlConnection dbService)
        {
            string expression = null;
            if (_rightArg != null)
            {
                if (_rightArg is DBExpression || _rightArg is DBExpressionField)
                {
                    expression = (this.FormatArgument(_leftArg) + _operatorStrings[(int)_expressionOperator] + this.FormatArgument(_rightArg));
                }
                else
                {
                    if (_expressionOperator == DBFilterExpressionOperator.In)
                    {
                        //TODO: JRod, consider making each item within the in array an individual parameter...
                        expression = _leftArg + " " + _operatorStrings[(int)_expressionOperator] + " " + this.FormatArgument(_rightArg);
                    }
                    else
                    {
                        string paramName = "@F" + (parameters.Count + 1);
                        expression = this.FormatArgument(_leftArg) + _operatorStrings[(int)_expressionOperator] + paramName;
                        parameters.Add(dbService.GetDbParameter(paramName, _rightArg, _rightArg.GetType()));
                    }
                }
            }
            else
            {
                expression = this.ToString();
            }

            if (expression == null) { expression = "0=0"; }

            return (_negate) ? (" NOT (" + expression + ")") : expression;
        }
        #endregion

        #region format argument
        private string FormatArgument(object argument) //TODO: JRod, optimize this...
        {
            if (argument is DBExpressionField)
            {
                return argument.ToString();
            }
            if (argument is DBExpression)
            {
                return argument.ToString();
            }
            if (argument is Enum)
            {
                return Convert.ToInt32(argument).ToString();
            }
            if (argument is DateTime || argument is Guid)
            {
                return "'" + argument + "'";
            }
            if (argument is string)
            {
                return "'" + ((string)argument).Replace("'", "''") + "'";
            }
            else if (argument is Array)
            {
                if ((argument as Array).Length == 0)
                {
                    return "(NULL)";
                }
                List<string> arguments = new List<string>();
                if ((argument is string[]) || (argument is DateTime[]) || (argument is Guid[]))
                {
                    foreach (object o in (Array)argument)
                    {
                        arguments.Add(FormatArgument((string)o));
                    }
                }
                else
                {
                    foreach (object o in (Array)argument)
                    {
                        arguments.Add(FormatArgument(o));
                    }
                }
                return "(" + string.Join(",", arguments.ToArray()) + ")";
            }
            else if (argument != null)
            {
                return argument.ToString();
            }

            return "NULL";
        }
        #endregion

        #region conditional &, | operators
        public static DBFilterExpressionSet operator &(DBFilterExpression a, DBFilterExpression b)
        {
            if (a == null && b != null) { return new DBFilterExpressionSet(b); }
            if (a != null && b == null) { return new DBFilterExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new DBFilterExpressionSet(a, b, DBConditionalExpressionOperator.And);
        }

        public static DBFilterExpressionSet operator |(DBFilterExpression a, DBFilterExpression b)
        {
            if (a == null && b != null) { return new DBFilterExpressionSet(b); }
            if (a != null && b == null) { return new DBFilterExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new DBFilterExpressionSet(a, b, DBConditionalExpressionOperator.Or);
        }
        #endregion

        #region implicit filter expression set operator
        public static implicit operator DBFilterExpressionSet(DBFilterExpression a)
        {
            return new DBFilterExpressionSet(a);
        }
        #endregion

        #region implicit having expression set operator
        public static implicit operator DBHavingExpression(DBFilterExpression a)
        {
            return new DBHavingExpression(a);
        }
        #endregion

        #region negation operator
        public static DBFilterExpression operator !(DBFilterExpression filter)
        {
            if (filter != null) filter._negate = !filter._negate;
            return filter;
        }
        #endregion
    }
    #endregion

    #region filter expression set
    public class DBFilterExpressionSet : DBExpression, IDBExpression
    {
        #region interface
        private object _leftArg;
        private object _rightArg;
        private DBConditionalExpressionOperator _conditinalOperator;
        private bool _negate;
        #endregion

        #region constructors
        internal DBFilterExpressionSet(DBFilterExpression singleFilter)
        {
            this._rightArg = singleFilter;
        }

        internal DBFilterExpressionSet(DBFilterExpression leftArg, DBFilterExpression rightArg, DBConditionalExpressionOperator conditinalOperator)
        {
            _leftArg = leftArg;
            _rightArg = rightArg;
            _conditinalOperator = conditinalOperator;
        }

        internal DBFilterExpressionSet(DBFilterExpressionSet leftArg, DBFilterExpression rightArg, DBConditionalExpressionOperator conditinalOperator)
        {
            _leftArg = leftArg;
            _rightArg = rightArg;
            _conditinalOperator = conditinalOperator;
        }

        internal DBFilterExpressionSet(DBFilterExpressionSet leftArg, DBFilterExpressionSet rightArg, DBConditionalExpressionOperator conditinalOperator)
        {
            _leftArg = leftArg;
            _rightArg = rightArg;
            _conditinalOperator = conditinalOperator;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            string left = (_leftArg == null) ? string.Empty : _leftArg.ToString();
            string right = _rightArg.ToString();
            string expression = null;

            if (_leftArg != null)
            {
                if (_conditinalOperator == DBConditionalExpressionOperator.And)
                {
                    if (left != null)
                    {
                        expression = "(" + left + " AND " + right + ")";
                    }
                    else
                    {
                        expression = right;
                    }
                }
                else if (_conditinalOperator == DBConditionalExpressionOperator.Or)
                {
                    expression = "(" + left + " OR " + right + ")";
                }
            }
            else
            {
                expression = right;
            }
            return (_negate) ? ("NOT (" + expression + ")") : expression;
        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(List<DbParameter> parameters, SqlConnection dbService)
        {
            string left = (_leftArg == null) ? string.Empty : (_leftArg as IDBExpression).ToParameterizedString(parameters, dbService);
            string right = (_rightArg as IDBExpression).ToParameterizedString(parameters, dbService);

            string expression = null;
            if (_leftArg != null)
            {
                if (_conditinalOperator == DBConditionalExpressionOperator.And)
                {
                    if (left != null)
                    {
                        expression = "(" + left + " AND " + right + ")";
                    }
                    else
                    {
                        expression = right;
                    }
                }
                else if (_conditinalOperator == DBConditionalExpressionOperator.Or)
                {
                    expression = "(" + left + " OR " + right + ")";
                }
            }
            else
            {
                expression = right;
            }
            return (_negate) ? ("NOT (" + expression + ")") : expression;
        }
        #endregion

        #region conditional &, | operators
        public static DBFilterExpressionSet operator &(DBFilterExpressionSet a, DBFilterExpression b)
        {
            if (a == null && b != null) { return new DBFilterExpressionSet(b); }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new DBFilterExpressionSet(a, b, DBConditionalExpressionOperator.And);
        }

        public static DBFilterExpressionSet operator &(DBFilterExpressionSet a, DBFilterExpressionSet b)
        {
            if (a == null && b != null) { return b; }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new DBFilterExpressionSet(a, b, DBConditionalExpressionOperator.And);
        }

        public static DBFilterExpressionSet operator |(DBFilterExpressionSet a, DBFilterExpression b)
        {
            if (a == null && b != null) { return new DBFilterExpressionSet(b); }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new DBFilterExpressionSet(a, b, DBConditionalExpressionOperator.Or);
        }

        public static DBFilterExpressionSet operator |(DBFilterExpressionSet a, DBFilterExpressionSet b)
        {
            if (a == null && b != null) { return b; }
            if (a != null && b == null) { return a; }
            if (a == null && b == null) { return null; }

            return new DBFilterExpressionSet(a, b, DBConditionalExpressionOperator.Or);
        }
        #endregion

        #region implicit having expression set operator
        public static implicit operator DBHavingExpression(DBFilterExpressionSet a)
        {
            return new DBHavingExpression(a);
        }
        #endregion

        #region negation operator
        public static DBFilterExpressionSet operator !(DBFilterExpressionSet filter)
        {
            if (filter != null) filter._negate = !filter._negate;
            return filter;
        }
        #endregion
    }
    #endregion

    #region order by expresssion
    public class DBOrderByExpression : DBExpression, IDBExpression
    {
        #region interface
        private object _orderExpression;
        private DBOrderExpressionDirection _direction;
        #endregion

        #region constructors
        internal DBOrderByExpression(DBExpressionField field, DBOrderExpressionDirection direction)
        {
            _orderExpression = field;
            _direction = direction;
        }

        internal DBOrderByExpression(DBExpression expression, DBOrderExpressionDirection direction)
        {
            _orderExpression = expression;
            _direction = direction;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            return _orderExpression.ToString() + " " + _direction;
        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(List<DbParameter> parameters, SqlConnection dbService)
        {
            string expression = null;
            if (_orderExpression is DBExpression)
            {
                expression = (_orderExpression as IDBExpression).ToParameterizedString(parameters, dbService) + " " + _direction;
            }
            else
            {
                expression = this.ToString();
            }
            return expression;
        }
        #endregion

        #region conditional & operator
        public static DBOrderByExpressionSet operator &(DBOrderByExpression a, DBOrderByExpression b)
        {
            return new DBOrderByExpressionSet(a, b);
        }
        #endregion

        #region implicit order by expression set operator
        public static implicit operator DBOrderByExpressionSet(DBOrderByExpression a)
        {
            return new DBOrderByExpressionSet(a);
        }
        #endregion
    }
    #endregion

    #region order by expression set
    public class DBOrderByExpressionSet : DBExpression, IDBExpression
    {
        #region internals
        private List<DBOrderByExpression> _orderBys;
        #endregion

        #region constructors
        internal DBOrderByExpressionSet(DBOrderByExpression a)
        {
            _orderBys = new List<DBOrderByExpression>();
            _orderBys.Add(a);
        }

        internal DBOrderByExpressionSet(DBOrderByExpression a, DBOrderByExpression b)
        {
            _orderBys = new List<DBOrderByExpression>();
            _orderBys.Add(a);
            _orderBys.Add(b);
        }
        #endregion

        #region to string
        public override string ToString()
        {
            return string.Join(", ", _orderBys.ConvertAll<string>(o => o.ToString()));
        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(List<DbParameter> parameters, SqlConnection dbService)
        {
            return string.Join(", ", _orderBys.ConvertAll<string>(o => o.ToParameterizedString(parameters, dbService)));
        }
        #endregion

        #region condition & operators
        public static DBOrderByExpressionSet operator &(DBOrderByExpressionSet aSet, DBOrderByExpression b)
        {
            aSet._orderBys.Add(b);
            return aSet;
        }

        public static DBOrderByExpressionSet operator &(DBOrderByExpressionSet aSet, DBOrderByExpressionSet bSet)
        {
            aSet._orderBys.AddRange(bSet._orderBys);
            return aSet;
        }
        #endregion
    }
    #endregion

    #region join expresssion
    public class DBJoinExpression : DBExpression, IDBExpression
    {
        #region internals
        private DBExpressionEntity _entity;
        private DBFilterExpression _onCondition;
        private DBExpressionJoinType _joinType;
        #endregion

        #region constructors
        public DBJoinExpression(DBExpressionEntity entity, DBExpressionJoinType joinType, DBFilterExpression onCondition)
        {
            _entity = entity;
            _joinType = joinType;
            _onCondition = onCondition;
        }
        #endregion

        #region on
        public DBJoinExpression On(DBFilterExpression filter)
        {
            _onCondition = filter;
            return this;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            string expression; 
           
            if (_joinType == DBExpressionJoinType.CROSS)
            {
                expression = _joinType + " JOIN " + _entity.ToString();
            }
            else
            {
                expression = _joinType + " JOIN " + _entity.ToString() + " ON " + _onCondition.ToString();
            }
            return expression;
        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(List<DbParameter> parameters, SqlConnection dbService)
        {
            string expression = null;
            if (_joinType == DBExpressionJoinType.CROSS)
            {
                expression = string.Concat("CROSS JOIN ", _entity.ToString());
            }
            else
            {
                expression = string.Concat(_joinType, " JOIN ", _entity.ToString(), " ON ", _onCondition.ToParameterizedString(parameters, dbService));
            }
            return expression;
        }
        #endregion

        #region logical & operator
        public static DBJoinExpressionSet operator &(DBJoinExpression a, DBJoinExpression b)
        {
            if (a == null && b != null) { return new DBJoinExpressionSet(b); }
            if (a != null && b == null) { return new DBJoinExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new DBJoinExpressionSet(a, b);
        }
        #endregion
    }
    #endregion

    #region join expression set
    public class DBJoinExpressionSet : DBExpression, IDBExpression
    {
        #region internals
        private List<DBJoinExpression> _joins;
        #endregion

        #region constructors
        public DBJoinExpressionSet(DBJoinExpression a)
        {
            _joins = new List<DBJoinExpression>();
            _joins.Add(a);
        }

        public DBJoinExpressionSet(DBJoinExpression a, DBJoinExpression b)
        {
            _joins = new List<DBJoinExpression>();
            _joins.Add(a);
            _joins.Add(b);
        }
        #endregion

        #region to string
        public override string ToString()
        {
            return string.Join(Environment.NewLine, _joins.ConvertAll<string>(j => j.ToString()));
        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(List<DbParameter> parameters, SqlConnection dbService)
        {
            return string.Join(Environment.NewLine, _joins.ConvertAll<string>(j => j.ToParameterizedString(parameters, dbService)));
        }
        #endregion

        #region logical & operator
        public static DBJoinExpressionSet operator &(DBJoinExpressionSet aSet, DBJoinExpression b)
        {
            aSet._joins.Add(b);
            return aSet;
        }

        public static DBJoinExpressionSet operator &(DBJoinExpressionSet aSet, DBJoinExpressionSet bSet)
        {
            aSet._joins.AddRange(bSet._joins);
            return aSet;
        }
        #endregion
    }
    #endregion

    #region group by expression
    public class DBGroupByExpression : DBExpression, IDBExpression
    {
        #region internals
        private DBExpression _groupingExpression;
        #endregion

        #region interface
        #endregion

        #region constructors
        internal DBGroupByExpression(DBExpressionField field)
        {
            _groupingExpression = field;
        }

        internal DBGroupByExpression(DBSelectExpression expression)
        {
            _groupingExpression = expression;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            return _groupingExpression.ToString();
        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(List<DbParameter> parameters, SqlConnection dbService)
        {
            //TODO: JRod, cast once using 'as' 
            string expression = null;
            if (_groupingExpression is IDBExpression)
            {
                expression = (_groupingExpression as IDBExpression).ToParameterizedString(parameters, dbService);
            }
            else
            {
                expression = _groupingExpression.ToString();
            }
            return expression;
        }
        #endregion

        #region conditional & operator
        public static DBGroupByExpressionSet operator &(DBGroupByExpression a, DBGroupByExpression b)
        {
            return new DBGroupByExpressionSet(a, b);
        }
        #endregion

        #region implicit group by expression set operator
        public static implicit operator DBGroupByExpressionSet(DBGroupByExpression a)
        {
            return new DBGroupByExpressionSet(a);
        }
        #endregion
    }
    #endregion

    #region group by expression set
    public class DBGroupByExpressionSet : DBExpression, IDBExpression
    {
        #region internals
        private List<DBGroupByExpression> _groupings;
        #endregion

        #region constructors
        internal DBGroupByExpressionSet(DBGroupByExpression a)
        {
            _groupings = new List<DBGroupByExpression>();
            _groupings.Add(a);
        }

        internal DBGroupByExpressionSet(DBGroupByExpression a, DBGroupByExpression b)
        {
            _groupings = new List<DBGroupByExpression>();
            _groupings.Add(a);
            _groupings.Add(b);
        }
        #endregion

        #region to string
        public override string ToString()
        {
            return string.Join(", ", _groupings.ConvertAll<string>(g => g.ToString()));
        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(List<DbParameter> parameters, SqlConnection dbService)
        {
            string expression = null;
            expression = string.Join(", ", _groupings.ConvertAll<string>(g => g.ToParameterizedString(parameters, dbService)));
            return expression;
        }
        #endregion

        #region conditional & operator
        public static DBGroupByExpressionSet operator &(DBGroupByExpressionSet aSet, DBGroupByExpression b)
        {
            aSet._groupings.Add(b);
            return aSet;
        }

        public static DBGroupByExpressionSet operator &(DBGroupByExpressionSet aSet, DBGroupByExpressionSet bSet)
        {
            aSet._groupings.AddRange(bSet._groupings);
            return aSet;
        }
        #endregion
    }
    #endregion

    #region having expression
    public class DBHavingExpression : DBExpression, IDBExpression
    {
        #region internals
        private DBFilterExpressionSet _havingCondition;
        #endregion

        #region constructors
        internal DBHavingExpression(DBFilterExpression havingCondition)
        {
            _havingCondition = new DBFilterExpressionSet(havingCondition);

        }

        public DBHavingExpression(DBFilterExpressionSet havingCondition)
        {
            _havingCondition = havingCondition;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            return _havingCondition.ToString();
        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(List<DbParameter> parameters, SqlConnection dbService)
        {
            string expression = _havingCondition.ToParameterizedString(parameters, dbService);
            return expression;
        }
        #endregion

        #region conditional & operator
        public static DBHavingExpression operator &(DBHavingExpression a, DBHavingExpression b)
        {
            a._havingCondition &= b._havingCondition;
            return a;
        }
        #endregion
    }
    #endregion

    #region expression set
    public class DBExpressionSet
    {
        #region interface
        public DBSelectExpressionSet Select
        { get; private set; }

        public DBInsertExpressionSet Insert
        { get; private set; }

        public DBAssignmentExpressionSet Assign
        { get; private set; }

        public DBFilterExpressionSet Where
        { get; private set; }

        public DBJoinExpressionSet Joins
        { get; private set; }

        public DBOrderByExpressionSet OrderBy
        { get; private set; }

        public DBGroupByExpressionSet GroupBy
        { get; private set; }

        public DBHavingExpression Having
        { get; private set; }
        #endregion

        #region operators
        public static DBExpressionSet operator &(DBExpressionSet set, DBSelectExpression selectExpression)
        {
            if (set != null)
            {
                if (set.Select == null)
                { set.Select = new DBSelectExpressionSet(selectExpression); }
                else
                { set.Select &= selectExpression; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBSelectExpressionSet selectExpressionSet)
        {
            if (set != null)
            {
                if (set.Select == null)
                { set.Select = selectExpressionSet; }
                else
                { set.Select &= selectExpressionSet; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBInsertExpression insertExpression)
        {
            if (set != null)
            {
                if (set.Insert == null)
                { set.Insert = new DBInsertExpressionSet(insertExpression); }
                else
                { set.Insert &= insertExpression; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBInsertExpressionSet insertExpressionSet)
        {
            if (set != null)
            {
                if (set.Insert == null)
                { set.Insert = insertExpressionSet; }
                else
                { set.Insert &= insertExpressionSet; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBAssignmentExpression assignmentExpression)
        {
            if (set != null)
            {
                if (set.Assign == null)
                { set.Assign = new DBAssignmentExpressionSet(assignmentExpression); }
                else
                { set.Assign &= assignmentExpression; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBAssignmentExpressionSet assignmentExpressionSet)
        {
            if (set != null)
            {
                if (set.Assign == null)
                { set.Assign = assignmentExpressionSet; }
                else
                { set.Assign &= assignmentExpressionSet; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBJoinExpression joinExpression)
        {
            if (set != null)
            {
                if (set.Joins == null)
                { set.Joins = new DBJoinExpressionSet(joinExpression); }
                else
                { set.Joins &= joinExpression; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBFilterExpression filterExpression)
        {
            if (set != null)
            {
                if (set.Where == null)
                { set.Where = new DBFilterExpressionSet(filterExpression); }
                else
                { set.Where &= filterExpression; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBFilterExpressionSet filterExpressionSet)
        {
            if (set != null)
            {
                if (set.Where == null)
                { set.Where = filterExpressionSet; }
                else
                { set.Where &= filterExpressionSet; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBOrderByExpression orderByExpression)
        {
            if (set != null)
            {
                if (set.OrderBy == null)
                { set.OrderBy = new DBOrderByExpressionSet(orderByExpression); }
                else
                { set.OrderBy &= orderByExpression; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBOrderByExpressionSet orderByExpressionSet)
        {
            if (set != null)
            {
                if (set.OrderBy == null)
                { set.OrderBy = orderByExpressionSet; }
                else
                { set.OrderBy &= orderByExpressionSet; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBGroupByExpression groupByExpression)
        {
            if (set != null)
            {
                if (set.GroupBy == null)
                { set.GroupBy = new DBGroupByExpressionSet(groupByExpression); }
                else
                { set.GroupBy &= groupByExpression; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBGroupByExpressionSet groupByExpressionSet)
        {
            if (set != null)
            {
                if (set.GroupBy == null)
                { set.GroupBy = groupByExpressionSet; }
                else
                { set.GroupBy &= groupByExpressionSet; }
            }
            return set;
        }

        public static DBExpressionSet operator &(DBExpressionSet set, DBHavingExpression havingCondition)
        {
            if (set != null)
            {
                if (set.Having == null)
                { set.Having = havingCondition; }
                else
                { set.Having &= havingCondition; }
            }
            return set;
        }
        #endregion

        #region clear selects
        public void ClearSelect()
        {
            this.Select = null;
        }
        #endregion
    }
    #endregion 
}