using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HatTrick.DbEx.Tools.Model
{
    public static class MsSqlColumnExtensions
    {
        public static string ToFriendlyName(this SqlDbType type, int maxLength, int precision, int scale)
        {
            switch (type)
            {
                case SqlDbType.Binary:
                case SqlDbType.VarBinary:
                case SqlDbType.Char:
                case SqlDbType.VarChar: return $"{type.ToString().ToLower()}({(maxLength == -1 ? "MAX" : maxLength.ToString())})";

                case SqlDbType.NChar:
                case SqlDbType.NVarChar: return $"{type.ToString().ToLower()}({(maxLength == -1 ? "MAX" : (maxLength / 2).ToString())})";

                case SqlDbType.Decimal:
                    return $"{type.ToString().ToLower()}({precision}{(scale > 0 ? $",{scale}" : string.Empty)})";

                default:
                    return type.ToString().ToLower();
            }
        }

        public static bool SupportsSize(this SqlDbType type)
        {
            switch (type)
            {
                case SqlDbType.Binary:
                case SqlDbType.Char:
                case SqlDbType.DateTime2:
                case SqlDbType.DateTimeOffset:
                case SqlDbType.VarBinary:
                case SqlDbType.VarChar:
                case SqlDbType.NChar:
                case SqlDbType.NVarChar:
                case SqlDbType.Time:
                    return true;

                default:
                    return false;
            }
        }

        public static bool SupportsPrecision(this SqlDbType type)
        {
            switch (type)
            {
                case SqlDbType.Decimal:
                    return true;

                default:
                    return false;
            }
        }
    }
}
