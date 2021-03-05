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

namespace HatTrick.DbEx.Sql
{
    public static class TypeExtensions
    { 
        public static bool IsNullableType(this Type t) => (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        public static Type EnsureUnderlyingType(this Type t) => t.IsNullableType() ? Nullable.GetUnderlyingType(t) : t;        
        public static Type GetUnderlyingEnumType(this Type t)
        {
            //ensure underlying to ensure we dont have a nullable..
            Type underlying = t.EnsureUnderlyingType();

            if (!underlying.IsEnum) { return null; }

            //return the integral base of this enum...
            return Enum.GetUnderlyingType(underlying);
        }
    }
}
