using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public partial class SqlFunctionExpressionBuilder
    {
        #region concat
        public static StringConcatFunctionExpression Concat(params StringExpressionMediator[] fields)
            => new StringConcatFunctionExpression(fields);

        public static StringConcatFunctionExpression Concat(string value, params StringExpressionMediator[] fields)
            => new StringConcatFunctionExpression(new List<StringExpressionMediator> { new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(fields).ToArray());

        public static StringConcatFunctionExpression Concat(StringExpressionMediator field1, string value, params StringExpressionMediator[] fields)
            => new StringConcatFunctionExpression(new List<StringExpressionMediator> { field1, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(fields).ToArray());

        public static StringConcatFunctionExpression Concat(StringExpressionMediator field1, StringExpressionMediator field2, string value, params StringExpressionMediator[] fields)
            => new StringConcatFunctionExpression(new List<StringExpressionMediator> { field1, field2, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(fields).ToArray());

        public static StringConcatFunctionExpression Concat(StringExpressionMediator field1, StringExpressionMediator field2, StringExpressionMediator field3, string value, params StringExpressionMediator[] fields)
            => new StringConcatFunctionExpression(new List<StringExpressionMediator> { field1, field2, field3, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(fields).ToArray());

        public static StringConcatFunctionExpression Concat(StringExpressionMediator field1, StringExpressionMediator field2, StringExpressionMediator field3, StringExpressionMediator field4, string value, params StringExpressionMediator[] fields)
            => new StringConcatFunctionExpression(new List<StringExpressionMediator> { field1, field2, field3, field4, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(fields).ToArray());
        #endregion

        #region coalesce
        #region bool
        public static BooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, bool value)
            => new BooleanCoalesceFunctionExpression(new List<NullableExpressionMediator<bool>> { field1 }, new BooleanExpressionMediator(new LiteralExpression<bool>(value)));

        public static NullableBooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, bool? value)
            => new NullableBooleanCoalesceFunctionExpression(new List<NullableBooleanExpressionMediator> { field1, new NullableBooleanExpressionMediator(new NullableLiteralExpression<bool?>(value)) }.ToArray());

        public static BooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, BooleanExpressionMediator field2)
            => new BooleanCoalesceFunctionExpression(new List<NullableExpressionMediator<bool>> { field1 }, field2);

        public static NullableBooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2)
            => new NullableBooleanCoalesceFunctionExpression(field1, field2);

        public static BooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, bool value)
            => new BooleanCoalesceFunctionExpression(new List<NullableExpressionMediator<bool>> { field1, field2 }, new BooleanExpressionMediator(new LiteralExpression<bool>(value)));

        public static NullableBooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, bool? value)
            => new NullableBooleanCoalesceFunctionExpression(field1, field2, new NullableBooleanExpressionMediator(new NullableLiteralExpression<bool?>(value)));

        public static BooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, BooleanExpressionMediator field3)
            => new BooleanCoalesceFunctionExpression(new List<NullableExpressionMediator<bool>> { field1, field2 }, field3);

        public static NullableBooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, NullableBooleanExpressionMediator field3)
            => new NullableBooleanCoalesceFunctionExpression(field1, field2, field3);

        public static BooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, NullableBooleanExpressionMediator field3, bool value)
            => new BooleanCoalesceFunctionExpression(new List<NullableExpressionMediator<bool>> { field1, field2, field3 }, new BooleanExpressionMediator(new LiteralExpression<bool>(value)));

        public static NullableBooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, NullableBooleanExpressionMediator field3, bool? value)
            => new NullableBooleanCoalesceFunctionExpression(field1, field2, field3, new NullableBooleanExpressionMediator(new NullableLiteralExpression<bool?>(value)));

        public static BooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, NullableBooleanExpressionMediator field3, BooleanExpressionMediator field4)
            => new BooleanCoalesceFunctionExpression(new List<NullableExpressionMediator<bool>> { field1, field2, field3 }, field4);

        public static NullableBooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, NullableBooleanExpressionMediator field3, NullableBooleanExpressionMediator field4)
            => new NullableBooleanCoalesceFunctionExpression(field1, field2, field3, field4);

        public static BooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, NullableBooleanExpressionMediator field3, NullableBooleanExpressionMediator field4, bool value)
            => new BooleanCoalesceFunctionExpression(new List<NullableExpressionMediator<bool>> { field1, field2, field3, field4 }, new BooleanExpressionMediator(new LiteralExpression<bool>(value)));

        public static NullableBooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, NullableBooleanExpressionMediator field3, NullableBooleanExpressionMediator field4, bool? value)
            => new NullableBooleanCoalesceFunctionExpression(field1, field2, field3, field4, new NullableBooleanExpressionMediator(new NullableLiteralExpression<bool?>(value)));

        public static BooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, NullableBooleanExpressionMediator field3, NullableBooleanExpressionMediator field4, BooleanExpressionMediator field5)
            => new BooleanCoalesceFunctionExpression(new List<NullableExpressionMediator<bool>> { field1, field2, field3, field4 }, field5);

        public static NullableBooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, NullableBooleanExpressionMediator field3, NullableBooleanExpressionMediator field4, NullableBooleanExpressionMediator field5)
            => new NullableBooleanCoalesceFunctionExpression(field1, field2, field3, field4, field5);

        public static BooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, NullableBooleanExpressionMediator field3, NullableBooleanExpressionMediator field4, NullableBooleanExpressionMediator field5, bool value)
            => new BooleanCoalesceFunctionExpression(new List<NullableExpressionMediator<bool>> { field1, field2, field3, field4, field5 }, new BooleanExpressionMediator(new LiteralExpression<bool>(value)));

        public static NullableBooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, NullableBooleanExpressionMediator field3, NullableBooleanExpressionMediator field4, NullableBooleanExpressionMediator field5, bool? value)
            => new NullableBooleanCoalesceFunctionExpression(field1, field2, field3, field4, field5, new NullableBooleanExpressionMediator(new NullableLiteralExpression<bool?>(value)));

        public static BooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, NullableBooleanExpressionMediator field3, NullableBooleanExpressionMediator field4, NullableBooleanExpressionMediator field5, BooleanExpressionMediator field6)
            => new BooleanCoalesceFunctionExpression(new List<NullableExpressionMediator<bool>> { field1, field2, field3, field4, field5 }, field6);

        public static NullableBooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, NullableBooleanExpressionMediator field3, NullableBooleanExpressionMediator field4, NullableBooleanExpressionMediator field5, NullableBooleanExpressionMediator field6)
            => new NullableBooleanCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6);

        public static BooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, NullableBooleanExpressionMediator field3, NullableBooleanExpressionMediator field4, NullableBooleanExpressionMediator field5, NullableBooleanExpressionMediator field6, bool value)
            => new BooleanCoalesceFunctionExpression(new List<NullableExpressionMediator<bool>> { field1, field2, field3, field4, field5, field6 }, new BooleanExpressionMediator(new LiteralExpression<bool>(value)));

        public static NullableBooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, NullableBooleanExpressionMediator field3, NullableBooleanExpressionMediator field4, NullableBooleanExpressionMediator field5, NullableBooleanExpressionMediator field6, bool? value)
            => new NullableBooleanCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, new NullableBooleanExpressionMediator(new NullableLiteralExpression<bool?>(value)));

        public static BooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, NullableBooleanExpressionMediator field3, NullableBooleanExpressionMediator field4, NullableBooleanExpressionMediator field5, NullableBooleanExpressionMediator field6, BooleanExpressionMediator field7)
            => new BooleanCoalesceFunctionExpression(new List<NullableExpressionMediator<bool>> { field1, field2, field3, field4, field5, field6 }, field7);

        public static NullableBooleanCoalesceFunctionExpression Coalesce(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2, NullableBooleanExpressionMediator field3, NullableBooleanExpressionMediator field4, NullableBooleanExpressionMediator field5, NullableBooleanExpressionMediator field6, NullableBooleanExpressionMediator field7)
            => new NullableBooleanCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, field7);
        #endregion

        #region byte
        public static ByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, byte value)
            => new ByteCoalesceFunctionExpression(new List<NullableExpressionMediator<byte>> { field1 }, new ByteExpressionMediator(new LiteralExpression<byte>(value)));

        public static NullableByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, byte? value)
            => new NullableByteCoalesceFunctionExpression(new List<NullableByteExpressionMediator> { field1, new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(value)) }.ToArray());

        public static ByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, ByteExpressionMediator field2)
            => new ByteCoalesceFunctionExpression(new List<NullableExpressionMediator<byte>> { field1 }, field2);

        public static NullableByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2)
            => new NullableByteCoalesceFunctionExpression(field1, field2);

        public static ByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, byte value)
            => new ByteCoalesceFunctionExpression(new List<NullableExpressionMediator<byte>> { field1, field2 }, new ByteExpressionMediator(new LiteralExpression<byte>(value)));

        public static NullableByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, byte? value)
            => new NullableByteCoalesceFunctionExpression(field1, field2, new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(value)));

        public static ByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, ByteExpressionMediator field3)
            => new ByteCoalesceFunctionExpression(new List<NullableExpressionMediator<byte>> { field1, field2 }, field3);

        public static NullableByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, NullableByteExpressionMediator field3)
            => new NullableByteCoalesceFunctionExpression(field1, field2, field3);

        public static ByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, NullableByteExpressionMediator field3, byte value)
            => new ByteCoalesceFunctionExpression(new List<NullableExpressionMediator<byte>> { field1, field2, field3 }, new ByteExpressionMediator(new LiteralExpression<byte>(value)));

        public static NullableByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, NullableByteExpressionMediator field3, byte? value)
            => new NullableByteCoalesceFunctionExpression(field1, field2, field3, new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(value)));

        public static ByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, NullableByteExpressionMediator field3, ByteExpressionMediator field4)
            => new ByteCoalesceFunctionExpression(new List<NullableExpressionMediator<byte>> { field1, field2, field3 }, field4);

        public static NullableByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, NullableByteExpressionMediator field3, NullableByteExpressionMediator field4)
            => new NullableByteCoalesceFunctionExpression(field1, field2, field3, field4);

        public static ByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, NullableByteExpressionMediator field3, NullableByteExpressionMediator field4, byte value)
            => new ByteCoalesceFunctionExpression(new List<NullableExpressionMediator<byte>> { field1, field2, field3, field4 }, new ByteExpressionMediator(new LiteralExpression<byte>(value)));

        public static NullableByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, NullableByteExpressionMediator field3, NullableByteExpressionMediator field4, byte? value)
            => new NullableByteCoalesceFunctionExpression(field1, field2, field3, field4, new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(value)));

        public static ByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, NullableByteExpressionMediator field3, NullableByteExpressionMediator field4, ByteExpressionMediator field5)
            => new ByteCoalesceFunctionExpression(new List<NullableExpressionMediator<byte>> { field1, field2, field3, field4 }, field5);

        public static NullableByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, NullableByteExpressionMediator field3, NullableByteExpressionMediator field4, NullableByteExpressionMediator field5)
            => new NullableByteCoalesceFunctionExpression(field1, field2, field3, field4, field5);

        public static ByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, NullableByteExpressionMediator field3, NullableByteExpressionMediator field4, NullableByteExpressionMediator field5, byte value)
            => new ByteCoalesceFunctionExpression(new List<NullableExpressionMediator<byte>> { field1, field2, field3, field4, field5 }, new ByteExpressionMediator(new LiteralExpression<byte>(value)));

        public static NullableByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, NullableByteExpressionMediator field3, NullableByteExpressionMediator field4, NullableByteExpressionMediator field5, byte? value)
            => new NullableByteCoalesceFunctionExpression(field1, field2, field3, field4, field5, new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(value)));

        public static ByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, NullableByteExpressionMediator field3, NullableByteExpressionMediator field4, NullableByteExpressionMediator field5, ByteExpressionMediator field6)
            => new ByteCoalesceFunctionExpression(new List<NullableExpressionMediator<byte>> { field1, field2, field3, field4, field5 }, field6);

        public static NullableByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, NullableByteExpressionMediator field3, NullableByteExpressionMediator field4, NullableByteExpressionMediator field5, NullableByteExpressionMediator field6)
            => new NullableByteCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6);

        public static ByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, NullableByteExpressionMediator field3, NullableByteExpressionMediator field4, NullableByteExpressionMediator field5, NullableByteExpressionMediator field6, byte value)
            => new ByteCoalesceFunctionExpression(new List<NullableExpressionMediator<byte>> { field1, field2, field3, field4, field5, field6 }, new ByteExpressionMediator(new LiteralExpression<byte>(value)));

        public static NullableByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, NullableByteExpressionMediator field3, NullableByteExpressionMediator field4, NullableByteExpressionMediator field5, NullableByteExpressionMediator field6, byte? value)
            => new NullableByteCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(value)));

        public static ByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, NullableByteExpressionMediator field3, NullableByteExpressionMediator field4, NullableByteExpressionMediator field5, NullableByteExpressionMediator field6, ByteExpressionMediator field7)
            => new ByteCoalesceFunctionExpression(new List<NullableExpressionMediator<byte>> { field1, field2, field3, field4, field5, field6 }, field7);

        public static NullableByteCoalesceFunctionExpression Coalesce(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2, NullableByteExpressionMediator field3, NullableByteExpressionMediator field4, NullableByteExpressionMediator field5, NullableByteExpressionMediator field6, NullableByteExpressionMediator field7)
            => new NullableByteCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, field7);
        #endregion

        #region DateTime
        public static DateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, DateTime value)
            => new DateTimeCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTime>> { field1 }, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(value)));

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, DateTime? value)
            => new NullableDateTimeCoalesceFunctionExpression(new List<NullableDateTimeExpressionMediator> { field1, new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(value)) }.ToArray());

        public static DateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, DateTimeExpressionMediator field2)
            => new DateTimeCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTime>> { field1 }, field2);

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2)
            => new NullableDateTimeCoalesceFunctionExpression(field1, field2);

        public static DateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, DateTime value)
            => new DateTimeCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTime>> { field1, field2 }, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(value)));

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, DateTime? value)
            => new NullableDateTimeCoalesceFunctionExpression(field1, field2, new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(value)));

        public static DateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, DateTimeExpressionMediator field3)
            => new DateTimeCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTime>> { field1, field2 }, field3);

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, NullableDateTimeExpressionMediator field3)
            => new NullableDateTimeCoalesceFunctionExpression(field1, field2, field3);

        public static DateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, NullableDateTimeExpressionMediator field3, DateTime value)
            => new DateTimeCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTime>> { field1, field2, field3 }, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(value)));

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, NullableDateTimeExpressionMediator field3, DateTime? value)
            => new NullableDateTimeCoalesceFunctionExpression(field1, field2, field3, new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(value)));

        public static DateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, NullableDateTimeExpressionMediator field3, DateTimeExpressionMediator field4)
            => new DateTimeCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTime>> { field1, field2, field3 }, field4);

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, NullableDateTimeExpressionMediator field3, NullableDateTimeExpressionMediator field4)
            => new NullableDateTimeCoalesceFunctionExpression(field1, field2, field3, field4);

        public static DateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, NullableDateTimeExpressionMediator field3, NullableDateTimeExpressionMediator field4, DateTime value)
            => new DateTimeCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTime>> { field1, field2, field3, field4 }, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(value)));

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, NullableDateTimeExpressionMediator field3, NullableDateTimeExpressionMediator field4, DateTime? value)
            => new NullableDateTimeCoalesceFunctionExpression(field1, field2, field3, field4, new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(value)));

        public static DateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, NullableDateTimeExpressionMediator field3, NullableDateTimeExpressionMediator field4, DateTimeExpressionMediator field5)
            => new DateTimeCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTime>> { field1, field2, field3, field4 }, field5);

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, NullableDateTimeExpressionMediator field3, NullableDateTimeExpressionMediator field4, NullableDateTimeExpressionMediator field5)
            => new NullableDateTimeCoalesceFunctionExpression(field1, field2, field3, field4, field5);

        public static DateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, NullableDateTimeExpressionMediator field3, NullableDateTimeExpressionMediator field4, NullableDateTimeExpressionMediator field5, DateTime value)
            => new DateTimeCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTime>> { field1, field2, field3, field4, field5 }, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(value)));

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, NullableDateTimeExpressionMediator field3, NullableDateTimeExpressionMediator field4, NullableDateTimeExpressionMediator field5, DateTime? value)
            => new NullableDateTimeCoalesceFunctionExpression(field1, field2, field3, field4, field5, new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(value)));

        public static DateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, NullableDateTimeExpressionMediator field3, NullableDateTimeExpressionMediator field4, NullableDateTimeExpressionMediator field5, DateTimeExpressionMediator field6)
            => new DateTimeCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTime>> { field1, field2, field3, field4, field5 }, field6);

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, NullableDateTimeExpressionMediator field3, NullableDateTimeExpressionMediator field4, NullableDateTimeExpressionMediator field5, NullableDateTimeExpressionMediator field6)
            => new NullableDateTimeCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6);

        public static DateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, NullableDateTimeExpressionMediator field3, NullableDateTimeExpressionMediator field4, NullableDateTimeExpressionMediator field5, NullableDateTimeExpressionMediator field6, DateTime value)
            => new DateTimeCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTime>> { field1, field2, field3, field4, field5, field6 }, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(value)));

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, NullableDateTimeExpressionMediator field3, NullableDateTimeExpressionMediator field4, NullableDateTimeExpressionMediator field5, NullableDateTimeExpressionMediator field6, DateTime? value)
            => new NullableDateTimeCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(value)));

        public static DateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, NullableDateTimeExpressionMediator field3, NullableDateTimeExpressionMediator field4, NullableDateTimeExpressionMediator field5, NullableDateTimeExpressionMediator field6, DateTimeExpressionMediator field7)
            => new DateTimeCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTime>> { field1, field2, field3, field4, field5, field6 }, field7);

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2, NullableDateTimeExpressionMediator field3, NullableDateTimeExpressionMediator field4, NullableDateTimeExpressionMediator field5, NullableDateTimeExpressionMediator field6, NullableDateTimeExpressionMediator field7)
            => new NullableDateTimeCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, field7);
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, DateTimeOffset value)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTimeOffset>> { field1 }, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(value)));

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, DateTimeOffset? value)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<NullableDateTimeOffsetExpressionMediator> { field1, new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(value)) }.ToArray());

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, DateTimeOffsetExpressionMediator field2)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTimeOffset>> { field1 }, field2);

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(field1, field2);

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, DateTimeOffset value)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTimeOffset>> { field1, field2 }, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(value)));

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, DateTimeOffset? value)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(field1, field2, new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(value)));

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, DateTimeOffsetExpressionMediator field3)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTimeOffset>> { field1, field2 }, field3);

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, NullableDateTimeOffsetExpressionMediator field3)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(field1, field2, field3);

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, NullableDateTimeOffsetExpressionMediator field3, DateTimeOffset value)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTimeOffset>> { field1, field2, field3 }, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(value)));

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, NullableDateTimeOffsetExpressionMediator field3, DateTimeOffset? value)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(field1, field2, field3, new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(value)));

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, NullableDateTimeOffsetExpressionMediator field3, DateTimeOffsetExpressionMediator field4)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTimeOffset>> { field1, field2, field3 }, field4);

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, NullableDateTimeOffsetExpressionMediator field3, NullableDateTimeOffsetExpressionMediator field4)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(field1, field2, field3, field4);

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, NullableDateTimeOffsetExpressionMediator field3, NullableDateTimeOffsetExpressionMediator field4, DateTimeOffset value)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4 }, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(value)));

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, NullableDateTimeOffsetExpressionMediator field3, NullableDateTimeOffsetExpressionMediator field4, DateTimeOffset? value)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(field1, field2, field3, field4, new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(value)));

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, NullableDateTimeOffsetExpressionMediator field3, NullableDateTimeOffsetExpressionMediator field4, DateTimeOffsetExpressionMediator field5)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4 }, field5);

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, NullableDateTimeOffsetExpressionMediator field3, NullableDateTimeOffsetExpressionMediator field4, NullableDateTimeOffsetExpressionMediator field5)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(field1, field2, field3, field4, field5);

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, NullableDateTimeOffsetExpressionMediator field3, NullableDateTimeOffsetExpressionMediator field4, NullableDateTimeOffsetExpressionMediator field5, DateTimeOffset value)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4, field5 }, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(value)));

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, NullableDateTimeOffsetExpressionMediator field3, NullableDateTimeOffsetExpressionMediator field4, NullableDateTimeOffsetExpressionMediator field5, DateTimeOffset? value)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(field1, field2, field3, field4, field5, new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(value)));

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, NullableDateTimeOffsetExpressionMediator field3, NullableDateTimeOffsetExpressionMediator field4, NullableDateTimeOffsetExpressionMediator field5, DateTimeOffsetExpressionMediator field6)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4, field5 }, field6);

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, NullableDateTimeOffsetExpressionMediator field3, NullableDateTimeOffsetExpressionMediator field4, NullableDateTimeOffsetExpressionMediator field5, NullableDateTimeOffsetExpressionMediator field6)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6);

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, NullableDateTimeOffsetExpressionMediator field3, NullableDateTimeOffsetExpressionMediator field4, NullableDateTimeOffsetExpressionMediator field5, NullableDateTimeOffsetExpressionMediator field6, DateTimeOffset value)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4, field5, field6 }, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(value)));

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, NullableDateTimeOffsetExpressionMediator field3, NullableDateTimeOffsetExpressionMediator field4, NullableDateTimeOffsetExpressionMediator field5, NullableDateTimeOffsetExpressionMediator field6, DateTimeOffset? value)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(value)));

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, NullableDateTimeOffsetExpressionMediator field3, NullableDateTimeOffsetExpressionMediator field4, NullableDateTimeOffsetExpressionMediator field5, NullableDateTimeOffsetExpressionMediator field6, DateTimeOffsetExpressionMediator field7)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<NullableExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4, field5, field6 }, field7);

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2, NullableDateTimeOffsetExpressionMediator field3, NullableDateTimeOffsetExpressionMediator field4, NullableDateTimeOffsetExpressionMediator field5, NullableDateTimeOffsetExpressionMediator field6, NullableDateTimeOffsetExpressionMediator field7)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, field7);
        #endregion

        #region double
        public static DoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, double value)
            => new DoubleCoalesceFunctionExpression(new List<NullableExpressionMediator<double>> { field1 }, new DoubleExpressionMediator(new LiteralExpression<double>(value)));

        public static NullableDoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, double? value)
            => new NullableDoubleCoalesceFunctionExpression(new List<NullableDoubleExpressionMediator> { field1, new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(value)) }.ToArray());

        public static DoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, DoubleExpressionMediator field2)
            => new DoubleCoalesceFunctionExpression(new List<NullableExpressionMediator<double>> { field1 }, field2);

        public static NullableDoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2)
            => new NullableDoubleCoalesceFunctionExpression(field1, field2);

        public static DoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, double value)
            => new DoubleCoalesceFunctionExpression(new List<NullableExpressionMediator<double>> { field1, field2 }, new DoubleExpressionMediator(new LiteralExpression<double>(value)));

        public static NullableDoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, double? value)
            => new NullableDoubleCoalesceFunctionExpression(field1, field2, new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(value)));

        public static DoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, DoubleExpressionMediator field3)
            => new DoubleCoalesceFunctionExpression(new List<NullableExpressionMediator<double>> { field1, field2 }, field3);

        public static NullableDoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, NullableDoubleExpressionMediator field3)
            => new NullableDoubleCoalesceFunctionExpression(field1, field2, field3);

        public static DoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, NullableDoubleExpressionMediator field3, double value)
            => new DoubleCoalesceFunctionExpression(new List<NullableExpressionMediator<double>> { field1, field2, field3 }, new DoubleExpressionMediator(new LiteralExpression<double>(value)));

        public static NullableDoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, NullableDoubleExpressionMediator field3, double? value)
            => new NullableDoubleCoalesceFunctionExpression(field1, field2, field3, new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(value)));

        public static DoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, NullableDoubleExpressionMediator field3, DoubleExpressionMediator field4)
            => new DoubleCoalesceFunctionExpression(new List<NullableExpressionMediator<double>> { field1, field2, field3 }, field4);

        public static NullableDoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, NullableDoubleExpressionMediator field3, NullableDoubleExpressionMediator field4)
            => new NullableDoubleCoalesceFunctionExpression(field1, field2, field3, field4);

        public static DoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, NullableDoubleExpressionMediator field3, NullableDoubleExpressionMediator field4, double value)
            => new DoubleCoalesceFunctionExpression(new List<NullableExpressionMediator<double>> { field1, field2, field3, field4 }, new DoubleExpressionMediator(new LiteralExpression<double>(value)));

        public static NullableDoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, NullableDoubleExpressionMediator field3, NullableDoubleExpressionMediator field4, double? value)
            => new NullableDoubleCoalesceFunctionExpression(field1, field2, field3, field4, new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(value)));

        public static DoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, NullableDoubleExpressionMediator field3, NullableDoubleExpressionMediator field4, DoubleExpressionMediator field5)
            => new DoubleCoalesceFunctionExpression(new List<NullableExpressionMediator<double>> { field1, field2, field3, field4 }, field5);

        public static NullableDoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, NullableDoubleExpressionMediator field3, NullableDoubleExpressionMediator field4, NullableDoubleExpressionMediator field5)
            => new NullableDoubleCoalesceFunctionExpression(field1, field2, field3, field4, field5);

        public static DoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, NullableDoubleExpressionMediator field3, NullableDoubleExpressionMediator field4, NullableDoubleExpressionMediator field5, double value)
            => new DoubleCoalesceFunctionExpression(new List<NullableExpressionMediator<double>> { field1, field2, field3, field4, field5 }, new DoubleExpressionMediator(new LiteralExpression<double>(value)));

        public static NullableDoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, NullableDoubleExpressionMediator field3, NullableDoubleExpressionMediator field4, NullableDoubleExpressionMediator field5, double? value)
            => new NullableDoubleCoalesceFunctionExpression(field1, field2, field3, field4, field5, new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(value)));

        public static DoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, NullableDoubleExpressionMediator field3, NullableDoubleExpressionMediator field4, NullableDoubleExpressionMediator field5, DoubleExpressionMediator field6)
            => new DoubleCoalesceFunctionExpression(new List<NullableExpressionMediator<double>> { field1, field2, field3, field4, field5 }, field6);

        public static NullableDoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, NullableDoubleExpressionMediator field3, NullableDoubleExpressionMediator field4, NullableDoubleExpressionMediator field5, NullableDoubleExpressionMediator field6)
            => new NullableDoubleCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6);

        public static DoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, NullableDoubleExpressionMediator field3, NullableDoubleExpressionMediator field4, NullableDoubleExpressionMediator field5, NullableDoubleExpressionMediator field6, double value)
            => new DoubleCoalesceFunctionExpression(new List<NullableExpressionMediator<double>> { field1, field2, field3, field4, field5, field6 }, new DoubleExpressionMediator(new LiteralExpression<double>(value)));

        public static NullableDoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, NullableDoubleExpressionMediator field3, NullableDoubleExpressionMediator field4, NullableDoubleExpressionMediator field5, NullableDoubleExpressionMediator field6, double? value)
            => new NullableDoubleCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(value)));

        public static DoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, NullableDoubleExpressionMediator field3, NullableDoubleExpressionMediator field4, NullableDoubleExpressionMediator field5, NullableDoubleExpressionMediator field6, DoubleExpressionMediator field7)
            => new DoubleCoalesceFunctionExpression(new List<NullableExpressionMediator<double>> { field1, field2, field3, field4, field5, field6 }, field7);

        public static NullableDoubleCoalesceFunctionExpression Coalesce(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2, NullableDoubleExpressionMediator field3, NullableDoubleExpressionMediator field4, NullableDoubleExpressionMediator field5, NullableDoubleExpressionMediator field6, NullableDoubleExpressionMediator field7)
            => new NullableDoubleCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, field7);
        #endregion

        #region decimal
        public static DecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, decimal value)
            => new DecimalCoalesceFunctionExpression(new List<NullableExpressionMediator<decimal>> { field1 }, new DecimalExpressionMediator(new LiteralExpression<decimal>(value)));

        public static NullableDecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, decimal? value)
            => new NullableDecimalCoalesceFunctionExpression(new List<NullableDecimalExpressionMediator> { field1, new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(value)) }.ToArray());

        public static DecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, DecimalExpressionMediator field2)
            => new DecimalCoalesceFunctionExpression(new List<NullableExpressionMediator<decimal>> { field1 }, field2);

        public static NullableDecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2)
            => new NullableDecimalCoalesceFunctionExpression(field1, field2);

        public static DecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, decimal value)
            => new DecimalCoalesceFunctionExpression(new List<NullableExpressionMediator<decimal>> { field1, field2 }, new DecimalExpressionMediator(new LiteralExpression<decimal>(value)));

        public static NullableDecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, decimal? value)
            => new NullableDecimalCoalesceFunctionExpression(field1, field2, new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(value)));

        public static DecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, DecimalExpressionMediator field3)
            => new DecimalCoalesceFunctionExpression(new List<NullableExpressionMediator<decimal>> { field1, field2 }, field3);

        public static NullableDecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, NullableDecimalExpressionMediator field3)
            => new NullableDecimalCoalesceFunctionExpression(field1, field2, field3);

        public static DecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, NullableDecimalExpressionMediator field3, decimal value)
            => new DecimalCoalesceFunctionExpression(new List<NullableExpressionMediator<decimal>> { field1, field2, field3 }, new DecimalExpressionMediator(new LiteralExpression<decimal>(value)));

        public static NullableDecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, NullableDecimalExpressionMediator field3, decimal? value)
            => new NullableDecimalCoalesceFunctionExpression(field1, field2, field3, new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(value)));

        public static DecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, NullableDecimalExpressionMediator field3, DecimalExpressionMediator field4)
            => new DecimalCoalesceFunctionExpression(new List<NullableExpressionMediator<decimal>> { field1, field2, field3 }, field4);

        public static NullableDecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, NullableDecimalExpressionMediator field3, NullableDecimalExpressionMediator field4)
            => new NullableDecimalCoalesceFunctionExpression(field1, field2, field3, field4);

        public static DecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, NullableDecimalExpressionMediator field3, NullableDecimalExpressionMediator field4, decimal value)
            => new DecimalCoalesceFunctionExpression(new List<NullableExpressionMediator<decimal>> { field1, field2, field3, field4 }, new DecimalExpressionMediator(new LiteralExpression<decimal>(value)));

        public static NullableDecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, NullableDecimalExpressionMediator field3, NullableDecimalExpressionMediator field4, decimal? value)
            => new NullableDecimalCoalesceFunctionExpression(field1, field2, field3, field4, new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(value)));

        public static DecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, NullableDecimalExpressionMediator field3, NullableDecimalExpressionMediator field4, DecimalExpressionMediator field5)
            => new DecimalCoalesceFunctionExpression(new List<NullableExpressionMediator<decimal>> { field1, field2, field3, field4 }, field5);

        public static NullableDecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, NullableDecimalExpressionMediator field3, NullableDecimalExpressionMediator field4, NullableDecimalExpressionMediator field5)
            => new NullableDecimalCoalesceFunctionExpression(field1, field2, field3, field4, field5);

        public static DecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, NullableDecimalExpressionMediator field3, NullableDecimalExpressionMediator field4, NullableDecimalExpressionMediator field5, decimal value)
            => new DecimalCoalesceFunctionExpression(new List<NullableExpressionMediator<decimal>> { field1, field2, field3, field4, field5 }, new DecimalExpressionMediator(new LiteralExpression<decimal>(value)));

        public static NullableDecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, NullableDecimalExpressionMediator field3, NullableDecimalExpressionMediator field4, NullableDecimalExpressionMediator field5, decimal? value)
            => new NullableDecimalCoalesceFunctionExpression(field1, field2, field3, field4, field5, new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(value)));

        public static DecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, NullableDecimalExpressionMediator field3, NullableDecimalExpressionMediator field4, NullableDecimalExpressionMediator field5, DecimalExpressionMediator field6)
            => new DecimalCoalesceFunctionExpression(new List<NullableExpressionMediator<decimal>> { field1, field2, field3, field4, field5 }, field6);

        public static NullableDecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, NullableDecimalExpressionMediator field3, NullableDecimalExpressionMediator field4, NullableDecimalExpressionMediator field5, NullableDecimalExpressionMediator field6)
            => new NullableDecimalCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6);

        public static DecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, NullableDecimalExpressionMediator field3, NullableDecimalExpressionMediator field4, NullableDecimalExpressionMediator field5, NullableDecimalExpressionMediator field6, decimal value)
            => new DecimalCoalesceFunctionExpression(new List<NullableExpressionMediator<decimal>> { field1, field2, field3, field4, field5, field6 }, new DecimalExpressionMediator(new LiteralExpression<decimal>(value)));

        public static NullableDecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, NullableDecimalExpressionMediator field3, NullableDecimalExpressionMediator field4, NullableDecimalExpressionMediator field5, NullableDecimalExpressionMediator field6, decimal? value)
            => new NullableDecimalCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(value)));

        public static DecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, NullableDecimalExpressionMediator field3, NullableDecimalExpressionMediator field4, NullableDecimalExpressionMediator field5, NullableDecimalExpressionMediator field6, DecimalExpressionMediator field7)
            => new DecimalCoalesceFunctionExpression(new List<NullableExpressionMediator<decimal>> { field1, field2, field3, field4, field5, field6 }, field7);

        public static NullableDecimalCoalesceFunctionExpression Coalesce(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2, NullableDecimalExpressionMediator field3, NullableDecimalExpressionMediator field4, NullableDecimalExpressionMediator field5, NullableDecimalExpressionMediator field6, NullableDecimalExpressionMediator field7)
            => new NullableDecimalCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, field7);
        #endregion

        #region TEnum
        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<NullableExpressionMediator<TEnum>> { field1 }, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)));

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(field1, new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(value)));

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<NullableExpressionMediator<TEnum>> { field1 }, field2);

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(field1, field2);

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<NullableExpressionMediator<TEnum>> { field1, field2 }, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)));

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(field1, field2, new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(value)));

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, EnumExpressionMediator<TEnum> field3)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<NullableExpressionMediator<TEnum>> { field1, field2 }, field3);

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, NullableEnumExpressionMediator<TEnum> field3)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(field1, field2, field3);

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, NullableEnumExpressionMediator<TEnum> field3, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<NullableExpressionMediator<TEnum>> { field1, field2, field3 }, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)));

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, NullableEnumExpressionMediator<TEnum> field3, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(field1, field2, field3, new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(value)));

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, NullableEnumExpressionMediator<TEnum> field3, EnumExpressionMediator<TEnum> field4)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<NullableExpressionMediator<TEnum>> { field1, field2, field3 }, field4);

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, NullableEnumExpressionMediator<TEnum> field3, NullableEnumExpressionMediator<TEnum> field4)
           where TEnum : struct, Enum, IComparable
             => new NullableEnumCoalesceFunctionExpression<TEnum>(field1, field2, field3, field4);

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, NullableEnumExpressionMediator<TEnum> field3, NullableEnumExpressionMediator<TEnum> field4, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<NullableExpressionMediator<TEnum>> { field1, field2, field3, field4 }, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)));

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, NullableEnumExpressionMediator<TEnum> field3, NullableEnumExpressionMediator<TEnum> field4, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(field1, field2, field3, field4, new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(value)));

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, NullableEnumExpressionMediator<TEnum> field3, NullableEnumExpressionMediator<TEnum> field4, EnumExpressionMediator<TEnum> field5)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<NullableExpressionMediator<TEnum>> { field1, field2, field3, field4 }, field5);

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, NullableEnumExpressionMediator<TEnum> field3, NullableEnumExpressionMediator<TEnum> field4, NullableEnumExpressionMediator<TEnum> field5)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(field1, field2, field3, field4, field5);

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, NullableEnumExpressionMediator<TEnum> field3, NullableEnumExpressionMediator<TEnum> field4, NullableEnumExpressionMediator<TEnum> field5, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<NullableExpressionMediator<TEnum>> { field1, field2, field3, field4, field5 }, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)));

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, NullableEnumExpressionMediator<TEnum> field3, NullableEnumExpressionMediator<TEnum> field4, NullableEnumExpressionMediator<TEnum> field5, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(field1, field2, field3, field4, field5, new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(value)));

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, NullableEnumExpressionMediator<TEnum> field3, NullableEnumExpressionMediator<TEnum> field4, NullableEnumExpressionMediator<TEnum> field5, EnumExpressionMediator<TEnum> field6)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<NullableExpressionMediator<TEnum>> { field1, field2, field3, field4, field5 }, field6);

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, NullableEnumExpressionMediator<TEnum> field3, NullableEnumExpressionMediator<TEnum> field4, NullableEnumExpressionMediator<TEnum> field5, NullableEnumExpressionMediator<TEnum> field6)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(field1, field2, field3, field4, field5, field6);

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, NullableEnumExpressionMediator<TEnum> field3, NullableEnumExpressionMediator<TEnum> field4, NullableEnumExpressionMediator<TEnum> field5, NullableEnumExpressionMediator<TEnum> field6, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<NullableExpressionMediator<TEnum>> { field1, field2, field3, field4, field5, field6 }, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)));

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, NullableEnumExpressionMediator<TEnum> field3, NullableEnumExpressionMediator<TEnum> field4, NullableEnumExpressionMediator<TEnum> field5, NullableEnumExpressionMediator<TEnum> field6, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(field1, field2, field3, field4, field5, field6, new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(value)));

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, NullableEnumExpressionMediator<TEnum> field3, NullableEnumExpressionMediator<TEnum> field4, NullableEnumExpressionMediator<TEnum> field5, NullableEnumExpressionMediator<TEnum> field6, EnumExpressionMediator<TEnum> field7)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<NullableExpressionMediator<TEnum>> { field1, field2, field3, field4, field5, field6 }, field7);

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2, NullableEnumExpressionMediator<TEnum> field3, NullableEnumExpressionMediator<TEnum> field4, NullableEnumExpressionMediator<TEnum> field5, NullableEnumExpressionMediator<TEnum> field6, NullableEnumExpressionMediator<TEnum> field7)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(field1, field2, field3, field4, field5, field6, field7);
        #endregion

        #region float
        public static SingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, float value)
            => new SingleCoalesceFunctionExpression(new List<NullableExpressionMediator<float>> { field1 }, new SingleExpressionMediator(new LiteralExpression<float>(value)));

        public static NullableSingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, float? value)
            => new NullableSingleCoalesceFunctionExpression(new List<NullableSingleExpressionMediator> { field1, new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(value)) }.ToArray());

        public static SingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, SingleExpressionMediator field2)
            => new SingleCoalesceFunctionExpression(new List<NullableExpressionMediator<float>> { field1 }, field2);

        public static NullableSingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2)
            => new NullableSingleCoalesceFunctionExpression(field1, field2);

        public static SingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, float value)
            => new SingleCoalesceFunctionExpression(new List<NullableExpressionMediator<float>> { field1, field2 }, new SingleExpressionMediator(new LiteralExpression<float>(value)));

        public static NullableSingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, float? value)
            => new NullableSingleCoalesceFunctionExpression(field1, field2, new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(value)));

        public static SingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, SingleExpressionMediator field3)
            => new SingleCoalesceFunctionExpression(new List<NullableExpressionMediator<float>> { field1, field2 }, field3);

        public static NullableSingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, NullableSingleExpressionMediator field3)
            => new NullableSingleCoalesceFunctionExpression(field1, field2, field3);

        public static SingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, NullableSingleExpressionMediator field3, float value)
            => new SingleCoalesceFunctionExpression(new List<NullableExpressionMediator<float>> { field1, field2, field3 }, new SingleExpressionMediator(new LiteralExpression<float>(value)));

        public static NullableSingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, NullableSingleExpressionMediator field3, float? value)
            => new NullableSingleCoalesceFunctionExpression(field1, field2, field3, new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(value)));

        public static SingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, NullableSingleExpressionMediator field3, SingleExpressionMediator field4)
            => new SingleCoalesceFunctionExpression(new List<NullableExpressionMediator<float>> { field1, field2, field3 }, field4);

        public static NullableSingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, NullableSingleExpressionMediator field3, NullableSingleExpressionMediator field4)
            => new NullableSingleCoalesceFunctionExpression(field1, field2, field3, field4);

        public static SingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, NullableSingleExpressionMediator field3, NullableSingleExpressionMediator field4, float value)
            => new SingleCoalesceFunctionExpression(new List<NullableExpressionMediator<float>> { field1, field2, field3, field4 }, new SingleExpressionMediator(new LiteralExpression<float>(value)));

        public static NullableSingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, NullableSingleExpressionMediator field3, NullableSingleExpressionMediator field4, float? value)
            => new NullableSingleCoalesceFunctionExpression(field1, field2, field3, field4, new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(value)));

        public static SingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, NullableSingleExpressionMediator field3, NullableSingleExpressionMediator field4, SingleExpressionMediator field5)
            => new SingleCoalesceFunctionExpression(new List<NullableExpressionMediator<float>> { field1, field2, field3, field4 }, field5);

        public static NullableSingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, NullableSingleExpressionMediator field3, NullableSingleExpressionMediator field4, NullableSingleExpressionMediator field5)
            => new NullableSingleCoalesceFunctionExpression(field1, field2, field3, field4, field5);

        public static SingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, NullableSingleExpressionMediator field3, NullableSingleExpressionMediator field4, NullableSingleExpressionMediator field5, float value)
            => new SingleCoalesceFunctionExpression(new List<NullableExpressionMediator<float>> { field1, field2, field3, field4, field5 }, new SingleExpressionMediator(new LiteralExpression<float>(value)));

        public static NullableSingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, NullableSingleExpressionMediator field3, NullableSingleExpressionMediator field4, NullableSingleExpressionMediator field5, float? value)
            => new NullableSingleCoalesceFunctionExpression(field1, field2, field3, field4, field5, new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(value)));

        public static SingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, NullableSingleExpressionMediator field3, NullableSingleExpressionMediator field4, NullableSingleExpressionMediator field5, SingleExpressionMediator field6)
            => new SingleCoalesceFunctionExpression(new List<NullableExpressionMediator<float>> { field1, field2, field3, field4, field5 }, field6);

        public static NullableSingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, NullableSingleExpressionMediator field3, NullableSingleExpressionMediator field4, NullableSingleExpressionMediator field5, NullableSingleExpressionMediator field6)
            => new NullableSingleCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6);

        public static SingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, NullableSingleExpressionMediator field3, NullableSingleExpressionMediator field4, NullableSingleExpressionMediator field5, NullableSingleExpressionMediator field6, float value)
            => new SingleCoalesceFunctionExpression(new List<NullableExpressionMediator<float>> { field1, field2, field3, field4, field5, field6 }, new SingleExpressionMediator(new LiteralExpression<float>(value)));

        public static NullableSingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, NullableSingleExpressionMediator field3, NullableSingleExpressionMediator field4, NullableSingleExpressionMediator field5, NullableSingleExpressionMediator field6, float? value)
            => new NullableSingleCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(value)));

        public static SingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, NullableSingleExpressionMediator field3, NullableSingleExpressionMediator field4, NullableSingleExpressionMediator field5, NullableSingleExpressionMediator field6, SingleExpressionMediator field7)
            => new SingleCoalesceFunctionExpression(new List<NullableExpressionMediator<float>> { field1, field2, field3, field4, field5, field6 }, field7);

        public static NullableSingleCoalesceFunctionExpression Coalesce(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2, NullableSingleExpressionMediator field3, NullableSingleExpressionMediator field4, NullableSingleExpressionMediator field5, NullableSingleExpressionMediator field6, NullableSingleExpressionMediator field7)
            => new NullableSingleCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, field7);
        #endregion

        #region Guid
        public static GuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, Guid value)
            => new GuidCoalesceFunctionExpression(new List<NullableExpressionMediator<Guid>> { field1 }, new GuidExpressionMediator(new LiteralExpression<Guid>(value)));

        public static NullableGuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, Guid? value)
            => new NullableGuidCoalesceFunctionExpression(new List<NullableGuidExpressionMediator> { field1, new NullableGuidExpressionMediator(new NullableLiteralExpression<Guid?>(value)) }.ToArray());

        public static GuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, GuidExpressionMediator field2)
            => new GuidCoalesceFunctionExpression(new List<NullableExpressionMediator<Guid>> { field1 }, field2);

        public static NullableGuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2)
            => new NullableGuidCoalesceFunctionExpression(field1, field2);

        public static GuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, Guid value)
            => new GuidCoalesceFunctionExpression(new List<NullableExpressionMediator<Guid>> { field1, field2 }, new GuidExpressionMediator(new LiteralExpression<Guid>(value)));

        public static NullableGuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, Guid? value)
            => new NullableGuidCoalesceFunctionExpression(field1, field2, new NullableGuidExpressionMediator(new NullableLiteralExpression<Guid?>(value)));

        public static GuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, GuidExpressionMediator field3)
            => new GuidCoalesceFunctionExpression(new List<NullableExpressionMediator<Guid>> { field1, field2 }, field3);

        public static NullableGuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, NullableGuidExpressionMediator field3)
            => new NullableGuidCoalesceFunctionExpression(field1, field2, field3);

        public static GuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, NullableGuidExpressionMediator field3, Guid value)
            => new GuidCoalesceFunctionExpression(new List<NullableExpressionMediator<Guid>> { field1, field2, field3 }, new GuidExpressionMediator(new LiteralExpression<Guid>(value)));

        public static NullableGuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, NullableGuidExpressionMediator field3, Guid? value)
            => new NullableGuidCoalesceFunctionExpression(field1, field2, field3, new NullableGuidExpressionMediator(new NullableLiteralExpression<Guid?>(value)));

        public static GuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, NullableGuidExpressionMediator field3, GuidExpressionMediator field4)
            => new GuidCoalesceFunctionExpression(new List<NullableExpressionMediator<Guid>> { field1, field2, field3 }, field4);

        public static NullableGuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, NullableGuidExpressionMediator field3, NullableGuidExpressionMediator field4)
            => new NullableGuidCoalesceFunctionExpression(field1, field2, field3, field4);

        public static GuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, NullableGuidExpressionMediator field3, NullableGuidExpressionMediator field4, Guid value)
            => new GuidCoalesceFunctionExpression(new List<NullableExpressionMediator<Guid>> { field1, field2, field3, field4 }, new GuidExpressionMediator(new LiteralExpression<Guid>(value)));

        public static NullableGuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, NullableGuidExpressionMediator field3, NullableGuidExpressionMediator field4, Guid? value)
            => new NullableGuidCoalesceFunctionExpression(field1, field2, field3, field4, new NullableGuidExpressionMediator(new NullableLiteralExpression<Guid?>(value)));

        public static GuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, NullableGuidExpressionMediator field3, NullableGuidExpressionMediator field4, GuidExpressionMediator field5)
            => new GuidCoalesceFunctionExpression(new List<NullableExpressionMediator<Guid>> { field1, field2, field3, field4 }, field5);

        public static NullableGuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, NullableGuidExpressionMediator field3, NullableGuidExpressionMediator field4, NullableGuidExpressionMediator field5)
            => new NullableGuidCoalesceFunctionExpression(field1, field2, field3, field4, field5);

        public static GuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, NullableGuidExpressionMediator field3, NullableGuidExpressionMediator field4, NullableGuidExpressionMediator field5, Guid value)
            => new GuidCoalesceFunctionExpression(new List<NullableExpressionMediator<Guid>> { field1, field2, field3, field4, field5 }, new GuidExpressionMediator(new LiteralExpression<Guid>(value)));

        public static NullableGuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, NullableGuidExpressionMediator field3, NullableGuidExpressionMediator field4, NullableGuidExpressionMediator field5, Guid? value)
            => new NullableGuidCoalesceFunctionExpression(field1, field2, field3, field4, field5, new NullableGuidExpressionMediator(new NullableLiteralExpression<Guid?>(value)));

        public static GuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, NullableGuidExpressionMediator field3, NullableGuidExpressionMediator field4, NullableGuidExpressionMediator field5, GuidExpressionMediator field6)
            => new GuidCoalesceFunctionExpression(new List<NullableExpressionMediator<Guid>> { field1, field2, field3, field4, field5 }, field6);

        public static NullableGuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, NullableGuidExpressionMediator field3, NullableGuidExpressionMediator field4, NullableGuidExpressionMediator field5, NullableGuidExpressionMediator field6)
            => new NullableGuidCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6);

        public static GuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, NullableGuidExpressionMediator field3, NullableGuidExpressionMediator field4, NullableGuidExpressionMediator field5, NullableGuidExpressionMediator field6, Guid value)
            => new GuidCoalesceFunctionExpression(new List<NullableExpressionMediator<Guid>> { field1, field2, field3, field4, field5, field6 }, new GuidExpressionMediator(new LiteralExpression<Guid>(value)));

        public static NullableGuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, NullableGuidExpressionMediator field3, NullableGuidExpressionMediator field4, NullableGuidExpressionMediator field5, NullableGuidExpressionMediator field6, Guid? value)
            => new NullableGuidCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, new NullableGuidExpressionMediator(new NullableLiteralExpression<Guid?>(value)));

        public static GuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, NullableGuidExpressionMediator field3, NullableGuidExpressionMediator field4, NullableGuidExpressionMediator field5, NullableGuidExpressionMediator field6, GuidExpressionMediator field7)
            => new GuidCoalesceFunctionExpression(new List<NullableExpressionMediator<Guid>> { field1, field2, field3, field4, field5, field6 }, field7);

        public static NullableGuidCoalesceFunctionExpression Coalesce(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2, NullableGuidExpressionMediator field3, NullableGuidExpressionMediator field4, NullableGuidExpressionMediator field5, NullableGuidExpressionMediator field6, NullableGuidExpressionMediator field7)
            => new NullableGuidCoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, field7);
        #endregion

        #region short
        public static Int16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, short value)
            => new Int16CoalesceFunctionExpression(new List<NullableExpressionMediator<short>> { field1 }, new Int16ExpressionMediator(new LiteralExpression<short>(value)));

        public static NullableInt16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, short? value)
            => new NullableInt16CoalesceFunctionExpression(new List<NullableInt16ExpressionMediator> { field1, new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(value)) }.ToArray());

        public static Int16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, Int16ExpressionMediator field2)
            => new Int16CoalesceFunctionExpression(new List<NullableExpressionMediator<short>> { field1 }, field2);

        public static NullableInt16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2)
            => new NullableInt16CoalesceFunctionExpression(field1, field2);

        public static Int16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, short value)
            => new Int16CoalesceFunctionExpression(new List<NullableExpressionMediator<short>> { field1, field2 }, new Int16ExpressionMediator(new LiteralExpression<short>(value)));

        public static NullableInt16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, short? value)
            => new NullableInt16CoalesceFunctionExpression(field1, field2, new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(value)));

        public static Int16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, Int16ExpressionMediator field3)
            => new Int16CoalesceFunctionExpression(new List<NullableExpressionMediator<short>> { field1, field2 }, field3);

        public static NullableInt16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, NullableInt16ExpressionMediator field3)
            => new NullableInt16CoalesceFunctionExpression(field1, field2, field3);

        public static Int16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, NullableInt16ExpressionMediator field3, short value)
            => new Int16CoalesceFunctionExpression(new List<NullableExpressionMediator<short>> { field1, field2, field3 }, new Int16ExpressionMediator(new LiteralExpression<short>(value)));

        public static NullableInt16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, NullableInt16ExpressionMediator field3, short? value)
            => new NullableInt16CoalesceFunctionExpression(field1, field2, field3, new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(value)));

        public static Int16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, NullableInt16ExpressionMediator field3, Int16ExpressionMediator field4)
            => new Int16CoalesceFunctionExpression(new List<NullableExpressionMediator<short>> { field1, field2, field3 }, field4);

        public static NullableInt16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, NullableInt16ExpressionMediator field3, NullableInt16ExpressionMediator field4)
            => new NullableInt16CoalesceFunctionExpression(field1, field2, field3, field4);

        public static Int16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, NullableInt16ExpressionMediator field3, NullableInt16ExpressionMediator field4, short value)
            => new Int16CoalesceFunctionExpression(new List<NullableExpressionMediator<short>> { field1, field2, field3, field4 }, new Int16ExpressionMediator(new LiteralExpression<short>(value)));

        public static NullableInt16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, NullableInt16ExpressionMediator field3, NullableInt16ExpressionMediator field4, short? value)
            => new NullableInt16CoalesceFunctionExpression(field1, field2, field3, field4, new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(value)));

        public static Int16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, NullableInt16ExpressionMediator field3, NullableInt16ExpressionMediator field4, Int16ExpressionMediator field5)
            => new Int16CoalesceFunctionExpression(new List<NullableExpressionMediator<short>> { field1, field2, field3, field4 }, field5);

        public static NullableInt16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, NullableInt16ExpressionMediator field3, NullableInt16ExpressionMediator field4, NullableInt16ExpressionMediator field5)
            => new NullableInt16CoalesceFunctionExpression(field1, field2, field3, field4, field5);

        public static Int16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, NullableInt16ExpressionMediator field3, NullableInt16ExpressionMediator field4, NullableInt16ExpressionMediator field5, short value)
            => new Int16CoalesceFunctionExpression(new List<NullableExpressionMediator<short>> { field1, field2, field3, field4, field5 }, new Int16ExpressionMediator(new LiteralExpression<short>(value)));

        public static NullableInt16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, NullableInt16ExpressionMediator field3, NullableInt16ExpressionMediator field4, NullableInt16ExpressionMediator field5, short? value)
            => new NullableInt16CoalesceFunctionExpression(field1, field2, field3, field4, field5, new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(value)));

        public static Int16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, NullableInt16ExpressionMediator field3, NullableInt16ExpressionMediator field4, NullableInt16ExpressionMediator field5, Int16ExpressionMediator field6)
            => new Int16CoalesceFunctionExpression(new List<NullableExpressionMediator<short>> { field1, field2, field3, field4, field5 }, field6);

        public static NullableInt16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, NullableInt16ExpressionMediator field3, NullableInt16ExpressionMediator field4, NullableInt16ExpressionMediator field5, NullableInt16ExpressionMediator field6)
            => new NullableInt16CoalesceFunctionExpression(field1, field2, field3, field4, field5, field6);

        public static Int16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, NullableInt16ExpressionMediator field3, NullableInt16ExpressionMediator field4, NullableInt16ExpressionMediator field5, NullableInt16ExpressionMediator field6, short value)
            => new Int16CoalesceFunctionExpression(new List<NullableExpressionMediator<short>> { field1, field2, field3, field4, field5, field6 }, new Int16ExpressionMediator(new LiteralExpression<short>(value)));

        public static NullableInt16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, NullableInt16ExpressionMediator field3, NullableInt16ExpressionMediator field4, NullableInt16ExpressionMediator field5, NullableInt16ExpressionMediator field6, short? value)
            => new NullableInt16CoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(value)));

        public static Int16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, NullableInt16ExpressionMediator field3, NullableInt16ExpressionMediator field4, NullableInt16ExpressionMediator field5, NullableInt16ExpressionMediator field6, Int16ExpressionMediator field7)
            => new Int16CoalesceFunctionExpression(new List<NullableExpressionMediator<short>> { field1, field2, field3, field4, field5, field6 }, field7);

        public static NullableInt16CoalesceFunctionExpression Coalesce(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2, NullableInt16ExpressionMediator field3, NullableInt16ExpressionMediator field4, NullableInt16ExpressionMediator field5, NullableInt16ExpressionMediator field6, NullableInt16ExpressionMediator field7)
            => new NullableInt16CoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, field7);
        #endregion

        #region int
        public static Int32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, int value)
            => new Int32CoalesceFunctionExpression(new List<NullableExpressionMediator<int>> { field1 }, new Int32ExpressionMediator(new LiteralExpression<int>(value)));

        public static NullableInt32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, int? value)
            => new NullableInt32CoalesceFunctionExpression(new List<NullableInt32ExpressionMediator> { field1, new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(value)) }.ToArray());

        public static Int32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, Int32ExpressionMediator field2)
            => new Int32CoalesceFunctionExpression(new List<NullableExpressionMediator<int>> { field1 }, field2);

        public static NullableInt32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2)
            => new NullableInt32CoalesceFunctionExpression(field1, field2);

        public static Int32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, int value)
            => new Int32CoalesceFunctionExpression(new List<NullableExpressionMediator<int>> { field1, field2 }, new Int32ExpressionMediator(new LiteralExpression<int>(value)));

        public static NullableInt32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, int? value)
            => new NullableInt32CoalesceFunctionExpression(field1, field2, new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(value)));

        public static Int32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, Int32ExpressionMediator field3)
            => new Int32CoalesceFunctionExpression(new List<NullableExpressionMediator<int>> { field1, field2 }, field3);

        public static NullableInt32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, NullableInt32ExpressionMediator field3)
            => new NullableInt32CoalesceFunctionExpression(field1, field2, field3);

        public static Int32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, NullableInt32ExpressionMediator field3, int value)
            => new Int32CoalesceFunctionExpression(new List<NullableExpressionMediator<int>> { field1, field2, field3 }, new Int32ExpressionMediator(new LiteralExpression<int>(value)));

        public static NullableInt32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, NullableInt32ExpressionMediator field3, int? value)
            => new NullableInt32CoalesceFunctionExpression(field1, field2, field3, new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(value)));

        public static Int32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, NullableInt32ExpressionMediator field3, Int32ExpressionMediator field4)
            => new Int32CoalesceFunctionExpression(new List<NullableExpressionMediator<int>> { field1, field2, field3 }, field4);

        public static NullableInt32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, NullableInt32ExpressionMediator field3, NullableInt32ExpressionMediator field4)
            => new NullableInt32CoalesceFunctionExpression(field1, field2, field3, field4);

        public static Int32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, NullableInt32ExpressionMediator field3, NullableInt32ExpressionMediator field4, int value)
            => new Int32CoalesceFunctionExpression(new List<NullableExpressionMediator<int>> { field1, field2, field3, field4 }, new Int32ExpressionMediator(new LiteralExpression<int>(value)));

        public static NullableInt32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, NullableInt32ExpressionMediator field3, NullableInt32ExpressionMediator field4, int? value)
            => new NullableInt32CoalesceFunctionExpression(field1, field2, field3, field4, new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(value)));

        public static Int32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, NullableInt32ExpressionMediator field3, NullableInt32ExpressionMediator field4, Int32ExpressionMediator field5)
            => new Int32CoalesceFunctionExpression(new List<NullableExpressionMediator<int>> { field1, field2, field3, field4 }, field5);

        public static NullableInt32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, NullableInt32ExpressionMediator field3, NullableInt32ExpressionMediator field4, NullableInt32ExpressionMediator field5)
            => new NullableInt32CoalesceFunctionExpression(field1, field2, field3, field4, field5);

        public static Int32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, NullableInt32ExpressionMediator field3, NullableInt32ExpressionMediator field4, NullableInt32ExpressionMediator field5, int value)
            => new Int32CoalesceFunctionExpression(new List<NullableExpressionMediator<int>> { field1, field2, field3, field4, field5 }, new Int32ExpressionMediator(new LiteralExpression<int>(value)));

        public static NullableInt32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, NullableInt32ExpressionMediator field3, NullableInt32ExpressionMediator field4, NullableInt32ExpressionMediator field5, int? value)
            => new NullableInt32CoalesceFunctionExpression(field1, field2, field3, field4, field5, new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(value)));

        public static Int32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, NullableInt32ExpressionMediator field3, NullableInt32ExpressionMediator field4, NullableInt32ExpressionMediator field5, Int32ExpressionMediator field6)
            => new Int32CoalesceFunctionExpression(new List<NullableExpressionMediator<int>> { field1, field2, field3, field4, field5 }, field6);

        public static NullableInt32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, NullableInt32ExpressionMediator field3, NullableInt32ExpressionMediator field4, NullableInt32ExpressionMediator field5, NullableInt32ExpressionMediator field6)
            => new NullableInt32CoalesceFunctionExpression(field1, field2, field3, field4, field5, field6);

        public static Int32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, NullableInt32ExpressionMediator field3, NullableInt32ExpressionMediator field4, NullableInt32ExpressionMediator field5, NullableInt32ExpressionMediator field6, int value)
            => new Int32CoalesceFunctionExpression(new List<NullableExpressionMediator<int>> { field1, field2, field3, field4, field5, field6 }, new Int32ExpressionMediator(new LiteralExpression<int>(value)));

        public static NullableInt32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, NullableInt32ExpressionMediator field3, NullableInt32ExpressionMediator field4, NullableInt32ExpressionMediator field5, NullableInt32ExpressionMediator field6, int? value)
            => new NullableInt32CoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(value)));

        public static Int32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, NullableInt32ExpressionMediator field3, NullableInt32ExpressionMediator field4, NullableInt32ExpressionMediator field5, NullableInt32ExpressionMediator field6, Int32ExpressionMediator field7)
            => new Int32CoalesceFunctionExpression(new List<NullableExpressionMediator<int>> { field1, field2, field3, field4, field5, field6 }, field7);

        public static NullableInt32CoalesceFunctionExpression Coalesce(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2, NullableInt32ExpressionMediator field3, NullableInt32ExpressionMediator field4, NullableInt32ExpressionMediator field5, NullableInt32ExpressionMediator field6, NullableInt32ExpressionMediator field7)
            => new NullableInt32CoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, field7);
        #endregion

        #region long
        public static Int64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, long value)
            => new Int64CoalesceFunctionExpression(new List<NullableExpressionMediator<long>> { field1 }, new Int64ExpressionMediator(new LiteralExpression<long>(value)));

        public static NullableInt64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, long? value)
            => new NullableInt64CoalesceFunctionExpression(new List<NullableInt64ExpressionMediator> { field1, new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(value)) }.ToArray());

        public static Int64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, Int64ExpressionMediator field2)
            => new Int64CoalesceFunctionExpression(new List<NullableExpressionMediator<long>> { field1 }, field2);

        public static NullableInt64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2)
            => new NullableInt64CoalesceFunctionExpression(field1, field2);

        public static Int64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, long value)
            => new Int64CoalesceFunctionExpression(new List<NullableExpressionMediator<long>> { field1, field2 }, new Int64ExpressionMediator(new LiteralExpression<long>(value)));

        public static NullableInt64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, long? value)
            => new NullableInt64CoalesceFunctionExpression(field1, field2, new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(value)));

        public static Int64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, Int64ExpressionMediator field3)
            => new Int64CoalesceFunctionExpression(new List<NullableExpressionMediator<long>> { field1, field2 }, field3);

        public static NullableInt64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, NullableInt64ExpressionMediator field3)
            => new NullableInt64CoalesceFunctionExpression(field1, field2, field3);

        public static Int64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, NullableInt64ExpressionMediator field3, long value)
            => new Int64CoalesceFunctionExpression(new List<NullableExpressionMediator<long>> { field1, field2, field3 }, new Int64ExpressionMediator(new LiteralExpression<long>(value)));

        public static NullableInt64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, NullableInt64ExpressionMediator field3, long? value)
            => new NullableInt64CoalesceFunctionExpression(field1, field2, field3, new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(value)));

        public static Int64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, NullableInt64ExpressionMediator field3, Int64ExpressionMediator field4)
            => new Int64CoalesceFunctionExpression(new List<NullableExpressionMediator<long>> { field1, field2, field3 }, field4);

        public static NullableInt64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, NullableInt64ExpressionMediator field3, NullableInt64ExpressionMediator field4)
            => new NullableInt64CoalesceFunctionExpression(field1, field2, field3, field4);

        public static Int64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, NullableInt64ExpressionMediator field3, NullableInt64ExpressionMediator field4, long value)
            => new Int64CoalesceFunctionExpression(new List<NullableExpressionMediator<long>> { field1, field2, field3, field4 }, new Int64ExpressionMediator(new LiteralExpression<long>(value)));

        public static NullableInt64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, NullableInt64ExpressionMediator field3, NullableInt64ExpressionMediator field4, long? value)
            => new NullableInt64CoalesceFunctionExpression(field1, field2, field3, field4, new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(value)));

        public static Int64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, NullableInt64ExpressionMediator field3, NullableInt64ExpressionMediator field4, Int64ExpressionMediator field5)
            => new Int64CoalesceFunctionExpression(new List<NullableExpressionMediator<long>> { field1, field2, field3, field4 }, field5);

        public static NullableInt64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, NullableInt64ExpressionMediator field3, NullableInt64ExpressionMediator field4, NullableInt64ExpressionMediator field5)
            => new NullableInt64CoalesceFunctionExpression(field1, field2, field3, field4, field5);

        public static Int64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, NullableInt64ExpressionMediator field3, NullableInt64ExpressionMediator field4, NullableInt64ExpressionMediator field5, long value)
            => new Int64CoalesceFunctionExpression(new List<NullableExpressionMediator<long>> { field1, field2, field3, field4, field5 }, new Int64ExpressionMediator(new LiteralExpression<long>(value)));

        public static NullableInt64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, NullableInt64ExpressionMediator field3, NullableInt64ExpressionMediator field4, NullableInt64ExpressionMediator field5, long? value)
            => new NullableInt64CoalesceFunctionExpression(field1, field2, field3, field4, field5, new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(value)));

        public static Int64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, NullableInt64ExpressionMediator field3, NullableInt64ExpressionMediator field4, NullableInt64ExpressionMediator field5, Int64ExpressionMediator field6)
            => new Int64CoalesceFunctionExpression(new List<NullableExpressionMediator<long>> { field1, field2, field3, field4, field5 }, field6);

        public static NullableInt64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, NullableInt64ExpressionMediator field3, NullableInt64ExpressionMediator field4, NullableInt64ExpressionMediator field5, NullableInt64ExpressionMediator field6)
            => new NullableInt64CoalesceFunctionExpression(field1, field2, field3, field4, field5, field6);

        public static Int64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, NullableInt64ExpressionMediator field3, NullableInt64ExpressionMediator field4, NullableInt64ExpressionMediator field5, NullableInt64ExpressionMediator field6, long value)
            => new Int64CoalesceFunctionExpression(new List<NullableExpressionMediator<long>> { field1, field2, field3, field4, field5, field6 }, new Int64ExpressionMediator(new LiteralExpression<long>(value)));

        public static NullableInt64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, NullableInt64ExpressionMediator field3, NullableInt64ExpressionMediator field4, NullableInt64ExpressionMediator field5, NullableInt64ExpressionMediator field6, long? value)
            => new NullableInt64CoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(value)));

        public static Int64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, NullableInt64ExpressionMediator field3, NullableInt64ExpressionMediator field4, NullableInt64ExpressionMediator field5, NullableInt64ExpressionMediator field6, Int64ExpressionMediator field7)
            => new Int64CoalesceFunctionExpression(new List<NullableExpressionMediator<long>> { field1, field2, field3, field4, field5, field6 }, field7);

        public static NullableInt64CoalesceFunctionExpression Coalesce(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2, NullableInt64ExpressionMediator field3, NullableInt64ExpressionMediator field4, NullableInt64ExpressionMediator field5, NullableInt64ExpressionMediator field6, NullableInt64ExpressionMediator field7)
            => new NullableInt64CoalesceFunctionExpression(field1, field2, field3, field4, field5, field6, field7);
        #endregion

        #region string
        public static StringCoalesceFunctionExpression Coalesce(StringExpressionMediator field1, string value)
            => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1 }, new StringExpressionMediator(new LiteralExpression<string>(value)));

        public static StringCoalesceFunctionExpression Coalesce(StringExpressionMediator field1, StringExpressionMediator field2)
            => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1 }, field2);

        public static StringCoalesceFunctionExpression Coalesce(StringExpressionMediator field1, StringExpressionMediator field2, string value)
            => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2 }, new StringExpressionMediator(new LiteralExpression<string>(value)));

       public static StringCoalesceFunctionExpression Coalesce(StringExpressionMediator field1, StringExpressionMediator field2, StringExpressionMediator field3)
            => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2 }, field3);

        public static StringCoalesceFunctionExpression Coalesce(StringExpressionMediator field1, StringExpressionMediator field2, StringExpressionMediator field3, string value)
            => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3 }, new StringExpressionMediator(new LiteralExpression<string>(value)));

        public static StringCoalesceFunctionExpression Coalesce(StringExpressionMediator field1, StringExpressionMediator field2, StringExpressionMediator field3, StringExpressionMediator field4)
            => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3 }, field4);

        public static StringCoalesceFunctionExpression Coalesce(StringExpressionMediator field1, StringExpressionMediator field2, StringExpressionMediator field3, StringExpressionMediator field4, string value)
            => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, field4 }, new StringExpressionMediator(new LiteralExpression<string>(value)));

        public static StringCoalesceFunctionExpression Coalesce(StringExpressionMediator field1, StringExpressionMediator field2, StringExpressionMediator field3, StringExpressionMediator field4, StringExpressionMediator field5)
            => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, field4 }, field5);

        public static StringCoalesceFunctionExpression Coalesce(StringExpressionMediator field1, StringExpressionMediator field2, StringExpressionMediator field3, StringExpressionMediator field4, StringExpressionMediator field5, string value)
            => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, field4, field5 }, new StringExpressionMediator(new LiteralExpression<string>(value)));

        public static StringCoalesceFunctionExpression Coalesce(StringExpressionMediator field1, StringExpressionMediator field2, StringExpressionMediator field3, StringExpressionMediator field4, StringExpressionMediator field5, StringExpressionMediator field6)
            => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, field4, field5 }, field6);

        public static StringCoalesceFunctionExpression Coalesce(StringExpressionMediator field1, StringExpressionMediator field2, StringExpressionMediator field3, StringExpressionMediator field4, StringExpressionMediator field5, StringExpressionMediator field6, string value)
            => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, field4, field5, field6 }, new StringExpressionMediator(new LiteralExpression<string>(value)));

        public static StringCoalesceFunctionExpression Coalesce(StringExpressionMediator field1, StringExpressionMediator field2, StringExpressionMediator field3, StringExpressionMediator field4, StringExpressionMediator field5, StringExpressionMediator field6, StringExpressionMediator field7)
            => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, field4, field5, field6 }, field7);
        #endregion

        #endregion

        #region isnull
        #region bool
        public static BooleanIsNullFunctionExpression IsNull(NullableBooleanExpressionMediator field1, BooleanExpressionMediator field2)
            => new BooleanIsNullFunctionExpression(field1, field2);

        public static NullableBooleanIsNullFunctionExpression IsNull(NullableBooleanExpressionMediator field1, NullableBooleanExpressionMediator field2)
            => new NullableBooleanIsNullFunctionExpression(field1, field2);

        public static BooleanIsNullFunctionExpression IsNull(NullableBooleanExpressionMediator field, bool value)
            => new BooleanIsNullFunctionExpression(field, new BooleanExpressionMediator(new LiteralExpression<bool>(value)));

        public static NullableBooleanIsNullFunctionExpression IsNull(NullableBooleanExpressionMediator field, bool? value)
            => new NullableBooleanIsNullFunctionExpression(field, new NullableBooleanExpressionMediator(new NullableLiteralExpression<bool?>(value)));
        #endregion

        #region byte
        public static ByteIsNullFunctionExpression IsNull(NullableByteExpressionMediator field1, ByteExpressionMediator field2)
            => new ByteIsNullFunctionExpression(field1, field2);

        public static NullableByteIsNullFunctionExpression IsNull(NullableByteExpressionMediator field1, NullableByteExpressionMediator field2)
            => new NullableByteIsNullFunctionExpression(field1, field2);

        public static ByteIsNullFunctionExpression IsNull(NullableByteExpressionMediator field, byte value)
            => new ByteIsNullFunctionExpression(field, new ByteExpressionMediator(new LiteralExpression<byte>(value)));

        public static NullableByteIsNullFunctionExpression IsNull(NullableByteExpressionMediator field, byte? value)
            => new NullableByteIsNullFunctionExpression(field, new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(value)));
        #endregion

        #region DateTime
        public static DateTimeIsNullFunctionExpression IsNull(NullableDateTimeExpressionMediator field1, DateTimeExpressionMediator field2)
            => new DateTimeIsNullFunctionExpression(field1, field2);

        public static NullableDateTimeIsNullFunctionExpression IsNull(NullableDateTimeExpressionMediator field1, NullableDateTimeExpressionMediator field2)
            => new NullableDateTimeIsNullFunctionExpression(field1, field2);

        public static DateTimeIsNullFunctionExpression IsNull(NullableDateTimeExpressionMediator field, DateTime value)
            => new DateTimeIsNullFunctionExpression(field, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(value)));

        public static NullableDateTimeIsNullFunctionExpression IsNull(NullableDateTimeExpressionMediator field, DateTime? value)
            => new NullableDateTimeIsNullFunctionExpression(field, new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(value)));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetIsNullFunctionExpression IsNull(NullableDateTimeOffsetExpressionMediator field1, DateTimeOffsetExpressionMediator field2)
             => new DateTimeOffsetIsNullFunctionExpression(field1, field2);

        public static NullableDateTimeOffsetIsNullFunctionExpression IsNull(NullableDateTimeOffsetExpressionMediator field1, NullableDateTimeOffsetExpressionMediator field2)
            => new NullableDateTimeOffsetIsNullFunctionExpression(field1, field2);

        public static DateTimeOffsetIsNullFunctionExpression IsNull(NullableDateTimeOffsetExpressionMediator field, DateTime value)
            => new DateTimeOffsetIsNullFunctionExpression(field, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTime>(value)));

        public static NullableDateTimeOffsetIsNullFunctionExpression IsNull(NullableDateTimeOffsetExpressionMediator field, DateTime? value)
            => new NullableDateTimeOffsetIsNullFunctionExpression(field, new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTime?>(value)));
        #endregion

        #region decimal
        public static DecimalIsNullFunctionExpression IsNull(NullableDecimalExpressionMediator field1, DecimalExpressionMediator field2)
            => new DecimalIsNullFunctionExpression(field1, field2);

        public static NullableDecimalIsNullFunctionExpression IsNull(NullableDecimalExpressionMediator field1, NullableDecimalExpressionMediator field2)
            => new NullableDecimalIsNullFunctionExpression(field1, field2);

        public static DecimalIsNullFunctionExpression IsNull(NullableDecimalExpressionMediator field, decimal value)
            => new DecimalIsNullFunctionExpression(field, new DecimalExpressionMediator(new LiteralExpression<decimal>(value)));

        public static NullableDecimalIsNullFunctionExpression IsNull(NullableDecimalExpressionMediator field, decimal? value)
            => new NullableDecimalIsNullFunctionExpression(field, new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(value)));
        #endregion

        #region double
        public static DoubleIsNullFunctionExpression IsNull(NullableDoubleExpressionMediator field1, DoubleExpressionMediator field2)
            => new DoubleIsNullFunctionExpression(field1, field2);

        public static NullableDoubleIsNullFunctionExpression IsNull(NullableDoubleExpressionMediator field1, NullableDoubleExpressionMediator field2)
            => new NullableDoubleIsNullFunctionExpression(field1, field2);

        public static DoubleIsNullFunctionExpression IsNull(NullableDoubleExpressionMediator field, double value)
            => new DoubleIsNullFunctionExpression(field, new DoubleExpressionMediator(new LiteralExpression<double>(value)));

        public static NullableDoubleIsNullFunctionExpression IsNull(NullableDoubleExpressionMediator field, double? value)
            => new NullableDoubleIsNullFunctionExpression(field, new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(value)));
        #endregion

        #region enum
        public static EnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(NullableEnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2)
            where TEnum : struct, Enum, IComparable
            => new EnumIsNullFunctionExpression<TEnum>(field1, field2);

        public static NullableEnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(NullableEnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumIsNullFunctionExpression<TEnum>(field1, field2);

        public static EnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(NullableEnumExpressionMediator<TEnum> field, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumIsNullFunctionExpression<TEnum>(field, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)));

        public static NullableEnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(NullableEnumExpressionMediator<TEnum> field, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumIsNullFunctionExpression<TEnum>(field, new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(value)));
        #endregion

        #region float
        public static SingleIsNullFunctionExpression IsNull(NullableSingleExpressionMediator field1, SingleExpressionMediator field2)
            => new SingleIsNullFunctionExpression(field1, field2);

        public static NullableSingleIsNullFunctionExpression IsNull(NullableSingleExpressionMediator field1, NullableSingleExpressionMediator field2)
            => new NullableSingleIsNullFunctionExpression(field1, field2);

        public static SingleIsNullFunctionExpression IsNull(NullableSingleExpressionMediator field, float value)
            => new SingleIsNullFunctionExpression(field, new SingleExpressionMediator(new LiteralExpression<float>(value)));

        public static NullableSingleIsNullFunctionExpression IsNull(NullableSingleExpressionMediator field, float? value)
            => new NullableSingleIsNullFunctionExpression(field, new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(value)));
        #endregion

        #region Guid
        public static GuidIsNullFunctionExpression IsNull(NullableGuidExpressionMediator field1, GuidExpressionMediator field2)
            => new GuidIsNullFunctionExpression(field1, field2);

        public static NullableGuidIsNullFunctionExpression IsNull(NullableGuidExpressionMediator field1, NullableGuidExpressionMediator field2)
            => new NullableGuidIsNullFunctionExpression(field1, field2);

        public static GuidIsNullFunctionExpression IsNull(NullableGuidExpressionMediator field, Guid value)
            => new GuidIsNullFunctionExpression(field, new GuidExpressionMediator(new LiteralExpression<Guid>(value)));

        public static NullableGuidIsNullFunctionExpression IsNull(NullableGuidExpressionMediator field, Guid? value)
            => new NullableGuidIsNullFunctionExpression(field, new NullableGuidExpressionMediator(new NullableLiteralExpression<Guid?>(value)));
        #endregion

        #region short
        public static Int16IsNullFunctionExpression IsNull(NullableInt16ExpressionMediator field1, Int16ExpressionMediator field2)
            => new Int16IsNullFunctionExpression(field1, field2);

        public static NullableInt16IsNullFunctionExpression IsNull(NullableInt16ExpressionMediator field1, NullableInt16ExpressionMediator field2)
            => new NullableInt16IsNullFunctionExpression(field1, field2);

        public static Int16IsNullFunctionExpression IsNull(NullableInt16ExpressionMediator field, short value)
            => new Int16IsNullFunctionExpression(field, new Int16ExpressionMediator(new LiteralExpression<short>(value)));

        public static NullableInt16IsNullFunctionExpression IsNull(NullableInt16ExpressionMediator field, short? value)
            => new NullableInt16IsNullFunctionExpression(field, new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(value)));
        #endregion

        #region int
        public static Int32IsNullFunctionExpression IsNull(NullableInt32ExpressionMediator field1, Int32ExpressionMediator field2)
            => new Int32IsNullFunctionExpression(field1, field2);

        public static NullableInt32IsNullFunctionExpression IsNull(NullableInt32ExpressionMediator field1, NullableInt32ExpressionMediator field2)
            => new NullableInt32IsNullFunctionExpression(field1, field2);

        public static Int32IsNullFunctionExpression IsNull(NullableInt32ExpressionMediator field, int value)
            => new Int32IsNullFunctionExpression(field, new Int32ExpressionMediator(new LiteralExpression<int>(value)));

        public static NullableInt32IsNullFunctionExpression IsNull(NullableInt32ExpressionMediator field, int? value)
            => new NullableInt32IsNullFunctionExpression(field, new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(value)));
        #endregion

        #region long
        public static Int64IsNullFunctionExpression IsNull(NullableInt64ExpressionMediator field1, Int64ExpressionMediator field2)
            => new Int64IsNullFunctionExpression(field1, field2);

        public static NullableInt64IsNullFunctionExpression IsNull(NullableInt64ExpressionMediator field1, NullableInt64ExpressionMediator field2)
            => new NullableInt64IsNullFunctionExpression(field1, field2);

        public static Int64IsNullFunctionExpression IsNull(NullableInt64ExpressionMediator field, long value)
            => new Int64IsNullFunctionExpression(field, new Int64ExpressionMediator(new LiteralExpression<long>(value)));

        public static NullableInt64IsNullFunctionExpression IsNull(NullableInt64ExpressionMediator field, long? value)
            => new NullableInt64IsNullFunctionExpression(field, new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(value)));
        #endregion

        #region string
        public static StringIsNullFunctionExpression IsNull(StringExpressionMediator field1, StringExpressionMediator field2)
            => new StringIsNullFunctionExpression(field1, field2);

        public static StringIsNullFunctionExpression IsNull(StringExpressionMediator field, string value)
            => new StringIsNullFunctionExpression(field, new StringExpressionMediator(new LiteralExpression<string>(value)));
        #endregion
        #endregion

        #region average
        public static Int32AverageFunctionExpression Avg(ByteExpressionMediator field, bool distinct = false)
            => new Int32AverageFunctionExpression(field, distinct);

        public static NullableInt32AverageFunctionExpression Avg(NullableByteExpressionMediator field, bool distinct = false)
            => new NullableInt32AverageFunctionExpression(field, distinct);

        public static Int32AverageFunctionExpression Avg(Int16ExpressionMediator field, bool distinct = false)
            => new Int32AverageFunctionExpression(field, distinct);

        public static NullableInt32AverageFunctionExpression Avg(NullableInt16ExpressionMediator field, bool distinct = false)
            => new NullableInt32AverageFunctionExpression(field, distinct);

        public static Int32AverageFunctionExpression Avg(Int32ExpressionMediator field, bool distinct = false)
            => new Int32AverageFunctionExpression(field, distinct);

        public static NullableInt32AverageFunctionExpression Avg(NullableInt32ExpressionMediator field, bool distinct = false)
            => new NullableInt32AverageFunctionExpression(field, distinct);

        public static Int64AverageFunctionExpression Avg(Int64ExpressionMediator field, bool distinct = false)
            => new Int64AverageFunctionExpression(field, distinct);

        public static NullableInt64AverageFunctionExpression Avg(NullableInt64ExpressionMediator field, bool distinct = false)
            => new NullableInt64AverageFunctionExpression(field, distinct);

        public static SingleAverageFunctionExpression Avg(SingleExpressionMediator field, bool distinct = false)
            => new SingleAverageFunctionExpression(field, distinct);

        public static NullableSingleAverageFunctionExpression Avg(NullableSingleExpressionMediator field, bool distinct = false)
            => new NullableSingleAverageFunctionExpression(field, distinct);

        public static DoubleAverageFunctionExpression Avg(DoubleExpressionMediator field, bool distinct = false)
            => new DoubleAverageFunctionExpression(field, distinct);

        public static NullableDoubleAverageFunctionExpression Avg(NullableDoubleExpressionMediator field, bool distinct = false)
            => new NullableDoubleAverageFunctionExpression(field, distinct);

        public static DecimalAverageFunctionExpression Avg(DecimalExpressionMediator field, bool distinct = false)
            => new DecimalAverageFunctionExpression(field, distinct);

        public static NullableDecimalAverageFunctionExpression Avg(NullableDecimalExpressionMediator field, bool distinct = false)
            => new NullableDecimalAverageFunctionExpression(field, distinct);
        #endregion

        #region minimum
        public static ByteMinimumFunctionExpression Min(ByteExpressionMediator field, bool distinct = false)
            => new ByteMinimumFunctionExpression(field, distinct);

        public static NullableByteMinimumFunctionExpression Min(NullableByteExpressionMediator field, bool distinct = false)
            => new NullableByteMinimumFunctionExpression(field, distinct);

        public static Int16MinimumFunctionExpression Min(Int16ExpressionMediator field, bool distinct = false)
            => new Int16MinimumFunctionExpression(field, distinct);

        public static NullableInt16MinimumFunctionExpression Min(NullableInt16ExpressionMediator field, bool distinct = false)
            => new NullableInt16MinimumFunctionExpression(field, distinct);

        public static Int32MinimumFunctionExpression Min(Int32ExpressionMediator field, bool distinct = false)
            => new Int32MinimumFunctionExpression(field, distinct);

        public static NullableInt32MinimumFunctionExpression Min(NullableInt32ExpressionMediator field, bool distinct = false)
            => new NullableInt32MinimumFunctionExpression(field, distinct);

        public static Int64MinimumFunctionExpression Min(Int64ExpressionMediator field, bool distinct = false)
            => new Int64MinimumFunctionExpression(field, distinct);

        public static NullableInt64MinimumFunctionExpression Min(NullableInt64ExpressionMediator field, bool distinct = false)
            => new NullableInt64MinimumFunctionExpression(field, distinct);

        public static SingleMinimumFunctionExpression Min(SingleExpressionMediator field, bool distinct = false)
            => new SingleMinimumFunctionExpression(field, distinct);

        public static NullableSingleMinimumFunctionExpression Min(NullableSingleExpressionMediator field, bool distinct = false)
            => new NullableSingleMinimumFunctionExpression(field, distinct);

        public static DoubleMinimumFunctionExpression Min(DoubleExpressionMediator field, bool distinct = false)
            => new DoubleMinimumFunctionExpression(field, distinct);

        public static NullableDoubleMinimumFunctionExpression Min(NullableDoubleExpressionMediator field, bool distinct = false)
            => new NullableDoubleMinimumFunctionExpression(field, distinct);

        public static DecimalMinimumFunctionExpression Min(DecimalExpressionMediator field, bool distinct = false)
            => new DecimalMinimumFunctionExpression(field, distinct);

        public static NullableDecimalMinimumFunctionExpression Min(NullableDecimalExpressionMediator field, bool distinct = false)
            => new NullableDecimalMinimumFunctionExpression(field, distinct);

        public static DateTimeMinimumFunctionExpression Min(DateTimeExpressionMediator field, bool distinct = false)
            => new DateTimeMinimumFunctionExpression(field, distinct);

        public static NullableDateTimeMinimumFunctionExpression Min(NullableDateTimeExpressionMediator field, bool distinct = false)
            => new NullableDateTimeMinimumFunctionExpression(field, distinct);

        public static DateTimeOffsetMinimumFunctionExpression Min(DateTimeOffsetExpressionMediator field, bool distinct = false)
            => new DateTimeOffsetMinimumFunctionExpression(field, distinct);

        public static NullableDateTimeOffsetMinimumFunctionExpression Min(NullableDateTimeOffsetExpressionMediator field, bool distinct = false)
            => new NullableDateTimeOffsetMinimumFunctionExpression(field, distinct);

        public static GuidMinimumFunctionExpression Min(GuidExpressionMediator field, bool distinct = false)
            => new GuidMinimumFunctionExpression(field, distinct);

        public static NullableGuidMinimumFunctionExpression Min(NullableGuidExpressionMediator field, bool distinct = false)
            => new NullableGuidMinimumFunctionExpression(field, distinct);

        public static StringMinimumFunctionExpression Min(StringExpressionMediator field, bool distinct = false)
            => new StringMinimumFunctionExpression(field, distinct);
        #endregion

        #region maximum
        public static ByteMaximumFunctionExpression Max(ByteExpressionMediator field, bool distinct = false)
            => new ByteMaximumFunctionExpression(field, distinct);

        public static NullableByteMaximumFunctionExpression Max(NullableByteExpressionMediator field, bool distinct = false)
            => new NullableByteMaximumFunctionExpression(field, distinct);

        public static Int16MaximumFunctionExpression Max(Int16ExpressionMediator field, bool distinct = false)
            => new Int16MaximumFunctionExpression(field, distinct);

        public static NullableInt16MaximumFunctionExpression Max(NullableInt16ExpressionMediator field, bool distinct = false)
            => new NullableInt16MaximumFunctionExpression(field, distinct);

        public static Int32MaximumFunctionExpression Max(Int32ExpressionMediator field, bool distinct = false)
            => new Int32MaximumFunctionExpression(field, distinct);

        public static NullableInt32MaximumFunctionExpression Max(NullableInt32ExpressionMediator field, bool distinct = false)
            => new NullableInt32MaximumFunctionExpression(field, distinct);

        public static Int64MaximumFunctionExpression Max(Int64ExpressionMediator field, bool distinct = false)
            => new Int64MaximumFunctionExpression(field, distinct);

        public static NullableInt64MaximumFunctionExpression Max(NullableInt64ExpressionMediator field, bool distinct = false)
            => new NullableInt64MaximumFunctionExpression(field, distinct);

        public static SingleMaximumFunctionExpression Max(SingleExpressionMediator field, bool distinct = false)
            => new SingleMaximumFunctionExpression(field, distinct);

        public static NullableSingleMaximumFunctionExpression Max(NullableSingleExpressionMediator field, bool distinct = false)
            => new NullableSingleMaximumFunctionExpression(field, distinct);

        public static DoubleMaximumFunctionExpression Max(DoubleExpressionMediator field, bool distinct = false)
            => new DoubleMaximumFunctionExpression(field, distinct);

        public static NullableDoubleMaximumFunctionExpression Max(NullableDoubleExpressionMediator field, bool distinct = false)
            => new NullableDoubleMaximumFunctionExpression(field, distinct);

        public static DecimalMaximumFunctionExpression Max(DecimalExpressionMediator field, bool distinct = false)
            => new DecimalMaximumFunctionExpression(field, distinct);

        public static NullableDecimalMaximumFunctionExpression Max(NullableDecimalExpressionMediator field, bool distinct = false)
            => new NullableDecimalMaximumFunctionExpression(field, distinct);

        public static DateTimeMaximumFunctionExpression Max(DateTimeExpressionMediator field, bool distinct = false)
            => new DateTimeMaximumFunctionExpression(field, distinct);

        public static NullableDateTimeMaximumFunctionExpression Max(NullableDateTimeExpressionMediator field, bool distinct = false)
            => new NullableDateTimeMaximumFunctionExpression(field, distinct);

        public static DateTimeOffsetMaximumFunctionExpression Max(DateTimeOffsetExpressionMediator field, bool distinct = false)
            => new DateTimeOffsetMaximumFunctionExpression(field, distinct);

        public static NullableDateTimeOffsetMaximumFunctionExpression Max(NullableDateTimeOffsetExpressionMediator field, bool distinct = false)
            => new NullableDateTimeOffsetMaximumFunctionExpression(field, distinct);

        public static GuidMaximumFunctionExpression Max(GuidExpressionMediator field, bool distinct = false)
            => new GuidMaximumFunctionExpression(field, distinct);

        public static NullableGuidMaximumFunctionExpression Max(NullableGuidExpressionMediator field, bool distinct = false)
            => new NullableGuidMaximumFunctionExpression(field, distinct);

        public static StringMaximumFunctionExpression Max(StringExpressionMediator field, bool distinct = false)
            => new StringMaximumFunctionExpression(field, distinct);
        #endregion

        #region count
        public static Int32CountFunctionExpression Count()
            => new Int32CountFunctionExpression();

        public static Int32CountFunctionExpression Count(ExpressionMediator field, bool distinct = false)
            => new Int32CountFunctionExpression(field, distinct);
        #endregion

        #region sum
        public static Int32SumFunctionExpression Sum(ByteExpressionMediator field, bool distinct = false)
            => new Int32SumFunctionExpression(field, distinct);

        public static NullableInt32SumFunctionExpression Sum(NullableByteExpressionMediator field, bool distinct = false)
            => new NullableInt32SumFunctionExpression(field, distinct);

        public static Int32SumFunctionExpression Sum(Int16ExpressionMediator field, bool distinct = false)
            => new Int32SumFunctionExpression(field, distinct);

        public static NullableInt32SumFunctionExpression Sum(NullableInt16ExpressionMediator field, bool distinct = false)
            => new NullableInt32SumFunctionExpression(field, distinct);

        public static Int32SumFunctionExpression Sum(Int32ExpressionMediator field, bool distinct = false)
            => new Int32SumFunctionExpression(field, distinct);

        public static NullableInt32SumFunctionExpression Sum(NullableInt32ExpressionMediator field, bool distinct = false)
            => new NullableInt32SumFunctionExpression(field, distinct);

        public static Int64SumFunctionExpression Sum(Int64ExpressionMediator field, bool distinct = false)
            => new Int64SumFunctionExpression(field, distinct);

        public static NullableInt64SumFunctionExpression Sum(NullableInt64ExpressionMediator field, bool distinct = false)
            => new NullableInt64SumFunctionExpression(field, distinct);

        public static DoubleSumFunctionExpression Sum(DoubleExpressionMediator field, bool distinct = false)
            => new DoubleSumFunctionExpression(field, distinct);

        public static NullableDoubleSumFunctionExpression Sum(NullableDoubleExpressionMediator field, bool distinct = false)
            => new NullableDoubleSumFunctionExpression(field, distinct);

        public static DecimalSumFunctionExpression Sum(DecimalExpressionMediator field, bool distinct = false)
            => new DecimalSumFunctionExpression(field, distinct);

        public static NullableDecimalSumFunctionExpression Sum(NullableDecimalExpressionMediator field, bool distinct = false)
            => new NullableDecimalSumFunctionExpression(field, distinct);

        public static SingleSumFunctionExpression Sum(SingleExpressionMediator field, bool distinct = false)
            => new SingleSumFunctionExpression(field, distinct);

        public static NullableSingleSumFunctionExpression Sum(NullableSingleExpressionMediator field, bool distinct = false)
            => new NullableSingleSumFunctionExpression(field, distinct);
        #endregion

        #region standard deviation
        public static SingleStandardDeviationFunctionExpression StDev(ByteExpressionMediator field, bool distinct = false)
            => new SingleStandardDeviationFunctionExpression(field, distinct);

        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableByteExpressionMediator field, bool distinct = false)
            => new NullableSingleStandardDeviationFunctionExpression(field, distinct);

        public static SingleStandardDeviationFunctionExpression StDev(Int16ExpressionMediator field, bool distinct = false)
            => new SingleStandardDeviationFunctionExpression(field, distinct);

        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableInt16ExpressionMediator field, bool distinct = false)
            => new NullableSingleStandardDeviationFunctionExpression(field, distinct);

        public static SingleStandardDeviationFunctionExpression StDev(Int32ExpressionMediator field, bool distinct = false)
            => new SingleStandardDeviationFunctionExpression(field, distinct);

        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableInt32ExpressionMediator field, bool distinct = false)
            => new NullableSingleStandardDeviationFunctionExpression(field, distinct);

        public static SingleStandardDeviationFunctionExpression StDev(Int64ExpressionMediator field, bool distinct = false)
            => new SingleStandardDeviationFunctionExpression(field, distinct);

        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableInt64ExpressionMediator field, bool distinct = false)
            => new NullableSingleStandardDeviationFunctionExpression(field, distinct);

        public static SingleStandardDeviationFunctionExpression StDev(DoubleExpressionMediator field, bool distinct = false)
            => new SingleStandardDeviationFunctionExpression(field, distinct);

        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableDoubleExpressionMediator field, bool distinct = false)
            => new NullableSingleStandardDeviationFunctionExpression(field, distinct);

        public static SingleStandardDeviationFunctionExpression StDev(DecimalExpressionMediator field, bool distinct = false)
            => new SingleStandardDeviationFunctionExpression(field, distinct);

        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableDecimalExpressionMediator field, bool distinct = false)
            => new NullableSingleStandardDeviationFunctionExpression(field, distinct);

        public static SingleStandardDeviationFunctionExpression StDev(SingleExpressionMediator field, bool distinct = false)
            => new SingleStandardDeviationFunctionExpression(field, distinct);

        public static NullableSingleStandardDeviationFunctionExpression StDev(NullableSingleExpressionMediator field, bool distinct = false)
            => new NullableSingleStandardDeviationFunctionExpression(field, distinct);
        #endregion

        #region standard deviation p
        public static SinglePopulationStandardDeviationFunctionExpression StDevP(ByteExpressionMediator field, bool distinct = false)
            => new SinglePopulationStandardDeviationFunctionExpression(field, distinct);

        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableByteExpressionMediator field, bool distinct = false)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(field, distinct);

        public static SinglePopulationStandardDeviationFunctionExpression StDevP(Int16ExpressionMediator field, bool distinct = false)
            => new SinglePopulationStandardDeviationFunctionExpression(field, distinct);

        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableInt16ExpressionMediator field, bool distinct = false)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(field, distinct);

        public static SinglePopulationStandardDeviationFunctionExpression StDevP(Int32ExpressionMediator field, bool distinct = false)
            => new SinglePopulationStandardDeviationFunctionExpression(field, distinct);

        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableInt32ExpressionMediator field, bool distinct = false)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(field, distinct);

        public static SinglePopulationStandardDeviationFunctionExpression StDevP(Int64ExpressionMediator field, bool distinct = false)
            => new SinglePopulationStandardDeviationFunctionExpression(field, distinct);

        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableInt64ExpressionMediator field, bool distinct = false)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(field, distinct);

        public static SinglePopulationStandardDeviationFunctionExpression StDevP(DoubleExpressionMediator field, bool distinct = false)
            => new SinglePopulationStandardDeviationFunctionExpression(field, distinct);

        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableDoubleExpressionMediator field, bool distinct = false)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(field, distinct);

        public static SinglePopulationStandardDeviationFunctionExpression StDevP(DecimalExpressionMediator field, bool distinct = false)
            => new SinglePopulationStandardDeviationFunctionExpression(field, distinct);

        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableDecimalExpressionMediator field, bool distinct = false)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(field, distinct);

        public static SinglePopulationStandardDeviationFunctionExpression StDevP(SingleExpressionMediator field, bool distinct = false)
            => new SinglePopulationStandardDeviationFunctionExpression(field, distinct);

        public static NullableSinglePopulationStandardDeviationFunctionExpression StDevP(NullableSingleExpressionMediator field, bool distinct = false)
            => new NullableSinglePopulationStandardDeviationFunctionExpression(field, distinct);
        #endregion

        #region variance
        public static SingleVarianceFunctionExpression Var(ByteExpressionMediator field, bool distinct = false)
            => new SingleVarianceFunctionExpression(field, distinct);

        public static NullableSingleVarianceFunctionExpression Var(NullableByteExpressionMediator field, bool distinct = false)
            => new NullableSingleVarianceFunctionExpression(field, distinct);

        public static SingleVarianceFunctionExpression Var(Int16ExpressionMediator field, bool distinct = false)
            => new SingleVarianceFunctionExpression(field, distinct);

        public static NullableSingleVarianceFunctionExpression Var(NullableInt16ExpressionMediator field, bool distinct = false)
            => new NullableSingleVarianceFunctionExpression(field, distinct);

        public static SingleVarianceFunctionExpression Var(Int32ExpressionMediator field, bool distinct = false)
            => new SingleVarianceFunctionExpression(field, distinct);

        public static NullableSingleVarianceFunctionExpression Var(NullableInt32ExpressionMediator field, bool distinct = false)
            => new NullableSingleVarianceFunctionExpression(field, distinct);

        public static SingleVarianceFunctionExpression Var(Int64ExpressionMediator field, bool distinct = false)
            => new SingleVarianceFunctionExpression(field, distinct);

        public static NullableSingleVarianceFunctionExpression Var(NullableInt64ExpressionMediator field, bool distinct = false)
            => new NullableSingleVarianceFunctionExpression(field, distinct);

        public static SingleVarianceFunctionExpression Var(DoubleExpressionMediator field, bool distinct = false)
            => new SingleVarianceFunctionExpression(field, distinct);

        public static NullableSingleVarianceFunctionExpression Var(NullableDoubleExpressionMediator field, bool distinct = false)
            => new NullableSingleVarianceFunctionExpression(field, distinct);

        public static SingleVarianceFunctionExpression Var(DecimalExpressionMediator field, bool distinct = false)
            => new SingleVarianceFunctionExpression(field, distinct);

        public static NullableSingleVarianceFunctionExpression Var(NullableDecimalExpressionMediator field, bool distinct = false)
            => new NullableSingleVarianceFunctionExpression(field, distinct);

        public static SingleVarianceFunctionExpression Var(SingleExpressionMediator field, bool distinct = false)
            => new SingleVarianceFunctionExpression(field, distinct);

        public static NullableSingleVarianceFunctionExpression Var(NullableSingleExpressionMediator field, bool distinct = false)
            => new NullableSingleVarianceFunctionExpression(field, distinct);
        #endregion

        #region variance p
        public static SinglePopulationVarianceFunctionExpression VarP(ByteExpressionMediator field, bool distinct = false)
            => new SinglePopulationVarianceFunctionExpression(field, distinct);

        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableByteExpressionMediator field, bool distinct = false)
            => new NullableSinglePopulationVarianceFunctionExpression(field, distinct);

        public static SinglePopulationVarianceFunctionExpression VarP(Int16ExpressionMediator field, bool distinct = false)
            => new SinglePopulationVarianceFunctionExpression(field, distinct);

        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableInt16ExpressionMediator field, bool distinct = false)
            => new NullableSinglePopulationVarianceFunctionExpression(field, distinct);

        public static SinglePopulationVarianceFunctionExpression VarP(Int32ExpressionMediator field, bool distinct = false)
            => new SinglePopulationVarianceFunctionExpression(field, distinct);

        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableInt32ExpressionMediator field, bool distinct = false)
            => new NullableSinglePopulationVarianceFunctionExpression(field, distinct);

        public static SinglePopulationVarianceFunctionExpression VarP(Int64ExpressionMediator field, bool distinct = false)
            => new SinglePopulationVarianceFunctionExpression(field, distinct);

        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableInt64ExpressionMediator field, bool distinct = false)
            => new NullableSinglePopulationVarianceFunctionExpression(field, distinct);

        public static SinglePopulationVarianceFunctionExpression VarP(DoubleExpressionMediator field, bool distinct = false)
            => new SinglePopulationVarianceFunctionExpression(field, distinct);

        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableDoubleExpressionMediator field, bool distinct = false)
            => new NullableSinglePopulationVarianceFunctionExpression(field, distinct);

        public static SinglePopulationVarianceFunctionExpression VarP(DecimalExpressionMediator field, bool distinct = false)
            => new SinglePopulationVarianceFunctionExpression(field, distinct);

        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableDecimalExpressionMediator field, bool distinct = false)
            => new NullableSinglePopulationVarianceFunctionExpression(field, distinct);

        public static SinglePopulationVarianceFunctionExpression VarP(SingleExpressionMediator field, bool distinct = false)
            => new SinglePopulationVarianceFunctionExpression(field, distinct);

        public static NullableSinglePopulationVarianceFunctionExpression VarP(NullableSingleExpressionMediator field, bool distinct = false)
            => new NullableSinglePopulationVarianceFunctionExpression(field, distinct);
        #endregion

        #region date
        public static CurrentTimestampFunctionExpression Current_Timestamp
            => new CurrentTimestampFunctionExpression();
        #endregion

        #region floor
        public static ByteFloorFunctionExpression Floor(ByteExpressionMediator field)
            => new ByteFloorFunctionExpression(field);

        public static NullableByteFloorFunctionExpression Floor(NullableByteExpressionMediator field)
            => new NullableByteFloorFunctionExpression(field);

        public static Int16FloorFunctionExpression Floor(Int16ExpressionMediator field)
            => new Int16FloorFunctionExpression(field);

        public static NullableInt16FloorFunctionExpression Floor(NullableInt16ExpressionMediator field)
            => new NullableInt16FloorFunctionExpression(field);

        public static Int32FloorFunctionExpression Floor(Int32ExpressionMediator field)
            => new Int32FloorFunctionExpression(field);

        public static NullableInt32FloorFunctionExpression Floor(NullableInt32ExpressionMediator field)
            => new NullableInt32FloorFunctionExpression(field);

        public static Int64FloorFunctionExpression Floor(Int64ExpressionMediator field)
            => new Int64FloorFunctionExpression(field);

        public static NullableInt64FloorFunctionExpression Floor(NullableInt64ExpressionMediator field)
            => new NullableInt64FloorFunctionExpression(field);

        public static SingleFloorFunctionExpression Floor(SingleExpressionMediator field)
            => new SingleFloorFunctionExpression(field);

        public static NullableSingleFloorFunctionExpression Floor(NullableSingleExpressionMediator field)
            => new NullableSingleFloorFunctionExpression(field);

        public static DoubleFloorFunctionExpression Floor(DoubleExpressionMediator field)
            => new DoubleFloorFunctionExpression(field);

        public static NullableDoubleFloorFunctionExpression Floor(NullableDoubleExpressionMediator field)
            => new NullableDoubleFloorFunctionExpression(field);

        public static DecimalFloorFunctionExpression Floor(DecimalExpressionMediator field)
            => new DecimalFloorFunctionExpression(field);

        public static NullableDecimalFloorFunctionExpression Floor(NullableDecimalExpressionMediator field)
            => new NullableDecimalFloorFunctionExpression(field);
        #endregion

        #region ceiling
        public static ByteCeilingFunctionExpression Ceiling(ByteExpressionMediator field)
            => new ByteCeilingFunctionExpression(field);

        public static NullableByteCeilingFunctionExpression Ceiling(NullableByteExpressionMediator field)
            => new NullableByteCeilingFunctionExpression(field);

        public static Int16CeilingFunctionExpression Ceiling(Int16ExpressionMediator field)
            => new Int16CeilingFunctionExpression(field);

        public static NullableInt16CeilingFunctionExpression Ceiling(NullableInt16ExpressionMediator field)
            => new NullableInt16CeilingFunctionExpression(field);

        public static Int32CeilingFunctionExpression Ceiling(Int32ExpressionMediator field)
            => new Int32CeilingFunctionExpression(field);

        public static NullableInt32CeilingFunctionExpression Ceiling(NullableInt32ExpressionMediator field)
            => new NullableInt32CeilingFunctionExpression(field);

        public static Int64CeilingFunctionExpression Ceiling(Int64ExpressionMediator field)
            => new Int64CeilingFunctionExpression(field);

        public static NullableInt64CeilingFunctionExpression Ceiling(NullableInt64ExpressionMediator field)
            => new NullableInt64CeilingFunctionExpression(field);

        public static SingleCeilingFunctionExpression Ceiling(SingleExpressionMediator field)
            => new SingleCeilingFunctionExpression(field);

        public static NullableSingleCeilingFunctionExpression Ceiling(NullableSingleExpressionMediator field)
            => new NullableSingleCeilingFunctionExpression(field);

        public static DoubleCeilingFunctionExpression Ceiling(DoubleExpressionMediator field)
            => new DoubleCeilingFunctionExpression(field);

        public static NullableDoubleCeilingFunctionExpression Ceiling(NullableDoubleExpressionMediator field)
            => new NullableDoubleCeilingFunctionExpression(field);

        public static DecimalCeilingFunctionExpression Ceiling(DecimalExpressionMediator field)
            => new DecimalCeilingFunctionExpression(field);

        public static NullableDecimalCeilingFunctionExpression Ceiling(NullableDecimalExpressionMediator field)
            => new NullableDecimalCeilingFunctionExpression(field);
        #endregion
    }
}
