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
using System.Runtime.CompilerServices;

namespace DbExpression.Sql
{
    public static class TypeExtensions
    {
        private static readonly List<Type> nonNullableTypes = new List<Type> { typeof(string), typeof(byte[]), typeof(object) };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullableType(this Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsConvertibleToNullableType(this Type t) => !nonNullableTypes.Contains(t);
    }
}
