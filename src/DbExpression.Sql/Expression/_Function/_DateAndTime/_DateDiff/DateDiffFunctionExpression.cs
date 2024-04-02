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

﻿using System;
using System.Collections.Generic;

namespace DbExpression.Sql.Expression
{
    public abstract class DateDiffFunctionExpression : DateAndTimeFunctionExpression,
        IExpressionListProvider<IExpressionElement>,
        IExpressionProvider<DatePartsExpression>,
        IEquatable<DateDiffFunctionExpression>
    {
        #region internals
        private readonly IExpressionElement startDate;
        private readonly IExpressionElement endDate;
        private readonly DatePartsExpression datePart;
        #endregion

        #region interface
        IEnumerable<IExpressionElement> IExpressionListProvider<IExpressionElement>.Expressions => new List<IExpressionElement>() { startDate, endDate };
        DatePartsExpression IExpressionProvider<DatePartsExpression>.Expression => datePart;
        #endregion

        #region constructors
        protected DateDiffFunctionExpression(DatePartsExpression datePart, IExpressionElement startDate, IExpressionElement endDate, Type convertToType)
            : base(convertToType)
        {
            this.datePart = datePart ?? throw new ArgumentNullException(nameof(datePart));
            this.startDate = startDate ?? throw new ArgumentNullException(nameof(startDate));
            this.endDate = endDate ?? throw new ArgumentNullException(nameof(endDate));
        }
        #endregion

        #region to string
        public override string? ToString() => $"DATEDIFF({datePart.ToString()?.ToLower()}, {startDate}, {endDate})";
        #endregion

        #region equals
        public bool Equals(DateDiffFunctionExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (startDate is null && obj.startDate is not null) return false;
            if (startDate is not null && obj.startDate is null) return false;
            if (startDate is not null && !startDate.Equals(obj.startDate)) return false;

            if (endDate is null && obj.endDate is not null) return false;
            if (endDate is not null && obj.endDate is null) return false;
            if (endDate is not null && !endDate.Equals(obj.endDate)) return false;

            if (datePart is null && obj.datePart is not null) return false;
            if (datePart is not null && obj.datePart is null) return false;
            if (datePart is not null && !datePart.Equals(obj.datePart)) return false;

            return true;
        }

        public override bool Equals(object? obj)
         => obj is DateDiffFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int multiplier = 16777619;

                int hash = base.GetHashCode();
                hash = (hash * multiplier) ^ (startDate is not null ? startDate.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (endDate is not null ? endDate.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (datePart is not null ? datePart.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
