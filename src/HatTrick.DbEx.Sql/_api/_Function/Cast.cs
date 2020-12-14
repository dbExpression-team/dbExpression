using HatTrick.DbEx.Sql.Expression;
using System.Data;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface Cast
#pragma warning restore IDE1006 // Naming Styles
    {
        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Bit"/>
        /// </summary>
        BooleanCastFunctionExpression AsBit();
        
        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.TinyInt"/>
        /// </summary>
        ByteCastFunctionExpression AsTinyInt();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.DateTime"/>
        /// </summary>
        DateTimeCastFunctionExpression AsDateTime();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.DateTimeOffset"/>
        /// </summary>
        DateTimeOffsetCastFunctionExpression AsDateTimeOffset();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Decimal"/>
        /// </summary>
        DecimalCastFunctionExpression AsDecimal(int precision, int scale);

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Float"/>
        /// </summary>
        SingleCastFunctionExpression AsFloat();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.UniqueIdentifier"/>
        /// </summary>
        GuidCastFunctionExpression AsUniqueIdentifier();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.SmallInt"/>
        /// </summary>
        Int16CastFunctionExpression AsSmallInt();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Int"/>
        /// </summary>
        Int32CastFunctionExpression AsInt();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.BigInt"/>
        /// </summary>
        Int64CastFunctionExpression AsBigInt();

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
        TimeSpanCastFunctionExpression AsTime();
    }
}
