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

using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Converter
{
    internal static class ValueConverterExtensions
    {
        public static bool TryFindConverterFor(this IEnumerable<IValueConverter> converters, Type converterTarget, out IValueConverter? converter)
        {
            converter = null;
            try
            {
                foreach (var a in converters)
                    if (IsConverterFor(a, converterTarget))
                    {
                        converter = a;
                        return true;
                    }
            }
            catch (Exception) { }
            return false;
        }

        private static bool IsConverterFor(IValueConverter converter, Type converterTarget)
        {
            return IsConverterFor(converter.GetType().GetInterfaces(), converterTarget);
        }

        private static bool IsConverterFor(Type[] interfaces, Type converterTarget)
        {
            var typedConverter = typeof(IValueConverter<>).MakeGenericType(new Type[] { converterTarget });
            if (interfaces.FirstOrDefault(x => x == typedConverter) is not null)
                return true;
            if (converterTarget.BaseType != typeof(object) && converterTarget.BaseType is not null && !converterTarget.IsEnum)
                return IsConverterFor(interfaces, converterTarget.BaseType);
            return false;
        }
    }
}
