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
using System.Reflection;

namespace DbExpression.Tools
{
    public static class PackageVersion
    {
        private static Assembly thisAssembly = typeof(PackageCompatibility).Assembly;
        private static Version thisVersion = typeof(PackageCompatibility).Assembly.GetName().Version!;
        private static string? _packageVersion;

        public static string VersionIdentifier => _packageVersion ??= $"{thisVersion.Major}.{thisVersion.Minor}.{thisVersion.Build}";
    }
}
