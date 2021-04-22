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

﻿using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DateDiffFunctionExpression : ConversionFunctionExpression,
        IEquatable<DateDiffFunctionExpression>
    {
        #region interface
        public DatePartsExpression DatePart { get; private set; }
        public IExpressionElement StartDate => base.Expression;
        public IExpressionElement EndDate { get; private set; }
        #endregion

        #region constructors
        protected DateDiffFunctionExpression(DatePartsExpression datePart, IExpressionElement startDate, IExpressionElement endDate, Type convertToType)
            : base(startDate, convertToType)
        {
            DatePart = datePart ?? throw new ArgumentNullException(nameof(datePart));
            EndDate = endDate ?? throw new ArgumentNullException(nameof(endDate));
        }
        #endregion

        #region to string
        public override string ToString() => $"DATEDIFF({DatePart.ToString().ToLower()}, {StartDate}, {EndDate})";
        #endregion

        #region equals
        public bool Equals(DateDiffFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;

            if (StartDate is null && obj.StartDate is object) return false;
            if (StartDate is object && obj.StartDate is null) return false;
            if (!StartDate.Equals(obj.StartDate)) return false;

            if (EndDate is null && obj.EndDate is object) return false;
            if (EndDate is object && obj.EndDate is null) return false;
            if (!EndDate.Equals(obj.EndDate)) return false;

            if (DatePart is null && obj.DatePart is object) return false;
            if (DatePart is object && obj.DatePart is null) return false;
            if (!DatePart.Equals(obj.DatePart)) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is DateDiffFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int multiplier = 16777619;

                int hash = base.GetHashCode();
                hash = (hash * multiplier) ^ (StartDate is object ? StartDate.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (EndDate is object ? EndDate.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (DatePart is object ? DatePart.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
