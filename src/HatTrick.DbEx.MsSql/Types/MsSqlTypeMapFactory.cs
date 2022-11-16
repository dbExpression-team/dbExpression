#region license
// Copyright (c) HatTrick Labs, LLC.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/HatTrickLabs/db-ex
#endregion

﻿using HatTrick.DbEx.Sql.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HatTrick.DbEx.MsSql.Types
{
    public class MsSqlTypeMapFactory : IDbTypeMapFactory<SqlDbType>
    {
        #region 
        /// <summary>
        /// Set of maps for converting between SqlDbType, DbType, and .NET runtime types.
        /// reference: https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-data-type-mappings
        /// </summary>
        /// <remarks>Precedence in this last is important; when resolving a SqlDbType or DbType by .NET runtime type, the "first" in the list matching the .NET runtime type will be returned.</remarks>
        private static readonly List<DbTypeMap<SqlDbType>> typeMaps = new List<DbTypeMap<SqlDbType>>()
        {
            new DbTypeMap<SqlDbType>(typeof(long), DbType.Int64, SqlDbType.BigInt),
            new DbTypeMap<SqlDbType>(typeof(long?), DbType.Int64, SqlDbType.BigInt),
            new DbTypeMap<SqlDbType>(typeof(ulong), DbType.Int64, SqlDbType.BigInt),
            new DbTypeMap<SqlDbType>(typeof(ulong?), DbType.Int64, SqlDbType.BigInt),

            new DbTypeMap<SqlDbType>(typeof(byte[]), DbType.Binary, SqlDbType.Binary),
            new DbTypeMap<SqlDbType>(typeof(byte[]), DbType.Binary, SqlDbType.Image),
            new DbTypeMap<SqlDbType>(typeof(byte[]), DbType.Binary, SqlDbType.VarBinary),
            new DbTypeMap<SqlDbType>(typeof(byte[]), DbType.Binary, SqlDbType.Timestamp),
            new DbTypeMap<SqlDbType>(typeof(byte[]), DbType.Binary, SqlDbType.Udt),

            new DbTypeMap<SqlDbType>(typeof(bool), DbType.Boolean, SqlDbType.Bit),
            new DbTypeMap<SqlDbType>(typeof(bool?), DbType.Boolean, SqlDbType.Bit),            

            //new DbTypeMap<SqlDbType>(typeof(char), DbType.AnsiStringFixedLength, SqlDbType.Char),
            //new DbTypeMap<SqlDbType>(typeof(char?), DbType.AnsiStringFixedLength, SqlDbType.Char),
            new DbTypeMap<SqlDbType>(typeof(string), DbType.AnsiStringFixedLength, SqlDbType.Char), //dbExpression doesn't support Char expressions; they map to string
            new DbTypeMap<SqlDbType>(typeof(char), DbType.StringFixedLength, SqlDbType.NChar),
            new DbTypeMap<SqlDbType>(typeof(char?), DbType.StringFixedLength, SqlDbType.NChar),
            new DbTypeMap<SqlDbType>(typeof(string), DbType.AnsiString, SqlDbType.VarChar),
            new DbTypeMap<SqlDbType>(typeof(string), DbType.String, SqlDbType.NText),
            new DbTypeMap<SqlDbType>(typeof(string), DbType.String, SqlDbType.NVarChar),
            new DbTypeMap<SqlDbType>(typeof(char[]), DbType.AnsiString, SqlDbType.VarChar),  //disagrees with reference.  Reference states SqlDbType=Char, but using SqlDbType=VarChar
            
            new DbTypeMap<SqlDbType>(typeof(DateTime), DbType.DateTime, SqlDbType.DateTime),
            new DbTypeMap<SqlDbType>(typeof(DateTime?), DbType.DateTime, SqlDbType.DateTime),
            new DbTypeMap<SqlDbType>(typeof(DateTime), DbType.DateTime2, SqlDbType.DateTime2),
            new DbTypeMap<SqlDbType>(typeof(DateTime), DbType.DateTime, SqlDbType.SmallDateTime), //not listed in reference
            new DbTypeMap<SqlDbType>(typeof(DateTime), DbType.Date, SqlDbType.Date),
            
            new DbTypeMap<SqlDbType>(typeof(DateTimeOffset), DbType.DateTimeOffset, SqlDbType.DateTimeOffset),
            new DbTypeMap<SqlDbType>(typeof(DateTimeOffset?), DbType.DateTimeOffset, SqlDbType.DateTimeOffset),

            new DbTypeMap<SqlDbType>(typeof(TimeSpan), DbType.Time, SqlDbType.Time),
            new DbTypeMap<SqlDbType>(typeof(TimeSpan?), DbType.Time, SqlDbType.Time),

            new DbTypeMap<SqlDbType>(typeof(decimal), DbType.Decimal, SqlDbType.Decimal),
            new DbTypeMap<SqlDbType>(typeof(decimal?), DbType.Decimal, SqlDbType.Decimal),
            
            new DbTypeMap<SqlDbType>(typeof(double), DbType.Double, SqlDbType.Float),
            new DbTypeMap<SqlDbType>(typeof(double?), DbType.Double, SqlDbType.Float),
            new DbTypeMap<SqlDbType>(typeof(double), DbType.Currency, SqlDbType.Money), //disagrees with reference. Reference states DbType=Decimal, but using DbType=Currency
            new DbTypeMap<SqlDbType>(typeof(double), DbType.Currency, SqlDbType.SmallMoney), //disagrees with reference. Reference states DbType=Decimal, but using DbType=Currency

            new DbTypeMap<SqlDbType>(typeof(int), DbType.Int32, SqlDbType.Int),
            new DbTypeMap<SqlDbType>(typeof(int?), DbType.Int32, SqlDbType.Int),
            new DbTypeMap<SqlDbType>(typeof(uint), DbType.Int32, SqlDbType.Int),
            new DbTypeMap<SqlDbType>(typeof(uint?), DbType.Int32, SqlDbType.Int),
            
            new DbTypeMap<SqlDbType>(typeof(short), DbType.Int16, SqlDbType.SmallInt),
            new DbTypeMap<SqlDbType>(typeof(short?), DbType.Int16, SqlDbType.SmallInt),
            new DbTypeMap<SqlDbType>(typeof(ushort), DbType.Int16, SqlDbType.SmallInt),
            new DbTypeMap<SqlDbType>(typeof(ushort?), DbType.Int16, SqlDbType.SmallInt),

            new DbTypeMap<SqlDbType>(typeof(byte), DbType.Byte, SqlDbType.TinyInt),
            new DbTypeMap<SqlDbType>(typeof(byte?), DbType.Byte, SqlDbType.TinyInt),
            new DbTypeMap<SqlDbType>(typeof(sbyte), DbType.Byte, SqlDbType.TinyInt),
            new DbTypeMap<SqlDbType>(typeof(sbyte?), DbType.Byte, SqlDbType.TinyInt),
            
            new DbTypeMap<SqlDbType>(typeof(Guid), DbType.Guid, SqlDbType.UniqueIdentifier),
            new DbTypeMap<SqlDbType>(typeof(Guid?), DbType.Guid, SqlDbType.UniqueIdentifier),

            new DbTypeMap<SqlDbType>(typeof(float), DbType.Single, SqlDbType.Real),
            new DbTypeMap<SqlDbType>(typeof(float?), DbType.Single, SqlDbType.Real)
        };
        #endregion

        #region methods
        public DbTypeMap<SqlDbType>? FindByDbType(DbType dbType)
            => typeMaps.FirstOrDefault(x => x.DbType == dbType);

        public DbTypeMap<SqlDbType>? FindByPlatformType(SqlDbType dbType)
            => typeMaps.FirstOrDefault(x => x.PlatformType == dbType);

        public DbTypeMap<SqlDbType>? FindByClrType(Type clrType)
        {
            var existing = typeMaps.FirstOrDefault(x => x.ClrType == clrType);
            if (existing is object)
                return existing;

            if (clrType.IsEnum)
                return typeMaps.FirstOrDefault(x => x.ClrType == clrType.GetEnumUnderlyingType());

            return null;
        }
        #endregion
    }
}
