#region license
// Copyright (c) dbExpression.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

using System;

namespace DbExpression.Sql
{
    public class SqlParameterMetadata :
        ISqlParameterMetadata,
        IEquatable<SqlParameterMetadata>
    {
        public string Name { get; private set; }
        public object DbType { get; private set; }
        public int? Size { get; private set; }
        public byte? Precision { get; private set; }
        public byte? Scale { get; private set; }

        public SqlParameterMetadata(string name, object dbType)
        {
            Name = name;
            DbType = dbType;
        }

        public SqlParameterMetadata(string name, object dbType, int size)
        {
            Name = name;
            DbType = dbType;
            Size = size;
        }

        public SqlParameterMetadata(string name, object dbType, byte precision, byte scale)
        {
            Name = name;
            DbType = dbType;
            Precision = precision;
            Scale = scale;
        }

        #region equals
        public bool Equals(SqlParameterMetadata? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!StringComparer.Ordinal.Equals(Name, obj.Name)) return false;

            if (DbType is null && obj.DbType is not null) return false;
            if (DbType is not null && obj.DbType is null) return false;
            if (DbType is not null && !DbType.Equals(obj.DbType)) return false;

            if (Size is null && obj.Size is not null) return false;
            if (Size is not null && obj.Size is null) return false;
            if (Size is not null && !Size.Equals(obj.Size)) return false;

            if (Precision is null && obj.Precision is not null) return false;
            if (Precision is not null && obj.Precision is null) return false;
            if (Precision is not null && !Precision.Equals(obj.Precision)) return false;

            if (Scale is null && obj.Scale is not null) return false;
            if (Scale is not null && obj.Scale is null) return false;
            if (Scale is not null && !Scale.Equals(obj.Scale)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is SqlParameterMetadata exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (Name is not null ? Name.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (DbType is not null ? DbType.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (Size is not null ? Size.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (Precision is not null ? Precision.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (Scale is not null ? Scale.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
