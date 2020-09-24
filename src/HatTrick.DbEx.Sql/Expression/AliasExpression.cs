using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class AliasExpression : 
        IExpression, 
        IExpressionAliasProvider,
        IEquatable<AliasExpression>
    {
        #region internals
        protected readonly string alias;
        #endregion

        #region interface
        public string TableAlias { get; private set; }
        public string FieldAlias { get; private set; }
        string IExpressionAliasProvider.Alias => alias;
        #endregion

        #region constructors
        public AliasExpression(string tableAlias, string fieldAlias)
        {
            TableAlias = tableAlias;
            FieldAlias = fieldAlias;
        }

        protected AliasExpression(string tableAlias, string fieldAlias, string alias)
        {
            TableAlias = tableAlias;
            FieldAlias = fieldAlias;
            this.alias = alias;
        }
        #endregion

        #region methods
        #region as
        public AliasExpression As(string alias)
            => new AliasExpression(TableAlias, FieldAlias, alias);

        #endregion

        #region conversion
        public BooleanExpressionMediator AsBoolean()
            => new BooleanExpressionMediator(this);

        public NullableBooleanExpressionMediator AsNullableBoolean()
            => new NullableBooleanExpressionMediator(this);

        public ByteExpressionMediator AsByte()
            => new ByteExpressionMediator(this);

        public NullableByteExpressionMediator AsNullableByte()
            => new NullableByteExpressionMediator(this);

        public DateTimeExpressionMediator AsDateTime()
            => new DateTimeExpressionMediator(this);

        public NullableDateTimeExpressionMediator AsNullableDateTime()
            => new NullableDateTimeExpressionMediator(this);

        public DateTimeOffsetExpressionMediator AsDateTimeOffset()
            => new DateTimeOffsetExpressionMediator(this);

        public NullableDateTimeOffsetExpressionMediator AsNullableDateTimeOffset()
            => new NullableDateTimeOffsetExpressionMediator(this);

        public DecimalExpressionMediator AsDecimal()
            => new DecimalExpressionMediator(this);

        public NullableDecimalExpressionMediator AsNullableDecimal()
            => new NullableDecimalExpressionMediator(this);

        public DoubleExpressionMediator AsDouble()
            => new DoubleExpressionMediator(this);

        public NullableDoubleExpressionMediator AsNullableDouble()
            => new NullableDoubleExpressionMediator(this);

        public NullableEnumExpressionMediator<TEnum> AsNullableEnum<TEnum>()
            where TEnum : struct, Enum, IComparable
            => new NullableEnumExpressionMediator<TEnum>(this);

        public EnumExpressionMediator<TEnum> AsEnum<TEnum>()
            where TEnum : struct, Enum, IComparable
            => new EnumExpressionMediator<TEnum>(this);

        public GuidExpressionMediator AsGuid()
            => new GuidExpressionMediator(this);

        public NullableGuidExpressionMediator AsNullableGuid()
            => new NullableGuidExpressionMediator(this);

        public Int16ExpressionMediator AsInt16()
            => new Int16ExpressionMediator(this);

        public NullableInt16ExpressionMediator AsNullableInt16()
            => new NullableInt16ExpressionMediator(this);

        public Int32ExpressionMediator AsInt32()
            => new Int32ExpressionMediator(this);

        public NullableInt32ExpressionMediator AsNullableInt32()
            => new NullableInt32ExpressionMediator(this);

        public Int64ExpressionMediator AsInt64()
            => new Int64ExpressionMediator(this);

        public NullableInt64ExpressionMediator AsNullableInt64()
            => new NullableInt64ExpressionMediator(this);

        public SingleExpressionMediator AsSingle()
            => new SingleExpressionMediator(this);

        public NullableSingleExpressionMediator AsNullableSingle()
            => new NullableSingleExpressionMediator(this);

        public StringExpressionMediator AsString()
            => new StringExpressionMediator(this);
        #endregion

        #region to string
        public override string ToString()
            => string.IsNullOrWhiteSpace(alias) ? $"{TableAlias}.{FieldAlias}" : $"{TableAlias}.{FieldAlias} AS {alias}";
        #endregion

        #region equals
        public bool Equals(AliasExpression obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!StringComparer.Ordinal.Equals(TableAlias, obj.TableAlias)) return false;
            if (!StringComparer.Ordinal.Equals(FieldAlias, obj.FieldAlias)) return false;
            if (!StringComparer.Ordinal.Equals(alias, obj.alias)) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is AliasExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (TableAlias is object ? TableAlias.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (FieldAlias is object ? FieldAlias.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (alias is object ? alias.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region order by
        public OrderByExpression Asc => new OrderByExpression(new ExpressionMediator(this), OrderExpressionDirection.ASC);
        public OrderByExpression Desc => new OrderByExpression(new ExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression(AliasExpression a) => new SelectExpression(new ExpressionMediator(a));
        public static implicit operator OrderByExpression(AliasExpression a) => new OrderByExpression(new ExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(AliasExpression a) => new GroupByExpression(new ExpressionMediator(a));

        #region data type
        public static implicit operator BooleanExpressionMediator(AliasExpression a) => new BooleanExpressionMediator(a);
        public static implicit operator ByteExpressionMediator(AliasExpression a) => new ByteExpressionMediator(a);
        public static implicit operator DecimalExpressionMediator(AliasExpression a) => new DecimalExpressionMediator(a);
        public static implicit operator DateTimeExpressionMediator(AliasExpression a) => new DateTimeExpressionMediator(a);
        public static implicit operator DateTimeOffsetExpressionMediator(AliasExpression a) => new DateTimeOffsetExpressionMediator(a);
        public static implicit operator DoubleExpressionMediator(AliasExpression a) => new DoubleExpressionMediator(a);
        public static implicit operator GuidExpressionMediator(AliasExpression a) => new GuidExpressionMediator(a);
        public static implicit operator Int16ExpressionMediator(AliasExpression a) => new Int16ExpressionMediator(a);
        public static implicit operator Int32ExpressionMediator(AliasExpression a) => new Int32ExpressionMediator(a);
        public static implicit operator Int64ExpressionMediator(AliasExpression a) => new Int64ExpressionMediator(a);
        public static implicit operator SingleExpressionMediator(AliasExpression a) => new SingleExpressionMediator(a);
        public static implicit operator StringExpressionMediator(AliasExpression a) => new StringExpressionMediator(a);

        public static implicit operator NullableBooleanExpressionMediator(AliasExpression a) => new NullableBooleanExpressionMediator(a);
        public static implicit operator NullableByteExpressionMediator(AliasExpression a) => new NullableByteExpressionMediator(a);
        public static implicit operator NullableDateTimeExpressionMediator(AliasExpression a) => new NullableDateTimeExpressionMediator(a);
        public static implicit operator NullableDateTimeOffsetExpressionMediator(AliasExpression a) => new NullableDateTimeOffsetExpressionMediator(a);
        public static implicit operator NullableDecimalExpressionMediator(AliasExpression a) => new NullableDecimalExpressionMediator(a);
        public static implicit operator NullableDoubleExpressionMediator(AliasExpression a) => new NullableDoubleExpressionMediator(a);
        public static implicit operator NullableGuidExpressionMediator(AliasExpression a) => new NullableGuidExpressionMediator(a);
        public static implicit operator NullableInt16ExpressionMediator(AliasExpression a) => new NullableInt16ExpressionMediator(a);
        public static implicit operator NullableInt32ExpressionMediator(AliasExpression a) => new NullableInt32ExpressionMediator(a);
        public static implicit operator NullableInt64ExpressionMediator(AliasExpression a) => new NullableInt64ExpressionMediator(a);
        public static implicit operator NullableSingleExpressionMediator(AliasExpression a) => new NullableSingleExpressionMediator(a);
        #endregion
        #endregion

        #region arithmetic operators
        #region alias
        public static ExpressionMediator operator +(AliasExpression a, AliasExpression b) => new ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static ExpressionMediator operator -(AliasExpression a, AliasExpression b) => new ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static ExpressionMediator operator *(AliasExpression a, AliasExpression b) => new ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static ExpressionMediator operator /(AliasExpression a, AliasExpression b) => new ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static ExpressionMediator operator %(AliasExpression a, AliasExpression b) => new ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region data type
        #region byte
        public static ByteExpressionMediator operator +(AliasExpression a, byte b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static ByteExpressionMediator operator -(AliasExpression a, byte b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));
        public static ByteExpressionMediator operator *(AliasExpression a, byte b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply));
        public static ByteExpressionMediator operator /(AliasExpression a, byte b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide));
        public static ByteExpressionMediator operator %(AliasExpression a, byte b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo));

        public static ByteExpressionMediator operator +(byte a, AliasExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static ByteExpressionMediator operator -(byte a, AliasExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static ByteExpressionMediator operator *(byte a, AliasExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static ByteExpressionMediator operator /(byte a, AliasExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static ByteExpressionMediator operator %(byte a, AliasExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableByteExpressionMediator operator +(AliasExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(AliasExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(AliasExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(AliasExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(AliasExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableByteExpressionMediator operator +(byte? a, AliasExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(byte? a, AliasExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(byte? a, AliasExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(byte? a, AliasExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(byte? a, AliasExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static DecimalExpressionMediator operator +(AliasExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(AliasExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(AliasExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(AliasExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(AliasExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(decimal a, AliasExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(decimal a, AliasExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(decimal a, AliasExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(decimal a, AliasExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(decimal a, AliasExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(AliasExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(AliasExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(AliasExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(AliasExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(AliasExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, AliasExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, AliasExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, AliasExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, AliasExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, AliasExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region double
        public static DoubleExpressionMediator operator +(AliasExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(AliasExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(AliasExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(AliasExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(AliasExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(double a, AliasExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(double a, AliasExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(double a, AliasExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(double a, AliasExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(double a, AliasExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(AliasExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(AliasExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(AliasExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(AliasExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(AliasExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, AliasExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, AliasExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, AliasExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, AliasExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, AliasExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static SingleExpressionMediator operator +(AliasExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(AliasExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(AliasExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(AliasExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(AliasExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(float a, AliasExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(float a, AliasExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(float a, AliasExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(float a, AliasExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(float a, AliasExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(AliasExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(AliasExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(AliasExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(AliasExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(AliasExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, AliasExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, AliasExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, AliasExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, AliasExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, AliasExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static Int16ExpressionMediator operator +(AliasExpression a, short b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static Int16ExpressionMediator operator -(AliasExpression a, short b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int16ExpressionMediator operator *(AliasExpression a, short b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int16ExpressionMediator operator /(AliasExpression a, short b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide));
        public static Int16ExpressionMediator operator %(AliasExpression a, short b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int16ExpressionMediator operator +(short a, AliasExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int16ExpressionMediator operator -(short a, AliasExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int16ExpressionMediator operator *(short a, AliasExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int16ExpressionMediator operator /(short a, AliasExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int16ExpressionMediator operator %(short a, AliasExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(AliasExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(AliasExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(AliasExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(AliasExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(AliasExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(short? a, AliasExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(short? a, AliasExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(short? a, AliasExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(short? a, AliasExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(short? a, AliasExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static Int32ExpressionMediator operator +(AliasExpression a, int b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(AliasExpression a, int b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(AliasExpression a, int b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(AliasExpression a, int b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(AliasExpression a, int b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int32ExpressionMediator operator +(int a, AliasExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(int a, AliasExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(int a, AliasExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(int a, AliasExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(int a, AliasExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(AliasExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(AliasExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(AliasExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(AliasExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(AliasExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int? a, AliasExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int? a, AliasExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int? a, AliasExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int? a, AliasExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int? a, AliasExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static Int64ExpressionMediator operator +(AliasExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(AliasExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(AliasExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(AliasExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(AliasExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(long a, AliasExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(long a, AliasExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(long a, AliasExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(long a, AliasExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(long a, AliasExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(AliasExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(AliasExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(AliasExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(AliasExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(AliasExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long? a, AliasExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long? a, AliasExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long? a, AliasExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long? a, AliasExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long? a, AliasExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region string
        public static StringExpressionMediator operator +(AliasExpression a, string b) => new StringExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Add));

        public static StringExpressionMediator operator +(string a, AliasExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(new LiteralExpression<string>(a)), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        #endregion
        #endregion

        #region fields
        #region byte
        public static ByteExpressionMediator operator +(AliasExpression a, ByteFieldExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static ByteExpressionMediator operator -(AliasExpression a, ByteFieldExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static ByteExpressionMediator operator *(AliasExpression a, ByteFieldExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static ByteExpressionMediator operator /(AliasExpression a, ByteFieldExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static ByteExpressionMediator operator %(AliasExpression a, ByteFieldExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static DateTimeExpressionMediator operator +(AliasExpression a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(AliasExpression a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(AliasExpression a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(AliasExpression a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region decimal
        public static DecimalExpressionMediator operator +(AliasExpression a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(AliasExpression a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(AliasExpression a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(AliasExpression a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(AliasExpression a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region double
        public static DoubleExpressionMediator operator +(AliasExpression a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(AliasExpression a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(AliasExpression a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(AliasExpression a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(AliasExpression a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static SingleExpressionMediator operator +(AliasExpression a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(AliasExpression a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(AliasExpression a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(AliasExpression a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(AliasExpression a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static Int16ExpressionMediator operator +(AliasExpression a, Int16FieldExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int16ExpressionMediator operator -(AliasExpression a, Int16FieldExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int16ExpressionMediator operator *(AliasExpression a, Int16FieldExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int16ExpressionMediator operator /(AliasExpression a, Int16FieldExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int16ExpressionMediator operator %(AliasExpression a, Int16FieldExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static Int32ExpressionMediator operator +(AliasExpression a, Int32FieldExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(AliasExpression a, Int32FieldExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(AliasExpression a, Int32FieldExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(AliasExpression a, Int32FieldExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(AliasExpression a, Int32FieldExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static Int64ExpressionMediator operator +(AliasExpression a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(AliasExpression a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(AliasExpression a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(AliasExpression a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(AliasExpression a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region string
        public static Int64ExpressionMediator operator +(AliasExpression a, StringFieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        #endregion
        #endregion

        #region mediator
        #region byte
        public static ByteExpressionMediator operator +(AliasExpression a, ByteExpressionMediator b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static ByteExpressionMediator operator -(AliasExpression a, ByteExpressionMediator b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static ByteExpressionMediator operator *(AliasExpression a, ByteExpressionMediator b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static ByteExpressionMediator operator /(AliasExpression a, ByteExpressionMediator b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static ByteExpressionMediator operator %(AliasExpression a, ByteExpressionMediator b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableByteExpressionMediator operator +(ByteExpressionMediator a, AliasExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(ByteExpressionMediator a, AliasExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(ByteExpressionMediator a, AliasExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(ByteExpressionMediator a, AliasExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(ByteExpressionMediator a, AliasExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static DateTimeExpressionMediator operator +(AliasExpression a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(AliasExpression a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDateTimeExpressionMediator operator +(AliasExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(AliasExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(AliasExpression a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(AliasExpression a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDateTimeOffsetExpressionMediator operator +(AliasExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(AliasExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region decimal
        public static DecimalExpressionMediator operator +(AliasExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(AliasExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(AliasExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(AliasExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(AliasExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        public static NullableDecimalExpressionMediator operator +(AliasExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(AliasExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(AliasExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(AliasExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(AliasExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region double
        public static DoubleExpressionMediator operator +(AliasExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(AliasExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(AliasExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(AliasExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(AliasExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        public static NullableDoubleExpressionMediator operator +(AliasExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(AliasExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(AliasExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(AliasExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(AliasExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static SingleExpressionMediator operator +(AliasExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(AliasExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(AliasExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(AliasExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(AliasExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        public static NullableSingleExpressionMediator operator +(AliasExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(AliasExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(AliasExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(AliasExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(AliasExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static Int16ExpressionMediator operator +(AliasExpression a, Int16ExpressionMediator b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static Int16ExpressionMediator operator -(AliasExpression a, Int16ExpressionMediator b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static Int16ExpressionMediator operator *(AliasExpression a, Int16ExpressionMediator b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static Int16ExpressionMediator operator /(AliasExpression a, Int16ExpressionMediator b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static Int16ExpressionMediator operator %(AliasExpression a, Int16ExpressionMediator b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        public static NullableInt16ExpressionMediator operator +(AliasExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(AliasExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(AliasExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(AliasExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(AliasExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static Int32ExpressionMediator operator +(AliasExpression a, Int32ExpressionMediator b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(AliasExpression a, Int32ExpressionMediator b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(AliasExpression a, Int32ExpressionMediator b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(AliasExpression a, Int32ExpressionMediator b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(AliasExpression a, Int32ExpressionMediator b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        public static NullableInt32ExpressionMediator operator +(AliasExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(AliasExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(AliasExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(AliasExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(AliasExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static Int64ExpressionMediator operator +(AliasExpression a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(AliasExpression a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(AliasExpression a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(AliasExpression a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(AliasExpression a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        public static NullableInt64ExpressionMediator operator +(AliasExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(AliasExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(AliasExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(AliasExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(AliasExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region string
        public static StringExpressionMediator operator +(AliasExpression a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        #endregion

        #endregion
        #endregion

        #region filter operators
        #region data type
        #region bool
        public static FilterExpression<bool> operator ==(AliasExpression a, bool b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, bool b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, bool b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, bool b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, bool b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, bool b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(bool a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<bool>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(bool a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<bool>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(bool a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<bool>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(bool a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<bool>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(bool a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<bool>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(bool a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<bool>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, bool? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, bool? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, bool? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, bool? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, bool? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, bool? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(bool? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<bool?>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(bool? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<bool?>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(bool? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<bool?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(bool? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<bool?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(bool? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<bool?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(bool? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<bool?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region byte
        public static FilterExpression<bool> operator ==(AliasExpression a, byte b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, byte b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, byte b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, byte b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, byte b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, byte b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(byte a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(byte a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(byte a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(byte a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(byte a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(byte a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, byte? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<byte?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, byte? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<byte?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, byte? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<byte?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, byte? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<byte?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, byte? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<byte?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, byte? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<byte?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(byte? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(byte? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(byte? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(byte? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(byte? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(byte? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region decimal
        public static FilterExpression<bool> operator ==(AliasExpression a, decimal b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<decimal>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, decimal b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<decimal>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, decimal b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<decimal>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, decimal b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<decimal>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, decimal b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<decimal>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, decimal b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<decimal>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(decimal a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(decimal a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(decimal a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(decimal a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(decimal a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(decimal a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, decimal? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<decimal?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, decimal? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<decimal?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, decimal? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<decimal?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, decimal? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<decimal?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, decimal? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<decimal?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, decimal? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<decimal?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(decimal? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(decimal? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(decimal? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(decimal? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(decimal? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(decimal? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region double
        public static FilterExpression<bool> operator ==(AliasExpression a, double b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<double>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, double b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<double>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, double b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<double>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, double b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<double>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, double b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<double>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, double b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<double>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(double a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(double a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(double a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(double a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(double a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(double a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, double? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<double?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, double? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<double?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, double? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<double?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, double? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<double?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, double? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<double?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, double? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<double?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(double? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(double? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(double? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(double? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(double? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(double? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region DateTime
        public static FilterExpression<bool> operator ==(AliasExpression a, DateTime b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, DateTime b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, DateTime b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, DateTime b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, DateTime b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, DateTime b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(DateTime a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<DateTime>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTime a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<DateTime>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTime a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<DateTime>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTime a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<DateTime>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTime a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<DateTime>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTime a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<DateTime>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, DateTime? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, DateTime? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, DateTime? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, DateTime? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, DateTime? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, DateTime? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(DateTime? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<DateTime?>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DateTime? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<DateTime?>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(DateTime? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<DateTime?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(DateTime? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<DateTime?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(DateTime? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<DateTime?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(DateTime? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<DateTime?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region DateTimeOffset
        public static FilterExpression<bool> operator ==(AliasExpression a, DateTimeOffset b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, DateTimeOffset b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, DateTimeOffset b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, DateTimeOffset b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, DateTimeOffset b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, DateTimeOffset b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(DateTimeOffset a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTimeOffset a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTimeOffset a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTimeOffset a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTimeOffset a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTimeOffset a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(DateTimeOffset? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DateTimeOffset? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(DateTimeOffset? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(DateTimeOffset? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(DateTimeOffset? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(DateTimeOffset? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region float
        public static FilterExpression<bool> operator ==(AliasExpression a, float b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, float b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, float b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, float b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, float b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, float b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(float a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(float a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(float a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(float a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(float a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(float a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, float? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, float? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, float? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, float? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, float? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, float? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(float? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(float? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(float? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(float? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(float? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(float? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region Guid
        public static FilterExpression<bool> operator ==(AliasExpression a, Guid b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, Guid b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, Guid b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, Guid b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, Guid b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, Guid b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(Guid a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<Guid>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(Guid a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<Guid>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(Guid a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<Guid>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(Guid a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<Guid>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(Guid a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<Guid>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(Guid a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<Guid>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, Guid? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, Guid? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, Guid? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, Guid? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, Guid? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, Guid? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(Guid? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<Guid?>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(Guid? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<Guid?>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(Guid? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<Guid?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(Guid? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<Guid?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(Guid? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<Guid?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(Guid? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<Guid?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region short
        public static FilterExpression<bool> operator ==(AliasExpression a, short b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<short>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, short b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<short>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, short b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<short>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, short b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<short>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, short b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<short>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, short b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<short>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(short a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(short a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(short a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(short a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(short a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(short a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, short? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<short?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, short? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<short?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, short? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<short?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, short? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<short?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, short? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<short?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, short? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<short?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(short? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(short? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(short? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(short? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(short? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(short? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region int
        public static FilterExpression<bool> operator ==(AliasExpression a, int b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, int b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, int b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, int b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, int b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, int b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(int a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(int a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(int a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(int a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(int a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(int a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, int? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, int? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, int? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, int? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, int? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, int? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(int? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(int? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(int? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(int? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(int? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(int? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region long
        public static FilterExpression<bool> operator ==(AliasExpression a, long b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, long b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, long b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, long b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, long b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, long b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(long a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(long a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(long a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(long a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(long a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(long a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, long? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, long? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, long? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, long? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, long? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, long? b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(long? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(long? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(long? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(long? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(long? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(long? a, AliasExpression b) => new FilterExpression<bool?>(new ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region string
        public static FilterExpression<bool> operator ==(AliasExpression a, string b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, string b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, string b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, string b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, string b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, string b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(string a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<string>(a)), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(string a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<string>(a)), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(string a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<string>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(string a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<string>(a)), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(string a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<string>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(string a, AliasExpression b) => new FilterExpression<bool>(new ExpressionMediator(new LiteralExpression<string>(a)), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region fields
        #region bool
        public static FilterExpression<bool> operator ==(AliasExpression a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region byte
        public static FilterExpression<bool> operator ==(AliasExpression a, ByteFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, ByteFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, ByteFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, ByteFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, ByteFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, ByteFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region decimal
        public static FilterExpression<bool> operator ==(AliasExpression a, DecimalFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, DecimalFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, DecimalFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, DecimalFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, DecimalFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, DecimalFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region double
        public static FilterExpression<bool> operator ==(AliasExpression a, DoubleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, DoubleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, DoubleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, DoubleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, DoubleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, DoubleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region DateTime
        public static FilterExpression<bool> operator ==(AliasExpression a, DateTimeFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, DateTimeFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, DateTimeFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, DateTimeFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, DateTimeFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, DateTimeFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region DateTimeOffset
        public static FilterExpression<bool> operator ==(AliasExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region float
        public static FilterExpression<bool> operator ==(AliasExpression a, SingleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, SingleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, SingleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, SingleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, SingleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, SingleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region Guid
        public static FilterExpression<bool> operator ==(AliasExpression a, GuidFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, GuidFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, GuidFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, GuidFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, GuidFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, GuidFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region short
        public static FilterExpression<bool> operator ==(AliasExpression a, Int16FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, Int16FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, Int16FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, Int16FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, Int16FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, Int16FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region int
        public static FilterExpression<bool> operator ==(AliasExpression a, Int32FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, Int32FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, Int32FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, Int32FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, Int32FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, Int32FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region long
        public static FilterExpression<bool> operator ==(AliasExpression a, Int64FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, Int64FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, Int64FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, Int64FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, Int64FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, Int64FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region string
        public static FilterExpression<bool> operator ==(AliasExpression a, StringFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, StringFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, StringFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, StringFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, StringFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, StringFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator(a), new ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        #region bool
        public static FilterExpression<bool> operator ==(AliasExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region byte
        public static FilterExpression<bool> operator ==(AliasExpression a, ByteExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, ByteExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, ByteExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, ByteExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, ByteExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, ByteExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region decimal
        public static FilterExpression<bool> operator ==(AliasExpression a, DecimalExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, DecimalExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, DecimalExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, DecimalExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, DecimalExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, DecimalExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region double
        public static FilterExpression<bool> operator ==(AliasExpression a, DoubleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, DoubleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, DoubleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, DoubleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, DoubleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, DoubleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region DateTime
        public static FilterExpression<bool> operator ==(AliasExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region DateTimeOffset
        public static FilterExpression<bool> operator ==(AliasExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region float
        public static FilterExpression<bool> operator ==(AliasExpression a, SingleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, SingleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, SingleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, SingleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, SingleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, SingleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region Guid
        public static FilterExpression<bool> operator ==(AliasExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, GuidExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region short
        public static FilterExpression<bool> operator ==(AliasExpression a, Int16ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, Int16ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, Int16ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, Int16ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, Int16ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, Int16ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region int
        public static FilterExpression<bool> operator ==(AliasExpression a, Int32ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, Int32ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, Int32ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, Int32ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, Int32ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, Int32ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region long
        public static FilterExpression<bool> operator ==(AliasExpression a, Int64ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, Int64ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, Int64ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, Int64ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, Int64ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, Int64ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(AliasExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(AliasExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(AliasExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(AliasExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(AliasExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(AliasExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region string
        public static FilterExpression<bool> operator ==(AliasExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(AliasExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(AliasExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(AliasExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(AliasExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(AliasExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
        #endregion
    }
}
