using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public partial class SqlFunctionExpressionBuilder
    {
        #region concat
        #region object
        public static StringConcatFunctionExpression Concat(params AnyObjectElement[] elements)
            => new StringConcatFunctionExpression(elements);

        public static StringConcatFunctionExpression Concat(string value, params AnyObjectElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyElement> { new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());

        public static StringConcatFunctionExpression Concat(AnyObjectElement element1, string value, params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyElement> { element1, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());

        public static StringConcatFunctionExpression Concat(AnyStringElement element1, AnyObjectElement element2, string value, params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyElement> { element1, element2, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());

        public static StringConcatFunctionExpression Concat(AnyStringElement element1, AnyStringElement element2, AnyObjectElement element3, string value, params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyElement> { element1, element2, element3, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());

        public static StringConcatFunctionExpression Concat(AnyStringElement element1, AnyStringElement element2, AnyStringElement element3, AnyObjectElement element4, string value, params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyElement> { element1, element2, element3, element4, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());
        #endregion

        #region string
        public static StringConcatFunctionExpression Concat(params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(elements);

        public static StringConcatFunctionExpression Concat(string value, params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyStringElement> { new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());

        public static StringConcatFunctionExpression Concat(AnyStringElement element1, string value, params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyStringElement> { element1, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());

        public static StringConcatFunctionExpression Concat(AnyStringElement element1, AnyStringElement element2, string value, params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyStringElement> { element1, element2, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());

        public static StringConcatFunctionExpression Concat(AnyStringElement element1, AnyStringElement element2, AnyStringElement element3, string value, params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyStringElement> { element1, element2, element3, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());

        public static StringConcatFunctionExpression Concat(AnyStringElement element1, AnyStringElement element2, AnyStringElement element3, AnyStringElement element4, string value, params AnyStringElement[] elements)
            => new StringConcatFunctionExpression(new List<AnyStringElement> { element1, element2, element3, element4, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(elements).ToArray());
        #endregion
        #endregion

        #region coalesce
        #region object
        public static ObjectCoalesceFunctionExpression Coalesce(AnyElement element, object value)
            => new ObjectCoalesceFunctionExpression(new List<AnyElement> { element, new ObjectExpressionMediator(new LiteralExpression<object>(value)) });

        public static ObjectCoalesceFunctionExpression Coalesce(AnyElement element1, AnyElement element2, object value)
            => new ObjectCoalesceFunctionExpression(new List<AnyElement> { element1, element2, new ObjectExpressionMediator(new LiteralExpression<object>(value)) });

        public static ObjectCoalesceFunctionExpression Coalesce(AnyElement element1, AnyElement element2, AnyElement element3, object value)
            => new ObjectCoalesceFunctionExpression(new List<AnyElement> { element1, element2, element3, new ObjectExpressionMediator(new LiteralExpression<object>(value)) });

        public static ObjectCoalesceFunctionExpression Coalesce(AnyElement element1, AnyElement element2, AnyElement element3, AnyElement element4, params AnyElement[] elements)
            => new ObjectCoalesceFunctionExpression(new List<AnyElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region bool
        public static BooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element, bool value)
            => new BooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element, new BooleanExpressionMediator(new LiteralExpression<bool>(value)) });

        public static NullableBooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, bool? value)
            => new NullableBooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1, new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(value)) });

        public static NullableBooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, BooleanElement element2)
            => new NullableBooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1 }, element2);

        public static NullableBooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, NullableBooleanElement element2)
            => new NullableBooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1 }, element2);

        public static BooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, AnyBooleanElement element2, bool value)
            => new BooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1, element2, new BooleanExpressionMediator(new LiteralExpression<bool>(value)) });

        public static NullableBooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, AnyBooleanElement element2, bool? value)
            => new NullableBooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1, element2, new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(value)) });

        public static NullableBooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, AnyBooleanElement element2, BooleanElement element3)
            => new NullableBooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1, element2 }, element3);

        public static NullableBooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, AnyBooleanElement element2, NullableBooleanElement element3)
            => new NullableBooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1, element2 }, element3);

        public static BooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, AnyBooleanElement element2, AnyBooleanElement element3, bool value)
            => new BooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1, element2, element3, new BooleanExpressionMediator(new LiteralExpression<bool>(value)) });

        public static NullableBooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, AnyBooleanElement element2, AnyBooleanElement element3, bool? value)
            => new NullableBooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1, element2, element3, new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(value)) });

        public static NullableBooleanCoalesceFunctionExpression Coalesce(AnyBooleanElement element1, AnyBooleanElement element2, AnyBooleanElement element3, AnyBooleanElement element4, params AnyBooleanElement[] elements)
            => new NullableBooleanCoalesceFunctionExpression(new List<AnyBooleanElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region byte
        public static ByteCoalesceFunctionExpression Coalesce(AnyByteElement element, byte value)
           => new ByteCoalesceFunctionExpression(new List<AnyByteElement> { element, new ByteExpressionMediator(new LiteralExpression<byte>(value)) });

        public static NullableByteCoalesceFunctionExpression Coalesce(AnyByteElement element, byte? value)
            => new NullableByteCoalesceFunctionExpression(new List<AnyByteElement> { element, new NullableByteExpressionMediator(new LiteralExpression<byte?>(value)) });

        public static NullableByteCoalesceFunctionExpression Coalesce(AnyByteElement element1, ByteElement element2)
            => new NullableByteCoalesceFunctionExpression(new List<AnyByteElement> { element1 }, element2);

        public static NullableByteCoalesceFunctionExpression Coalesce(AnyByteElement element1, NullableByteElement element2)
            => new NullableByteCoalesceFunctionExpression(new List<AnyByteElement> { element1 }, element2);

        public static ByteCoalesceFunctionExpression Coalesce(AnyByteElement element1, AnyByteElement element2, byte value)
            => new ByteCoalesceFunctionExpression(new List<AnyByteElement> { element1, element2, new ByteExpressionMediator(new LiteralExpression<byte>(value)) });

        public static NullableByteCoalesceFunctionExpression Coalesce(AnyByteElement element1, AnyByteElement element2, byte? value)
            => new NullableByteCoalesceFunctionExpression(new List<AnyByteElement> { element1, element2, new NullableByteExpressionMediator(new LiteralExpression<byte?>(value)) });

        public static NullableByteCoalesceFunctionExpression Coalesce(AnyByteElement element1, AnyByteElement element2, ByteElement element3)
            => new NullableByteCoalesceFunctionExpression(new List<AnyByteElement> { element1, element2 }, element3);

        public static NullableByteCoalesceFunctionExpression Coalesce(AnyByteElement element1, AnyByteElement element2, NullableByteElement element3)
            => new NullableByteCoalesceFunctionExpression(new List<AnyByteElement> { element1, element2 }, element3);

        public static ByteCoalesceFunctionExpression Coalesce(AnyByteElement element1, AnyByteElement element2, AnyByteElement element3, byte value)
            => new ByteCoalesceFunctionExpression(new List<AnyByteElement> { element1, element2, element3, new ByteExpressionMediator(new LiteralExpression<byte>(value)) });

        public static NullableByteCoalesceFunctionExpression Coalesce(AnyByteElement element1, AnyByteElement element2, AnyByteElement element3, byte? value)
            => new NullableByteCoalesceFunctionExpression(new List<AnyByteElement> { element1, element2, element3, new NullableByteExpressionMediator(new LiteralExpression<byte?>(value)) });

        public static NullableByteCoalesceFunctionExpression Coalesce(AnyByteElement element1, AnyByteElement element2, AnyByteElement element3, AnyByteElement element4, params AnyByteElement[] elements)
            => new NullableByteCoalesceFunctionExpression(new List<AnyByteElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region DateTime
        public static DateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element, DateTime value)
            => new DateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(value)) });

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element, DateTime? value)
            => new NullableDateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(value)) });

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element1, DateTimeElement element2)
            => new NullableDateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element1 }, element2);

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element1, NullableDateTimeElement element2)
            => new NullableDateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element1 }, element2);

        public static DateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element1, AnyDateTimeElement element2, DateTime value)
            => new DateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element1, element2, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(value)) });

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element1, AnyDateTimeElement element2, DateTime? value)
            => new NullableDateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element1, element2, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(value)) });

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element1, AnyDateTimeElement element2, DateTimeElement element3)
            => new NullableDateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element1, element2 }, element3);

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element1, AnyDateTimeElement element2, NullableDateTimeElement element3)
            => new NullableDateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element1, element2 }, element3);

        public static DateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element1, AnyDateTimeElement element2, AnyDateTimeElement element3, DateTime value)
            => new DateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element1, element2, element3, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(value)) });

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element1, AnyDateTimeElement element2, AnyDateTimeElement element3, DateTime? value)
            => new NullableDateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element1, element2, element3, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(value)) });

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(AnyDateTimeElement element1, AnyDateTimeElement element2, AnyDateTimeElement element3, AnyDateTimeElement element4, params AnyDateTimeElement[] elements)
            => new NullableDateTimeCoalesceFunctionExpression(new List<AnyDateTimeElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element, DateTimeOffset value)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(value)) });

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element, DateTimeOffset? value)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(value)) });

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element1, DateTimeOffsetElement element2)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element1 }, element2);

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element1, NullableDateTimeOffsetElement element2)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element1 }, element2);

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element1, AnyDateTimeOffsetElement element2, DateTimeOffset value)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element1, element2, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(value)) });

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element1, AnyDateTimeOffsetElement element2, DateTimeOffset? value)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element1, element2, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(value)) });

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element1, AnyDateTimeOffsetElement element2, DateTimeOffsetElement element3)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element1, element2 }, element3);

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element1, AnyDateTimeOffsetElement element2, NullableDateTimeOffsetElement element3)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element1, element2 }, element3);

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element1, AnyDateTimeOffsetElement element2, AnyDateTimeOffsetElement element3, DateTimeOffset value)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element1, element2, element3, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(value)) });

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element1, AnyDateTimeOffsetElement element2, AnyDateTimeOffsetElement element3, DateTimeOffset? value)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element1, element2, element3, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(value)) });

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(AnyDateTimeOffsetElement element1, AnyDateTimeOffsetElement element2, AnyDateTimeOffsetElement element3, AnyDateTimeOffsetElement element4, params AnyDateTimeOffsetElement[] elements)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<AnyDateTimeOffsetElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region double
        public static DoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element, double value)
           => new DoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element, new DoubleExpressionMediator(new LiteralExpression<double>(value)) });

        public static NullableDoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element, double? value)
            => new NullableDoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(value)) });

        public static NullableDoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element1, DoubleElement element2)
            => new NullableDoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element1 }, element2);

        public static NullableDoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element1, NullableDoubleElement element2)
            => new NullableDoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element1 }, element2);

        public static DoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element1, AnyDoubleElement element2, double value)
            => new DoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element1, element2, new DoubleExpressionMediator(new LiteralExpression<double>(value)) });

        public static NullableDoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element1, AnyDoubleElement element2, double? value)
            => new NullableDoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element1, element2, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(value)) });

        public static NullableDoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element1, AnyDoubleElement element2, DoubleElement element3)
            => new NullableDoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element1, element2 }, element3);

        public static NullableDoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element1, AnyDoubleElement element2, NullableDoubleElement element3)
            => new NullableDoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element1, element2 }, element3);

        public static DoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element1, AnyDoubleElement element2, AnyDoubleElement element3, double value)
            => new DoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element1, element2, element3, new DoubleExpressionMediator(new LiteralExpression<double>(value)) });

        public static NullableDoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element1, AnyDoubleElement element2, AnyDoubleElement element3, double? value)
            => new NullableDoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element1, element2, element3, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(value)) });

        public static NullableDoubleCoalesceFunctionExpression Coalesce(AnyDoubleElement element1, AnyDoubleElement element2, AnyDoubleElement element3, AnyDoubleElement element4, params AnyDoubleElement[] elements)
            => new NullableDoubleCoalesceFunctionExpression(new List<AnyDoubleElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region decimal
        public static DecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element, decimal value)
            => new DecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element, new DecimalExpressionMediator(new LiteralExpression<decimal>(value)) });

        public static NullableDecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element, decimal? value)
            => new NullableDecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(value)) });

        public static NullableDecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element1, DecimalElement element2)
            => new NullableDecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element1 }, element2);

        public static NullableDecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element1, NullableDecimalElement element2)
            => new NullableDecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element1 }, element2);

        public static DecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element1, AnyDecimalElement element2, decimal value)
            => new DecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element1, element2, new DecimalExpressionMediator(new LiteralExpression<decimal>(value)) });

        public static NullableDecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element1, AnyDecimalElement element2, decimal? value)
            => new NullableDecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element1, element2, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(value)) });

        public static NullableDecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element1, AnyDecimalElement element2, DecimalElement element3)
            => new NullableDecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element1, element2 }, element3);

        public static NullableDecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element1, AnyDecimalElement element2, NullableDecimalElement element3)
            => new NullableDecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element1, element2 }, element3);

        public static DecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element1, AnyDecimalElement element2, AnyDecimalElement element3, decimal value)
            => new DecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element1, element2, element3, new DecimalExpressionMediator(new LiteralExpression<decimal>(value)) });

        public static NullableDecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element1, AnyDecimalElement element2, AnyDecimalElement element3, decimal? value)
            => new NullableDecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element1, element2, element3, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(value)) });

        public static NullableDecimalCoalesceFunctionExpression Coalesce(AnyDecimalElement element1, AnyDecimalElement element2, AnyDecimalElement element3, AnyDecimalElement element4, params AnyDecimalElement[] elements)
            => new NullableDecimalCoalesceFunctionExpression(new List<AnyDecimalElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region Enum
        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)) });

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element, new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(value)) });

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element1, EnumElement<TEnum> element2)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element1 }, element2);

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element1, NullableEnumElement<TEnum> element2)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element1 }, element2);

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element1, AnyEnumElement<TEnum> element2, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element1, element2, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)) });

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element1, AnyEnumElement<TEnum> element2, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element1, element2, new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(value)) });

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element1, AnyEnumElement<TEnum> element2, EnumElement<TEnum> element3)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element1, element2 }, element3);

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element1, AnyEnumElement<TEnum> element2, NullableEnumElement<TEnum> element3)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element1, element2 }, element3);

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element1, AnyEnumElement<TEnum> element2, AnyEnumElement<TEnum> element3, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element1, element2, element3, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)) });

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element1, AnyEnumElement<TEnum> element2, AnyEnumElement<TEnum> element3, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element1, element2, element3, new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(value)) });

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(AnyEnumElement<TEnum> element1, AnyEnumElement<TEnum> element2, AnyEnumElement<TEnum> element3, AnyEnumElement<TEnum> element4, params AnyEnumElement<TEnum>[] elements)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<AnyEnumElement<TEnum>> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region float
        public static SingleCoalesceFunctionExpression Coalesce(AnySingleElement element, float value)
            => new SingleCoalesceFunctionExpression(new List<AnySingleElement> { element, new SingleExpressionMediator(new LiteralExpression<float>(value)) });

        public static NullableSingleCoalesceFunctionExpression Coalesce(AnySingleElement element, float? value)
            => new NullableSingleCoalesceFunctionExpression(new List<AnySingleElement> { element, new NullableSingleExpressionMediator(new LiteralExpression<float?>(value)) });

        public static NullableSingleCoalesceFunctionExpression Coalesce(AnySingleElement element1, SingleElement element2)
            => new NullableSingleCoalesceFunctionExpression(new List<AnySingleElement> { element1 }, element2);

        public static NullableSingleCoalesceFunctionExpression Coalesce(AnySingleElement element1, NullableSingleElement element2)
            => new NullableSingleCoalesceFunctionExpression(new List<AnySingleElement> { element1 }, element2);

        public static SingleCoalesceFunctionExpression Coalesce(AnySingleElement element1, AnySingleElement element2, float value)
            => new SingleCoalesceFunctionExpression(new List<AnySingleElement> { element1, element2, new SingleExpressionMediator(new LiteralExpression<float>(value)) });

        public static NullableSingleCoalesceFunctionExpression Coalesce(AnySingleElement element1, AnySingleElement element2, float? value)
            => new NullableSingleCoalesceFunctionExpression(new List<AnySingleElement> { element1, element2, new NullableSingleExpressionMediator(new LiteralExpression<float?>(value)) });

        public static NullableSingleCoalesceFunctionExpression Coalesce(AnySingleElement element1, AnySingleElement element2, SingleElement element3)
            => new NullableSingleCoalesceFunctionExpression(new List<AnySingleElement> { element1, element2 }, element3);

        public static NullableSingleCoalesceFunctionExpression Coalesce(AnySingleElement element1, AnySingleElement element2, NullableSingleElement element3)
            => new NullableSingleCoalesceFunctionExpression(new List<AnySingleElement> { element1, element2 }, element3);

        public static SingleCoalesceFunctionExpression Coalesce(AnySingleElement element1, AnySingleElement element2, AnySingleElement element3, float value)
            => new SingleCoalesceFunctionExpression(new List<AnySingleElement> { element1, element2, element3, new SingleExpressionMediator(new LiteralExpression<float>(value)) });

        public static NullableSingleCoalesceFunctionExpression Coalesce(AnySingleElement element1, AnySingleElement element2, AnySingleElement element3, float? value)
            => new NullableSingleCoalesceFunctionExpression(new List<AnySingleElement> { element1, element2, element3, new NullableSingleExpressionMediator(new LiteralExpression<float?>(value)) });

        public static NullableSingleCoalesceFunctionExpression Coalesce(AnySingleElement element1, AnySingleElement element2, AnySingleElement element3, AnySingleElement element4, params AnySingleElement[] elements)
            => new NullableSingleCoalesceFunctionExpression(new List<AnySingleElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region Guid
        public static GuidCoalesceFunctionExpression Coalesce(AnyGuidElement element, decimal value)
           => new GuidCoalesceFunctionExpression(new List<AnyGuidElement> { element, new GuidExpressionMediator(new LiteralExpression<decimal>(value)) });

        public static NullableGuidCoalesceFunctionExpression Coalesce(AnyGuidElement element, decimal? value)
            => new NullableGuidCoalesceFunctionExpression(new List<AnyGuidElement> { element, new NullableGuidExpressionMediator(new LiteralExpression<decimal?>(value)) });

        public static NullableGuidCoalesceFunctionExpression Coalesce(AnyGuidElement element1, GuidElement element2)
            => new NullableGuidCoalesceFunctionExpression(new List<AnyGuidElement> { element1 }, element2);

        public static NullableGuidCoalesceFunctionExpression Coalesce(AnyGuidElement element1, NullableGuidElement element2)
            => new NullableGuidCoalesceFunctionExpression(new List<AnyGuidElement> { element1 }, element2);

        public static GuidCoalesceFunctionExpression Coalesce(AnyGuidElement element1, AnyGuidElement element2, decimal value)
            => new GuidCoalesceFunctionExpression(new List<AnyGuidElement> { element1, element2, new GuidExpressionMediator(new LiteralExpression<decimal>(value)) });

        public static NullableGuidCoalesceFunctionExpression Coalesce(AnyGuidElement element1, AnyGuidElement element2, decimal? value)
            => new NullableGuidCoalesceFunctionExpression(new List<AnyGuidElement> { element1, element2, new NullableGuidExpressionMediator(new LiteralExpression<decimal?>(value)) });

        public static NullableGuidCoalesceFunctionExpression Coalesce(AnyGuidElement element1, AnyGuidElement element2, GuidElement element3)
            => new NullableGuidCoalesceFunctionExpression(new List<AnyGuidElement> { element1, element2 }, element3);

        public static NullableGuidCoalesceFunctionExpression Coalesce(AnyGuidElement element1, AnyGuidElement element2, NullableGuidElement element3)
            => new NullableGuidCoalesceFunctionExpression(new List<AnyGuidElement> { element1, element2 }, element3);

        public static GuidCoalesceFunctionExpression Coalesce(AnyGuidElement element1, AnyGuidElement element2, AnyGuidElement element3, decimal value)
            => new GuidCoalesceFunctionExpression(new List<AnyGuidElement> { element1, element2, element3, new GuidExpressionMediator(new LiteralExpression<decimal>(value)) });

        public static NullableGuidCoalesceFunctionExpression Coalesce(AnyGuidElement element1, AnyGuidElement element2, AnyGuidElement element3, decimal? value)
            => new NullableGuidCoalesceFunctionExpression(new List<AnyGuidElement> { element1, element2, element3, new NullableGuidExpressionMediator(new LiteralExpression<decimal?>(value)) });

        public static NullableGuidCoalesceFunctionExpression Coalesce(AnyGuidElement element1, AnyGuidElement element2, AnyGuidElement element3, AnyGuidElement element4, params AnyGuidElement[] elements)
            => new NullableGuidCoalesceFunctionExpression(new List<AnyGuidElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region short
        public static Int16CoalesceFunctionExpression Coalesce(AnyInt16Element element, short value)
            => new Int16CoalesceFunctionExpression(new List<AnyInt16Element> { element, new Int16ExpressionMediator(new LiteralExpression<int>(value)) });

        public static NullableInt16CoalesceFunctionExpression Coalesce(AnyInt16Element element, short? value)
            => new NullableInt16CoalesceFunctionExpression(new List<AnyInt16Element> { element, new NullableInt16ExpressionMediator(new LiteralExpression<int?>(value)) });

        public static NullableInt16CoalesceFunctionExpression Coalesce(AnyInt16Element element1, Int16Element element2)
            => new NullableInt16CoalesceFunctionExpression(new List<AnyInt16Element> { element1 }, element2);

        public static NullableInt16CoalesceFunctionExpression Coalesce(AnyInt16Element element1, NullableInt16Element element2)
            => new NullableInt16CoalesceFunctionExpression(new List<AnyInt16Element> { element1 }, element2);

        public static Int16CoalesceFunctionExpression Coalesce(AnyInt16Element element1, AnyInt16Element element2, short value)
            => new Int16CoalesceFunctionExpression(new List<AnyInt16Element> { element1, element2, new Int16ExpressionMediator(new LiteralExpression<short>(value)) });

        public static NullableInt16CoalesceFunctionExpression Coalesce(AnyInt16Element element1, AnyInt16Element element2, short? value)
            => new NullableInt16CoalesceFunctionExpression(new List<AnyInt16Element> { element1, element2, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(value)) });

        public static NullableInt16CoalesceFunctionExpression Coalesce(AnyInt16Element element1, AnyInt16Element element2, Int16Element element3)
            => new NullableInt16CoalesceFunctionExpression(new List<AnyInt16Element> { element1, element2 }, element3);

        public static NullableInt16CoalesceFunctionExpression Coalesce(AnyInt16Element element1, AnyInt16Element element2, NullableInt16Element element3)
            => new NullableInt16CoalesceFunctionExpression(new List<AnyInt16Element> { element1, element2 }, element3);

        public static Int16CoalesceFunctionExpression Coalesce(AnyInt16Element element1, AnyInt16Element element2, AnyInt16Element element3, short value)
            => new Int16CoalesceFunctionExpression(new List<AnyInt16Element> { element1, element2, element3, new Int16ExpressionMediator(new LiteralExpression<short>(value)) });

        public static NullableInt16CoalesceFunctionExpression Coalesce(AnyInt16Element element1, AnyInt16Element element2, AnyInt16Element element3, short? value)
            => new NullableInt16CoalesceFunctionExpression(new List<AnyInt16Element> { element1, element2, element3, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(value)) });

        public static NullableInt16CoalesceFunctionExpression Coalesce(AnyInt16Element element1, AnyInt16Element element2, AnyInt16Element element3, AnyInt16Element element4, params AnyInt16Element[] elements)
            => new NullableInt16CoalesceFunctionExpression(new List<AnyInt16Element> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region int
        public static Int32CoalesceFunctionExpression Coalesce(AnyInt32Element element, int value)
            => new Int32CoalesceFunctionExpression(new List<AnyInt32Element> { element, new Int32ExpressionMediator(new LiteralExpression<int>(value)) });

        public static NullableInt32CoalesceFunctionExpression Coalesce(AnyInt32Element element, int? value)
            => new NullableInt32CoalesceFunctionExpression(new List<AnyInt32Element> { element, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(value)) });

        public static NullableInt32CoalesceFunctionExpression Coalesce(AnyInt32Element element1, Int32Element element2)
            => new NullableInt32CoalesceFunctionExpression(new List<AnyInt32Element> { element1 }, element2);

        public static NullableInt32CoalesceFunctionExpression Coalesce(AnyInt32Element element1, NullableInt32Element element2)
            => new NullableInt32CoalesceFunctionExpression(new List<AnyInt32Element> { element1 }, element2);

        public static Int32CoalesceFunctionExpression Coalesce(AnyInt32Element element1, AnyInt32Element element2, int value)
            => new Int32CoalesceFunctionExpression(new List<AnyInt32Element> { element1, element2, new Int32ExpressionMediator(new LiteralExpression<int>(value)) });

        public static NullableInt32CoalesceFunctionExpression Coalesce(AnyInt32Element element1, AnyInt32Element element2, int? value)
            => new NullableInt32CoalesceFunctionExpression(new List<AnyInt32Element> { element1, element2, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(value)) });

        public static NullableInt32CoalesceFunctionExpression Coalesce(AnyInt32Element element1, AnyInt32Element element2, Int32Element element3)
            => new NullableInt32CoalesceFunctionExpression(new List<AnyInt32Element> { element1, element2 }, element3);

        public static NullableInt32CoalesceFunctionExpression Coalesce(AnyInt32Element element1, AnyInt32Element element2, NullableInt32Element element3)
            => new NullableInt32CoalesceFunctionExpression(new List<AnyInt32Element> { element1, element2 }, element3);

        public static Int32CoalesceFunctionExpression Coalesce(AnyInt32Element element1, AnyInt32Element element2, AnyInt32Element element3, int value)
            => new Int32CoalesceFunctionExpression(new List<AnyInt32Element> { element1, element2, element3, new Int32ExpressionMediator(new LiteralExpression<int>(value)) });

        public static NullableInt32CoalesceFunctionExpression Coalesce(AnyInt32Element element1, AnyInt32Element element2, AnyInt32Element element3, int? value)
            => new NullableInt32CoalesceFunctionExpression(new List<AnyInt32Element> { element1, element2, element3, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(value)) });

        public static NullableInt32CoalesceFunctionExpression Coalesce(AnyInt32Element element1, AnyInt32Element element2, AnyInt32Element element3, AnyInt32Element element4, params AnyInt32Element[] elements)
            => new NullableInt32CoalesceFunctionExpression(new List<AnyInt32Element> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region long
        public static Int64CoalesceFunctionExpression Coalesce(AnyInt64Element element, long value)
            => new Int64CoalesceFunctionExpression(new List<AnyInt64Element> { element, new Int64ExpressionMediator(new LiteralExpression<long>(value)) });

        public static NullableInt64CoalesceFunctionExpression Coalesce(AnyInt64Element element, long? value)
            => new NullableInt64CoalesceFunctionExpression(new List<AnyInt64Element> { element, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(value)) });

        public static NullableInt64CoalesceFunctionExpression Coalesce(AnyInt64Element element1, Int64Element element2)
            => new NullableInt64CoalesceFunctionExpression(new List<AnyInt64Element> { element1 }, element2);

        public static NullableInt64CoalesceFunctionExpression Coalesce(AnyInt64Element element1, NullableInt64Element element2)
            => new NullableInt64CoalesceFunctionExpression(new List<AnyInt64Element> { element1 }, element2);

        public static Int64CoalesceFunctionExpression Coalesce(AnyInt64Element element1, AnyInt64Element element2, long value)
            => new Int64CoalesceFunctionExpression(new List<AnyInt64Element> { element1, element2, new Int64ExpressionMediator(new LiteralExpression<long>(value)) });

        public static NullableInt64CoalesceFunctionExpression Coalesce(AnyInt64Element element1, AnyInt64Element element2, long? value)
            => new NullableInt64CoalesceFunctionExpression(new List<AnyInt64Element> { element1, element2, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(value)) });

        public static NullableInt64CoalesceFunctionExpression Coalesce(AnyInt64Element element1, AnyInt64Element element2, Int64Element element3)
            => new NullableInt64CoalesceFunctionExpression(new List<AnyInt64Element> { element1, element2 }, element3);

        public static NullableInt64CoalesceFunctionExpression Coalesce(AnyInt64Element element1, AnyInt64Element element2, NullableInt64Element element3)
            => new NullableInt64CoalesceFunctionExpression(new List<AnyInt64Element> { element1, element2 }, element3);

        public static Int64CoalesceFunctionExpression Coalesce(AnyInt64Element element1, AnyInt64Element element2, AnyInt64Element element3, long value)
            => new Int64CoalesceFunctionExpression(new List<AnyInt64Element> { element1, element2, element3, new Int64ExpressionMediator(new LiteralExpression<long>(value)) });

        public static NullableInt64CoalesceFunctionExpression Coalesce(AnyInt64Element element1, AnyInt64Element element2, AnyInt64Element element3, long? value)
            => new NullableInt64CoalesceFunctionExpression(new List<AnyInt64Element> { element1, element2, element3, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(value)) });

        public static NullableInt64CoalesceFunctionExpression Coalesce(AnyInt64Element element1, AnyInt64Element element2, AnyInt64Element element3, AnyInt64Element element4, params AnyInt64Element[] elements)
            => new NullableInt64CoalesceFunctionExpression(new List<AnyInt64Element> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region string
        public static StringCoalesceFunctionExpression Coalesce(AnyStringElement element, string value)
            => new StringCoalesceFunctionExpression(new List<AnyStringElement> { element, new StringExpressionMediator(new LiteralExpression<string>(value)) });

        public static NullableStringCoalesceFunctionExpression Coalesce(AnyStringElement element1, StringElement element2)
            => new NullableStringCoalesceFunctionExpression(new List<AnyStringElement> { element1 }, element2);

        public static NullableStringCoalesceFunctionExpression Coalesce(AnyStringElement element1, NullableStringElement element2)
            => new NullableStringCoalesceFunctionExpression(new List<AnyStringElement> { element1 }, element2);

        public static StringCoalesceFunctionExpression Coalesce(AnyStringElement element1, AnyStringElement element2, string value)
            => new StringCoalesceFunctionExpression(new List<AnyStringElement> { element1, element2, new StringExpressionMediator(new LiteralExpression<string>(value)) });

        public static NullableStringCoalesceFunctionExpression Coalesce(AnyStringElement element1, AnyStringElement element2, StringElement element3)
            => new NullableStringCoalesceFunctionExpression(new List<AnyStringElement> { element1, element2 }, element3);

        public static NullableStringCoalesceFunctionExpression Coalesce(AnyStringElement element1, AnyStringElement element2, NullableStringElement element3)
            => new NullableStringCoalesceFunctionExpression(new List<AnyStringElement> { element1, element2 }, element3);

        public static StringCoalesceFunctionExpression Coalesce(AnyStringElement element1, AnyStringElement element2, AnyStringElement element3, string value)
            => new StringCoalesceFunctionExpression(new List<AnyStringElement> { element1, element2, element3, new StringExpressionMediator(new LiteralExpression<string>(value)) });

        public static NullableStringCoalesceFunctionExpression Coalesce(AnyStringElement element1, AnyStringElement element2, AnyStringElement element3, AnyStringElement element4, params AnyStringElement[] elements)
            => new NullableStringCoalesceFunctionExpression(new List<AnyStringElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion

        #region TimeSpan
        public static TimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element, TimeSpan value)
            => new TimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(value)) });

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element, TimeSpan? value)
            => new NullableTimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element, new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(value)) });

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element1, TimeSpanElement element2)
            => new NullableTimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element1 }, element2);

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element1, NullableTimeSpanElement element2)
            => new NullableTimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element1 }, element2);

        public static TimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element1, AnyTimeSpanElement element2, TimeSpan value)
            => new TimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element1, element2, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(value)) });

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element1, AnyTimeSpanElement element2, TimeSpan? value)
            => new NullableTimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element1, element2, new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(value)) });

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element1, AnyTimeSpanElement element2, TimeSpanElement element3)
            => new NullableTimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element1, element2 }, element3);

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element1, AnyTimeSpanElement element2, NullableTimeSpanElement element3)
            => new NullableTimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element1, element2 }, element3);

        public static TimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element1, AnyTimeSpanElement element2, AnyTimeSpanElement element3, TimeSpan value)
            => new TimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element1, element2, element3, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(value)) });

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element1, AnyTimeSpanElement element2, AnyTimeSpanElement element3, TimeSpan? value)
            => new NullableTimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element1, element2, element3, new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(value)) });

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(AnyTimeSpanElement element1, AnyTimeSpanElement element2, AnyTimeSpanElement element3, AnyTimeSpanElement element4, params AnyTimeSpanElement[] elements)
            => new NullableTimeSpanCoalesceFunctionExpression(new List<AnyTimeSpanElement> { element1, element2, element3, element4 }.Concat(elements).ToList());
        #endregion
        #endregion

        #region isnull
        #region object
        public static ObjectIsNullFunctionExpression IsNull(AnyObjectElement element1, AnyObjectElement element2)
            => new ObjectIsNullFunctionExpression(element1, element2);

        public static ObjectIsNullFunctionExpression IsNull(AnyObjectElement element, object value)
            => new ObjectIsNullFunctionExpression(element, new ObjectExpressionMediator(new LiteralExpression<object>(value)));
        #endregion

        #region bool
        public static BooleanIsNullFunctionExpression IsNull(AnyBooleanElement element1, BooleanElement element2)
            => new BooleanIsNullFunctionExpression(element1, element2);

        public static NullableBooleanIsNullFunctionExpression IsNull(AnyBooleanElement element1, NullableBooleanElement element2)
            => new NullableBooleanIsNullFunctionExpression(element1, element2);

        public static BooleanIsNullFunctionExpression IsNull(AnyBooleanElement element, bool value)
            => new BooleanIsNullFunctionExpression(element, new BooleanExpressionMediator(new LiteralExpression<bool>(value)));

        public static NullableBooleanIsNullFunctionExpression IsNull(AnyBooleanElement element, bool? value)
            => new NullableBooleanIsNullFunctionExpression(element, new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(value)));
        #endregion

        #region byte
        public static ByteIsNullFunctionExpression IsNull(AnyByteElement element1, ByteElement element2)
            => new ByteIsNullFunctionExpression(element1, element2);

        public static NullableByteIsNullFunctionExpression IsNull(AnyByteElement element1, NullableByteElement element2)
            => new NullableByteIsNullFunctionExpression(element1, element2);

        public static ByteIsNullFunctionExpression IsNull(AnyByteElement element, byte value)
            => new ByteIsNullFunctionExpression(element, new ByteExpressionMediator(new LiteralExpression<byte>(value)));

        public static NullableByteIsNullFunctionExpression IsNull(AnyByteElement element, byte? value)
            => new NullableByteIsNullFunctionExpression(element, new NullableByteExpressionMediator(new LiteralExpression<byte?>(value)));
        #endregion

        #region DateTime
        public static DateTimeIsNullFunctionExpression IsNull(AnyDateTimeElement element1, DateTimeElement element2)
            => new DateTimeIsNullFunctionExpression(element1, element2);

        public static NullableDateTimeIsNullFunctionExpression IsNull(AnyDateTimeElement element1, NullableDateTimeElement element2)
            => new NullableDateTimeIsNullFunctionExpression(element1, element2);

        public static DateTimeIsNullFunctionExpression IsNull(AnyDateTimeElement element, DateTime value)
            => new DateTimeIsNullFunctionExpression(element, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(value)));

        public static NullableDateTimeIsNullFunctionExpression IsNull(AnyDateTimeElement element, DateTime? value)
            => new NullableDateTimeIsNullFunctionExpression(element, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(value)));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetIsNullFunctionExpression IsNull(AnyDateTimeOffsetElement element1, DateTimeOffsetElement element2)
            => new DateTimeOffsetIsNullFunctionExpression(element1, element2);

        public static NullableDateTimeOffsetIsNullFunctionExpression IsNull(AnyDateTimeOffsetElement element1, NullableDateTimeOffsetElement element2)
            => new NullableDateTimeOffsetIsNullFunctionExpression(element1, element2);

        public static DateTimeOffsetIsNullFunctionExpression IsNull(AnyDateTimeOffsetElement element, DateTimeOffset value)
            => new DateTimeOffsetIsNullFunctionExpression(element, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(value)));

        public static NullableDateTimeOffsetIsNullFunctionExpression IsNull(AnyDateTimeOffsetElement element, DateTimeOffset? value)
            => new NullableDateTimeOffsetIsNullFunctionExpression(element, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(value)));
        #endregion

        #region decimal
        public static DecimalIsNullFunctionExpression IsNull(AnyDecimalElement element1, DecimalElement element2)
            => new DecimalIsNullFunctionExpression(element1, element2);

        public static NullableDecimalIsNullFunctionExpression IsNull(AnyDecimalElement element1, NullableDecimalElement element2)
            => new NullableDecimalIsNullFunctionExpression(element1, element2);

        public static DecimalIsNullFunctionExpression IsNull(AnyDecimalElement element, decimal value)
            => new DecimalIsNullFunctionExpression(element, new DecimalExpressionMediator(new LiteralExpression<decimal>(value)));

        public static NullableDecimalIsNullFunctionExpression IsNull(AnyDecimalElement element, decimal? value)
            => new NullableDecimalIsNullFunctionExpression(element, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(value)));
        #endregion

        #region double
        public static DoubleIsNullFunctionExpression IsNull(AnyDoubleElement element1, DoubleElement element2)
            => new DoubleIsNullFunctionExpression(element1, element2);

        public static NullableDoubleIsNullFunctionExpression IsNull(AnyDoubleElement element1, NullableDoubleElement element2)
            => new NullableDoubleIsNullFunctionExpression(element1, element2);

        public static DoubleIsNullFunctionExpression IsNull(AnyDoubleElement element, double value)
            => new DoubleIsNullFunctionExpression(element, new DoubleExpressionMediator(new LiteralExpression<double>(value)));

        public static NullableDoubleIsNullFunctionExpression IsNull(AnyDoubleElement element, double? value)
            => new NullableDoubleIsNullFunctionExpression(element, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(value)));
        #endregion

        #region Enum
        public static EnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(AnyEnumElement<TEnum> element1, EnumElement<TEnum> element2)
            where TEnum : struct, Enum, IComparable
            => new EnumIsNullFunctionExpression<TEnum>(element1, element2);

        public static NullableEnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(AnyEnumElement<TEnum> element1, NullableEnumElement<TEnum> element2)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumIsNullFunctionExpression<TEnum>(element1, element2);

        public static EnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(AnyEnumElement<TEnum> element, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumIsNullFunctionExpression<TEnum>(element, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)));

        public static NullableEnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(AnyEnumElement<TEnum> element, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumIsNullFunctionExpression<TEnum>(element, new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(value)));
        #endregion

        #region float
        public static SingleIsNullFunctionExpression IsNull(AnySingleElement element1, SingleElement element2)
            => new SingleIsNullFunctionExpression(element1, element2);

        public static NullableSingleIsNullFunctionExpression IsNull(AnySingleElement element1, NullableSingleElement element2)
            => new NullableSingleIsNullFunctionExpression(element1, element2);

        public static SingleIsNullFunctionExpression IsNull(AnySingleElement element, float value)
            => new SingleIsNullFunctionExpression(element, new SingleExpressionMediator(new LiteralExpression<float>(value)));

        public static NullableSingleIsNullFunctionExpression IsNull(AnySingleElement element, float? value)
            => new NullableSingleIsNullFunctionExpression(element, new NullableSingleExpressionMediator(new LiteralExpression<float?>(value)));
        #endregion

        #region Guid
        public static GuidIsNullFunctionExpression IsNull(AnyGuidElement element1, GuidElement element2)
            => new GuidIsNullFunctionExpression(element1, element2);

        public static NullableGuidIsNullFunctionExpression IsNull(AnyGuidElement element1, NullableGuidElement element2)
            => new NullableGuidIsNullFunctionExpression(element1, element2);

        public static GuidIsNullFunctionExpression IsNull(AnyGuidElement element, Guid value)
            => new GuidIsNullFunctionExpression(element, new GuidExpressionMediator(new LiteralExpression<Guid>(value)));

        public static NullableGuidIsNullFunctionExpression IsNull(AnyGuidElement element, Guid? value)
            => new NullableGuidIsNullFunctionExpression(element, new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(value)));
        #endregion

        #region short
        public static Int16IsNullFunctionExpression IsNull(AnyInt16Element element1, Int16Element element2)
            => new Int16IsNullFunctionExpression(element1, element2);

        public static NullableInt16IsNullFunctionExpression IsNull(AnyInt16Element element1, NullableInt16Element element2)
            => new NullableInt16IsNullFunctionExpression(element1, element2);

        public static Int16IsNullFunctionExpression IsNull(AnyInt16Element element, short value)
            => new Int16IsNullFunctionExpression(element, new Int16ExpressionMediator(new LiteralExpression<short>(value)));

        public static NullableInt16IsNullFunctionExpression IsNull(AnyInt16Element element, short? value)
            => new NullableInt16IsNullFunctionExpression(element, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(value)));
        #endregion

        #region int
        public static Int32IsNullFunctionExpression IsNull(AnyInt32Element element1, Int32Element element2)
            => new Int32IsNullFunctionExpression(element1, element2);

        public static NullableInt32IsNullFunctionExpression IsNull(AnyInt32Element element1, NullableInt32Element element2)
            => new NullableInt32IsNullFunctionExpression(element1, element2);

        public static Int32IsNullFunctionExpression IsNull(AnyInt32Element element, int value)
            => new Int32IsNullFunctionExpression(element, new Int32ExpressionMediator(new LiteralExpression<int>(value)));

        public static NullableInt32IsNullFunctionExpression IsNull(AnyInt32Element element, int? value)
            => new NullableInt32IsNullFunctionExpression(element, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(value)));
        #endregion

        #region long
        public static Int64IsNullFunctionExpression IsNull(AnyInt64Element element1, Int64Element element2)
            => new Int64IsNullFunctionExpression(element1, element2);

        public static NullableInt64IsNullFunctionExpression IsNull(AnyInt64Element element1, NullableInt64Element element2)
            => new NullableInt64IsNullFunctionExpression(element1, element2);

        public static Int64IsNullFunctionExpression IsNull(AnyInt64Element element, long value)
            => new Int64IsNullFunctionExpression(element, new Int64ExpressionMediator(new LiteralExpression<long>(value)));

        public static NullableInt64IsNullFunctionExpression IsNull(AnyInt64Element element, long? value)
            => new NullableInt64IsNullFunctionExpression(element, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(value)));
        #endregion

        #region string
        public static StringIsNullFunctionExpression IsNull(AnyStringElement element1, StringElement element2)
            => new StringIsNullFunctionExpression(element1, element2);

        public static NullableStringIsNullFunctionExpression IsNull(AnyStringElement element1, NullableStringElement element2)
            => new NullableStringIsNullFunctionExpression(element1, element2);

        public static StringIsNullFunctionExpression IsNull(AnyStringElement element, string value)
            => new StringIsNullFunctionExpression(element, new StringExpressionMediator(new LiteralExpression<string>(value)));
        #endregion

        #region TimeSpan
        public static TimeSpanIsNullFunctionExpression IsNull(AnyTimeSpanElement element1, TimeSpanElement element2)
            => new TimeSpanIsNullFunctionExpression(element1, element2);

        public static NullableTimeSpanIsNullFunctionExpression IsNull(AnyTimeSpanElement element1, NullableTimeSpanElement element2)
            => new NullableTimeSpanIsNullFunctionExpression(element1, element2);

        public static TimeSpanIsNullFunctionExpression IsNull(AnyTimeSpanElement element, TimeSpan value)
            => new TimeSpanIsNullFunctionExpression(element, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(value)));

        public static NullableTimeSpanIsNullFunctionExpression IsNull(AnyTimeSpanElement element, TimeSpan? value)
            => new NullableTimeSpanIsNullFunctionExpression(element, new NullableTimeSpanExpressionMediator(new LiteralExpression<TimeSpan?>(value)));
        #endregion
        #endregion

        #region average
        public static ObjectAverageFunctionExpression Avg(AnyObjectElement element)
            => new ObjectAverageFunctionExpression(element);

        public static Int32AverageFunctionExpression Avg(ByteElement element)
            => new Int32AverageFunctionExpression(element);

        public static NullableInt32AverageFunctionExpression Avg(NullableByteElement element)
            => new NullableInt32AverageFunctionExpression(element);

        public static Int32AverageFunctionExpression Avg(Int16Element element)
            => new Int32AverageFunctionExpression(element);

        public static NullableInt32AverageFunctionExpression Avg(NullableInt16Element element)
            => new NullableInt32AverageFunctionExpression(element);

        public static Int32AverageFunctionExpression Avg(Int32Element element)
            => new Int32AverageFunctionExpression(element);

        public static NullableInt32AverageFunctionExpression Avg(NullableInt32Element element)
            => new NullableInt32AverageFunctionExpression(element);

        public static Int64AverageFunctionExpression Avg(Int64Element element)
            => new Int64AverageFunctionExpression(element);

        public static NullableInt64AverageFunctionExpression Avg(NullableInt64Element element)
            => new NullableInt64AverageFunctionExpression(element);

        public static SingleAverageFunctionExpression Avg(SingleElement element)
            => new SingleAverageFunctionExpression(element);

        public static NullableSingleAverageFunctionExpression Avg(NullableSingleElement element)
            => new NullableSingleAverageFunctionExpression(element);

        public static DoubleAverageFunctionExpression Avg(DoubleElement element)
            => new DoubleAverageFunctionExpression(element);

        public static NullableDoubleAverageFunctionExpression Avg(NullableDoubleElement element)
            => new NullableDoubleAverageFunctionExpression(element);

        public static DecimalAverageFunctionExpression Avg(DecimalElement element)
            => new DecimalAverageFunctionExpression(element);

        public static NullableDecimalAverageFunctionExpression Avg(NullableDecimalElement element)
            => new NullableDecimalAverageFunctionExpression(element);
        #endregion

        #region minimum
        public static ObjectMinimumFunctionExpression Min(AnyObjectElement element)
            => new ObjectMinimumFunctionExpression(element);

        public static ByteMinimumFunctionExpression Min(ByteElement element)
            => new ByteMinimumFunctionExpression(element);

        public static NullableByteMinimumFunctionExpression Min(NullableByteElement element)
            => new NullableByteMinimumFunctionExpression(element);

        public static Int16MinimumFunctionExpression Min(Int16Element element)
            => new Int16MinimumFunctionExpression(element);

        public static NullableInt16MinimumFunctionExpression Min(NullableInt16Element element)
            => new NullableInt16MinimumFunctionExpression(element);

        public static Int32MinimumFunctionExpression Min(Int32Element element)
            => new Int32MinimumFunctionExpression(element);

        public static NullableInt32MinimumFunctionExpression Min(NullableInt32Element element)
            => new NullableInt32MinimumFunctionExpression(element);

        public static Int64MinimumFunctionExpression Min(Int64Element element)
            => new Int64MinimumFunctionExpression(element);

        public static NullableInt64MinimumFunctionExpression Min(NullableInt64Element element)
            => new NullableInt64MinimumFunctionExpression(element);

        public static SingleMinimumFunctionExpression Min(SingleElement element)
            => new SingleMinimumFunctionExpression(element);

        public static NullableSingleMinimumFunctionExpression Min(NullableSingleElement element)
            => new NullableSingleMinimumFunctionExpression(element);

        public static DoubleMinimumFunctionExpression Min(DoubleElement element)
            => new DoubleMinimumFunctionExpression(element);

        public static NullableDoubleMinimumFunctionExpression Min(NullableDoubleElement element)
            => new NullableDoubleMinimumFunctionExpression(element);

        public static DecimalMinimumFunctionExpression Min(DecimalElement element)
            => new DecimalMinimumFunctionExpression(element);

        public static NullableDecimalMinimumFunctionExpression Min(NullableDecimalElement element)
            => new NullableDecimalMinimumFunctionExpression(element);

        public static DateTimeMinimumFunctionExpression Min(DateTimeElement element)
            => new DateTimeMinimumFunctionExpression(element);

        public static NullableDateTimeMinimumFunctionExpression Min(NullableDateTimeElement element)
            => new NullableDateTimeMinimumFunctionExpression(element);

        public static DateTimeOffsetMinimumFunctionExpression Min(DateTimeOffsetElement element)
            => new DateTimeOffsetMinimumFunctionExpression(element);

        public static NullableDateTimeOffsetMinimumFunctionExpression Min(NullableDateTimeOffsetElement element)
            => new NullableDateTimeOffsetMinimumFunctionExpression(element);

        public static GuidMinimumFunctionExpression Min(GuidElement element)
            => new GuidMinimumFunctionExpression(element);

        public static NullableGuidMinimumFunctionExpression Min(NullableGuidElement element)
            => new NullableGuidMinimumFunctionExpression(element);

        public static StringMinimumFunctionExpression Min(StringElement element)
            => new StringMinimumFunctionExpression(element);

        public static TimeSpanMinimumFunctionExpression Min(TimeSpanElement element)
            => new TimeSpanMinimumFunctionExpression(element);

        public static NullableTimeSpanMinimumFunctionExpression Min(NullableTimeSpanElement element)
            => new NullableTimeSpanMinimumFunctionExpression(element);
        #endregion

        #region maximum
        public static ObjectMaximumFunctionExpression Max(AnyObjectElement element)
            => new ObjectMaximumFunctionExpression(element);

        public static ByteMaximumFunctionExpression Max(ByteElement element)
            => new ByteMaximumFunctionExpression(element);

        public static NullableByteMaximumFunctionExpression Max(NullableByteElement element)
            => new NullableByteMaximumFunctionExpression(element);

        public static Int16MaximumFunctionExpression Max(Int16Element element)
            => new Int16MaximumFunctionExpression(element);

        public static NullableInt16MaximumFunctionExpression Max(NullableInt16Element element)
            => new NullableInt16MaximumFunctionExpression(element);

        public static Int32MaximumFunctionExpression Max(Int32Element element)
            => new Int32MaximumFunctionExpression(element);

        public static NullableInt32MaximumFunctionExpression Max(NullableInt32Element element)
            => new NullableInt32MaximumFunctionExpression(element);

        public static Int64MaximumFunctionExpression Max(Int64Element element)
            => new Int64MaximumFunctionExpression(element);

        public static NullableInt64MaximumFunctionExpression Max(NullableInt64Element element)
            => new NullableInt64MaximumFunctionExpression(element);

        public static SingleMaximumFunctionExpression Max(SingleElement element)
            => new SingleMaximumFunctionExpression(element);

        public static NullableSingleMaximumFunctionExpression Max(NullableSingleElement element)
            => new NullableSingleMaximumFunctionExpression(element);

        public static DoubleMaximumFunctionExpression Max(DoubleElement element)
            => new DoubleMaximumFunctionExpression(element);

        public static NullableDoubleMaximumFunctionExpression Max(NullableDoubleElement element)
            => new NullableDoubleMaximumFunctionExpression(element);

        public static DecimalMaximumFunctionExpression Max(DecimalElement element)
            => new DecimalMaximumFunctionExpression(element);

        public static NullableDecimalMaximumFunctionExpression Max(NullableDecimalElement element)
            => new NullableDecimalMaximumFunctionExpression(element);

        public static DateTimeMaximumFunctionExpression Max(DateTimeElement element)
            => new DateTimeMaximumFunctionExpression(element);

        public static NullableDateTimeMaximumFunctionExpression Max(NullableDateTimeElement element)
            => new NullableDateTimeMaximumFunctionExpression(element);

        public static DateTimeOffsetMaximumFunctionExpression Max(DateTimeOffsetElement element)
            => new DateTimeOffsetMaximumFunctionExpression(element);

        public static NullableDateTimeOffsetMaximumFunctionExpression Max(NullableDateTimeOffsetElement element)
            => new NullableDateTimeOffsetMaximumFunctionExpression(element);

        public static GuidMaximumFunctionExpression Max(GuidElement element)
            => new GuidMaximumFunctionExpression(element);

        public static NullableGuidMaximumFunctionExpression Max(NullableGuidElement element)
            => new NullableGuidMaximumFunctionExpression(element);

        public static StringMaximumFunctionExpression Max(StringElement element)
            => new StringMaximumFunctionExpression(element);

        public static TimeSpanMaximumFunctionExpression Max(TimeSpanElement element)
            => new TimeSpanMaximumFunctionExpression(element);

        public static NullableTimeSpanMaximumFunctionExpression Max(NullableTimeSpanElement element)
            => new NullableTimeSpanMaximumFunctionExpression(element);
        #endregion

        #region count
        public static Int32CountFunctionExpression Count()
            => new Int32CountFunctionExpression();

        public static Int32CountFunctionExpression Count(AnyElement element)
            => new Int32CountFunctionExpression(element);
        #endregion

        #region sum
        public static ObjectSumFunctionExpression Sum(AnyObjectElement element)
            => new ObjectSumFunctionExpression(element);

        public static Int32SumFunctionExpression Sum(ByteElement element)
            => new Int32SumFunctionExpression(element);

        public static NullableInt32SumFunctionExpression Sum(NullableByteElement element)
            => new NullableInt32SumFunctionExpression(element);

        public static Int32SumFunctionExpression Sum(Int16Element element)
            => new Int32SumFunctionExpression(element);

        public static NullableInt32SumFunctionExpression Sum(NullableInt16Element element)
            => new NullableInt32SumFunctionExpression(element);

        public static Int32SumFunctionExpression Sum(Int32Element element)
            => new Int32SumFunctionExpression(element);

        public static NullableInt32SumFunctionExpression Sum(NullableInt32Element element)
            => new NullableInt32SumFunctionExpression(element);

        public static Int64SumFunctionExpression Sum(Int64Element element)
            => new Int64SumFunctionExpression(element);

        public static NullableInt64SumFunctionExpression Sum(NullableInt64Element element)
            => new NullableInt64SumFunctionExpression(element);

        public static DoubleSumFunctionExpression Sum(DoubleElement element)
            => new DoubleSumFunctionExpression(element);

        public static NullableDoubleSumFunctionExpression Sum(NullableDoubleElement element)
            => new NullableDoubleSumFunctionExpression(element);

        public static DecimalSumFunctionExpression Sum(DecimalElement element)
            => new DecimalSumFunctionExpression(element);

        public static NullableDecimalSumFunctionExpression Sum(NullableDecimalElement element)
            => new NullableDecimalSumFunctionExpression(element);

        public static SingleSumFunctionExpression Sum(SingleElement element)
            => new SingleSumFunctionExpression(element);

        public static NullableSingleSumFunctionExpression Sum(NullableSingleElement element)
            => new NullableSingleSumFunctionExpression(element);
        #endregion

        #region standard deviation
        public static ObjectStandardDeviationFunctionExpression StDev(AnyObjectElement element)
            => new ObjectStandardDeviationFunctionExpression(element);

        public static SingleStandardDeviationFunctionExpression StDev(ByteElement element)
            => new SingleStandardDeviationFunctionExpression(element);

        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableByteElement element)
            => new NullableSingleStandardDeviationFunctionExpression(element);

        public static SingleStandardDeviationFunctionExpression StDev(Int16Element element)
            => new SingleStandardDeviationFunctionExpression(element);

        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableInt16Element element)
            => new NullableSingleStandardDeviationFunctionExpression(element);

        public static SingleStandardDeviationFunctionExpression StDev(Int32Element element)
            => new SingleStandardDeviationFunctionExpression(element);

        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableInt32Element element)
            => new NullableSingleStandardDeviationFunctionExpression(element);

        public static SingleStandardDeviationFunctionExpression StDev(Int64Element element)
            => new SingleStandardDeviationFunctionExpression(element);

        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableInt64Element element)
            => new NullableSingleStandardDeviationFunctionExpression(element);

        public static SingleStandardDeviationFunctionExpression StDev(DoubleElement element)
            => new SingleStandardDeviationFunctionExpression(element);

        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableDoubleElement element)
            => new NullableSingleStandardDeviationFunctionExpression(element);

        public static SingleStandardDeviationFunctionExpression StDev(DecimalElement element)
            => new SingleStandardDeviationFunctionExpression(element);

        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableDecimalElement element)
            => new NullableSingleStandardDeviationFunctionExpression(element);

        public static SingleStandardDeviationFunctionExpression StDev(SingleElement element)
            => new SingleStandardDeviationFunctionExpression(element);

        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableSingleElement element)
            => new NullableSingleStandardDeviationFunctionExpression(element);
        #endregion

        #region standard deviation p
        public static ObjectPopulationStandardDeviationFunctionExpression StDevP(AnyObjectElement element)
            => new ObjectPopulationStandardDeviationFunctionExpression(element);

        public static SinglePopulationStandardDeviationFunctionExpression StDevP(ByteElement element)
            => new SinglePopulationStandardDeviationFunctionExpression(element);

        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableByteElement element)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(element);

        public static SinglePopulationStandardDeviationFunctionExpression StDevP(Int16Element element)
            => new SinglePopulationStandardDeviationFunctionExpression(element);

        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableInt16Element element)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(element);

        public static SinglePopulationStandardDeviationFunctionExpression StDevP(Int32Element element)
            => new SinglePopulationStandardDeviationFunctionExpression(element);

        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableInt32Element element)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(element);

        public static SinglePopulationStandardDeviationFunctionExpression StDevP(Int64Element element)
            => new SinglePopulationStandardDeviationFunctionExpression(element);

        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableInt64Element element)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(element);

        public static SinglePopulationStandardDeviationFunctionExpression StDevP(DoubleElement element)
            => new SinglePopulationStandardDeviationFunctionExpression(element);

        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableDoubleElement element)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(element);

        public static SinglePopulationStandardDeviationFunctionExpression StDevP(DecimalElement element)
            => new SinglePopulationStandardDeviationFunctionExpression(element);

        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableDecimalElement element)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(element);

        public static SinglePopulationStandardDeviationFunctionExpression StDevP(SingleElement element)
            => new SinglePopulationStandardDeviationFunctionExpression(element);

        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableSingleElement element)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(element);
        #endregion

        #region variance
        public static ObjectVarianceFunctionExpression Var(AnyObjectElement element)
            => new ObjectVarianceFunctionExpression(element);

        public static SingleVarianceFunctionExpression Var(ByteElement element)
            => new SingleVarianceFunctionExpression(element);

        public static NullableSingleVarianceFunctionExpression Var(NullableByteElement element)
            => new NullableSingleVarianceFunctionExpression(element);

        public static SingleVarianceFunctionExpression Var(Int16Element element)
            => new SingleVarianceFunctionExpression(element);

        public static NullableSingleVarianceFunctionExpression Var(NullableInt16Element element)
            => new NullableSingleVarianceFunctionExpression(element);

        public static SingleVarianceFunctionExpression Var(Int32Element element)
            => new SingleVarianceFunctionExpression(element);

        public static NullableSingleVarianceFunctionExpression Var(NullableInt32Element element)
            => new NullableSingleVarianceFunctionExpression(element);

        public static SingleVarianceFunctionExpression Var(Int64Element element)
            => new SingleVarianceFunctionExpression(element);

        public static NullableSingleVarianceFunctionExpression Var(NullableInt64Element element)
            => new NullableSingleVarianceFunctionExpression(element);

        public static SingleVarianceFunctionExpression Var(DoubleElement element)
            => new SingleVarianceFunctionExpression(element);

        public static NullableSingleVarianceFunctionExpression Var(NullableDoubleElement element)
            => new NullableSingleVarianceFunctionExpression(element);

        public static SingleVarianceFunctionExpression Var(DecimalElement element)
            => new SingleVarianceFunctionExpression(element);

        public static NullableSingleVarianceFunctionExpression Var(NullableDecimalElement element)
            => new NullableSingleVarianceFunctionExpression(element);

        public static SingleVarianceFunctionExpression Var(SingleElement element)
            => new SingleVarianceFunctionExpression(element);

        public static NullableSingleVarianceFunctionExpression Var(NullableSingleElement element)
            => new NullableSingleVarianceFunctionExpression(element);
        #endregion

        #region variance p
        public static ObjectPopulationVarianceFunctionExpression VarP(AnyObjectElement element)
            => new ObjectPopulationVarianceFunctionExpression(element);

        public static SinglePopulationVarianceFunctionExpression VarP(ByteElement element)
            => new SinglePopulationVarianceFunctionExpression(element);

        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableByteElement element)
            => new NullableSinglePopulationVarianceFunctionExpression(element);

        public static SinglePopulationVarianceFunctionExpression VarP(Int16Element element)
            => new SinglePopulationVarianceFunctionExpression(element);

        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableInt16Element element)
            => new NullableSinglePopulationVarianceFunctionExpression(element);

        public static SinglePopulationVarianceFunctionExpression VarP(Int32Element element)
            => new SinglePopulationVarianceFunctionExpression(element);

        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableInt32Element element)
            => new NullableSinglePopulationVarianceFunctionExpression(element);

        public static SinglePopulationVarianceFunctionExpression VarP(Int64Element element)
            => new SinglePopulationVarianceFunctionExpression(element);

        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableInt64Element element)
            => new NullableSinglePopulationVarianceFunctionExpression(element);

        public static SinglePopulationVarianceFunctionExpression VarP(DoubleElement element)
            => new SinglePopulationVarianceFunctionExpression(element);

        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableDoubleElement element)
            => new NullableSinglePopulationVarianceFunctionExpression(element);

        public static SinglePopulationVarianceFunctionExpression VarP(DecimalElement element)
            => new SinglePopulationVarianceFunctionExpression(element);

        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableDecimalElement element)
            => new NullableSinglePopulationVarianceFunctionExpression(element);

        public static SinglePopulationVarianceFunctionExpression VarP(SingleElement element)
            => new SinglePopulationVarianceFunctionExpression(element);

        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableSingleElement element)
            => new NullableSinglePopulationVarianceFunctionExpression(element);
        #endregion

        #region date
        public static CurrentTimestampFunctionExpression Current_Timestamp
            => new CurrentTimestampFunctionExpression();
        #endregion

        #region floor
        public static ObjectFloorFunctionExpression Floor(AnyObjectElement element)
            => new ObjectFloorFunctionExpression(element);

        public static ByteFloorFunctionExpression Floor(ByteElement element)
            => new ByteFloorFunctionExpression(element);

        public static NullableByteFloorFunctionExpression Floor(NullableByteElement element)
            => new NullableByteFloorFunctionExpression(element);

        public static Int16FloorFunctionExpression Floor(Int16Element element)
            => new Int16FloorFunctionExpression(element);

        public static NullableInt16FloorFunctionExpression Floor(NullableInt16Element element)
            => new NullableInt16FloorFunctionExpression(element);

        public static Int32FloorFunctionExpression Floor(Int32Element element)
            => new Int32FloorFunctionExpression(element);

        public static NullableInt32FloorFunctionExpression Floor(NullableInt32Element element)
            => new NullableInt32FloorFunctionExpression(element);

        public static Int64FloorFunctionExpression Floor(Int64Element element)
            => new Int64FloorFunctionExpression(element);

        public static NullableInt64FloorFunctionExpression Floor(NullableInt64Element element)
            => new NullableInt64FloorFunctionExpression(element);

        public static SingleFloorFunctionExpression Floor(SingleElement element)
            => new SingleFloorFunctionExpression(element);

        public static NullableSingleFloorFunctionExpression Floor(NullableSingleElement element)
            => new NullableSingleFloorFunctionExpression(element);

        public static DoubleFloorFunctionExpression Floor(DoubleElement element)
            => new DoubleFloorFunctionExpression(element);

        public static NullableDoubleFloorFunctionExpression Floor(NullableDoubleElement element)
            => new NullableDoubleFloorFunctionExpression(element);

        public static DecimalFloorFunctionExpression Floor(DecimalElement element)
            => new DecimalFloorFunctionExpression(element);

        public static NullableDecimalFloorFunctionExpression Floor(NullableDecimalElement element)
            => new NullableDecimalFloorFunctionExpression(element);
        #endregion

        #region ceiling
        public static ObjectCeilingFunctionExpression Ceiling(AnyObjectElement element)
            => new ObjectCeilingFunctionExpression(element);

        public static ByteCeilingFunctionExpression Ceiling(ByteElement element)
            => new ByteCeilingFunctionExpression(element);

        public static NullableByteCeilingFunctionExpression Ceiling(NullableByteElement element)
            => new NullableByteCeilingFunctionExpression(element);

        public static Int16CeilingFunctionExpression Ceiling(Int16Element element)
            => new Int16CeilingFunctionExpression(element);

        public static NullableInt16CeilingFunctionExpression Ceiling(NullableInt16Element element)
            => new NullableInt16CeilingFunctionExpression(element);

        public static Int32CeilingFunctionExpression Ceiling(Int32Element element)
            => new Int32CeilingFunctionExpression(element);

        public static NullableInt32CeilingFunctionExpression Ceiling(NullableInt32Element element)
            => new NullableInt32CeilingFunctionExpression(element);

        public static Int64CeilingFunctionExpression Ceiling(Int64Element element)
            => new Int64CeilingFunctionExpression(element);

        public static NullableInt64CeilingFunctionExpression Ceiling(NullableInt64Element element)
            => new NullableInt64CeilingFunctionExpression(element);

        public static SingleCeilingFunctionExpression Ceiling(SingleElement element)
            => new SingleCeilingFunctionExpression(element);

        public static NullableSingleCeilingFunctionExpression Ceiling(NullableSingleElement element)
            => new NullableSingleCeilingFunctionExpression(element);

        public static DoubleCeilingFunctionExpression Ceiling(DoubleElement element)
            => new DoubleCeilingFunctionExpression(element);

        public static NullableDoubleCeilingFunctionExpression Ceiling(NullableDoubleElement element)
            => new NullableDoubleCeilingFunctionExpression(element);

        public static DecimalCeilingFunctionExpression Ceiling(DecimalElement element)
            => new DecimalCeilingFunctionExpression(element);

        public static NullableDecimalCeilingFunctionExpression Ceiling(NullableDecimalElement element)
            => new NullableDecimalCeilingFunctionExpression(element);
        #endregion
    }
}
