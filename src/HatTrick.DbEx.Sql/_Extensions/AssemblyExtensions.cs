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
using System.Reflection;
using System.Text;

namespace HatTrick.DbEx.Sql
{
    public static class AssemblyExtensions
    {
        private static char[] valid = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public static string? GetPackageVersionFromInformationalVersionAttribute(this Assembly assembly)
        {
            var attributeValue = ((AssemblyInformationalVersionAttribute?)assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute)).FirstOrDefault())?.InformationalVersion;
            if (attributeValue is null)
                return attributeValue;

            var last = attributeValue.LastIndexOf('.');
            var version = attributeValue
                .Take(++last)
                .Concat(attributeValue.Skip(last).TakeWhile(c => valid.Contains(c)))
                .ToArray();

            return version.Any() ? new string(version) : null;
        }

        public static bool TryGetPackageVersionFromInformationalVersionAttribute(this Assembly assembly, out string? packageVersion)
        {
            packageVersion = null;
            try
            {
                packageVersion = assembly.GetPackageVersionFromInformationalVersionAttribute();
                return true;
            }
            catch
            { }
            return false;
        }
    }
}
