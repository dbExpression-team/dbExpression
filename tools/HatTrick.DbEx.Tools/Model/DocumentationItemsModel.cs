using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Tools.Model
{
    public class DocumentationItemsModel
    {
        #region internals
        private readonly DatabasePairModel database;
        private EntityPairModel _entity;
        private IDictionary<string, ColumnPairModel> columns = new Dictionary<string, ColumnPairModel>();
        private ColumnPairModel enumField;
        private ColumnPairModel nullableEnumField;
        #endregion

        #region interface
        public EntityExpressionModel AnyEntityExpression
        { 
            get
            {
                if (_entity is object)
                    return _entity.EntityExpression;

                _entity = database.Items.FirstOrDefault()?.Items.FirstOrDefault();

                return _entity?.EntityExpression;
            }
        }

        #region bool
        public FieldExpressionModel AnyFieldExpressionOfTypeBoolean
            => GetColumnPairOfType(nameof(Boolean), false)?.FieldExpression;

        public FieldExpressionModel AnyFieldExpressionOfTypeNullableBoolean
            => GetColumnPairOfType(nameof(Boolean), true)?.FieldExpression;

        public ColumnModel AnyColumnOfTypeBoolean
            => GetColumnPairOfType(nameof(Boolean), false)?.Column;

        public ColumnModel AnyColumnOfTypeNullableBoolean
            => GetColumnPairOfType(nameof(Boolean), true)?.Column;
        #endregion

        #region byte
        public FieldExpressionModel AnyFieldExpressionOfByte
            => GetColumnPairOfType(nameof(Byte), false)?.FieldExpression;

        public FieldExpressionModel AnyFieldExpressionOfTypeNullableByte
            => GetColumnPairOfType(nameof(Byte), true)?.FieldExpression;

        public ColumnModel AnyColumnOfTypeByte
            => GetColumnPairOfType(nameof(Byte), false)?.Column;

        public ColumnModel AnyColumnOfTypeNullableByte
            => GetColumnPairOfType(nameof(Byte), true)?.Column;
        #endregion

        #region byte[]
        public FieldExpressionModel AnyFieldExpressionOfByteArray
            => GetColumnPairOfType("ByteArray", false)?.FieldExpression;

        public FieldExpressionModel AnyFieldExpressionOfTypeNullableByteArray
            => GetColumnPairOfType("ByteArray", true)?.FieldExpression;

        public ColumnModel AnyColumnOfTypeByteArray
            => GetColumnPairOfType("ByteArray", false)?.Column;

        public ColumnModel AnyColumnOfTypeNullableByteArray
            => GetColumnPairOfType("ByteArray", true)?.Column;
        #endregion

        #region DateTime
        public FieldExpressionModel AnyFieldExpressionOfDateTime
            => GetColumnPairOfType(nameof(DateTime), false)?.FieldExpression;

        public FieldExpressionModel AnyFieldExpressionOfTypeNullableDateTime
            => GetColumnPairOfType(nameof(DateTime), true)?.FieldExpression;

        public ColumnModel AnyColumnOfTypeDateTime
            => GetColumnPairOfType(nameof(DateTime), false)?.Column;

        public ColumnModel AnyColumnOfTypeNullableDateTime
            => GetColumnPairOfType(nameof(DateTime), true)?.Column;
        #endregion

        #region DateTimeOffset
        public FieldExpressionModel AnyFieldExpressionOfDateTimeOffset
            => GetColumnPairOfType(nameof(DateTimeOffset), false)?.FieldExpression;

        public FieldExpressionModel AnyFieldExpressionOfTypeNullableDateTimeOffset
            => GetColumnPairOfType(nameof(DateTimeOffset), true)?.FieldExpression;

        public ColumnModel AnyColumnOfTypeDateTimeOffset
            => GetColumnPairOfType(nameof(DateTimeOffset), false)?.Column;

        public ColumnModel AnyColumnOfTypeNullableDateTimeOffset
            => GetColumnPairOfType(nameof(DateTimeOffset), true)?.Column;
        #endregion

        #region Decimal
        public FieldExpressionModel AnyFieldExpressionOfDecimal
            => GetColumnPairOfType(nameof(Decimal), false)?.FieldExpression;

        public FieldExpressionModel AnyFieldExpressionOfTypeNullableDecimal
            => GetColumnPairOfType(nameof(Decimal), true)?.FieldExpression;

        public ColumnModel AnyColumnOfTypeDecimal
            => GetColumnPairOfType(nameof(Decimal), false)?.Column;

        public ColumnModel AnyColumnOfTypeNullableDecimal
            => GetColumnPairOfType(nameof(Decimal), true)?.Column;
        #endregion

        #region Double
        public FieldExpressionModel AnyFieldExpressionOfDouble
            => GetColumnPairOfType(nameof(Double), false)?.FieldExpression;

        public FieldExpressionModel AnyFieldExpressionOfTypeNullableDouble
            => GetColumnPairOfType(nameof(Double), true)?.FieldExpression;

        public ColumnModel AnyColumnOfTypeDouble
            => GetColumnPairOfType(nameof(Double), false)?.Column;

        public ColumnModel AnyColumnOfTypeNullableDouble
            => GetColumnPairOfType(nameof(Double), true)?.Column;
        #endregion

        #region Guid
        public FieldExpressionModel AnyFieldExpressionOfGuid
            => GetColumnPairOfType(nameof(Guid), false)?.FieldExpression;

        public FieldExpressionModel AnyFieldExpressionOfTypeNullableGuid
            => GetColumnPairOfType(nameof(Guid), true)?.FieldExpression;

        public ColumnModel AnyColumnOfTypeGuid
            => GetColumnPairOfType(nameof(Guid), false)?.Column;

        public ColumnModel AnyColumnOfTypeNullableGuid
            => GetColumnPairOfType(nameof(Guid), true)?.Column;
        #endregion

        #region short
        public FieldExpressionModel AnyFieldExpressionOfInt16
            => GetColumnPairOfType(nameof(Int16), false)?.FieldExpression;

        public FieldExpressionModel AnyFieldExpressionOfTypeNullableInt16
            => GetColumnPairOfType(nameof(Int16), true)?.FieldExpression;

        public ColumnModel AnyColumnOfTypeInt16
            => GetColumnPairOfType(nameof(Int16), false)?.Column;

        public ColumnModel AnyColumnOfTypeNullableInt16
            => GetColumnPairOfType(nameof(Int16), true)?.Column;
        #endregion

        #region int
        public FieldExpressionModel AnyFieldExpressionOfTypeInt32
            => GetColumnPairOfType(nameof(Int32), false)?.FieldExpression;

        public FieldExpressionModel AnyFieldExpressionOfTypeNullableInt32
            => GetColumnPairOfType(nameof(Int32), true)?.FieldExpression;

        public ColumnModel AnyColumnOfTypeInt32
            => GetColumnPairOfType(nameof(Int32), false)?.Column;

        public ColumnModel AnyColumnOfTypeNullableInt32
            => GetColumnPairOfType(nameof(Int32), true)?.Column;
        #endregion

        #region long
        public FieldExpressionModel AnyFieldExpressionOfTypeInt64
            => GetColumnPairOfType(nameof(Int64), false)?.FieldExpression;

        public FieldExpressionModel AnyFieldExpressionOfTypeNullableInt64
            => GetColumnPairOfType(nameof(Int64), true)?.FieldExpression;

        public ColumnModel AnyColumnOfTypeInt64
            => GetColumnPairOfType(nameof(Int64), false)?.Column;

        public ColumnModel AnyColumnOfTypeNullableInt64
            => GetColumnPairOfType(nameof(Int64), true)?.Column;
        #endregion

        #region float
        public FieldExpressionModel AnyFieldExpressionOfTypeSingle
            => GetColumnPairOfType(nameof(Single), false)?.FieldExpression;

        public FieldExpressionModel AnyFieldExpressionOfTypeNullableSingle
            => GetColumnPairOfType(nameof(Single), true)?.FieldExpression;

        public ColumnModel AnyColumnOfTypeSingle
            => GetColumnPairOfType(nameof(Single), false)?.Column;

        public ColumnModel AnyColumnOfTypeNullableSingle
            => GetColumnPairOfType(nameof(Single), true)?.Column;
        #endregion

        #region string
        public FieldExpressionModel AnyFieldExpressionOfTypeString
            => GetColumnPairOfType(nameof(String), false)?.FieldExpression;

        public FieldExpressionModel AnyFieldExpressionOfTypeNullableString
            => GetColumnPairOfType(nameof(String), true)?.FieldExpression;

        public ColumnModel AnyColumnOfTypeString
            => GetColumnPairOfType(nameof(String), false)?.Column;

        public ColumnModel AnyColumnOfTypeNullableString
            => GetColumnPairOfType(nameof(String), true)?.Column;
        #endregion

        #region string
        public FieldExpressionModel AnyFieldExpressionOfTypeTimeSpan
            => GetColumnPairOfType(nameof(TimeSpan), false)?.FieldExpression;

        public FieldExpressionModel AnyFieldExpressionOfTypeNullableTimeSpan
            => GetColumnPairOfType(nameof(TimeSpan), true)?.FieldExpression;

        public ColumnModel AnyColumnOfTypeTimeSpan
            => GetColumnPairOfType(nameof(TimeSpan), false)?.Column;

        public ColumnModel AnyColumnOfTypeNullableTimeSpan
            => GetColumnPairOfType(nameof(TimeSpan), true)?.Column;
        #endregion

        #region enum
        public ColumnModel AnyEnumColumnExpression
        {
            get
            {
                if (enumField is object)
                    return enumField.Column;

                foreach (var schema in database.Items)
                    foreach (var entity in schema.Items)
                    {
                        var field = entity.Items.FirstOrDefault(x => x.FieldExpression.Type.IsEnum && !x.FieldExpression.Type.IsNullable);
                        if (field is object)
                        {
                            nullableEnumField = field;
                            return nullableEnumField.Column;
                        }
                    }

                return enumField?.Column;
            }
        }

        public ColumnModel AnyNullableEnumColumnExpression
        {
            get
            {
                if (nullableEnumField is object)
                    return nullableEnumField.Column;

                foreach (var schema in database.Items)
                    foreach (var entity in schema.Items)
                    {
                        var field = entity.Items.FirstOrDefault(x => x.FieldExpression.Type.IsEnum && x.FieldExpression.Type.IsNullable);
                        if (field is object)
                        {
                            nullableEnumField = field;
                            return nullableEnumField.Column;
                        }
                    }

                return null;
            }
        }
        #endregion
        #endregion

        #region constructors
        public DocumentationItemsModel(DatabasePairModel database)
        {
            this.database = database ?? throw new ArgumentNullException(nameof(database));
        }
        #endregion

        #region methods
        private ColumnPairModel GetColumnPairOfType(string typeName, bool isNullable = false)
        {
            var key = isNullable ? $"{typeName}?" : typeName;

            if (columns.ContainsKey(key))
                return columns[key];


            foreach (var schema in database.Items)
                foreach (var entity in schema.Items)
                    { 
                        var field = entity.Items.FirstOrDefault(x => x.FieldExpression.Type.TypeName == typeName && x.FieldExpression.Type.IsNullable == isNullable);
                        if (field is object)
                        { 
                            columns.Add(key, field);
                            return field;                    
                        }                
                    }

            return null;

        }
        #endregion
    }
}
