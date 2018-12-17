using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class FieldExpression : 
        IDbExpression,
        IDbExpressionColumnExpression, 
        IAssemblyPart,
        IExpressionMetadataProvider<FieldExpressionMetadata>
    {
        #region internals
        protected FieldExpressionMetadata Metadata { get; private set; }
        protected string Alias { get; private set; }
        #endregion

        #region interface

        public OrderByExpression Asc => new OrderByExpression(this, OrderExpressionDirection.ASC);

        public OrderByExpression Desc => new OrderByExpression(this, OrderExpressionDirection.DESC);

        FieldExpressionMetadata IExpressionMetadataProvider<FieldExpressionMetadata>.Metadata => Metadata;

        #endregion

        #region constructors
        protected FieldExpression(FieldExpressionMetadata metadata) : this(metadata, null)
        {
        }

        protected FieldExpression(FieldExpressionMetadata metadata, string alias)
        {
            this.Metadata = metadata;
            Alias = alias;
        }
        #endregion

        #region to string
        public override string ToString() => $"{this.Metadata.ParentEntity.ToString()}.[{this.Metadata.Name}]";

        public string ToString(string format)
        {
            switch (format)
            {
                case "f":
                    return this.Metadata.Name;
                case "[f]":
                    return $"[{this.Metadata.Name}]";
                case "e.f":
                    return this.ToString();
                case "s.e.f":
                    return $"{this.Metadata.ParentEntity.ToString("s.e")}.{this.Metadata.Name}";
                case "[s].[e].[f]":
                    return $"{this.Metadata.ParentEntity.ToString("[s].[e]")}.[{this.Metadata.Name}]";
                case "[s.e.f]":
                    return $"[{this.Metadata.ParentEntity.ToString("s.e")}.{this.Metadata.Name}]";
                default:
                    throw new ArgumentException($"encountered unknown format string: {format} valid formats are 'e','f','[e]','[f]','e.f','[e].[f]'", "format");
            }
        }
        #endregion

        #region like
        public FilterExpression Like(string phrase) => new FilterExpression(this, phrase, FilterExpressionOperator.Like);
        #endregion

        #region set field
        public AssignmentExpression Set(IDbExpression expression) => new AssignmentExpression(this, expression);
        #endregion

        #region implicit select operator
        public static implicit operator SelectExpression(FieldExpression field) => new SelectExpression(field);
        public static implicit operator OrderByExpression(FieldExpression field) => new OrderByExpression(field, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(FieldExpression field) => new GroupByExpression(field);
        #endregion

        #region field to expression relational operators
        public static FilterExpression operator ==(FieldExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(FieldExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(FieldExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(FieldExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(FieldExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(FieldExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field to field arithmetic operators
        public static ArithmeticExpression operator +(FieldExpression a, FieldExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(FieldExpression a, FieldExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(FieldExpression a, FieldExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(FieldExpression a, FieldExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(FieldExpression a, FieldExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region field to arithmetic expression arithmetic operators
        public static ArithmeticExpression operator +(FieldExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(FieldExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(FieldExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(FieldExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(FieldExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region conditional & operator
        public static SelectExpressionSet operator &(FieldExpression a, FieldExpression b) => new SelectExpressionSet(a, b);
        #endregion

        #region equals
        public bool Equals(FieldExpression obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.Metadata.ParentEntity != this.Metadata.ParentEntity) return false;
            if (string.Compare(obj.Metadata.Name, this.Metadata.Name, true) != 0) return false;
            if (obj.Metadata.Size != this.Metadata.Size) return false;

            return true;
        }

        public override bool Equals(object obj)
         => Equals(obj as FieldExpression);

        public override int GetHashCode()
            => base.GetHashCode();

        public static bool operator ==(FieldExpression obj1, FieldExpression obj2)
        {
            if (ReferenceEquals(obj1, obj2)) return true;
            if (ReferenceEquals(obj1, null)) return false;
            if (ReferenceEquals(obj2, null)) return false;
            if (obj1.Metadata.ParentEntity != obj2.Metadata.ParentEntity) return false;
            if (string.Compare(obj1.Metadata.Name, obj2.Metadata.Name, true) != 0) return false;
            if (obj1.Metadata.Size != obj2.Metadata.Size) return false;

            return true;
        }

        public static bool operator !=(FieldExpression obj1, FieldExpression obj2)
            => !(obj1 == obj2);
        #endregion
    }

}
