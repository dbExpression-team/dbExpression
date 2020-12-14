using HatTrick.DbEx.Sql.Expression;
using System.Data;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface NullableCast
#pragma warning restore IDE1006 // Naming Styles
    {
        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Bit"/>
        /// </summary>
        NullableBooleanCastFunctionExpression AsBit();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.TinyInt"/>
        /// </summary>
        NullableByteCastFunctionExpression AsTinyInt();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.DateTime"/>
        /// </summary>
        NullableDateTimeCastFunctionExpression AsDateTime();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.DateTimeOffset"/>
        /// </summary>
        NullableDateTimeOffsetCastFunctionExpression AsDateTimeOffset();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Decimal"/>
        /// </summary>
        NullableDecimalCastFunctionExpression AsDecimal(int precision, int scale);

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Float"/>
        /// </summary>
        NullableSingleCastFunctionExpression AsFloat();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.UniqueIdentifier"/>
        /// </summary>
        NullableGuidCastFunctionExpression AsUniqueIdentifier();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.SmallInt"/>
        /// </summary>
        NullableInt16CastFunctionExpression AsSmallInt();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Int"/>
        /// </summary>
        NullableInt32CastFunctionExpression AsInt();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.BigInt"/>
        /// </summary>
        NullableInt64CastFunctionExpression AsBigInt();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.VarChar"/>
        /// </summary>
        StringCastFunctionExpression AsVarChar(int size);

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Char"/>
        /// </summary>
        StringCastFunctionExpression AsChar(int size);

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.NVarChar"/>
        /// </summary>
        StringCastFunctionExpression AsNVarChar(int size);

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.NChar"/>
        /// </summary>
        StringCastFunctionExpression AsNChar(int size);

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Time"/>
        /// </summary>
        NullableTimeSpanCastFunctionExpression AsTime();
    }
}
