using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public partial class SqlFunctionExpressionBuilder
    {
        #region concat
        public static StringConcatFunctionExpression Concat(params ExpressionMediator<string>[] fields)
            => new StringConcatFunctionExpression(fields);

        public static StringConcatFunctionExpression Concat(string value, params ExpressionMediator<string>[] fields)
            => new StringConcatFunctionExpression(new List<ExpressionMediator<string>> { new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(fields).ToArray());

        public static StringConcatFunctionExpression Concat(ExpressionMediator<string> field1, string value, params ExpressionMediator<string>[] fields)
            => new StringConcatFunctionExpression(new List<ExpressionMediator<string>> { field1, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(fields).ToArray());

        public static StringConcatFunctionExpression Concat(ExpressionMediator<string> field1, ExpressionMediator<string> field2, string value, params ExpressionMediator<string>[] fields)
            => new StringConcatFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(fields).ToArray());

        public static StringConcatFunctionExpression Concat(ExpressionMediator<string> field1, ExpressionMediator<string> field2, ExpressionMediator<string> field3, string value, params ExpressionMediator<string>[] fields)
            => new StringConcatFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(fields).ToArray());

        public static StringConcatFunctionExpression Concat(ExpressionMediator<string> field1, ExpressionMediator<string> field2, ExpressionMediator<string> field3, ExpressionMediator<string> field4, string value, params ExpressionMediator<string>[] fields)
            => new StringConcatFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, field4, new StringExpressionMediator(new LiteralExpression<string>(value)) }.Concat(fields).ToArray());
        #endregion

        #region coalesce
        #region bool
        public static BooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, bool value)
            => new BooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, new ExpressionMediator<bool>(new LiteralExpression<bool>(value)) });

        public static NullableBooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, bool? value)
          => new NullableBooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, new NullableExpressionMediator<bool>(new NullableLiteralExpression<bool?>(value)) });

        public static NullableBooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, NullableBooleanExpressionMediator field2)
          => new NullableBooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2 });

        public static BooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, BooleanExpressionMediator field2)
          => new BooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2 });

        public static BooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, bool value)
          => new BooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, new ExpressionMediator<bool>(new LiteralExpression<bool>(value)) });

        public static NullableBooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, bool? value)
          => new NullableBooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, new ExpressionMediator<bool>(new NullableLiteralExpression<bool?>(value)) });

        public static NullableBooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, NullableBooleanExpressionMediator field3)
          => new NullableBooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, field3 });

        public static BooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, BooleanExpressionMediator field3)
          => new BooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, field3 });

        public static BooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, ExpressionMediator<bool> field3, bool value)
          => new BooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, field3, new ExpressionMediator<bool>(new LiteralExpression<bool>(value)) });

        public static NullableBooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, ExpressionMediator<bool> field3, bool? value)
          => new NullableBooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, field3, new ExpressionMediator<bool>(new NullableLiteralExpression<bool?>(value)) });

        public static NullableBooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, ExpressionMediator<bool> field3, NullableBooleanExpressionMediator field4)
          => new NullableBooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, field3, field4 });

        public static BooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, ExpressionMediator<bool> field3, BooleanExpressionMediator field4)
          => new BooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, field3, field4 });

        public static BooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, ExpressionMediator<bool> field3, ExpressionMediator<bool> field4, bool value)
          => new BooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, field3, field4, new ExpressionMediator<bool>(new LiteralExpression<bool>(value)) });

        public static NullableBooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, ExpressionMediator<bool> field3, ExpressionMediator<bool> field4, bool? value)
          => new NullableBooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, field3, field4, new ExpressionMediator<bool>(new NullableLiteralExpression<bool?>(value)) });

        public static NullableBooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, ExpressionMediator<bool> field3, ExpressionMediator<bool> field4, NullableBooleanExpressionMediator field5)
          => new NullableBooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, field3, field4, field5 });

        public static BooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, ExpressionMediator<bool> field3, ExpressionMediator<bool> field4, BooleanExpressionMediator field5)
          => new BooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, field3, field4, field5 });

        public static BooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, ExpressionMediator<bool> field3, ExpressionMediator<bool> field4, ExpressionMediator<bool> field5, bool value)
          => new BooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, field3, field4, field5, new ExpressionMediator<bool>(new LiteralExpression<bool>(value)) });

        public static NullableBooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, ExpressionMediator<bool> field3, ExpressionMediator<bool> field4, ExpressionMediator<bool> field5, bool? value)
          => new NullableBooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, field3, field4, field5, new ExpressionMediator<bool>(new NullableLiteralExpression<bool?>(value)) });

        public static NullableBooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, ExpressionMediator<bool> field3, ExpressionMediator<bool> field4, ExpressionMediator<bool> field5, NullableBooleanExpressionMediator field6)
          => new NullableBooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, field3, field4, field5, field6 });

        public static BooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, ExpressionMediator<bool> field3, ExpressionMediator<bool> field4, ExpressionMediator<bool> field5, BooleanExpressionMediator field6)
          => new BooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, field3, field4, field5, field6 });

        public static BooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, ExpressionMediator<bool> field3, ExpressionMediator<bool> field4, ExpressionMediator<bool> field5, ExpressionMediator<bool> field6, bool value)
          => new BooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<bool>(new LiteralExpression<bool>(value)) });

        public static NullableBooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, ExpressionMediator<bool> field3, ExpressionMediator<bool> field4, ExpressionMediator<bool> field5, ExpressionMediator<bool> field6, bool? value)
          => new NullableBooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<bool>(new NullableLiteralExpression<bool?>(value)) });

        public static NullableBooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, ExpressionMediator<bool> field3, ExpressionMediator<bool> field4, ExpressionMediator<bool> field5, ExpressionMediator<bool> field6, NullableBooleanExpressionMediator field7)
          => new NullableBooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, field3, field4, field5, field6, field7 });

        public static BooleanCoalesceFunctionExpression Coalesce(ExpressionMediator<bool> field1, ExpressionMediator<bool> field2, ExpressionMediator<bool> field3, ExpressionMediator<bool> field4, ExpressionMediator<bool> field5, ExpressionMediator<bool> field6, BooleanExpressionMediator field7)
          => new BooleanCoalesceFunctionExpression(new List<ExpressionMediator<bool>> { field1, field2, field3, field4, field5, field6, field7 });
        #endregion

        #region byte
        public static ByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, byte value)
            => new ByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, new ExpressionMediator<byte>(new LiteralExpression<byte>(value)) });

        public static NullableByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, byte? value)
          => new NullableByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, new NullableExpressionMediator<byte>(new NullableLiteralExpression<byte?>(value)) });

        public static NullableByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, NullableByteExpressionMediator field2)
          => new NullableByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2 });

        public static ByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ByteExpressionMediator field2)
          => new ByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2 });

        public static ByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, byte value)
          => new ByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, new ExpressionMediator<byte>(new LiteralExpression<byte>(value)) });

        public static NullableByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, byte? value)
          => new NullableByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, new ExpressionMediator<byte>(new NullableLiteralExpression<byte?>(value)) });

        public static NullableByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, NullableByteExpressionMediator field3)
          => new NullableByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, field3 });

        public static ByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, ByteExpressionMediator field3)
          => new ByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, field3 });

        public static ByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, ExpressionMediator<byte> field3, byte value)
          => new ByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, field3, new ExpressionMediator<byte>(new LiteralExpression<byte>(value)) });

        public static NullableByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, ExpressionMediator<byte> field3, byte? value)
          => new NullableByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, field3, new ExpressionMediator<byte>(new NullableLiteralExpression<byte?>(value)) });

        public static NullableByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, ExpressionMediator<byte> field3, NullableByteExpressionMediator field4)
          => new NullableByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, field3, field4 });

        public static ByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, ExpressionMediator<byte> field3, ByteExpressionMediator field4)
          => new ByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, field3, field4 });

        public static ByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, ExpressionMediator<byte> field3, ExpressionMediator<byte> field4, byte value)
          => new ByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, field3, field4, new ExpressionMediator<byte>(new LiteralExpression<byte>(value)) });

        public static NullableByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, ExpressionMediator<byte> field3, ExpressionMediator<byte> field4, byte? value)
          => new NullableByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, field3, field4, new ExpressionMediator<byte>(new NullableLiteralExpression<byte?>(value)) });

        public static NullableByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, ExpressionMediator<byte> field3, ExpressionMediator<byte> field4, NullableByteExpressionMediator field5)
          => new NullableByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, field3, field4, field5 });

        public static ByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, ExpressionMediator<byte> field3, ExpressionMediator<byte> field4, ByteExpressionMediator field5)
          => new ByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, field3, field4, field5 });

        public static ByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, ExpressionMediator<byte> field3, ExpressionMediator<byte> field4, ExpressionMediator<byte> field5, byte value)
          => new ByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, field3, field4, field5, new ExpressionMediator<byte>(new LiteralExpression<byte>(value)) });

        public static NullableByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, ExpressionMediator<byte> field3, ExpressionMediator<byte> field4, ExpressionMediator<byte> field5, byte? value)
          => new NullableByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, field3, field4, field5, new ExpressionMediator<byte>(new NullableLiteralExpression<byte?>(value)) });

        public static NullableByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, ExpressionMediator<byte> field3, ExpressionMediator<byte> field4, ExpressionMediator<byte> field5, NullableByteExpressionMediator field6)
          => new NullableByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, field3, field4, field5, field6 });

        public static ByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, ExpressionMediator<byte> field3, ExpressionMediator<byte> field4, ExpressionMediator<byte> field5, ByteExpressionMediator field6)
          => new ByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, field3, field4, field5, field6 });

        public static ByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, ExpressionMediator<byte> field3, ExpressionMediator<byte> field4, ExpressionMediator<byte> field5, ExpressionMediator<byte> field6, byte value)
          => new ByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<byte>(new LiteralExpression<byte>(value)) });

        public static NullableByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, ExpressionMediator<byte> field3, ExpressionMediator<byte> field4, ExpressionMediator<byte> field5, ExpressionMediator<byte> field6, byte? value)
          => new NullableByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<byte>(new NullableLiteralExpression<byte?>(value)) });

        public static NullableByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, ExpressionMediator<byte> field3, ExpressionMediator<byte> field4, ExpressionMediator<byte> field5, ExpressionMediator<byte> field6, NullableByteExpressionMediator field7)
          => new NullableByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, field3, field4, field5, field6, field7 });

        public static ByteCoalesceFunctionExpression Coalesce(ExpressionMediator<byte> field1, ExpressionMediator<byte> field2, ExpressionMediator<byte> field3, ExpressionMediator<byte> field4, ExpressionMediator<byte> field5, ExpressionMediator<byte> field6, ByteExpressionMediator field7)
          => new ByteCoalesceFunctionExpression(new List<ExpressionMediator<byte>> { field1, field2, field3, field4, field5, field6, field7 });
        #endregion

        #region DateTime
        public static DateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, DateTime value)
            => new DateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, new ExpressionMediator<DateTime>(new LiteralExpression<DateTime>(value)) });

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, DateTime? value)
            => new NullableDateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, new NullableExpressionMediator<DateTime>(new NullableLiteralExpression<DateTime?>(value)) });

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, NullableDateTimeExpressionMediator field2)
            => new NullableDateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2 });

        public static DateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, DateTimeExpressionMediator field2)
            => new DateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2 });

        public static DateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, DateTime value)
            => new DateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, new ExpressionMediator<DateTime>(new LiteralExpression<DateTime>(value)) });

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, DateTime? value)
            => new NullableDateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, new ExpressionMediator<DateTime>(new NullableLiteralExpression<DateTime?>(value)) });

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, NullableDateTimeExpressionMediator field3)
            => new NullableDateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, field3 });

        public static DateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, DateTimeExpressionMediator field3)
            => new DateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, field3 });

        public static DateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, ExpressionMediator<DateTime> field3, DateTime value)
            => new DateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, field3, new ExpressionMediator<DateTime>(new LiteralExpression<DateTime>(value)) });

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, ExpressionMediator<DateTime> field3, DateTime? value)
            => new NullableDateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, field3, new ExpressionMediator<DateTime>(new NullableLiteralExpression<DateTime?>(value)) });

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, ExpressionMediator<DateTime> field3, NullableDateTimeExpressionMediator field4)
            => new NullableDateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, field3, field4 });

        public static DateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, ExpressionMediator<DateTime> field3, DateTimeExpressionMediator field4)
            => new DateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, field3, field4 });

        public static DateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, ExpressionMediator<DateTime> field3, ExpressionMediator<DateTime> field4, DateTime value)
            => new DateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, field3, field4, new ExpressionMediator<DateTime>(new LiteralExpression<DateTime>(value)) });

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, ExpressionMediator<DateTime> field3, ExpressionMediator<DateTime> field4, DateTime? value)
            => new NullableDateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, field3, field4, new ExpressionMediator<DateTime>(new NullableLiteralExpression<DateTime?>(value)) });

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, ExpressionMediator<DateTime> field3, ExpressionMediator<DateTime> field4, NullableDateTimeExpressionMediator field5)
            => new NullableDateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, field3, field4, field5 });

        public static DateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, ExpressionMediator<DateTime> field3, ExpressionMediator<DateTime> field4, DateTimeExpressionMediator field5)
            => new DateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, field3, field4, field5 });

        public static DateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, ExpressionMediator<DateTime> field3, ExpressionMediator<DateTime> field4, ExpressionMediator<DateTime> field5, DateTime value)
            => new DateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, field3, field4, field5, new ExpressionMediator<DateTime>(new LiteralExpression<DateTime>(value)) });

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, ExpressionMediator<DateTime> field3, ExpressionMediator<DateTime> field4, ExpressionMediator<DateTime> field5, DateTime? value)
            => new NullableDateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, field3, field4, field5, new ExpressionMediator<DateTime>(new NullableLiteralExpression<DateTime?>(value)) });

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, ExpressionMediator<DateTime> field3, ExpressionMediator<DateTime> field4, ExpressionMediator<DateTime> field5, NullableDateTimeExpressionMediator field6)
            => new NullableDateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, field3, field4, field5, field6 });

        public static DateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, ExpressionMediator<DateTime> field3, ExpressionMediator<DateTime> field4, ExpressionMediator<DateTime> field5, DateTimeExpressionMediator field6)
            => new DateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, field3, field4, field5, field6 });

        public static DateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, ExpressionMediator<DateTime> field3, ExpressionMediator<DateTime> field4, ExpressionMediator<DateTime> field5, ExpressionMediator<DateTime> field6, DateTime value)
            => new DateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<DateTime>(new LiteralExpression<DateTime>(value)) });

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, ExpressionMediator<DateTime> field3, ExpressionMediator<DateTime> field4, ExpressionMediator<DateTime> field5, ExpressionMediator<DateTime> field6, DateTime? value)
            => new NullableDateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<DateTime>(new NullableLiteralExpression<DateTime?>(value)) });

        public static NullableDateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, ExpressionMediator<DateTime> field3, ExpressionMediator<DateTime> field4, ExpressionMediator<DateTime> field5, ExpressionMediator<DateTime> field6, NullableDateTimeExpressionMediator field7)
            => new NullableDateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, field3, field4, field5, field6, field7 });

        public static DateTimeCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTime> field1, ExpressionMediator<DateTime> field2, ExpressionMediator<DateTime> field3, ExpressionMediator<DateTime> field4, ExpressionMediator<DateTime> field5, ExpressionMediator<DateTime> field6, DateTimeExpressionMediator field7)
            => new DateTimeCoalesceFunctionExpression(new List<ExpressionMediator<DateTime>> { field1, field2, field3, field4, field5, field6, field7 });
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, DateTimeOffset value)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, new ExpressionMediator<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(value)) });

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, DateTimeOffset? value)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, new NullableExpressionMediator<DateTimeOffset>(new NullableLiteralExpression<DateTimeOffset?>(value)) });

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, NullableDateTimeOffsetExpressionMediator field2)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2 });

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, DateTimeOffsetExpressionMediator field2)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2 });

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, DateTimeOffset value)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, new ExpressionMediator<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(value)) });

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, DateTimeOffset? value)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, new ExpressionMediator<DateTimeOffset>(new NullableLiteralExpression<DateTimeOffset?>(value)) });

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, NullableDateTimeOffsetExpressionMediator field3)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, field3 });

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, DateTimeOffsetExpressionMediator field3)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, field3 });

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, ExpressionMediator<DateTimeOffset> field3, DateTimeOffset value)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, field3, new ExpressionMediator<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(value)) });

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, ExpressionMediator<DateTimeOffset> field3, DateTimeOffset? value)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, field3, new ExpressionMediator<DateTimeOffset>(new NullableLiteralExpression<DateTimeOffset?>(value)) });

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, ExpressionMediator<DateTimeOffset> field3, NullableDateTimeOffsetExpressionMediator field4)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4 });

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, ExpressionMediator<DateTimeOffset> field3, DateTimeOffsetExpressionMediator field4)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4 });

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, ExpressionMediator<DateTimeOffset> field3, ExpressionMediator<DateTimeOffset> field4, DateTimeOffset value)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4, new ExpressionMediator<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(value)) });

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, ExpressionMediator<DateTimeOffset> field3, ExpressionMediator<DateTimeOffset> field4, DateTimeOffset? value)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4, new ExpressionMediator<DateTimeOffset>(new NullableLiteralExpression<DateTimeOffset?>(value)) });

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, ExpressionMediator<DateTimeOffset> field3, ExpressionMediator<DateTimeOffset> field4, NullableDateTimeOffsetExpressionMediator field5)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4, field5 });

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, ExpressionMediator<DateTimeOffset> field3, ExpressionMediator<DateTimeOffset> field4, DateTimeOffsetExpressionMediator field5)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4, field5 });

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, ExpressionMediator<DateTimeOffset> field3, ExpressionMediator<DateTimeOffset> field4, ExpressionMediator<DateTimeOffset> field5, DateTimeOffset value)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4, field5, new ExpressionMediator<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(value)) });

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, ExpressionMediator<DateTimeOffset> field3, ExpressionMediator<DateTimeOffset> field4, ExpressionMediator<DateTimeOffset> field5, DateTimeOffset? value)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4, field5, new ExpressionMediator<DateTimeOffset>(new NullableLiteralExpression<DateTimeOffset?>(value)) });

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, ExpressionMediator<DateTimeOffset> field3, ExpressionMediator<DateTimeOffset> field4, ExpressionMediator<DateTimeOffset> field5, NullableDateTimeOffsetExpressionMediator field6)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4, field5, field6 });

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, ExpressionMediator<DateTimeOffset> field3, ExpressionMediator<DateTimeOffset> field4, ExpressionMediator<DateTimeOffset> field5, DateTimeOffsetExpressionMediator field6)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4, field5, field6 });

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, ExpressionMediator<DateTimeOffset> field3, ExpressionMediator<DateTimeOffset> field4, ExpressionMediator<DateTimeOffset> field5, ExpressionMediator<DateTimeOffset> field6, DateTimeOffset value)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(value)) });

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, ExpressionMediator<DateTimeOffset> field3, ExpressionMediator<DateTimeOffset> field4, ExpressionMediator<DateTimeOffset> field5, ExpressionMediator<DateTimeOffset> field6, DateTimeOffset? value)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<DateTimeOffset>(new NullableLiteralExpression<DateTimeOffset?>(value)) });

        public static NullableDateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, ExpressionMediator<DateTimeOffset> field3, ExpressionMediator<DateTimeOffset> field4, ExpressionMediator<DateTimeOffset> field5, ExpressionMediator<DateTimeOffset> field6, NullableDateTimeOffsetExpressionMediator field7)
            => new NullableDateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4, field5, field6, field7 });

        public static DateTimeOffsetCoalesceFunctionExpression Coalesce(ExpressionMediator<DateTimeOffset> field1, ExpressionMediator<DateTimeOffset> field2, ExpressionMediator<DateTimeOffset> field3, ExpressionMediator<DateTimeOffset> field4, ExpressionMediator<DateTimeOffset> field5, ExpressionMediator<DateTimeOffset> field6, DateTimeOffsetExpressionMediator field7)
            => new DateTimeOffsetCoalesceFunctionExpression(new List<ExpressionMediator<DateTimeOffset>> { field1, field2, field3, field4, field5, field6, field7 });
        #endregion

        #region double
        public static DoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, double value)
            => new DoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, new ExpressionMediator<double>(new LiteralExpression<double>(value)) });

        public static NullableDoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, double? value)
          => new NullableDoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, new NullableExpressionMediator<double>(new NullableLiteralExpression<double?>(value)) });

        public static NullableDoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, NullableDoubleExpressionMediator field2)
          => new NullableDoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2 });

        public static DoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, DoubleExpressionMediator field2)
          => new DoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2 });

        public static DoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, double value)
          => new DoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, new ExpressionMediator<double>(new LiteralExpression<double>(value)) });

        public static NullableDoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, double? value)
          => new NullableDoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, new ExpressionMediator<double>(new NullableLiteralExpression<double?>(value)) });

        public static NullableDoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, NullableDoubleExpressionMediator field3)
          => new NullableDoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, field3 });

        public static DoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, DoubleExpressionMediator field3)
          => new DoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, field3 });

        public static DoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, ExpressionMediator<double> field3, double value)
          => new DoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, field3, new ExpressionMediator<double>(new LiteralExpression<double>(value)) });

        public static NullableDoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, ExpressionMediator<double> field3, double? value)
          => new NullableDoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, field3, new ExpressionMediator<double>(new NullableLiteralExpression<double?>(value)) });

        public static NullableDoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, ExpressionMediator<double> field3, NullableDoubleExpressionMediator field4)
          => new NullableDoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, field3, field4 });

        public static DoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, ExpressionMediator<double> field3, DoubleExpressionMediator field4)
          => new DoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, field3, field4 });

        public static DoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, ExpressionMediator<double> field3, ExpressionMediator<double> field4, double value)
          => new DoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, field3, field4, new ExpressionMediator<double>(new LiteralExpression<double>(value)) });

        public static NullableDoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, ExpressionMediator<double> field3, ExpressionMediator<double> field4, double? value)
          => new NullableDoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, field3, field4, new ExpressionMediator<double>(new NullableLiteralExpression<double?>(value)) });

        public static NullableDoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, ExpressionMediator<double> field3, ExpressionMediator<double> field4, NullableDoubleExpressionMediator field5)
          => new NullableDoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, field3, field4, field5 });

        public static DoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, ExpressionMediator<double> field3, ExpressionMediator<double> field4, DoubleExpressionMediator field5)
          => new DoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, field3, field4, field5 });

        public static DoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, ExpressionMediator<double> field3, ExpressionMediator<double> field4, ExpressionMediator<double> field5, double value)
          => new DoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, field3, field4, field5, new ExpressionMediator<double>(new LiteralExpression<double>(value)) });

        public static NullableDoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, ExpressionMediator<double> field3, ExpressionMediator<double> field4, ExpressionMediator<double> field5, double? value)
          => new NullableDoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, field3, field4, field5, new ExpressionMediator<double>(new NullableLiteralExpression<double?>(value)) });

        public static NullableDoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, ExpressionMediator<double> field3, ExpressionMediator<double> field4, ExpressionMediator<double> field5, NullableDoubleExpressionMediator field6)
          => new NullableDoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, field3, field4, field5, field6 });

        public static DoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, ExpressionMediator<double> field3, ExpressionMediator<double> field4, ExpressionMediator<double> field5, DoubleExpressionMediator field6)
          => new DoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, field3, field4, field5, field6 });

        public static DoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, ExpressionMediator<double> field3, ExpressionMediator<double> field4, ExpressionMediator<double> field5, ExpressionMediator<double> field6, double value)
          => new DoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<double>(new LiteralExpression<double>(value)) });

        public static NullableDoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, ExpressionMediator<double> field3, ExpressionMediator<double> field4, ExpressionMediator<double> field5, ExpressionMediator<double> field6, double? value)
          => new NullableDoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<double>(new NullableLiteralExpression<double?>(value)) });

        public static NullableDoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, ExpressionMediator<double> field3, ExpressionMediator<double> field4, ExpressionMediator<double> field5, ExpressionMediator<double> field6, NullableDoubleExpressionMediator field7)
          => new NullableDoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, field3, field4, field5, field6, field7 });

        public static DoubleCoalesceFunctionExpression Coalesce(ExpressionMediator<double> field1, ExpressionMediator<double> field2, ExpressionMediator<double> field3, ExpressionMediator<double> field4, ExpressionMediator<double> field5, ExpressionMediator<double> field6, DoubleExpressionMediator field7)
          => new DoubleCoalesceFunctionExpression(new List<ExpressionMediator<double>> { field1, field2, field3, field4, field5, field6, field7 });
        #endregion

        #region decimal
        public static DecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, decimal value)
            => new DecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, new ExpressionMediator<decimal>(new LiteralExpression<decimal>(value)) });

        public static NullableDecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, decimal? value)
          => new NullableDecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, new NullableExpressionMediator<decimal>(new NullableLiteralExpression<decimal?>(value)) });

        public static NullableDecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, NullableDecimalExpressionMediator field2)
          => new NullableDecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2 });

        public static DecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, DecimalExpressionMediator field2)
          => new DecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2 });

        public static DecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, decimal value)
          => new DecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, new ExpressionMediator<decimal>(new LiteralExpression<decimal>(value)) });

        public static NullableDecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, decimal? value)
          => new NullableDecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, new ExpressionMediator<decimal>(new NullableLiteralExpression<decimal?>(value)) });

        public static NullableDecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, NullableDecimalExpressionMediator field3)
          => new NullableDecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, field3 });

        public static DecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, DecimalExpressionMediator field3)
          => new DecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, field3 });

        public static DecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, ExpressionMediator<decimal> field3, decimal value)
          => new DecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, field3, new ExpressionMediator<decimal>(new LiteralExpression<decimal>(value)) });

        public static NullableDecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, ExpressionMediator<decimal> field3, decimal? value)
          => new NullableDecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, field3, new ExpressionMediator<decimal>(new NullableLiteralExpression<decimal?>(value)) });

        public static NullableDecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, ExpressionMediator<decimal> field3, NullableDecimalExpressionMediator field4)
          => new NullableDecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, field3, field4 });

        public static DecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, ExpressionMediator<decimal> field3, DecimalExpressionMediator field4)
          => new DecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, field3, field4 });

        public static DecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, ExpressionMediator<decimal> field3, ExpressionMediator<decimal> field4, decimal value)
          => new DecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, field3, field4, new ExpressionMediator<decimal>(new LiteralExpression<decimal>(value)) });

        public static NullableDecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, ExpressionMediator<decimal> field3, ExpressionMediator<decimal> field4, decimal? value)
          => new NullableDecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, field3, field4, new ExpressionMediator<decimal>(new NullableLiteralExpression<decimal?>(value)) });

        public static NullableDecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, ExpressionMediator<decimal> field3, ExpressionMediator<decimal> field4, NullableDecimalExpressionMediator field5)
          => new NullableDecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, field3, field4, field5 });

        public static DecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, ExpressionMediator<decimal> field3, ExpressionMediator<decimal> field4, DecimalExpressionMediator field5)
          => new DecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, field3, field4, field5 });

        public static DecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, ExpressionMediator<decimal> field3, ExpressionMediator<decimal> field4, ExpressionMediator<decimal> field5, decimal value)
          => new DecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, field3, field4, field5, new ExpressionMediator<decimal>(new LiteralExpression<decimal>(value)) });

        public static NullableDecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, ExpressionMediator<decimal> field3, ExpressionMediator<decimal> field4, ExpressionMediator<decimal> field5, decimal? value)
          => new NullableDecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, field3, field4, field5, new ExpressionMediator<decimal>(new NullableLiteralExpression<decimal?>(value)) });

        public static NullableDecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, ExpressionMediator<decimal> field3, ExpressionMediator<decimal> field4, ExpressionMediator<decimal> field5, NullableDecimalExpressionMediator field6)
          => new NullableDecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, field3, field4, field5, field6 });

        public static DecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, ExpressionMediator<decimal> field3, ExpressionMediator<decimal> field4, ExpressionMediator<decimal> field5, DecimalExpressionMediator field6)
          => new DecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, field3, field4, field5, field6 });

        public static DecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, ExpressionMediator<decimal> field3, ExpressionMediator<decimal> field4, ExpressionMediator<decimal> field5, ExpressionMediator<decimal> field6, decimal value)
          => new DecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<decimal>(new LiteralExpression<decimal>(value)) });

        public static NullableDecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, ExpressionMediator<decimal> field3, ExpressionMediator<decimal> field4, ExpressionMediator<decimal> field5, ExpressionMediator<decimal> field6, decimal? value)
          => new NullableDecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<decimal>(new NullableLiteralExpression<decimal?>(value)) });

        public static NullableDecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, ExpressionMediator<decimal> field3, ExpressionMediator<decimal> field4, ExpressionMediator<decimal> field5, ExpressionMediator<decimal> field6, NullableDecimalExpressionMediator field7)
          => new NullableDecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, field3, field4, field5, field6, field7 });

        public static DecimalCoalesceFunctionExpression Coalesce(ExpressionMediator<decimal> field1, ExpressionMediator<decimal> field2, ExpressionMediator<decimal> field3, ExpressionMediator<decimal> field4, ExpressionMediator<decimal> field5, ExpressionMediator<decimal> field6, DecimalExpressionMediator field7)
          => new DecimalCoalesceFunctionExpression(new List<ExpressionMediator<decimal>> { field1, field2, field3, field4, field5, field6, field7 });
        #endregion

        #region TEnum
        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)) });

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(value)) });

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2 });

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2 });

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)) });

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, new EnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(value)) });

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, NullableEnumExpressionMediator<TEnum> field3)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, field3 });

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, EnumExpressionMediator<TEnum> field3)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, field3 });

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, EnumExpressionMediator<TEnum> field3, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, field3, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)) });

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, EnumExpressionMediator<TEnum> field3, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, field3, new EnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(value)) });

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, EnumExpressionMediator<TEnum> field3, NullableEnumExpressionMediator<TEnum> field4)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, field3, field4 });

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, EnumExpressionMediator<TEnum> field3, EnumExpressionMediator<TEnum> field4)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, field3, field4 });

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, EnumExpressionMediator<TEnum> field3, EnumExpressionMediator<TEnum> field4, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, field3, field4, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)) });

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, EnumExpressionMediator<TEnum> field3, EnumExpressionMediator<TEnum> field4, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, field3, field4, new EnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(value)) });

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, EnumExpressionMediator<TEnum> field3, EnumExpressionMediator<TEnum> field4, NullableEnumExpressionMediator<TEnum> field5)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, field3, field4, field5 });

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, EnumExpressionMediator<TEnum> field3, EnumExpressionMediator<TEnum> field4, EnumExpressionMediator<TEnum> field5)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, field3, field4, field5 });

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, EnumExpressionMediator<TEnum> field3, EnumExpressionMediator<TEnum> field4, EnumExpressionMediator<TEnum> field5, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, field3, field4, field5, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)) });

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, EnumExpressionMediator<TEnum> field3, EnumExpressionMediator<TEnum> field4, EnumExpressionMediator<TEnum> field5, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, field3, field4, field5, new EnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(value)) });

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, EnumExpressionMediator<TEnum> field3, EnumExpressionMediator<TEnum> field4, EnumExpressionMediator<TEnum> field5, NullableEnumExpressionMediator<TEnum> field6)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, field3, field4, field5, field6 });

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, EnumExpressionMediator<TEnum> field3, EnumExpressionMediator<TEnum> field4, EnumExpressionMediator<TEnum> field5, EnumExpressionMediator<TEnum> field6)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, field3, field4, field5, field6 });

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, EnumExpressionMediator<TEnum> field3, EnumExpressionMediator<TEnum> field4, EnumExpressionMediator<TEnum> field5, EnumExpressionMediator<TEnum> field6, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, field3, field4, field5, field6, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)) });

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, EnumExpressionMediator<TEnum> field3, EnumExpressionMediator<TEnum> field4, EnumExpressionMediator<TEnum> field5, EnumExpressionMediator<TEnum> field6, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, field3, field4, field5, field6, new EnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(value)) });

        public static NullableEnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, EnumExpressionMediator<TEnum> field3, EnumExpressionMediator<TEnum> field4, EnumExpressionMediator<TEnum> field5, EnumExpressionMediator<TEnum> field6, NullableEnumExpressionMediator<TEnum> field7)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, field3, field4, field5, field6, field7 });

        public static EnumCoalesceFunctionExpression<TEnum> Coalesce<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2, EnumExpressionMediator<TEnum> field3, EnumExpressionMediator<TEnum> field4, EnumExpressionMediator<TEnum> field5, EnumExpressionMediator<TEnum> field6, EnumExpressionMediator<TEnum> field7)
            where TEnum : struct, Enum, IComparable
            => new EnumCoalesceFunctionExpression<TEnum>(new List<EnumExpressionMediator<TEnum>> { field1, field2, field3, field4, field5, field6, field7 });
        #endregion

        #region float
        public static SingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, float value)
            => new SingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, new ExpressionMediator<float>(new LiteralExpression<float>(value)) });

        public static NullableSingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, float? value)
          => new NullableSingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, new NullableExpressionMediator<float>(new NullableLiteralExpression<float?>(value)) });

        public static NullableSingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, NullableSingleExpressionMediator field2)
          => new NullableSingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2 });

        public static SingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, SingleExpressionMediator field2)
          => new SingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2 });

        public static SingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, float value)
          => new SingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, new ExpressionMediator<float>(new LiteralExpression<float>(value)) });

        public static NullableSingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, float? value)
          => new NullableSingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, new ExpressionMediator<float>(new NullableLiteralExpression<float?>(value)) });

        public static NullableSingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, NullableSingleExpressionMediator field3)
          => new NullableSingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, field3 });

        public static SingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, SingleExpressionMediator field3)
          => new SingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, field3 });

        public static SingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, ExpressionMediator<float> field3, float value)
          => new SingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, field3, new ExpressionMediator<float>(new LiteralExpression<float>(value)) });

        public static NullableSingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, ExpressionMediator<float> field3, float? value)
          => new NullableSingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, field3, new ExpressionMediator<float>(new NullableLiteralExpression<float?>(value)) });

        public static NullableSingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, ExpressionMediator<float> field3, NullableSingleExpressionMediator field4)
          => new NullableSingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, field3, field4 });

        public static SingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, ExpressionMediator<float> field3, SingleExpressionMediator field4)
          => new SingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, field3, field4 });

        public static SingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, ExpressionMediator<float> field3, ExpressionMediator<float> field4, float value)
          => new SingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, field3, field4, new ExpressionMediator<float>(new LiteralExpression<float>(value)) });

        public static NullableSingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, ExpressionMediator<float> field3, ExpressionMediator<float> field4, float? value)
          => new NullableSingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, field3, field4, new ExpressionMediator<float>(new NullableLiteralExpression<float?>(value)) });

        public static NullableSingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, ExpressionMediator<float> field3, ExpressionMediator<float> field4, NullableSingleExpressionMediator field5)
          => new NullableSingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, field3, field4, field5 });

        public static SingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, ExpressionMediator<float> field3, ExpressionMediator<float> field4, SingleExpressionMediator field5)
          => new SingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, field3, field4, field5 });

        public static SingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, ExpressionMediator<float> field3, ExpressionMediator<float> field4, ExpressionMediator<float> field5, float value)
          => new SingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, field3, field4, field5, new ExpressionMediator<float>(new LiteralExpression<float>(value)) });

        public static NullableSingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, ExpressionMediator<float> field3, ExpressionMediator<float> field4, ExpressionMediator<float> field5, float? value)
          => new NullableSingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, field3, field4, field5, new ExpressionMediator<float>(new NullableLiteralExpression<float?>(value)) });

        public static NullableSingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, ExpressionMediator<float> field3, ExpressionMediator<float> field4, ExpressionMediator<float> field5, NullableSingleExpressionMediator field6)
          => new NullableSingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, field3, field4, field5, field6 });

        public static SingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, ExpressionMediator<float> field3, ExpressionMediator<float> field4, ExpressionMediator<float> field5, SingleExpressionMediator field6)
          => new SingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, field3, field4, field5, field6 });

        public static SingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, ExpressionMediator<float> field3, ExpressionMediator<float> field4, ExpressionMediator<float> field5, ExpressionMediator<float> field6, float value)
          => new SingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<float>(new LiteralExpression<float>(value)) });

        public static NullableSingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, ExpressionMediator<float> field3, ExpressionMediator<float> field4, ExpressionMediator<float> field5, ExpressionMediator<float> field6, float? value)
          => new NullableSingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<float>(new NullableLiteralExpression<float?>(value)) });

        public static NullableSingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, ExpressionMediator<float> field3, ExpressionMediator<float> field4, ExpressionMediator<float> field5, ExpressionMediator<float> field6, NullableSingleExpressionMediator field7)
          => new NullableSingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, field3, field4, field5, field6, field7 });

        public static SingleCoalesceFunctionExpression Coalesce(ExpressionMediator<float> field1, ExpressionMediator<float> field2, ExpressionMediator<float> field3, ExpressionMediator<float> field4, ExpressionMediator<float> field5, ExpressionMediator<float> field6, SingleExpressionMediator field7)
          => new SingleCoalesceFunctionExpression(new List<ExpressionMediator<float>> { field1, field2, field3, field4, field5, field6, field7 });
        #endregion

        #region Guid
        public static GuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, Guid value)
            => new GuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, new ExpressionMediator<Guid>(new LiteralExpression<Guid>(value)) });

        public static NullableGuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, Guid? value)
          => new NullableGuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, new NullableExpressionMediator<Guid>(new NullableLiteralExpression<Guid?>(value)) });

        public static NullableGuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, NullableGuidExpressionMediator field2)
          => new NullableGuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2 });

        public static GuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, GuidExpressionMediator field2)
          => new GuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2 });

        public static GuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, Guid value)
          => new GuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, new ExpressionMediator<Guid>(new LiteralExpression<Guid>(value)) });

        public static NullableGuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, Guid? value)
          => new NullableGuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, new ExpressionMediator<Guid>(new NullableLiteralExpression<Guid?>(value)) });

        public static NullableGuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, NullableGuidExpressionMediator field3)
          => new NullableGuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, field3 });

        public static GuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, GuidExpressionMediator field3)
          => new GuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, field3 });

        public static GuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, ExpressionMediator<Guid> field3, Guid value)
          => new GuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, field3, new ExpressionMediator<Guid>(new LiteralExpression<Guid>(value)) });

        public static NullableGuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, ExpressionMediator<Guid> field3, Guid? value)
          => new NullableGuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, field3, new ExpressionMediator<Guid>(new NullableLiteralExpression<Guid?>(value)) });

        public static NullableGuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, ExpressionMediator<Guid> field3, NullableGuidExpressionMediator field4)
          => new NullableGuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, field3, field4 });

        public static GuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, ExpressionMediator<Guid> field3, GuidExpressionMediator field4)
          => new GuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, field3, field4 });

        public static GuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, ExpressionMediator<Guid> field3, ExpressionMediator<Guid> field4, Guid value)
          => new GuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, field3, field4, new ExpressionMediator<Guid>(new LiteralExpression<Guid>(value)) });

        public static NullableGuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, ExpressionMediator<Guid> field3, ExpressionMediator<Guid> field4, Guid? value)
          => new NullableGuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, field3, field4, new ExpressionMediator<Guid>(new NullableLiteralExpression<Guid?>(value)) });

        public static NullableGuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, ExpressionMediator<Guid> field3, ExpressionMediator<Guid> field4, NullableGuidExpressionMediator field5)
          => new NullableGuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, field3, field4, field5 });

        public static GuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, ExpressionMediator<Guid> field3, ExpressionMediator<Guid> field4, GuidExpressionMediator field5)
          => new GuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, field3, field4, field5 });

        public static GuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, ExpressionMediator<Guid> field3, ExpressionMediator<Guid> field4, ExpressionMediator<Guid> field5, Guid value)
          => new GuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, field3, field4, field5, new ExpressionMediator<Guid>(new LiteralExpression<Guid>(value)) });

        public static NullableGuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, ExpressionMediator<Guid> field3, ExpressionMediator<Guid> field4, ExpressionMediator<Guid> field5, Guid? value)
          => new NullableGuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, field3, field4, field5, new ExpressionMediator<Guid>(new NullableLiteralExpression<Guid?>(value)) });

        public static NullableGuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, ExpressionMediator<Guid> field3, ExpressionMediator<Guid> field4, ExpressionMediator<Guid> field5, NullableGuidExpressionMediator field6)
          => new NullableGuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, field3, field4, field5, field6 });

        public static GuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, ExpressionMediator<Guid> field3, ExpressionMediator<Guid> field4, ExpressionMediator<Guid> field5, GuidExpressionMediator field6)
          => new GuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, field3, field4, field5, field6 });

        public static GuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, ExpressionMediator<Guid> field3, ExpressionMediator<Guid> field4, ExpressionMediator<Guid> field5, ExpressionMediator<Guid> field6, Guid value)
          => new GuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<Guid>(new LiteralExpression<Guid>(value)) });

        public static NullableGuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, ExpressionMediator<Guid> field3, ExpressionMediator<Guid> field4, ExpressionMediator<Guid> field5, ExpressionMediator<Guid> field6, Guid? value)
          => new NullableGuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<Guid>(new NullableLiteralExpression<Guid?>(value)) });

        public static NullableGuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, ExpressionMediator<Guid> field3, ExpressionMediator<Guid> field4, ExpressionMediator<Guid> field5, ExpressionMediator<Guid> field6, NullableGuidExpressionMediator field7)
          => new NullableGuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, field3, field4, field5, field6, field7 });

        public static GuidCoalesceFunctionExpression Coalesce(ExpressionMediator<Guid> field1, ExpressionMediator<Guid> field2, ExpressionMediator<Guid> field3, ExpressionMediator<Guid> field4, ExpressionMediator<Guid> field5, ExpressionMediator<Guid> field6, GuidExpressionMediator field7)
          => new GuidCoalesceFunctionExpression(new List<ExpressionMediator<Guid>> { field1, field2, field3, field4, field5, field6, field7 });
        #endregion

        #region short
        public static Int16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, short value)
            => new Int16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, new ExpressionMediator<short>(new LiteralExpression<short>(value)) });

        public static NullableInt16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, short? value)
          => new NullableInt16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, new NullableExpressionMediator<short>(new NullableLiteralExpression<short?>(value)) });

        public static NullableInt16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, NullableInt16ExpressionMediator field2)
          => new NullableInt16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2 });

        public static Int16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, Int16ExpressionMediator field2)
          => new Int16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2 });

        public static Int16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, short value)
          => new Int16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, new ExpressionMediator<short>(new LiteralExpression<short>(value)) });

        public static NullableInt16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, short? value)
          => new NullableInt16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, new ExpressionMediator<short>(new NullableLiteralExpression<short?>(value)) });

        public static NullableInt16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, NullableInt16ExpressionMediator field3)
          => new NullableInt16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, field3 });

        public static Int16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, Int16ExpressionMediator field3)
          => new Int16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, field3 });

        public static Int16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, ExpressionMediator<short> field3, short value)
          => new Int16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, field3, new ExpressionMediator<short>(new LiteralExpression<short>(value)) });

        public static NullableInt16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, ExpressionMediator<short> field3, short? value)
          => new NullableInt16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, field3, new ExpressionMediator<short>(new NullableLiteralExpression<short?>(value)) });

        public static NullableInt16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, ExpressionMediator<short> field3, NullableInt16ExpressionMediator field4)
          => new NullableInt16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, field3, field4 });

        public static Int16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, ExpressionMediator<short> field3, Int16ExpressionMediator field4)
          => new Int16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, field3, field4 });

        public static Int16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, ExpressionMediator<short> field3, ExpressionMediator<short> field4, short value)
          => new Int16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, field3, field4, new ExpressionMediator<short>(new LiteralExpression<short>(value)) });

        public static NullableInt16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, ExpressionMediator<short> field3, ExpressionMediator<short> field4, short? value)
          => new NullableInt16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, field3, field4, new ExpressionMediator<short>(new NullableLiteralExpression<short?>(value)) });

        public static NullableInt16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, ExpressionMediator<short> field3, ExpressionMediator<short> field4, NullableInt16ExpressionMediator field5)
          => new NullableInt16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, field3, field4, field5 });

        public static Int16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, ExpressionMediator<short> field3, ExpressionMediator<short> field4, Int16ExpressionMediator field5)
          => new Int16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, field3, field4, field5 });

        public static Int16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, ExpressionMediator<short> field3, ExpressionMediator<short> field4, ExpressionMediator<short> field5, short value)
          => new Int16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, field3, field4, field5, new ExpressionMediator<short>(new LiteralExpression<short>(value)) });

        public static NullableInt16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, ExpressionMediator<short> field3, ExpressionMediator<short> field4, ExpressionMediator<short> field5, short? value)
          => new NullableInt16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, field3, field4, field5, new ExpressionMediator<short>(new NullableLiteralExpression<short?>(value)) });

        public static NullableInt16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, ExpressionMediator<short> field3, ExpressionMediator<short> field4, ExpressionMediator<short> field5, NullableInt16ExpressionMediator field6)
          => new NullableInt16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, field3, field4, field5, field6 });

        public static Int16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, ExpressionMediator<short> field3, ExpressionMediator<short> field4, ExpressionMediator<short> field5, Int16ExpressionMediator field6)
          => new Int16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, field3, field4, field5, field6 });

        public static Int16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, ExpressionMediator<short> field3, ExpressionMediator<short> field4, ExpressionMediator<short> field5, ExpressionMediator<short> field6, short value)
          => new Int16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<short>(new LiteralExpression<short>(value)) });

        public static NullableInt16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, ExpressionMediator<short> field3, ExpressionMediator<short> field4, ExpressionMediator<short> field5, ExpressionMediator<short> field6, short? value)
          => new NullableInt16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<short>(new NullableLiteralExpression<short?>(value)) });

        public static NullableInt16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, ExpressionMediator<short> field3, ExpressionMediator<short> field4, ExpressionMediator<short> field5, ExpressionMediator<short> field6, NullableInt16ExpressionMediator field7)
          => new NullableInt16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, field3, field4, field5, field6, field7 });

        public static Int16CoalesceFunctionExpression Coalesce(ExpressionMediator<short> field1, ExpressionMediator<short> field2, ExpressionMediator<short> field3, ExpressionMediator<short> field4, ExpressionMediator<short> field5, ExpressionMediator<short> field6, Int16ExpressionMediator field7)
          => new Int16CoalesceFunctionExpression(new List<ExpressionMediator<short>> { field1, field2, field3, field4, field5, field6, field7 });
        #endregion

        #region int
        public static Int32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, int value)
            => new Int32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, new ExpressionMediator<int>(new LiteralExpression<int>(value)) });

        public static NullableInt32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, int? value)
          => new NullableInt32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, new NullableExpressionMediator<int>(new NullableLiteralExpression<int?>(value)) });

        public static NullableInt32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, NullableInt32ExpressionMediator field2)
          => new NullableInt32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2 });

        public static Int32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, Int32ExpressionMediator field2)
          => new Int32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2 });

        public static Int32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, int value)
          => new Int32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, new ExpressionMediator<int>(new LiteralExpression<int>(value)) });

        public static NullableInt32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, int? value)
          => new NullableInt32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, new ExpressionMediator<int>(new NullableLiteralExpression<int?>(value)) });

        public static NullableInt32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, NullableInt32ExpressionMediator field3)
          => new NullableInt32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, field3 });

        public static Int32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, Int32ExpressionMediator field3)
          => new Int32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, field3 });

        public static Int32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, ExpressionMediator<int> field3, int value)
          => new Int32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, field3, new ExpressionMediator<int>(new LiteralExpression<int>(value)) });

        public static NullableInt32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, ExpressionMediator<int> field3, int? value)
          => new NullableInt32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, field3, new ExpressionMediator<int>(new NullableLiteralExpression<int?>(value)) });

        public static NullableInt32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, ExpressionMediator<int> field3, NullableInt32ExpressionMediator field4)
          => new NullableInt32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, field3, field4 });

        public static Int32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, ExpressionMediator<int> field3, Int32ExpressionMediator field4)
          => new Int32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, field3, field4 });

        public static Int32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, ExpressionMediator<int> field3, ExpressionMediator<int> field4, int value)
          => new Int32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, field3, field4, new ExpressionMediator<int>(new LiteralExpression<int>(value)) });

        public static NullableInt32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, ExpressionMediator<int> field3, ExpressionMediator<int> field4, int? value)
          => new NullableInt32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, field3, field4, new ExpressionMediator<int>(new NullableLiteralExpression<int?>(value)) });

        public static NullableInt32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, ExpressionMediator<int> field3, ExpressionMediator<int> field4, NullableInt32ExpressionMediator field5)
          => new NullableInt32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, field3, field4, field5 });

        public static Int32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, ExpressionMediator<int> field3, ExpressionMediator<int> field4, Int32ExpressionMediator field5)
          => new Int32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, field3, field4, field5 });

        public static Int32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, ExpressionMediator<int> field3, ExpressionMediator<int> field4, ExpressionMediator<int> field5, int value)
          => new Int32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, field3, field4, field5, new ExpressionMediator<int>(new LiteralExpression<int>(value)) });

        public static NullableInt32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, ExpressionMediator<int> field3, ExpressionMediator<int> field4, ExpressionMediator<int> field5, int? value)
          => new NullableInt32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, field3, field4, field5, new ExpressionMediator<int>(new NullableLiteralExpression<int?>(value)) });

        public static NullableInt32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, ExpressionMediator<int> field3, ExpressionMediator<int> field4, ExpressionMediator<int> field5, NullableInt32ExpressionMediator field6)
          => new NullableInt32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, field3, field4, field5, field6 });

        public static Int32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, ExpressionMediator<int> field3, ExpressionMediator<int> field4, ExpressionMediator<int> field5, Int32ExpressionMediator field6)
          => new Int32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, field3, field4, field5, field6 });

        public static Int32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, ExpressionMediator<int> field3, ExpressionMediator<int> field4, ExpressionMediator<int> field5, ExpressionMediator<int> field6, int value)
          => new Int32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<int>(new LiteralExpression<int>(value)) });

        public static NullableInt32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, ExpressionMediator<int> field3, ExpressionMediator<int> field4, ExpressionMediator<int> field5, ExpressionMediator<int> field6, int? value)
          => new NullableInt32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<int>(new NullableLiteralExpression<int?>(value)) });

        public static NullableInt32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, ExpressionMediator<int> field3, ExpressionMediator<int> field4, ExpressionMediator<int> field5, ExpressionMediator<int> field6, NullableInt32ExpressionMediator field7)
          => new NullableInt32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, field3, field4, field5, field6, field7 });

        public static Int32CoalesceFunctionExpression Coalesce(ExpressionMediator<int> field1, ExpressionMediator<int> field2, ExpressionMediator<int> field3, ExpressionMediator<int> field4, ExpressionMediator<int> field5, ExpressionMediator<int> field6, Int32ExpressionMediator field7)
          => new Int32CoalesceFunctionExpression(new List<ExpressionMediator<int>> { field1, field2, field3, field4, field5, field6, field7 });
        #endregion

        #region long
        public static Int64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, long value)
            => new Int64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, new ExpressionMediator<long>(new LiteralExpression<long>(value)) });

        public static NullableInt64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, long? value)
          => new NullableInt64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, new NullableExpressionMediator<long>(new NullableLiteralExpression<long?>(value)) });

        public static NullableInt64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, NullableInt64ExpressionMediator field2)
          => new NullableInt64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2 });

        public static Int64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, Int64ExpressionMediator field2)
          => new Int64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2 });

        public static Int64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, long value)
          => new Int64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, new ExpressionMediator<long>(new LiteralExpression<long>(value)) });

        public static NullableInt64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, long? value)
          => new NullableInt64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, new ExpressionMediator<long>(new NullableLiteralExpression<long?>(value)) });

        public static NullableInt64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, NullableInt64ExpressionMediator field3)
          => new NullableInt64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, field3 });

        public static Int64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, Int64ExpressionMediator field3)
          => new Int64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, field3 });

        public static Int64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, ExpressionMediator<long> field3, long value)
          => new Int64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, field3, new ExpressionMediator<long>(new LiteralExpression<long>(value)) });

        public static NullableInt64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, ExpressionMediator<long> field3, long? value)
          => new NullableInt64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, field3, new ExpressionMediator<long>(new NullableLiteralExpression<long?>(value)) });

        public static NullableInt64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, ExpressionMediator<long> field3, NullableInt64ExpressionMediator field4)
          => new NullableInt64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, field3, field4 });

        public static Int64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, ExpressionMediator<long> field3, Int64ExpressionMediator field4)
          => new Int64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, field3, field4 });

        public static Int64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, ExpressionMediator<long> field3, ExpressionMediator<long> field4, long value)
          => new Int64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, field3, field4, new ExpressionMediator<long>(new LiteralExpression<long>(value)) });

        public static NullableInt64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, ExpressionMediator<long> field3, ExpressionMediator<long> field4, long? value)
          => new NullableInt64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, field3, field4, new ExpressionMediator<long>(new NullableLiteralExpression<long?>(value)) });

        public static NullableInt64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, ExpressionMediator<long> field3, ExpressionMediator<long> field4, NullableInt64ExpressionMediator field5)
          => new NullableInt64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, field3, field4, field5 });

        public static Int64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, ExpressionMediator<long> field3, ExpressionMediator<long> field4, Int64ExpressionMediator field5)
          => new Int64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, field3, field4, field5 });

        public static Int64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, ExpressionMediator<long> field3, ExpressionMediator<long> field4, ExpressionMediator<long> field5, long value)
          => new Int64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, field3, field4, field5, new ExpressionMediator<long>(new LiteralExpression<long>(value)) });

        public static NullableInt64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, ExpressionMediator<long> field3, ExpressionMediator<long> field4, ExpressionMediator<long> field5, long? value)
          => new NullableInt64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, field3, field4, field5, new ExpressionMediator<long>(new NullableLiteralExpression<long?>(value)) });

        public static NullableInt64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, ExpressionMediator<long> field3, ExpressionMediator<long> field4, ExpressionMediator<long> field5, NullableInt64ExpressionMediator field6)
          => new NullableInt64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, field3, field4, field5, field6 });

        public static Int64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, ExpressionMediator<long> field3, ExpressionMediator<long> field4, ExpressionMediator<long> field5, Int64ExpressionMediator field6)
          => new Int64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, field3, field4, field5, field6 });

        public static Int64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, ExpressionMediator<long> field3, ExpressionMediator<long> field4, ExpressionMediator<long> field5, ExpressionMediator<long> field6, long value)
          => new Int64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<long>(new LiteralExpression<long>(value)) });

        public static NullableInt64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, ExpressionMediator<long> field3, ExpressionMediator<long> field4, ExpressionMediator<long> field5, ExpressionMediator<long> field6, long? value)
          => new NullableInt64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<long>(new NullableLiteralExpression<long?>(value)) });

        public static NullableInt64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, ExpressionMediator<long> field3, ExpressionMediator<long> field4, ExpressionMediator<long> field5, ExpressionMediator<long> field6, NullableInt64ExpressionMediator field7)
          => new NullableInt64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, field3, field4, field5, field6, field7 });

        public static Int64CoalesceFunctionExpression Coalesce(ExpressionMediator<long> field1, ExpressionMediator<long> field2, ExpressionMediator<long> field3, ExpressionMediator<long> field4, ExpressionMediator<long> field5, ExpressionMediator<long> field6, Int64ExpressionMediator field7)
          => new Int64CoalesceFunctionExpression(new List<ExpressionMediator<long>> { field1, field2, field3, field4, field5, field6, field7 });
        #endregion

        #region string
        public static StringCoalesceFunctionExpression Coalesce(ExpressionMediator<string> field1, string value)
            => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, new ExpressionMediator<string>(new LiteralExpression<string>(value)) });

        public static NullableStringCoalesceFunctionExpression Coalesce(ExpressionMediator<string> field1, NullableStringExpressionMediator field2)
          => new NullableStringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2 });

        public static StringCoalesceFunctionExpression Coalesce(ExpressionMediator<string> field1, StringExpressionMediator field2)
          => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2 });

        public static StringCoalesceFunctionExpression Coalesce(ExpressionMediator<string> field1, ExpressionMediator<string> field2, string value)
          => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, new ExpressionMediator<string>(new LiteralExpression<string>(value)) });

        public static NullableStringCoalesceFunctionExpression Coalesce(ExpressionMediator<string> field1, ExpressionMediator<string> field2, NullableStringExpressionMediator field3)
          => new NullableStringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3 });

        public static StringCoalesceFunctionExpression Coalesce(ExpressionMediator<string> field1, ExpressionMediator<string> field2, StringExpressionMediator field3)
          => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3 });

        public static StringCoalesceFunctionExpression Coalesce(ExpressionMediator<string> field1, ExpressionMediator<string> field2, ExpressionMediator<string> field3, string value)
          => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, new ExpressionMediator<string>(new LiteralExpression<string>(value)) });

        public static NullableStringCoalesceFunctionExpression Coalesce(ExpressionMediator<string> field1, ExpressionMediator<string> field2, ExpressionMediator<string> field3, NullableStringExpressionMediator field4)
          => new NullableStringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, field4 });

        public static StringCoalesceFunctionExpression Coalesce(ExpressionMediator<string> field1, ExpressionMediator<string> field2, ExpressionMediator<string> field3, StringExpressionMediator field4)
          => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, field4 });

        public static StringCoalesceFunctionExpression Coalesce(ExpressionMediator<string> field1, ExpressionMediator<string> field2, ExpressionMediator<string> field3, ExpressionMediator<string> field4, string value)
          => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, field4, new ExpressionMediator<string>(new LiteralExpression<string>(value)) });

        public static NullableStringCoalesceFunctionExpression Coalesce(ExpressionMediator<string> field1, ExpressionMediator<string> field2, ExpressionMediator<string> field3, ExpressionMediator<string> field4, NullableStringExpressionMediator field5)
          => new NullableStringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, field4, field5 });

        public static StringCoalesceFunctionExpression Coalesce(ExpressionMediator<string> field1, ExpressionMediator<string> field2, ExpressionMediator<string> field3, ExpressionMediator<string> field4, StringExpressionMediator field5)
          => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, field4, field5 });

        public static StringCoalesceFunctionExpression Coalesce(ExpressionMediator<string> field1, ExpressionMediator<string> field2, ExpressionMediator<string> field3, ExpressionMediator<string> field4, ExpressionMediator<string> field5, string value)
          => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, field4, field5, new ExpressionMediator<string>(new LiteralExpression<string>(value)) });

        public static NullableStringCoalesceFunctionExpression Coalesce(ExpressionMediator<string> field1, ExpressionMediator<string> field2, ExpressionMediator<string> field3, ExpressionMediator<string> field4, ExpressionMediator<string> field5, NullableStringExpressionMediator field6)
          => new NullableStringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, field4, field5, field6 });

        public static StringCoalesceFunctionExpression Coalesce(ExpressionMediator<string> field1, ExpressionMediator<string> field2, ExpressionMediator<string> field3, ExpressionMediator<string> field4, ExpressionMediator<string> field5, StringExpressionMediator field6)
          => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, field4, field5, field6 });

        public static StringCoalesceFunctionExpression Coalesce(ExpressionMediator<string> field1, ExpressionMediator<string> field2, ExpressionMediator<string> field3, ExpressionMediator<string> field4, ExpressionMediator<string> field5, ExpressionMediator<string> field6, string value)
          => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<string>(new LiteralExpression<string>(value)) });

        public static NullableStringCoalesceFunctionExpression Coalesce(ExpressionMediator<string> field1, ExpressionMediator<string> field2, ExpressionMediator<string> field3, ExpressionMediator<string> field4, ExpressionMediator<string> field5, ExpressionMediator<string> field6, NullableStringExpressionMediator field7)
          => new NullableStringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, field4, field5, field6, field7 });

        public static StringCoalesceFunctionExpression Coalesce(ExpressionMediator<string> field1, ExpressionMediator<string> field2, ExpressionMediator<string> field3, ExpressionMediator<string> field4, ExpressionMediator<string> field5, ExpressionMediator<string> field6, StringExpressionMediator field7)
          => new StringCoalesceFunctionExpression(new List<ExpressionMediator<string>> { field1, field2, field3, field4, field5, field6, field7 });
        #endregion

        #region TimeSpan
        public static TimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, TimeSpan value)
            => new TimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, new ExpressionMediator<TimeSpan>(new LiteralExpression<TimeSpan>(value)) });

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, TimeSpan? value)
          => new NullableTimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, new NullableExpressionMediator<TimeSpan>(new NullableLiteralExpression<TimeSpan?>(value)) });

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, NullableTimeSpanExpressionMediator field2)
          => new NullableTimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2 });

        public static TimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, TimeSpanExpressionMediator field2)
          => new TimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2 });

        public static TimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, TimeSpan value)
          => new TimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, new ExpressionMediator<TimeSpan>(new LiteralExpression<TimeSpan>(value)) });

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, TimeSpan? value)
          => new NullableTimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, new ExpressionMediator<TimeSpan>(new NullableLiteralExpression<TimeSpan?>(value)) });

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, NullableTimeSpanExpressionMediator field3)
          => new NullableTimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, field3 });

        public static TimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, TimeSpanExpressionMediator field3)
          => new TimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, field3 });

        public static TimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, ExpressionMediator<TimeSpan> field3, TimeSpan value)
          => new TimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, field3, new ExpressionMediator<TimeSpan>(new LiteralExpression<TimeSpan>(value)) });

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, ExpressionMediator<TimeSpan> field3, TimeSpan? value)
          => new NullableTimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, field3, new ExpressionMediator<TimeSpan>(new NullableLiteralExpression<TimeSpan?>(value)) });

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, ExpressionMediator<TimeSpan> field3, NullableTimeSpanExpressionMediator field4)
          => new NullableTimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, field3, field4 });

        public static TimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, ExpressionMediator<TimeSpan> field3, TimeSpanExpressionMediator field4)
          => new TimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, field3, field4 });

        public static TimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, ExpressionMediator<TimeSpan> field3, ExpressionMediator<TimeSpan> field4, TimeSpan value)
          => new TimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, field3, field4, new ExpressionMediator<TimeSpan>(new LiteralExpression<TimeSpan>(value)) });

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, ExpressionMediator<TimeSpan> field3, ExpressionMediator<TimeSpan> field4, TimeSpan? value)
          => new NullableTimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, field3, field4, new ExpressionMediator<TimeSpan>(new NullableLiteralExpression<TimeSpan?>(value)) });

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, ExpressionMediator<TimeSpan> field3, ExpressionMediator<TimeSpan> field4, NullableTimeSpanExpressionMediator field5)
          => new NullableTimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, field3, field4, field5 });

        public static TimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, ExpressionMediator<TimeSpan> field3, ExpressionMediator<TimeSpan> field4, TimeSpanExpressionMediator field5)
          => new TimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, field3, field4, field5 });

        public static TimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, ExpressionMediator<TimeSpan> field3, ExpressionMediator<TimeSpan> field4, ExpressionMediator<TimeSpan> field5, TimeSpan value)
          => new TimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, field3, field4, field5, new ExpressionMediator<TimeSpan>(new LiteralExpression<TimeSpan>(value)) });

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, ExpressionMediator<TimeSpan> field3, ExpressionMediator<TimeSpan> field4, ExpressionMediator<TimeSpan> field5, TimeSpan? value)
          => new NullableTimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, field3, field4, field5, new ExpressionMediator<TimeSpan>(new NullableLiteralExpression<TimeSpan?>(value)) });

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, ExpressionMediator<TimeSpan> field3, ExpressionMediator<TimeSpan> field4, ExpressionMediator<TimeSpan> field5, NullableTimeSpanExpressionMediator field6)
          => new NullableTimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, field3, field4, field5, field6 });

        public static TimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, ExpressionMediator<TimeSpan> field3, ExpressionMediator<TimeSpan> field4, ExpressionMediator<TimeSpan> field5, TimeSpanExpressionMediator field6)
          => new TimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, field3, field4, field5, field6 });

        public static TimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, ExpressionMediator<TimeSpan> field3, ExpressionMediator<TimeSpan> field4, ExpressionMediator<TimeSpan> field5, ExpressionMediator<TimeSpan> field6, TimeSpan value)
          => new TimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<TimeSpan>(new LiteralExpression<TimeSpan>(value)) });

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, ExpressionMediator<TimeSpan> field3, ExpressionMediator<TimeSpan> field4, ExpressionMediator<TimeSpan> field5, ExpressionMediator<TimeSpan> field6, TimeSpan? value)
          => new NullableTimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, field3, field4, field5, field6, new ExpressionMediator<TimeSpan>(new NullableLiteralExpression<TimeSpan?>(value)) });

        public static NullableTimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, ExpressionMediator<TimeSpan> field3, ExpressionMediator<TimeSpan> field4, ExpressionMediator<TimeSpan> field5, ExpressionMediator<TimeSpan> field6, NullableTimeSpanExpressionMediator field7)
          => new NullableTimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, field3, field4, field5, field6, field7 });

        public static TimeSpanCoalesceFunctionExpression Coalesce(ExpressionMediator<TimeSpan> field1, ExpressionMediator<TimeSpan> field2, ExpressionMediator<TimeSpan> field3, ExpressionMediator<TimeSpan> field4, ExpressionMediator<TimeSpan> field5, ExpressionMediator<TimeSpan> field6, TimeSpanExpressionMediator field7)
          => new TimeSpanCoalesceFunctionExpression(new List<ExpressionMediator<TimeSpan>> { field1, field2, field3, field4, field5, field6, field7 });
        #endregion
        #endregion

        #region isnull
        #region bool
        public static BooleanIsNullFunctionExpression IsNull(ExpressionMediator<bool> field1, BooleanExpressionMediator field2)
            => new BooleanIsNullFunctionExpression(field1, field2);

        public static NullableBooleanIsNullFunctionExpression IsNull(ExpressionMediator<bool> field1, NullableBooleanExpressionMediator field2)
            => new NullableBooleanIsNullFunctionExpression(field1, field2);

        public static BooleanIsNullFunctionExpression IsNull(ExpressionMediator<bool> field, bool value)
            => new BooleanIsNullFunctionExpression(field, new BooleanExpressionMediator(new LiteralExpression<bool>(value)));

        public static NullableBooleanIsNullFunctionExpression IsNull(ExpressionMediator<bool> field, bool? value)
            => new NullableBooleanIsNullFunctionExpression(field, new NullableBooleanExpressionMediator(new NullableLiteralExpression<bool?>(value)));
        #endregion

        #region byte
        public static ByteIsNullFunctionExpression IsNull(ExpressionMediator<byte> field1, ByteExpressionMediator field2)
            => new ByteIsNullFunctionExpression(field1, field2);

        public static NullableByteIsNullFunctionExpression IsNull(ExpressionMediator<byte> field1, NullableByteExpressionMediator field2)
            => new NullableByteIsNullFunctionExpression(field1, field2);

        public static ByteIsNullFunctionExpression IsNull(ExpressionMediator<byte> field, byte value)
            => new ByteIsNullFunctionExpression(field, new ByteExpressionMediator(new LiteralExpression<byte>(value)));

        public static NullableByteIsNullFunctionExpression IsNull(ExpressionMediator<byte> field, byte? value)
            => new NullableByteIsNullFunctionExpression(field, new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(value)));
        #endregion

        #region DateTime
        public static DateTimeIsNullFunctionExpression IsNull(ExpressionMediator<DateTime> field1, DateTimeExpressionMediator field2)
            => new DateTimeIsNullFunctionExpression(field1, field2);

        public static NullableDateTimeIsNullFunctionExpression IsNull(ExpressionMediator<DateTime> field1, NullableDateTimeExpressionMediator field2)
            => new NullableDateTimeIsNullFunctionExpression(field1, field2);

        public static DateTimeIsNullFunctionExpression IsNull(ExpressionMediator<DateTime> field, DateTime value)
            => new DateTimeIsNullFunctionExpression(field, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(value)));

        public static NullableDateTimeIsNullFunctionExpression IsNull(ExpressionMediator<DateTime> field, DateTime? value)
            => new NullableDateTimeIsNullFunctionExpression(field, new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(value)));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetIsNullFunctionExpression IsNull(ExpressionMediator<DateTimeOffset> field1, DateTimeOffsetExpressionMediator field2)
             => new DateTimeOffsetIsNullFunctionExpression(field1, field2);

        public static NullableDateTimeOffsetIsNullFunctionExpression IsNull(ExpressionMediator<DateTimeOffset> field1, NullableDateTimeOffsetExpressionMediator field2)
            => new NullableDateTimeOffsetIsNullFunctionExpression(field1, field2);

        public static DateTimeOffsetIsNullFunctionExpression IsNull(ExpressionMediator<DateTimeOffset> field, DateTime value)
            => new DateTimeOffsetIsNullFunctionExpression(field, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTime>(value)));

        public static NullableDateTimeOffsetIsNullFunctionExpression IsNull(ExpressionMediator<DateTimeOffset> field, DateTime? value)
            => new NullableDateTimeOffsetIsNullFunctionExpression(field, new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTime?>(value)));
        #endregion

        #region decimal
        public static DecimalIsNullFunctionExpression IsNull(ExpressionMediator<decimal> field1, DecimalExpressionMediator field2)
            => new DecimalIsNullFunctionExpression(field1, field2);

        public static NullableDecimalIsNullFunctionExpression IsNull(ExpressionMediator<decimal> field1, NullableDecimalExpressionMediator field2)
            => new NullableDecimalIsNullFunctionExpression(field1, field2);

        public static DecimalIsNullFunctionExpression IsNull(ExpressionMediator<decimal> field, decimal value)
            => new DecimalIsNullFunctionExpression(field, new DecimalExpressionMediator(new LiteralExpression<decimal>(value)));

        public static NullableDecimalIsNullFunctionExpression IsNull(ExpressionMediator<decimal> field, decimal? value)
            => new NullableDecimalIsNullFunctionExpression(field, new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(value)));
        #endregion

        #region double
        public static DoubleIsNullFunctionExpression IsNull(ExpressionMediator<double> field1, DoubleExpressionMediator field2)
            => new DoubleIsNullFunctionExpression(field1, field2);

        public static NullableDoubleIsNullFunctionExpression IsNull(ExpressionMediator<double> field1, NullableDoubleExpressionMediator field2)
            => new NullableDoubleIsNullFunctionExpression(field1, field2);

        public static DoubleIsNullFunctionExpression IsNull(ExpressionMediator<double> field, double value)
            => new DoubleIsNullFunctionExpression(field, new DoubleExpressionMediator(new LiteralExpression<double>(value)));

        public static NullableDoubleIsNullFunctionExpression IsNull(ExpressionMediator<double> field, double? value)
            => new NullableDoubleIsNullFunctionExpression(field, new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(value)));
        #endregion

        #region enum
        public static EnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(EnumExpressionMediator<TEnum> field1, EnumExpressionMediator<TEnum> field2)
            where TEnum : struct, Enum, IComparable
            => new EnumIsNullFunctionExpression<TEnum>(field1, field2);

        public static NullableEnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(EnumExpressionMediator<TEnum> field1, NullableEnumExpressionMediator<TEnum> field2)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumIsNullFunctionExpression<TEnum>(field1, field2);

        public static EnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(EnumExpressionMediator<TEnum> field, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumIsNullFunctionExpression<TEnum>(field, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)));

        public static NullableEnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(EnumExpressionMediator<TEnum> field, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumIsNullFunctionExpression<TEnum>(field, new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(value)));
        #endregion

        #region float
        public static SingleIsNullFunctionExpression IsNull(ExpressionMediator<float> field1, SingleExpressionMediator field2)
            => new SingleIsNullFunctionExpression(field1, field2);

        public static NullableSingleIsNullFunctionExpression IsNull(ExpressionMediator<float> field1, NullableSingleExpressionMediator field2)
            => new NullableSingleIsNullFunctionExpression(field1, field2);

        public static SingleIsNullFunctionExpression IsNull(ExpressionMediator<float> field, float value)
            => new SingleIsNullFunctionExpression(field, new SingleExpressionMediator(new LiteralExpression<float>(value)));

        public static NullableSingleIsNullFunctionExpression IsNull(ExpressionMediator<float> field, float? value)
            => new NullableSingleIsNullFunctionExpression(field, new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(value)));
        #endregion

        #region Guid
        public static GuidIsNullFunctionExpression IsNull(ExpressionMediator<Guid> field1, GuidExpressionMediator field2)
            => new GuidIsNullFunctionExpression(field1, field2);

        public static NullableGuidIsNullFunctionExpression IsNull(ExpressionMediator<Guid> field1, NullableGuidExpressionMediator field2)
            => new NullableGuidIsNullFunctionExpression(field1, field2);

        public static GuidIsNullFunctionExpression IsNull(ExpressionMediator<Guid> field, Guid value)
            => new GuidIsNullFunctionExpression(field, new GuidExpressionMediator(new LiteralExpression<Guid>(value)));

        public static NullableGuidIsNullFunctionExpression IsNull(ExpressionMediator<Guid> field, Guid? value)
            => new NullableGuidIsNullFunctionExpression(field, new NullableGuidExpressionMediator(new NullableLiteralExpression<Guid?>(value)));
        #endregion

        #region short
        public static Int16IsNullFunctionExpression IsNull(ExpressionMediator<short> field1, Int16ExpressionMediator field2)
            => new Int16IsNullFunctionExpression(field1, field2);

        public static NullableInt16IsNullFunctionExpression IsNull(ExpressionMediator<short> field1, NullableInt16ExpressionMediator field2)
            => new NullableInt16IsNullFunctionExpression(field1, field2);

        public static Int16IsNullFunctionExpression IsNull(ExpressionMediator<short> field, short value)
            => new Int16IsNullFunctionExpression(field, new Int16ExpressionMediator(new LiteralExpression<short>(value)));

        public static NullableInt16IsNullFunctionExpression IsNull(ExpressionMediator<short> field, short? value)
            => new NullableInt16IsNullFunctionExpression(field, new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(value)));
        #endregion

        #region int
        public static Int32IsNullFunctionExpression IsNull(ExpressionMediator<int> field1, Int32ExpressionMediator field2)
            => new Int32IsNullFunctionExpression(field1, field2);

        public static NullableInt32IsNullFunctionExpression IsNull(ExpressionMediator<int> field1, NullableInt32ExpressionMediator field2)
            => new NullableInt32IsNullFunctionExpression(field1, field2);

        public static Int32IsNullFunctionExpression IsNull(ExpressionMediator<int> field, int value)
            => new Int32IsNullFunctionExpression(field, new Int32ExpressionMediator(new LiteralExpression<int>(value)));

        public static NullableInt32IsNullFunctionExpression IsNull(ExpressionMediator<int> field, int? value)
            => new NullableInt32IsNullFunctionExpression(field, new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(value)));
        #endregion

        #region long
        public static Int64IsNullFunctionExpression IsNull(ExpressionMediator<long> field1, Int64ExpressionMediator field2)
            => new Int64IsNullFunctionExpression(field1, field2);

        public static NullableInt64IsNullFunctionExpression IsNull(ExpressionMediator<long> field1, NullableInt64ExpressionMediator field2)
            => new NullableInt64IsNullFunctionExpression(field1, field2);

        public static Int64IsNullFunctionExpression IsNull(ExpressionMediator<long> field, long value)
            => new Int64IsNullFunctionExpression(field, new Int64ExpressionMediator(new LiteralExpression<long>(value)));

        public static NullableInt64IsNullFunctionExpression IsNull(ExpressionMediator<long> field, long? value)
            => new NullableInt64IsNullFunctionExpression(field, new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(value)));
        #endregion

        #region string
        public static StringIsNullFunctionExpression IsNull(ExpressionMediator<string> field1, StringExpressionMediator field2)
            => new StringIsNullFunctionExpression(field1, field2);

        public static NullableStringIsNullFunctionExpression IsNull(ExpressionMediator<string> field1, NullableStringExpressionMediator field2)
            => new NullableStringIsNullFunctionExpression(field1, field2);

        public static StringIsNullFunctionExpression IsNull(ExpressionMediator<string> field, string value)
            => new StringIsNullFunctionExpression(field, new StringExpressionMediator(new LiteralExpression<string>(value)));
        #endregion

        #region TimeSpan
        public static TimeSpanIsNullFunctionExpression IsNull(ExpressionMediator<TimeSpan> field1, TimeSpanExpressionMediator field2)
            => new TimeSpanIsNullFunctionExpression(field1, field2);

        public static NullableTimeSpanIsNullFunctionExpression IsNull(ExpressionMediator<TimeSpan> field1, NullableTimeSpanExpressionMediator field2)
            => new NullableTimeSpanIsNullFunctionExpression(field1, field2);

        public static TimeSpanIsNullFunctionExpression IsNull(ExpressionMediator<TimeSpan> field, TimeSpan value)
            => new TimeSpanIsNullFunctionExpression(field, new TimeSpanExpressionMediator(new LiteralExpression<TimeSpan>(value)));

        public static NullableTimeSpanIsNullFunctionExpression IsNull(ExpressionMediator<TimeSpan> field, TimeSpan? value)
            => new NullableTimeSpanIsNullFunctionExpression(field, new NullableTimeSpanExpressionMediator(new NullableLiteralExpression<TimeSpan?>(value)));
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

        public static TimeSpanMinimumFunctionExpression Min(TimeSpanExpressionMediator field, bool distinct = false)
            => new TimeSpanMinimumFunctionExpression(field, distinct);

        public static NullableTimeSpanMinimumFunctionExpression Min(NullableTimeSpanExpressionMediator field, bool distinct = false)
            => new NullableTimeSpanMinimumFunctionExpression(field, distinct);
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

        public static TimeSpanMaximumFunctionExpression Max(TimeSpanExpressionMediator field, bool distinct = false)
            => new TimeSpanMaximumFunctionExpression(field, distinct);

        public static NullableTimeSpanMaximumFunctionExpression Max(NullableTimeSpanExpressionMediator field, bool distinct = false)
            => new NullableTimeSpanMaximumFunctionExpression(field, distinct);
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
