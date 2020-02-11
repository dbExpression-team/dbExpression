using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public partial class SqlFunctionExpressionBuilder
    {
        #region concat
        public static ConcatFunctionExpression<string> Concat(params ISupportedForFunctionExpression<ConcatFunctionExpression, string>[] fields)
            => BuildConcatFunctionExpression(fields);

        public static ConcatFunctionExpression<string> Concat(string value, params ISupportedForFunctionExpression<ConcatFunctionExpression, string>[] fields)
            => BuildConcatFunctionExpression(new List<ISupportedForFunctionExpression<ConcatFunctionExpression, string>>() { new LiteralExpression<string>(value) }, fields);

        public static ConcatFunctionExpression<string> Concat(ISupportedForFunctionExpression<ConcatFunctionExpression, string> field1, string value, params ISupportedForFunctionExpression<ConcatFunctionExpression, string>[] fields)
            => BuildConcatFunctionExpression(new List<ISupportedForFunctionExpression<ConcatFunctionExpression, string>>() { field1, new LiteralExpression<string>(value) }, fields);

        public static ConcatFunctionExpression<string> Concat(ISupportedForFunctionExpression<ConcatFunctionExpression, string> field1, ISupportedForFunctionExpression<ConcatFunctionExpression, string> field2, string value, params ISupportedForFunctionExpression<ConcatFunctionExpression, string>[] fields)
            => BuildConcatFunctionExpression(new List<ISupportedForFunctionExpression<ConcatFunctionExpression, string>>() { field1, field2, new LiteralExpression<string>(value) }, fields);

        public static ConcatFunctionExpression<string> Concat(ISupportedForFunctionExpression<ConcatFunctionExpression, string> field1, ISupportedForFunctionExpression<ConcatFunctionExpression, string> field2, ISupportedForFunctionExpression<ConcatFunctionExpression, string> field3, string value, params ISupportedForFunctionExpression<ConcatFunctionExpression, string>[] fields)
            => BuildConcatFunctionExpression(new List<ISupportedForFunctionExpression<ConcatFunctionExpression, string>>() { field1, field2, field3, new LiteralExpression<string>(value) }, fields);

        public static ConcatFunctionExpression<string> Concat(ISupportedForFunctionExpression<ConcatFunctionExpression, string> field1, ISupportedForFunctionExpression<ConcatFunctionExpression, string> field2, ISupportedForFunctionExpression<ConcatFunctionExpression, string> field3, ISupportedForFunctionExpression<ConcatFunctionExpression, string> field4, string value, params ISupportedForFunctionExpression<ConcatFunctionExpression, string>[] fields)
            => BuildConcatFunctionExpression(new List<ISupportedForFunctionExpression<ConcatFunctionExpression, string>>() { field1, field2, field3, field4, new LiteralExpression<string>(value) }, fields);

        private static ConcatFunctionExpression<string> BuildConcatFunctionExpression(IList<ISupportedForFunctionExpression<ConcatFunctionExpression, string>> parts, params ISupportedForFunctionExpression<ConcatFunctionExpression, string>[] fields)
        {
            if (fields != null && fields.Any())
            {
                return new ConcatFunctionExpression<string>(parts.Select(p => (p.GetType(), p as object)).ToList().Concat(fields.Select(f => (f.GetType(), f as object))).ToList());
            }
            return new ConcatFunctionExpression<string>(parts.Select(p => (p.GetType(), p as object)).ToList());
        }
        #endregion

        #region coalesce
        #region bool
        public static CoalesceFunctionExpression<bool> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, bool value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1 }, value);

        public static NullableCoalesceFunctionExpression<bool?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, bool? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1 }, value);

        public static CoalesceFunctionExpression<bool> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool> field2)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1 }, field2);

        public static NullableCoalesceFunctionExpression<bool?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field2)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1, field2 });

        public static CoalesceFunctionExpression<bool> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field2, bool value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1, field2 }, value);

        public static NullableCoalesceFunctionExpression<bool?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field2, bool? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1, field2 }, value);

        public static CoalesceFunctionExpression<bool> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool> field3)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1, field2 }, field3);

        public static NullableCoalesceFunctionExpression<bool?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field3)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1, field2, field3 });

        public static CoalesceFunctionExpression<bool> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field3, bool value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1, field2, field3 }, value);

        public static NullableCoalesceFunctionExpression<bool?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field3, bool? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1, field2, field3 }, value);

        public static CoalesceFunctionExpression<bool> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool> field4)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1, field2, field3 }, field4);

        public static NullableCoalesceFunctionExpression<bool?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field4)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1, field2, field3, field4 });

        public static CoalesceFunctionExpression<bool> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field4, bool value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1, field2, field3, field4 }, value);

        public static NullableCoalesceFunctionExpression<bool?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field4, bool? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1, field2, field3, field4 }, value);

        public static CoalesceFunctionExpression<bool> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool> field5)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1, field2, field3, field4 }, field5);

        public static NullableCoalesceFunctionExpression<bool?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field5)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1, field2, field3, field4, field5 });

        public static CoalesceFunctionExpression<bool> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field5, bool value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1, field2, field3, field4, field5 }, value);

        public static NullableCoalesceFunctionExpression<bool?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field5, bool? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1, field2, field3, field4, field5 }, value);

        public static CoalesceFunctionExpression<bool> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool> field6)
           => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1, field2, field3, field4, field5 }, field6);

        public static NullableCoalesceFunctionExpression<bool?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field6)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1, field2, field3, field4, field5, field6 });

        public static CoalesceFunctionExpression<bool> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field6, bool value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1, field2, field3, field4, field6 }, value);

        public static NullableCoalesceFunctionExpression<bool?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?> field6, bool? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, bool?>>() { field1, field2, field3, field4, field6 }, value);
        #endregion

        #region byte
        public static CoalesceFunctionExpression<byte> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, byte value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1 }, value);

        public static NullableCoalesceFunctionExpression<byte?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, byte? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1 }, value);

        public static CoalesceFunctionExpression<byte> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte> field2)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1 }, field2);

        public static NullableCoalesceFunctionExpression<byte?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field2)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1, field2 });

        public static CoalesceFunctionExpression<byte> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field2, byte value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1, field2 }, value);

        public static NullableCoalesceFunctionExpression<byte?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field2, byte? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1, field2 }, value);

        public static CoalesceFunctionExpression<byte> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte> field3)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1, field2 }, field3);

        public static NullableCoalesceFunctionExpression<byte?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field3)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1, field2, field3 });

        public static CoalesceFunctionExpression<byte> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field3, byte value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1, field2, field3 }, value);

        public static NullableCoalesceFunctionExpression<byte?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field3, byte? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1, field2, field3 }, value);

        public static CoalesceFunctionExpression<byte> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte> field4)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1, field2, field3 }, field4);

        public static NullableCoalesceFunctionExpression<byte?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field4)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1, field2, field3, field4 });

        public static CoalesceFunctionExpression<byte> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field4, byte value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1, field2, field3, field4 }, value);

        public static NullableCoalesceFunctionExpression<byte?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field4, byte? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1, field2, field3, field4 }, value);

        public static CoalesceFunctionExpression<byte> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte> field5)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1, field2, field3, field4 }, field5);

        public static NullableCoalesceFunctionExpression<byte?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field5)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1, field2, field3, field4, field5 });

        public static CoalesceFunctionExpression<byte> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field5, byte value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1, field2, field3, field4, field5 }, value);

        public static NullableCoalesceFunctionExpression<byte?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field5, byte? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1, field2, field3, field4, field5 }, value);

        public static CoalesceFunctionExpression<byte> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte> field6)
           => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1, field2, field3, field4, field5 }, field6);

        public static NullableCoalesceFunctionExpression<byte?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field6)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1, field2, field3, field4, field5, field6 });

        public static CoalesceFunctionExpression<byte> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field6, byte value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1, field2, field3, field4, field6 }, value);

        public static NullableCoalesceFunctionExpression<byte?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?> field6, byte? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>>() { field1, field2, field3, field4, field6 }, value);
        #endregion

        #region DateTime
        public static CoalesceFunctionExpression<DateTime> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, DateTime value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1 }, value);

        public static NullableCoalesceFunctionExpression<DateTime?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, DateTime? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1 }, value);

        public static CoalesceFunctionExpression<DateTime> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime> field2)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1 }, field2);

        public static NullableCoalesceFunctionExpression<DateTime?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field2)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1, field2 });

        public static CoalesceFunctionExpression<DateTime> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field2, DateTime value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1, field2 }, value);

        public static NullableCoalesceFunctionExpression<DateTime?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field2, DateTime? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1, field2 }, value);

        public static CoalesceFunctionExpression<DateTime> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime> field3)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1, field2 }, field3);

        public static NullableCoalesceFunctionExpression<DateTime?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field3)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1, field2, field3 });

        public static CoalesceFunctionExpression<DateTime> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field3, DateTime value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1, field2, field3 }, value);

        public static NullableCoalesceFunctionExpression<DateTime?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field3, DateTime? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1, field2, field3 }, value);

        public static CoalesceFunctionExpression<DateTime> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime> field4)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1, field2, field3 }, field4);

        public static NullableCoalesceFunctionExpression<DateTime?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field4)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1, field2, field3, field4 });

        public static CoalesceFunctionExpression<DateTime> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field4, DateTime value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1, field2, field3, field4 }, value);

        public static NullableCoalesceFunctionExpression<DateTime?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field4, DateTime? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1, field2, field3, field4 }, value);

        public static CoalesceFunctionExpression<DateTime> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime> field5)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1, field2, field3, field4 }, field5);

        public static NullableCoalesceFunctionExpression<DateTime?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field5)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1, field2, field3, field4, field5 });

        public static CoalesceFunctionExpression<DateTime> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field5, DateTime value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1, field2, field3, field4, field5 }, value);

        public static NullableCoalesceFunctionExpression<DateTime?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field5, DateTime? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1, field2, field3, field4, field5 }, value);

        public static CoalesceFunctionExpression<DateTime> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime> field6)
           => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1, field2, field3, field4, field5 }, field6);

        public static NullableCoalesceFunctionExpression<DateTime?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field6)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1, field2, field3, field4, field5, field6 });

        public static CoalesceFunctionExpression<DateTime> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field6, DateTime value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1, field2, field3, field4, field6 }, value);

        public static NullableCoalesceFunctionExpression<DateTime?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?> field6, DateTime? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime?>>() { field1, field2, field3, field4, field6 }, value);
        #endregion

        #region DateTimeOffset
        public static CoalesceFunctionExpression<DateTimeOffset> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, DateTimeOffset value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1 }, value);

        public static NullableCoalesceFunctionExpression<DateTimeOffset?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, DateTimeOffset? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1 }, value);

        public static CoalesceFunctionExpression<DateTimeOffset> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset> field2)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1 }, field2);

        public static NullableCoalesceFunctionExpression<DateTimeOffset?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field2)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1, field2 });

        public static CoalesceFunctionExpression<DateTimeOffset> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field2, DateTimeOffset value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1, field2 }, value);

        public static NullableCoalesceFunctionExpression<DateTimeOffset?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field2, DateTimeOffset? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1, field2 }, value);

        public static CoalesceFunctionExpression<DateTimeOffset> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset> field3)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1, field2 }, field3);

        public static NullableCoalesceFunctionExpression<DateTimeOffset?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field3)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1, field2, field3 });

        public static CoalesceFunctionExpression<DateTimeOffset> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field3, DateTimeOffset value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1, field2, field3 }, value);

        public static NullableCoalesceFunctionExpression<DateTimeOffset?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field3, DateTimeOffset? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1, field2, field3 }, value);

        public static CoalesceFunctionExpression<DateTimeOffset> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset> field4)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1, field2, field3 }, field4);

        public static NullableCoalesceFunctionExpression<DateTimeOffset?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field4)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1, field2, field3, field4 });

        public static CoalesceFunctionExpression<DateTimeOffset> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field4, DateTimeOffset value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1, field2, field3, field4 }, value);

        public static NullableCoalesceFunctionExpression<DateTimeOffset?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field4, DateTimeOffset? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1, field2, field3, field4 }, value);

        public static CoalesceFunctionExpression<DateTimeOffset> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset> field5)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1, field2, field3, field4 }, field5);

        public static NullableCoalesceFunctionExpression<DateTimeOffset?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field5)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1, field2, field3, field4, field5 });

        public static CoalesceFunctionExpression<DateTimeOffset> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field5, DateTimeOffset value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1, field2, field3, field4, field5 }, value);

        public static NullableCoalesceFunctionExpression<DateTimeOffset?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field5, DateTimeOffset? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1, field2, field3, field4, field5 }, value);

        public static CoalesceFunctionExpression<DateTimeOffset> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset> field6)
           => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1, field2, field3, field4, field5 }, field6);

        public static NullableCoalesceFunctionExpression<DateTimeOffset?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field6)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1, field2, field3, field4, field5, field6 });

        public static CoalesceFunctionExpression<DateTimeOffset> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field6, DateTimeOffset value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1, field2, field3, field4, field6 }, value);

        public static NullableCoalesceFunctionExpression<DateTimeOffset?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?> field6, DateTimeOffset? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset?>>() { field1, field2, field3, field4, field6 }, value);
        #endregion

        #region decimal
        public static CoalesceFunctionExpression<decimal> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, decimal value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1 }, value);

        public static NullableCoalesceFunctionExpression<decimal?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, decimal? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1 }, value);

        public static CoalesceFunctionExpression<decimal> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal> field2)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1 }, field2);

        public static NullableCoalesceFunctionExpression<decimal?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field2)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1, field2 });

        public static CoalesceFunctionExpression<decimal> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field2, decimal value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1, field2 }, value);

        public static NullableCoalesceFunctionExpression<decimal?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field2, decimal? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1, field2 }, value);

        public static CoalesceFunctionExpression<decimal> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal> field3)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1, field2 }, field3);

        public static NullableCoalesceFunctionExpression<decimal?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field3)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1, field2, field3 });

        public static CoalesceFunctionExpression<decimal> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field3, decimal value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1, field2, field3 }, value);

        public static NullableCoalesceFunctionExpression<decimal?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field3, decimal? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1, field2, field3 }, value);

        public static CoalesceFunctionExpression<decimal> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal> field4)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1, field2, field3 }, field4);

        public static NullableCoalesceFunctionExpression<decimal?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field4)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1, field2, field3, field4 });

        public static CoalesceFunctionExpression<decimal> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field4, decimal value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1, field2, field3, field4 }, value);

        public static NullableCoalesceFunctionExpression<decimal?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field4, decimal? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1, field2, field3, field4 }, value);

        public static CoalesceFunctionExpression<decimal> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal> field5)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1, field2, field3, field4 }, field5);

        public static NullableCoalesceFunctionExpression<decimal?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field5)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1, field2, field3, field4, field5 });

        public static CoalesceFunctionExpression<decimal> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field5, decimal value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1, field2, field3, field4, field5 }, value);

        public static NullableCoalesceFunctionExpression<decimal?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field5, decimal? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1, field2, field3, field4, field5 }, value);

        public static CoalesceFunctionExpression<decimal> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal> field6)
           => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1, field2, field3, field4, field5 }, field6);

        public static NullableCoalesceFunctionExpression<decimal?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field6)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1, field2, field3, field4, field5, field6 });

        public static CoalesceFunctionExpression<decimal> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field6, decimal value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1, field2, field3, field4, field6 }, value);

        public static NullableCoalesceFunctionExpression<decimal?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?> field6, decimal? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal?>>() { field1, field2, field3, field4, field6 }, value);
        #endregion

        #region enum
        public static CoalesceFunctionExpression<TEnum> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, TEnum value)
            where TEnum : struct, Enum, IComparable
            => BuildEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1 }, value);

        public static NullableCoalesceFunctionExpression<TEnum?> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => BuildNullableEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1 }, value);

        public static CoalesceFunctionExpression<TEnum> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum> field2)
            where TEnum : struct, Enum, IComparable
            => BuildEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1 }, field2);

        public static NullableCoalesceFunctionExpression<TEnum?> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field2)
            where TEnum : struct, Enum, IComparable
            => BuildNullableEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1, field2 });

        public static CoalesceFunctionExpression<TEnum> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field2, TEnum value)
            where TEnum : struct, Enum, IComparable
            => BuildEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1, field2 }, value);

        public static NullableCoalesceFunctionExpression<TEnum?> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field2, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => BuildNullableEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1, field2 }, value);

        public static CoalesceFunctionExpression<TEnum> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum> field3)
            where TEnum : struct, Enum, IComparable
            => BuildEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1, field2 }, field3);

        public static NullableCoalesceFunctionExpression<TEnum?> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field3)
            where TEnum : struct, Enum, IComparable
            => BuildNullableEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1, field2, field3 });

        public static CoalesceFunctionExpression<TEnum> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field3, TEnum value)
            where TEnum : struct, Enum, IComparable
            => BuildEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1, field2, field3 }, value);

        public static NullableCoalesceFunctionExpression<TEnum?> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field3, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => BuildNullableEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1, field2, field3 }, value);

        public static CoalesceFunctionExpression<TEnum> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum> field4)
            where TEnum : struct, Enum, IComparable
            => BuildEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1, field2, field3 }, field4);

        public static NullableCoalesceFunctionExpression<TEnum?> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field4)
            where TEnum : struct, Enum, IComparable
            => BuildNullableEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1, field2, field3, field4 });

        public static CoalesceFunctionExpression<TEnum> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field4, TEnum value)
            where TEnum : struct, Enum, IComparable
            => BuildEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1, field2, field3, field4 }, value);

        public static NullableCoalesceFunctionExpression<TEnum?> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field4, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => BuildNullableEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1, field2, field3, field4 }, value);

        public static CoalesceFunctionExpression<TEnum> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum> field5)
            where TEnum : struct, Enum, IComparable
            => BuildEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1, field2, field3, field4 }, field5);

        public static NullableCoalesceFunctionExpression<TEnum?> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field5)
            where TEnum : struct, Enum, IComparable
            => BuildNullableEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1, field2, field3, field4, field5 });

        public static CoalesceFunctionExpression<TEnum> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field5, TEnum value)
            where TEnum : struct, Enum, IComparable
            => BuildEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1, field2, field3, field4, field5 }, value);

        public static NullableCoalesceFunctionExpression<TEnum?> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field5, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => BuildNullableEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1, field2, field3, field4, field5 }, value);

        public static CoalesceFunctionExpression<TEnum> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum> field6)
           where TEnum : struct, Enum, IComparable
            => BuildEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1, field2, field3, field4, field5 }, field6);

        public static NullableCoalesceFunctionExpression<TEnum?> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field6)
            where TEnum : struct, Enum, IComparable
            => BuildNullableEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1, field2, field3, field4, field5, field6 });

        public static CoalesceFunctionExpression<TEnum> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field6, TEnum value)
            where TEnum : struct, Enum, IComparable
            => BuildEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1, field2, field3, field4, field6 }, value);

        public static NullableCoalesceFunctionExpression<TEnum?> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?> field6, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => BuildNullableEnumCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>>() { field1, field2, field3, field4, field6 }, value);

        private static NullableCoalesceFunctionExpression<TEnum?> BuildNullableEnumCoalesceFunctionExpression<TEnum>(IList<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>> fields)
            where TEnum : struct, Enum, IComparable
            => new NullableCoalesceFunctionExpression<TEnum?>(fields.Select(f => (f.GetType(), f as object)).ToArray());

        private static CoalesceFunctionExpression<TEnum> BuildEnumCoalesceFunctionExpression<TEnum>(IList<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>> fields, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum> field2)
            where TEnum : struct, Enum, IComparable
            => new CoalesceFunctionExpression<TEnum>(fields.Select(f => (f.GetType(), f as object)).ToList(),  (field2.GetType(), field2));

        private static CoalesceFunctionExpression<TEnum> BuildEnumCoalesceFunctionExpression<TEnum>(IList<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>> fields, TEnum value)
           where TEnum : struct, Enum, IComparable
            => new CoalesceFunctionExpression<TEnum>(fields.Select(f => (f.GetType(), f as object)).ToList(), (typeof(LiteralExpression<TEnum>), new LiteralExpression<TEnum>(value)));

        private static NullableCoalesceFunctionExpression<TEnum?> BuildNullableEnumCoalesceFunctionExpression<TEnum>(IList<ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum?>> fields, TEnum? value)
           where TEnum : struct, Enum, IComparable
            => new NullableCoalesceFunctionExpression<TEnum?>(fields.Select(f => (f.GetType(), f as object)).Concat(new List<(Type, object)> { (typeof(LiteralExpression<TEnum?>), new LiteralExpression<TEnum?>(value)) }).ToArray());
        #endregion

        #region float
        public static CoalesceFunctionExpression<float> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, float value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1 }, value);

        public static NullableCoalesceFunctionExpression<float?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, float? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1 }, value);

        public static CoalesceFunctionExpression<float> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float> field2)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1 }, field2);

        public static NullableCoalesceFunctionExpression<float?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field2)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1, field2 });

        public static CoalesceFunctionExpression<float> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field2, float value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1, field2 }, value);

        public static NullableCoalesceFunctionExpression<float?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field2, float? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1, field2 }, value);

        public static CoalesceFunctionExpression<float> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, float> field3)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1, field2 }, field3);

        public static NullableCoalesceFunctionExpression<float?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field3)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1, field2, field3 });

        public static CoalesceFunctionExpression<float> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field3, float value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1, field2, field3 }, value);

        public static NullableCoalesceFunctionExpression<float?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field3, float? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1, field2, field3 }, value);

        public static CoalesceFunctionExpression<float> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, float> field4)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1, field2, field3 }, field4);

        public static NullableCoalesceFunctionExpression<float?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field4)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1, field2, field3, field4 });

        public static CoalesceFunctionExpression<float> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field4, float value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1, field2, field3, field4 }, value);

        public static NullableCoalesceFunctionExpression<float?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field4, float? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1, field2, field3, field4 }, value);

        public static CoalesceFunctionExpression<float> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, float> field5)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1, field2, field3, field4 }, field5);

        public static NullableCoalesceFunctionExpression<float?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field5)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1, field2, field3, field4, field5 });

        public static CoalesceFunctionExpression<float> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field5, float value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1, field2, field3, field4, field5 }, value);

        public static NullableCoalesceFunctionExpression<float?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field5, float? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1, field2, field3, field4, field5 }, value);

        public static CoalesceFunctionExpression<float> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, float> field6)
           => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1, field2, field3, field4, field5 }, field6);

        public static NullableCoalesceFunctionExpression<float?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field6)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1, field2, field3, field4, field5, field6 });

        public static CoalesceFunctionExpression<float> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, float> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field6, float value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1, field2, field3, field4, field6 }, value);

        public static NullableCoalesceFunctionExpression<float?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, float> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, float?> field6, float? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, float?>>() { field1, field2, field3, field4, field6 }, value);
        #endregion

        #region Guid
        public static CoalesceFunctionExpression<Guid> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, Guid value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1 }, value);

        public static NullableCoalesceFunctionExpression<Guid?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, Guid? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1 }, value);

        public static CoalesceFunctionExpression<Guid> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid> field2)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1 }, field2);

        public static NullableCoalesceFunctionExpression<Guid?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field2)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1, field2 });

        public static CoalesceFunctionExpression<Guid> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field2, Guid value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1, field2 }, value);

        public static NullableCoalesceFunctionExpression<Guid?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field2, Guid? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1, field2 }, value);

        public static CoalesceFunctionExpression<Guid> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid> field3)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1, field2 }, field3);

        public static NullableCoalesceFunctionExpression<Guid?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field3)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1, field2, field3 });

        public static CoalesceFunctionExpression<Guid> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field3, Guid value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1, field2, field3 }, value);

        public static NullableCoalesceFunctionExpression<Guid?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field3, Guid? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1, field2, field3 }, value);

        public static CoalesceFunctionExpression<Guid> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid> field4)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1, field2, field3 }, field4);

        public static NullableCoalesceFunctionExpression<Guid?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field4)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1, field2, field3, field4 });

        public static CoalesceFunctionExpression<Guid> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field4, Guid value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1, field2, field3, field4 }, value);

        public static NullableCoalesceFunctionExpression<Guid?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field4, Guid? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1, field2, field3, field4 }, value);

        public static CoalesceFunctionExpression<Guid> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid> field5)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1, field2, field3, field4 }, field5);

        public static NullableCoalesceFunctionExpression<Guid?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field5)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1, field2, field3, field4, field5 });

        public static CoalesceFunctionExpression<Guid> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field5, Guid value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1, field2, field3, field4, field5 }, value);

        public static NullableCoalesceFunctionExpression<Guid?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field5, Guid? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1, field2, field3, field4, field5 }, value);

        public static CoalesceFunctionExpression<Guid> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid> field6)
           => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1, field2, field3, field4, field5 }, field6);

        public static NullableCoalesceFunctionExpression<Guid?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field6)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1, field2, field3, field4, field5, field6 });

        public static CoalesceFunctionExpression<Guid> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field6, Guid value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1, field2, field3, field4, field6 }, value);

        public static NullableCoalesceFunctionExpression<Guid?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?> field6, Guid? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid?>>() { field1, field2, field3, field4, field6 }, value);
        #endregion

        #region short
        public static CoalesceFunctionExpression<short> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, short value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1 }, value);

        public static NullableCoalesceFunctionExpression<short?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, short? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1 }, value);

        public static CoalesceFunctionExpression<short> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short> field2)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1 }, field2);

        public static NullableCoalesceFunctionExpression<short?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field2)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1, field2 });

        public static CoalesceFunctionExpression<short> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field2, short value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1, field2 }, value);

        public static NullableCoalesceFunctionExpression<short?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field2, short? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1, field2 }, value);

        public static CoalesceFunctionExpression<short> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, short> field3)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1, field2 }, field3);

        public static NullableCoalesceFunctionExpression<short?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field3)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1, field2, field3 });

        public static CoalesceFunctionExpression<short> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field3, short value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1, field2, field3 }, value);

        public static NullableCoalesceFunctionExpression<short?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field3, short? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1, field2, field3 }, value);

        public static CoalesceFunctionExpression<short> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, short> field4)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1, field2, field3 }, field4);

        public static NullableCoalesceFunctionExpression<short?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field4)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1, field2, field3, field4 });

        public static CoalesceFunctionExpression<short> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field4, short value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1, field2, field3, field4 }, value);

        public static NullableCoalesceFunctionExpression<short?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field4, short? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1, field2, field3, field4 }, value);

        public static CoalesceFunctionExpression<short> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, short> field5)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1, field2, field3, field4 }, field5);

        public static NullableCoalesceFunctionExpression<short?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field5)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1, field2, field3, field4, field5 });

        public static CoalesceFunctionExpression<short> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field5, short value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1, field2, field3, field4, field5 }, value);

        public static NullableCoalesceFunctionExpression<short?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field5, short? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1, field2, field3, field4, field5 }, value);

        public static CoalesceFunctionExpression<short> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, short> field6)
           => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1, field2, field3, field4, field5 }, field6);

        public static NullableCoalesceFunctionExpression<short?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field6)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1, field2, field3, field4, field5, field6 });

        public static CoalesceFunctionExpression<short> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, short> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field6, short value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1, field2, field3, field4, field6 }, value);

        public static NullableCoalesceFunctionExpression<short?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, short> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, short?> field6, short? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, short?>>() { field1, field2, field3, field4, field6 }, value);
        #endregion

        #region int
        public static CoalesceFunctionExpression<int> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, int value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1 }, value);

        public static NullableCoalesceFunctionExpression<int?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, int? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1 }, value);

        public static CoalesceFunctionExpression<int> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int> field2)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1 }, field2);

        public static NullableCoalesceFunctionExpression<int?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field2)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1, field2 });

        public static CoalesceFunctionExpression<int> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field2, int value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1, field2 }, value);

        public static NullableCoalesceFunctionExpression<int?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field2, int? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1, field2 }, value);

        public static CoalesceFunctionExpression<int> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, int> field3)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1, field2 }, field3);

        public static NullableCoalesceFunctionExpression<int?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field3)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1, field2, field3 });

        public static CoalesceFunctionExpression<int> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field3, int value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1, field2, field3 }, value);

        public static NullableCoalesceFunctionExpression<int?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field3, int? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1, field2, field3 }, value);

        public static CoalesceFunctionExpression<int> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, int> field4)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1, field2, field3 }, field4);

        public static NullableCoalesceFunctionExpression<int?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field4)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1, field2, field3, field4 });

        public static CoalesceFunctionExpression<int> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field4, int value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1, field2, field3, field4 }, value);

        public static NullableCoalesceFunctionExpression<int?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field4, int? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1, field2, field3, field4 }, value);

        public static CoalesceFunctionExpression<int> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, int> field5)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1, field2, field3, field4 }, field5);

        public static NullableCoalesceFunctionExpression<int?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field5)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1, field2, field3, field4, field5 });

        public static CoalesceFunctionExpression<int> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field5, int value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1, field2, field3, field4, field5 }, value);

        public static NullableCoalesceFunctionExpression<int?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field5, int? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1, field2, field3, field4, field5 }, value);

        public static CoalesceFunctionExpression<int> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, int> field6)
           => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1, field2, field3, field4, field5 }, field6);

        public static NullableCoalesceFunctionExpression<int?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field6)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1, field2, field3, field4, field5, field6 });

        public static CoalesceFunctionExpression<int> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, int> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field6, int value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1, field2, field3, field4, field6 }, value);

        public static NullableCoalesceFunctionExpression<int?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, int> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, int?> field6, int? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, int?>>() { field1, field2, field3, field4, field6 }, value);
        #endregion

        #region long
        public static CoalesceFunctionExpression<long> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, long value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1 }, value);

        public static NullableCoalesceFunctionExpression<long?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, long? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1 }, value);

        public static CoalesceFunctionExpression<long> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long> field2)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1 }, field2);

        public static NullableCoalesceFunctionExpression<long?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field2)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1, field2 });

        public static CoalesceFunctionExpression<long> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field2, long value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1, field2 }, value);

        public static NullableCoalesceFunctionExpression<long?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field2, long? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1, field2 }, value);

        public static CoalesceFunctionExpression<long> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, long> field3)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1, field2 }, field3);

        public static NullableCoalesceFunctionExpression<long?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field3)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1, field2, field3 });

        public static CoalesceFunctionExpression<long> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field3, long value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1, field2, field3 }, value);

        public static NullableCoalesceFunctionExpression<long?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field3, long? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1, field2, field3 }, value);

        public static CoalesceFunctionExpression<long> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, long> field4)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1, field2, field3 }, field4);

        public static NullableCoalesceFunctionExpression<long?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field4)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1, field2, field3, field4 });

        public static CoalesceFunctionExpression<long> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field4, long value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1, field2, field3, field4 }, value);

        public static NullableCoalesceFunctionExpression<long?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field4, long? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1, field2, field3, field4 }, value);

        public static CoalesceFunctionExpression<long> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, long> field5)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1, field2, field3, field4 }, field5);

        public static NullableCoalesceFunctionExpression<long?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field5)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1, field2, field3, field4, field5 });

        public static CoalesceFunctionExpression<long> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field5, long value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1, field2, field3, field4, field5 }, value);

        public static NullableCoalesceFunctionExpression<long?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field5, long? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1, field2, field3, field4, field5 }, value);

        public static CoalesceFunctionExpression<long> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, long> field6)
           => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1, field2, field3, field4, field5 }, field6);

        public static NullableCoalesceFunctionExpression<long?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field6)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1, field2, field3, field4, field5, field6 });

        public static CoalesceFunctionExpression<long> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, long> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field6, long value)
            => BuildPrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1, field2, field3, field4, field6 }, value);

        public static NullableCoalesceFunctionExpression<long?> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, long> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, long?> field6, long? value)
            => BuildNullablePrimitiveCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, long?>>() { field1, field2, field3, field4, field6 }, value);
        #endregion

        #region string
        public static CoalesceFunctionExpression<string> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field1, string value)
            => BuildStringCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, string>>() { field1 }, value);

        public static CoalesceFunctionExpression<string> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field2)
            => BuildStringCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, string>>() { field1 }, field2);

        public static CoalesceFunctionExpression<string> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field2, string value)
            => BuildStringCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, string>>() { field1, field2 }, value);

        public static CoalesceFunctionExpression<string> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field3)
            => BuildStringCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, string>>() { field1, field2 }, field3);

        public static CoalesceFunctionExpression<string> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field3, string value)
            => BuildStringCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, string>>() { field1, field2, field3 }, value);

        public static CoalesceFunctionExpression<string> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field4)
            => BuildStringCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, string>>() { field1, field2, field3 }, field4);

        public static CoalesceFunctionExpression<string> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field4, string value)
            => BuildStringCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, string>>() { field1, field2, field3, field4 }, value);

        public static CoalesceFunctionExpression<string> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field5)
            => BuildStringCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, string>>() { field1, field2, field3, field4 }, field5);

        public static CoalesceFunctionExpression<string> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field5, string value)
            => BuildStringCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, string>>() { field1, field2, field3, field4, field5 }, value);

        public static CoalesceFunctionExpression<string> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field6)
            => BuildStringCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, string>>() { field1, field2, field3, field4, field5 }, field6);

        public static CoalesceFunctionExpression<string> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field2, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field3, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field4, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field5, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> field6, string value)
            => BuildStringCoalesceFunctionExpression(new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, string>>() { field1, field2, field3, field4, field5, field6 }, value);

        private static CoalesceFunctionExpression<string> BuildStringCoalesceFunctionExpression(IList<ISupportedForFunctionExpression<CoalesceFunctionExpression, string>> fields, ISupportedForFunctionExpression<CoalesceFunctionExpression, string> notNull)
            => new CoalesceFunctionExpression<string>(fields.Select(f => (f.GetType(), f as object)).ToList(), (notNull.GetType(), notNull));

        private static CoalesceFunctionExpression<string> BuildStringCoalesceFunctionExpression(IList<ISupportedForFunctionExpression<CoalesceFunctionExpression, string>> fields, string value)
            => new CoalesceFunctionExpression<string>(fields.Select(f => (f.GetType(), f as object)).ToList(), (typeof(LiteralExpression<string>), new LiteralExpression<string>(value)));
        #endregion

        private static CoalesceFunctionExpression<TValue> BuildPrimitiveCoalesceFunctionExpression<TValue>(IList<ISupportedForFunctionExpression<CoalesceFunctionExpression, TValue?>> fields, ISupportedForFunctionExpression<CoalesceFunctionExpression, TValue> field)
            where TValue : struct, IComparable
            => new CoalesceFunctionExpression<TValue>(fields.Select(f => (f.GetType(), f as object)).ToList(), (field.GetType(), field));

        private static CoalesceFunctionExpression<TValue> BuildPrimitiveCoalesceFunctionExpression<TValue>(IList<ISupportedForFunctionExpression<CoalesceFunctionExpression, TValue?>> fields, TValue value)
            where TValue : struct, IComparable
            => new CoalesceFunctionExpression<TValue>(fields.Select(f => (f.GetType(), f as object)).ToList(), (typeof(LiteralExpression<TValue>), new LiteralExpression<TValue>(value)));

        private static NullableCoalesceFunctionExpression<TValue?> BuildNullablePrimitiveCoalesceFunctionExpression<TValue>(IList<ISupportedForFunctionExpression<CoalesceFunctionExpression, TValue?>> fields)
            where TValue : struct, IComparable
            => new NullableCoalesceFunctionExpression<TValue?>(fields.Select(f => (f.GetType(), f as object)).ToArray());

        private static NullableCoalesceFunctionExpression<TValue?> BuildNullablePrimitiveCoalesceFunctionExpression<TValue>(IList<ISupportedForFunctionExpression<CoalesceFunctionExpression, TValue?>> fields, TValue? value)
           where TValue : struct, IComparable
            => new NullableCoalesceFunctionExpression<TValue?>(fields.Select(f => (f.GetType(), f as object)).ToList().Concat(new List<(Type, object)> { (typeof(LiteralExpression<TValue?>), new LiteralExpression<TValue?>(value)) }).ToArray());
        #endregion

        #region isnull
        public static IsNullFunctionExpression<bool> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, bool?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, bool> field2)
            => new IsNullFunctionExpression<bool>((field1.GetType(), field1), (field2.GetType(), field2));

        public static NullableIsNullFunctionExpression<bool?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, bool?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, bool?> field2)
            => new NullableIsNullFunctionExpression<bool?>((field1.GetType(), field1), (field2.GetType(), field2));

        public static IsNullFunctionExpression<byte> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, byte?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, byte> field2)
            => new IsNullFunctionExpression<byte>((field1.GetType(), field1), (field2.GetType(), field2));

        public static NullableIsNullFunctionExpression<byte?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, byte?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, byte?> field2)
            => new NullableIsNullFunctionExpression<byte?>((field1.GetType(), field1), (field2.GetType(), field2));

        public static IsNullFunctionExpression<DateTime> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime> field2)
            => new IsNullFunctionExpression<DateTime>((field1.GetType(), field1), (field2.GetType(), field2));

        public static NullableIsNullFunctionExpression<DateTime?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime?> field2)
            => new NullableIsNullFunctionExpression<DateTime?>((field1.GetType(), field1), (field2.GetType(), field2));

        public static IsNullFunctionExpression<decimal> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, decimal> field2)
            => new IsNullFunctionExpression<decimal>((field1.GetType(), field1), (field2.GetType(), field2));

        public static NullableIsNullFunctionExpression<decimal?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, decimal?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, decimal?> field2)
            => new NullableIsNullFunctionExpression<decimal?>((field1.GetType(), field1), (field2.GetType(), field2));

        public static IsNullFunctionExpression<double> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, double?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, double> field2)
            => new IsNullFunctionExpression<double>((field1.GetType(), field1), (field2.GetType(), field2));

        public static NullableIsNullFunctionExpression<double?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, double?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, double?> field2)
            => new NullableIsNullFunctionExpression<double?>((field1.GetType(), field1), (field2.GetType(), field2));

        public static IsNullFunctionExpression<float> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, float?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, float> field2)
            => new IsNullFunctionExpression<float>((field1.GetType(), field1), (field2.GetType(), field2));

        public static NullableIsNullFunctionExpression<float?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, float?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, float?> field2)
            => new NullableIsNullFunctionExpression<float?>((field1.GetType(), field1), (field2.GetType(), field2));

        public static IsNullFunctionExpression<string> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, string> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, string> field2)
            => new IsNullFunctionExpression<string>((field1.GetType(), field1), (field2.GetType(), field2));

        public static IsNullFunctionExpression<Guid> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, Guid> field2)
            => new IsNullFunctionExpression<Guid>((field1.GetType(), field1), (field2.GetType(), field2));

        public static NullableIsNullFunctionExpression<Guid?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, Guid?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, Guid?> field2)
            => new NullableIsNullFunctionExpression<Guid?>((field1.GetType(), field1), (field2.GetType(), field2));

        public static IsNullFunctionExpression<short> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, short?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, short> field2)
            => new IsNullFunctionExpression<short>((field1.GetType(), field1), (field2.GetType(), field2));

        public static NullableIsNullFunctionExpression<short?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, short?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, short?> field2)
            => new NullableIsNullFunctionExpression<short?>((field1.GetType(), field1), (field2.GetType(), field2));

        public static IsNullFunctionExpression<int> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, int?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, int> field2)
            => new IsNullFunctionExpression<int>((field1.GetType(), field1), (field2.GetType(), field2));

        public static NullableIsNullFunctionExpression<int?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, int?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, int?> field2)
            => new NullableIsNullFunctionExpression<int?>((field1.GetType(), field1), (field2.GetType(), field2));

        public static IsNullFunctionExpression<long> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, long?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, long> field2)
            => new IsNullFunctionExpression<long>((field1.GetType(), field1), (field2.GetType(), field2));

        public static NullableIsNullFunctionExpression<long?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, long?> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, long?> field2)
            => new NullableIsNullFunctionExpression<long?>((field1.GetType(), field1), (field2.GetType(), field2));

        public static IsNullFunctionExpression<bool> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, bool?> field, bool value)
            => new IsNullFunctionExpression<bool>((field.GetType(), field), (value.GetType(), value));

        public static NullableIsNullFunctionExpression<bool?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, bool?> field, bool? value)
            => new NullableIsNullFunctionExpression<bool?>((field.GetType(), field), (value.GetType(), value));

        public static IsNullFunctionExpression<byte> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, byte?> field, byte value)
            => new IsNullFunctionExpression<byte>((field.GetType(), field), (value.GetType(), value));

        public static NullableIsNullFunctionExpression<byte?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, byte?> field, byte? value)
           => new NullableIsNullFunctionExpression<byte?>((field.GetType(), field), (value.GetType(), value));

        public static IsNullFunctionExpression<DateTime> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime?> field, DateTime value)
            => new IsNullFunctionExpression<DateTime>((field.GetType(), field), (value.GetType(), value));

        public static NullableIsNullFunctionExpression<DateTime?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime?> field, DateTime? value)
            => new NullableIsNullFunctionExpression<DateTime?>((field.GetType(), field), (value.GetType(), value));

        public static IsNullFunctionExpression<decimal> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, decimal?> field, decimal value)
            => new IsNullFunctionExpression<decimal>((field.GetType(), field), (value.GetType(), value));

        public static NullableIsNullFunctionExpression<decimal?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, decimal?> field, decimal? value)
            => new NullableIsNullFunctionExpression<decimal?>((field.GetType(), field), (value.GetType(), value));

        public static IsNullFunctionExpression<double> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, double?> field, double value)
            => new IsNullFunctionExpression<double>((field.GetType(), field), (value.GetType(), value));

        public static NullableIsNullFunctionExpression<double?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, double?> field, double? value)
            => new NullableIsNullFunctionExpression<double?>((field.GetType(), field), (value.GetType(), value));

        public static IsNullFunctionExpression<float> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, float?> field, float value)
            => new IsNullFunctionExpression<float>((field.GetType(), field), (value.GetType(), value));

        public static NullableIsNullFunctionExpression<float?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, float?> field, float? value)
            => new NullableIsNullFunctionExpression<float?>((field.GetType(), field), (value.GetType(), value));

        public static IsNullFunctionExpression<TEnum> IsNull<TEnum>(NullableEnumFieldExpression<TEnum> field, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new IsNullFunctionExpression<TEnum>((field.GetType(), field), (typeof(TEnum), value));

        public static NullableIsNullFunctionExpression<TEnum> IsNull<TEnum>(NullableEnumFieldExpression<TEnum> field, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableIsNullFunctionExpression<TEnum>((field.GetType(), field), (typeof(TEnum), value));

        public static IsNullFunctionExpression<string> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, string> field, string value)
            => new IsNullFunctionExpression<string>((field.GetType(), field), (value.GetType(), value));

        public static IsNullFunctionExpression<Guid> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, Guid?> field, Guid value)
            => new IsNullFunctionExpression<Guid>((field.GetType(), field), (value.GetType(), value));

        public static NullableIsNullFunctionExpression<Guid?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, Guid?> field, Guid? value)
            => new NullableIsNullFunctionExpression<Guid?>((field.GetType(), field), (value.GetType(), value));

        public static IsNullFunctionExpression<short> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, short?> field, short value)
            => new IsNullFunctionExpression<short>((field.GetType(), field), (value.GetType(), value));

        public static NullableIsNullFunctionExpression<short?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, short?> field, short? value)
            => new NullableIsNullFunctionExpression<short?>((field.GetType(), field), (value.GetType(), value));

        public static IsNullFunctionExpression<int> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, int?> field, int value)
            => new IsNullFunctionExpression<int>((field.GetType(), field), (value.GetType(), value));

        public static NullableIsNullFunctionExpression<int?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, int?> field, int? value)
            => new NullableIsNullFunctionExpression<int?>((field.GetType(), field), (value.GetType(), value));

        public static IsNullFunctionExpression<long> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, long?> field, long value)
            => new IsNullFunctionExpression<long>((field.GetType(), field), (value.GetType(), value));

        public static NullableIsNullFunctionExpression<long?> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, long?> field, long? value)
            => new NullableIsNullFunctionExpression<long?>((field.GetType(), field), (value.GetType(), value));

        #endregion

        #region literal
        public static LiteralExpression<TValue> Literal<TValue>(TValue value)
            where TValue : IComparable
            => new LiteralExpression<TValue>(value);
        #endregion

        #region average
        public static AverageFunctionExpression<int> Avg(ISupportedForFunctionExpression<AverageFunctionExpression, byte> field, bool distinct = false)
            => new AverageFunctionExpression<int>((field.GetType(), field), distinct);

        public static NullableAverageFunctionExpression<int?> Avg(ISupportedForFunctionExpression<AverageFunctionExpression, byte?> field, bool distinct = false)
            => new NullableAverageFunctionExpression<int?>((field.GetType(), field), distinct);

        public static AverageFunctionExpression<int> Avg(ISupportedForFunctionExpression<AverageFunctionExpression, short> field, bool distinct = false)
            => new AverageFunctionExpression<int>((field.GetType(), field), distinct);

        public static NullableAverageFunctionExpression<int?> Avg(ISupportedForFunctionExpression<AverageFunctionExpression, short?> field, bool distinct = false)
            => new NullableAverageFunctionExpression<int?>((field.GetType(), field), distinct);

        public static AverageFunctionExpression<int> Avg(ISupportedForFunctionExpression<AverageFunctionExpression, int> field, bool distinct = false)
            => new AverageFunctionExpression<int>((field.GetType(), field), distinct);

        public static NullableAverageFunctionExpression<int?> Avg(ISupportedForFunctionExpression<AverageFunctionExpression, int?> field, bool distinct = false)
            => new NullableAverageFunctionExpression<int?>((field.GetType(), field), distinct);

        public static AverageFunctionExpression<long> Avg(ISupportedForFunctionExpression<AverageFunctionExpression, long> field, bool distinct = false)
            => new AverageFunctionExpression<long>((field.GetType(), field), distinct);

        public static NullableAverageFunctionExpression<long?> Avg(ISupportedForFunctionExpression<AverageFunctionExpression, long?> field, bool distinct = false)
            => new NullableAverageFunctionExpression<long?>((field.GetType(), field), distinct);

        public static AverageFunctionExpression<float> Avg(ISupportedForFunctionExpression<AverageFunctionExpression, float> field, bool distinct = false)
            => new AverageFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullableAverageFunctionExpression<float?> Avg(ISupportedForFunctionExpression<AverageFunctionExpression, float?> field, bool distinct = false)
            => new NullableAverageFunctionExpression<float?>((field.GetType(), field), distinct);

        public static AverageFunctionExpression<double> Avg(ISupportedForFunctionExpression<AverageFunctionExpression, double> field, bool distinct = false)
            => new AverageFunctionExpression<double>((field.GetType(), field), distinct);

        public static NullableAverageFunctionExpression<double?> Avg(ISupportedForFunctionExpression<AverageFunctionExpression, double?> field, bool distinct = false)
            => new NullableAverageFunctionExpression<double?>((field.GetType(), field), distinct);

        public static AverageFunctionExpression<decimal> Avg(ISupportedForFunctionExpression<AverageFunctionExpression, decimal> field, bool distinct = false)
            => new AverageFunctionExpression<decimal>((field.GetType(), field), distinct);

        public static NullableAverageFunctionExpression<decimal?> Avg(ISupportedForFunctionExpression<AverageFunctionExpression, decimal?> field, bool distinct = false)
            => new NullableAverageFunctionExpression<decimal?>((field.GetType(), field), distinct);
        #endregion

        #region minimum
        public static MinimumFunctionExpression<byte> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, byte> field, bool distinct = false)
            => new MinimumFunctionExpression<byte>((field.GetType(), field), distinct);

        public static NullableMinimumFunctionExpression<byte?> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, byte?> field, bool distinct = false)
            => new NullableMinimumFunctionExpression<byte?>((field.GetType(), field), distinct);

        public static MinimumFunctionExpression<short> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, short> field, bool distinct = false)
            => new MinimumFunctionExpression<short>((field.GetType(), field), distinct);

        public static NullableMinimumFunctionExpression<short?> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, short?> field, bool distinct = false)
            => new NullableMinimumFunctionExpression<short?>((field.GetType(), field), distinct);

        public static MinimumFunctionExpression<int> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, int> field, bool distinct = false)
            => new MinimumFunctionExpression<int>((field.GetType(), field), distinct);

        public static NullableMinimumFunctionExpression<int?> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, int?> field, bool distinct = false)
            => new NullableMinimumFunctionExpression<int?>((field.GetType(), field), distinct);

        public static MinimumFunctionExpression<long> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, long> field, bool distinct = false)
            => new MinimumFunctionExpression<long>((field.GetType(), field), distinct);

        public static NullableMinimumFunctionExpression<long?> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, long?> field, bool distinct = false)
            => new NullableMinimumFunctionExpression<long?>((field.GetType(), field), distinct);

        public static MinimumFunctionExpression<float> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, float> field, bool distinct = false)
            => new MinimumFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullableMinimumFunctionExpression<float?> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, float?> field, bool distinct = false)
            => new NullableMinimumFunctionExpression<float?>((field.GetType(), field), distinct);

        public static MinimumFunctionExpression<double> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, double> field, bool distinct = false)
            => new MinimumFunctionExpression<double>((field.GetType(), field), distinct);

        public static NullableMinimumFunctionExpression<double?> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, double?> field, bool distinct = false)
            => new NullableMinimumFunctionExpression<double?>((field.GetType(), field), distinct);

        public static MinimumFunctionExpression<decimal> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, decimal> field, bool distinct = false)
            => new MinimumFunctionExpression<decimal>((field.GetType(), field), distinct);

        public static NullableMinimumFunctionExpression<decimal?> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, decimal?> field, bool distinct = false)
            => new NullableMinimumFunctionExpression<decimal?>((field.GetType(), field), distinct);

        public static MinimumFunctionExpression<DateTime> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, DateTime> field, bool distinct = false)
            => new MinimumFunctionExpression<DateTime>((field.GetType(), field), distinct);

        public static NullableMinimumFunctionExpression<DateTime?> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, DateTime?> field, bool distinct = false)
            => new NullableMinimumFunctionExpression<DateTime?>((field.GetType(), field), distinct);

        public static MinimumFunctionExpression<DateTimeOffset> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, DateTimeOffset> field, bool distinct = false)
            => new MinimumFunctionExpression<DateTimeOffset>((field.GetType(), field), distinct);

        public static NullableMinimumFunctionExpression<DateTimeOffset?> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, DateTimeOffset?> field, bool distinct = false)
            => new NullableMinimumFunctionExpression<DateTimeOffset?>((field.GetType(), field), distinct);

        public static MinimumFunctionExpression<Guid> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, Guid> field, bool distinct = false)
            => new MinimumFunctionExpression<Guid>((field.GetType(), field), distinct);

        public static NullableMinimumFunctionExpression<Guid?> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, Guid?> field, bool distinct = false)
            => new NullableMinimumFunctionExpression<Guid?>((field.GetType(), field), distinct);

        public static MinimumFunctionExpression<string> Min(ISupportedForFunctionExpression<MinimumFunctionExpression, string> field, bool distinct = false)
            => new MinimumFunctionExpression<string>((field.GetType(), field), distinct);
        #endregion

        #region maximum
        public static MaximumFunctionExpression<byte> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, byte> field, bool distinct = false)
            => new MaximumFunctionExpression<byte>((field.GetType(), field), distinct);

        public static NullableMaximumFunctionExpression<byte?> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, byte?> field, bool distinct = false)
            => new NullableMaximumFunctionExpression<byte?>((field.GetType(), field), distinct);

        public static MaximumFunctionExpression<short> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, short> field, bool distinct = false)
            => new MaximumFunctionExpression<short>((field.GetType(), field), distinct);

        public static NullableMaximumFunctionExpression<short?> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, short?> field, bool distinct = false)
            => new NullableMaximumFunctionExpression<short?>((field.GetType(), field), distinct);

        public static MaximumFunctionExpression<int> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, int> field, bool distinct = false)
            => new MaximumFunctionExpression<int>((field.GetType(), field), distinct);

        public static NullableMaximumFunctionExpression<int?> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, int?> field, bool distinct = false)
            => new NullableMaximumFunctionExpression<int?>((field.GetType(), field), distinct);

        public static MaximumFunctionExpression<long> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, long> field, bool distinct = false)
            => new MaximumFunctionExpression<long>((field.GetType(), field), distinct);

        public static NullableMaximumFunctionExpression<long?> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, long?> field, bool distinct = false)
            => new NullableMaximumFunctionExpression<long?>((field.GetType(), field), distinct);

        public static MaximumFunctionExpression<float> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, float> field, bool distinct = false)
            => new MaximumFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullableMaximumFunctionExpression<float?> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, float?> field, bool distinct = false)
            => new NullableMaximumFunctionExpression<float?>((field.GetType(), field), distinct);

        public static MaximumFunctionExpression<double> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, double> field, bool distinct = false)
            => new MaximumFunctionExpression<double>((field.GetType(), field), distinct);

        public static NullableMaximumFunctionExpression<double?> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, double?> field, bool distinct = false)
            => new NullableMaximumFunctionExpression<double?>((field.GetType(), field), distinct);

        public static MaximumFunctionExpression<decimal> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, decimal> field, bool distinct = false)
            => new MaximumFunctionExpression<decimal>((field.GetType(), field), distinct);

        public static NullableMaximumFunctionExpression<decimal?> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, decimal?> field, bool distinct = false)
            => new NullableMaximumFunctionExpression<decimal?>((field.GetType(), field), distinct);

        public static MaximumFunctionExpression<DateTime> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, DateTime> field, bool distinct = false)
            => new MaximumFunctionExpression<DateTime>((field.GetType(), field), distinct);

        public static NullableMaximumFunctionExpression<DateTime?> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, DateTime?> field, bool distinct = false)
            => new NullableMaximumFunctionExpression<DateTime?>((field.GetType(), field), distinct);

        public static MaximumFunctionExpression<DateTimeOffset> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, DateTimeOffset> field, bool distinct = false)
            => new MaximumFunctionExpression<DateTimeOffset>((field.GetType(), field), distinct);

        public static NullableMaximumFunctionExpression<DateTimeOffset?> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, DateTimeOffset?> field, bool distinct = false)
            => new NullableMaximumFunctionExpression<DateTimeOffset?>((field.GetType(), field), distinct);

        public static MaximumFunctionExpression<Guid> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, Guid> field, bool distinct = false)
            => new MaximumFunctionExpression<Guid>((field.GetType(), field), distinct);

        public static NullableMaximumFunctionExpression<Guid?> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, Guid?> field, bool distinct = false)
            => new NullableMaximumFunctionExpression<Guid?>((field.GetType(), field), distinct);

        public static MaximumFunctionExpression<string> Max(ISupportedForFunctionExpression<MaximumFunctionExpression, string> field, bool distinct = false)
            => new MaximumFunctionExpression<string>((field.GetType(), field), distinct);
        #endregion

        #region count
        public static CountFunctionExpression<int> Count()
            => new CountFunctionExpression<int>();

        public static CountFunctionExpression<int> Count(ISupportedForFunctionExpression<CountFunctionExpression> field, bool distinct = false)
            => new CountFunctionExpression<int>((field.GetType(), field), distinct);

        //public static CountFunctionExpression<int> Count(ISupportedForFunctionExpression<CountFunctionExpression, bool> field, bool distinct = false)
        //    => new CountFunctionExpression<int>(field, distinct);

        //public static CountFunctionExpression<int> Count(ISupportedForFunctionExpression<CountFunctionExpression, byte> field, bool distinct = false)
        //    => new CountFunctionExpression<int>(field, distinct);

        //public static CountFunctionExpression<int> Count(ISupportedForFunctionExpression<CountFunctionExpression, DateTime> field, bool distinct = false)
        //    => new CountFunctionExpression<int>(field, distinct);

        //public static CountFunctionExpression<int> Count(ISupportedForFunctionExpression<CountFunctionExpression, decimal> field, bool distinct = false)
        //    => new CountFunctionExpression<int>(field, distinct);

        //public static CountFunctionExpression<int> Count(ISupportedForFunctionExpression<CountFunctionExpression, double> field, bool distinct = false)
        //    => new CountFunctionExpression<int>(field, distinct);

        //public static CountFunctionExpression<int> Count(ISupportedForFunctionExpression<CountFunctionExpression, Enum> field, bool distinct = false)
        //    => new CountFunctionExpression<int>(field, distinct);

        //public static CountFunctionExpression<int> Count(ISupportedForFunctionExpression<CountFunctionExpression, Guid> field, bool distinct = false)
        //    => new CountFunctionExpression<int>(field, distinct);

        //public static CountFunctionExpression<int> Count(ISupportedForFunctionExpression<CountFunctionExpression, short> field, bool distinct = false)
        //    => new CountFunctionExpression<int>(field, distinct);

        //public static CountFunctionExpression<int> Count(ISupportedForFunctionExpression<CountFunctionExpression, int> field, bool distinct = false)
        //    => new CountFunctionExpression<int>(field, distinct);

        //public static CountFunctionExpression<int> Count(ISupportedForFunctionExpression<CountFunctionExpression, long> field, bool distinct = false)
        //    => new CountFunctionExpression<int>(field, distinct);
        #endregion

        #region sum
        public static SumFunctionExpression<int> Sum(ISupportedForFunctionExpression<SumFunctionExpression, byte> field, bool distinct = false)
            => new SumFunctionExpression<int>((field.GetType(), field), distinct);

        public static NullableSumFunctionExpression<int?> Sum(ISupportedForFunctionExpression<SumFunctionExpression, byte?> field, bool distinct = false)
            => new NullableSumFunctionExpression<int?>((field.GetType(), field), distinct);

        public static SumFunctionExpression<int> Sum(ISupportedForFunctionExpression<SumFunctionExpression, short> field, bool distinct = false)
            => new SumFunctionExpression<int>((field.GetType(), field), distinct);

        public static NullableSumFunctionExpression<int?> Sum(ISupportedForFunctionExpression<SumFunctionExpression, short?> field, bool distinct = false)
            => new NullableSumFunctionExpression<int?>((field.GetType(), field), distinct);

        public static SumFunctionExpression<int> Sum(ISupportedForFunctionExpression<SumFunctionExpression, int> field, bool distinct = false)
            => new SumFunctionExpression<int>((field.GetType(), field), distinct);

        public static NullableSumFunctionExpression<int?> Sum(ISupportedForFunctionExpression<SumFunctionExpression, int?> field, bool distinct = false)
            => new NullableSumFunctionExpression<int?>((field.GetType(), field), distinct);

        public static SumFunctionExpression<long> Sum(ISupportedForFunctionExpression<SumFunctionExpression, long> field, bool distinct = false)
            => new SumFunctionExpression<long>((field.GetType(), field), distinct);

        public static NullableSumFunctionExpression<long?> Sum(ISupportedForFunctionExpression<SumFunctionExpression, long?> field, bool distinct = false)
            => new NullableSumFunctionExpression<long?>((field.GetType(), field), distinct);

        public static SumFunctionExpression<double> Sum(ISupportedForFunctionExpression<SumFunctionExpression, double> field, bool distinct = false)
            => new SumFunctionExpression<double>((field.GetType(), field), distinct);

        public static NullableSumFunctionExpression<double?> Sum(ISupportedForFunctionExpression<SumFunctionExpression, double?> field, bool distinct = false)
            => new NullableSumFunctionExpression<double?>((field.GetType(), field), distinct);

        public static SumFunctionExpression<decimal> Sum(ISupportedForFunctionExpression<SumFunctionExpression, decimal> field, bool distinct = false)
            => new SumFunctionExpression<decimal>((field.GetType(), field), distinct);

        public static NullableSumFunctionExpression<decimal?> Sum(ISupportedForFunctionExpression<SumFunctionExpression, decimal?> field, bool distinct = false)
            => new NullableSumFunctionExpression<decimal?>((field.GetType(), field), distinct);

        public static SumFunctionExpression<float> Sum(ISupportedForFunctionExpression<SumFunctionExpression, float> field, bool distinct = false)
            => new SumFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullableSumFunctionExpression<float?> Sum(ISupportedForFunctionExpression<SumFunctionExpression, float?> field, bool distinct = false)
            => new NullableSumFunctionExpression<float?>((field.GetType(), field), distinct);
        #endregion

        #region standard deviation
        public static StandardDeviationFunctionExpression<float> StDev(ISupportedForFunctionExpression<StandardDeviationFunctionExpression, byte> field, bool distinct = false)
            => new StandardDeviationFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullableStandardDeviationFunctionExpression<float?> StDev(ISupportedForFunctionExpression<StandardDeviationFunctionExpression, byte?> field, bool distinct = false)
            => new NullableStandardDeviationFunctionExpression<float?>((field.GetType(), field), distinct);

        public static StandardDeviationFunctionExpression<float> StDev(ISupportedForFunctionExpression<StandardDeviationFunctionExpression, short> field, bool distinct = false)
            => new StandardDeviationFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullableStandardDeviationFunctionExpression<float?> StDev(ISupportedForFunctionExpression<StandardDeviationFunctionExpression, short?> field, bool distinct = false)
            => new NullableStandardDeviationFunctionExpression<float?>((field.GetType(), field), distinct);

        public static StandardDeviationFunctionExpression<float> StDev(ISupportedForFunctionExpression<StandardDeviationFunctionExpression, int> field, bool distinct = false)
            => new StandardDeviationFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullableStandardDeviationFunctionExpression<float?> StDev(ISupportedForFunctionExpression<StandardDeviationFunctionExpression, int?> field, bool distinct = false)
            => new NullableStandardDeviationFunctionExpression<float?>((field.GetType(), field), distinct);

        public static StandardDeviationFunctionExpression<float> StDev(ISupportedForFunctionExpression<StandardDeviationFunctionExpression, long> field, bool distinct = false)
            => new StandardDeviationFunctionExpression<float>((field.GetType(), field), distinct);

        public static StandardDeviationFunctionExpression<float?> StDev(ISupportedForFunctionExpression<StandardDeviationFunctionExpression, long?> field, bool distinct = false)
            => new StandardDeviationFunctionExpression<float?>((field.GetType(), field), distinct);

        public static StandardDeviationFunctionExpression<float> StDev(ISupportedForFunctionExpression<StandardDeviationFunctionExpression, double> field, bool distinct = false)
            => new StandardDeviationFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullableStandardDeviationFunctionExpression<float?> StDev(ISupportedForFunctionExpression<StandardDeviationFunctionExpression, double?> field, bool distinct = false)
            => new NullableStandardDeviationFunctionExpression<float?>((field.GetType(), field), distinct);

        public static StandardDeviationFunctionExpression<float> StDev(ISupportedForFunctionExpression<StandardDeviationFunctionExpression, decimal> field, bool distinct = false)
            => new StandardDeviationFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullableStandardDeviationFunctionExpression<float?> StDev(ISupportedForFunctionExpression<StandardDeviationFunctionExpression, decimal?> field, bool distinct = false)
            => new NullableStandardDeviationFunctionExpression<float?>((field.GetType(), field), distinct);

        public static StandardDeviationFunctionExpression<float> StDev(ISupportedForFunctionExpression<StandardDeviationFunctionExpression, float> field, bool distinct = false)
            => new StandardDeviationFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullableStandardDeviationFunctionExpression<float?> StDev(ISupportedForFunctionExpression<StandardDeviationFunctionExpression, float?> field, bool distinct = false)
            => new NullableStandardDeviationFunctionExpression<float?>((field.GetType(), field), distinct);
        #endregion

        #region standard deviation p
        public static PopulationStandardDeviationFunctionExpression<float> StDevP(ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, byte> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullablePopulationStandardDeviationFunctionExpression<float?> StDevP(ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, byte?> field, bool distinct = false)
            => new NullablePopulationStandardDeviationFunctionExpression<float?>((field.GetType(), field), distinct);

        public static PopulationStandardDeviationFunctionExpression<float> StDevP(ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, short> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullablePopulationStandardDeviationFunctionExpression<float?> StDevP(ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, short?> field, bool distinct = false)
            => new NullablePopulationStandardDeviationFunctionExpression<float?>((field.GetType(), field), distinct);

        public static PopulationStandardDeviationFunctionExpression<float> StDevP(ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, int> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullablePopulationStandardDeviationFunctionExpression<float?> StDevP(ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, int?> field, bool distinct = false)
            => new NullablePopulationStandardDeviationFunctionExpression<float?>((field.GetType(), field), distinct);

        public static PopulationStandardDeviationFunctionExpression<float> StDevP(ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, long> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullablePopulationStandardDeviationFunctionExpression<float?> StDevP(ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, long?> field, bool distinct = false)
            => new NullablePopulationStandardDeviationFunctionExpression<float?>((field.GetType(), field), distinct);

        public static PopulationStandardDeviationFunctionExpression<float> StDevP(ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, double> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullablePopulationStandardDeviationFunctionExpression<float?> StDevP(ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, double?> field, bool distinct = false)
            => new NullablePopulationStandardDeviationFunctionExpression<float?>((field.GetType(), field), distinct);

        public static PopulationStandardDeviationFunctionExpression<float> StDevP(ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, decimal> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullablePopulationStandardDeviationFunctionExpression<float?> StDevP(ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, decimal?> field, bool distinct = false)
            => new NullablePopulationStandardDeviationFunctionExpression<float?>((field.GetType(), field), distinct);

        public static PopulationStandardDeviationFunctionExpression<float> StDevP(ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, float> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullablePopulationStandardDeviationFunctionExpression<float?> StDevP(ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, float?> field, bool distinct = false)
            => new NullablePopulationStandardDeviationFunctionExpression<float?>((field.GetType(), field), distinct);
        #endregion

        #region variance
        public static VarianceFunctionExpression<float> Var(ISupportedForFunctionExpression<VarianceFunctionExpression, byte> field, bool distinct = false)
            => new VarianceFunctionExpression<float>((field.GetType(), field), distinct);

        public static VarianceFunctionExpression<float> Var(ISupportedForFunctionExpression<VarianceFunctionExpression, short> field, bool distinct = false)
            => new VarianceFunctionExpression<float>((field.GetType(), field), distinct);

        public static VarianceFunctionExpression<float> Var(ISupportedForFunctionExpression<VarianceFunctionExpression, int> field, bool distinct = false)
            => new VarianceFunctionExpression<float>((field.GetType(), field), distinct);

        public static VarianceFunctionExpression<float> Var(ISupportedForFunctionExpression<VarianceFunctionExpression, long> field, bool distinct = false)
            => new VarianceFunctionExpression<float>((field.GetType(), field), distinct);

        public static VarianceFunctionExpression<float> Var(ISupportedForFunctionExpression<VarianceFunctionExpression, float> field, bool distinct = false)
            => new VarianceFunctionExpression<float>((field.GetType(), field), distinct);

        public static VarianceFunctionExpression<float> Var(ISupportedForFunctionExpression<VarianceFunctionExpression, double> field, bool distinct = false)
            => new VarianceFunctionExpression<float>((field.GetType(), field), distinct);

        public static VarianceFunctionExpression<float> Var(ISupportedForFunctionExpression<VarianceFunctionExpression, decimal> field, bool distinct = false)
            => new VarianceFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullableVarianceFunctionExpression<float?> Var(ISupportedForFunctionExpression<VarianceFunctionExpression, byte?> field, bool distinct = false)
           => new NullableVarianceFunctionExpression<float?>((field.GetType(), field), distinct);

        public static NullableVarianceFunctionExpression<float?> Var(ISupportedForFunctionExpression<VarianceFunctionExpression, short?> field, bool distinct = false)
            => new NullableVarianceFunctionExpression<float?>((field.GetType(), field), distinct);

        public static NullableVarianceFunctionExpression<float?> Var(ISupportedForFunctionExpression<VarianceFunctionExpression, int?> field, bool distinct = false)
            => new NullableVarianceFunctionExpression<float?>((field.GetType(), field), distinct);

        public static NullableVarianceFunctionExpression<float?> Var(ISupportedForFunctionExpression<VarianceFunctionExpression, long?> field, bool distinct = false)
            => new NullableVarianceFunctionExpression<float?>((field.GetType(), field), distinct);

        public static NullableVarianceFunctionExpression<float?> Var(ISupportedForFunctionExpression<VarianceFunctionExpression, float?> field, bool distinct = false)
            => new NullableVarianceFunctionExpression<float?>((field.GetType(), field), distinct);

        public static NullableVarianceFunctionExpression<float?> Var(ISupportedForFunctionExpression<VarianceFunctionExpression, double?> field, bool distinct = false)
            => new NullableVarianceFunctionExpression<float?>((field.GetType(), field), distinct);

        public static NullableVarianceFunctionExpression<float?> Var(ISupportedForFunctionExpression<VarianceFunctionExpression, decimal?> field, bool distinct = false)
            => new NullableVarianceFunctionExpression<float?>((field.GetType(), field), distinct);
        #endregion

        #region variance p
        public static PopulationVarianceFunctionExpression<float> VarP(ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, byte> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullablePopulationVarianceFunctionExpression<float?> VarP(ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, byte?> field, bool distinct = false)
            => new NullablePopulationVarianceFunctionExpression<float?>((field.GetType(), field), distinct);

        public static PopulationVarianceFunctionExpression<float> VarP(ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, short> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullablePopulationVarianceFunctionExpression<float?> VarP(ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, short?> field, bool distinct = false)
            => new NullablePopulationVarianceFunctionExpression<float?>((field.GetType(), field), distinct);

        public static PopulationVarianceFunctionExpression<float> VarP(ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, int> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullablePopulationVarianceFunctionExpression<float?> VarP(ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, int?> field, bool distinct = false)
            => new NullablePopulationVarianceFunctionExpression<float?>((field.GetType(), field), distinct);

        public static PopulationVarianceFunctionExpression<float> VarP(ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, long> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullablePopulationVarianceFunctionExpression<float?> VarP(ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, long?> field, bool distinct = false)
            => new NullablePopulationVarianceFunctionExpression<float?>((field.GetType(), field), distinct);

        public static PopulationVarianceFunctionExpression<float> VarP(ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, double> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullablePopulationVarianceFunctionExpression<float?> VarP(ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, double?> field, bool distinct = false)
            => new NullablePopulationVarianceFunctionExpression<float?>((field.GetType(), field), distinct);

        public static PopulationVarianceFunctionExpression<float> VarP(ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, decimal> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression<float>((field.GetType(), field), distinct);

        public static PopulationVarianceFunctionExpression<float?> VarP(ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, decimal?> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression<float?>((field.GetType(), field), distinct);

        public static PopulationVarianceFunctionExpression<float> VarP(ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, float> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression<float>((field.GetType(), field), distinct);

        public static NullablePopulationVarianceFunctionExpression<float?> VarP(ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, float?> field, bool distinct = false)
            => new NullablePopulationVarianceFunctionExpression<float?>((field.GetType(), field), distinct);
        #endregion

        #region date
        public static CurrentTimestampFunctionExpression Current_Timestamp
            => new CurrentTimestampFunctionExpression();
        #endregion
    }
}
