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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HatTrick.DbEx.Tools
{
    public static class PackageCompatibility
    {
        #region internals
        private static Assembly thisAssembly = typeof(PackageCompatibility).Assembly;
        private static Version thisVersion = typeof(PackageCompatibility).Assembly.GetName().Version!;
        private static VersionCompatibilityData? _data;
        private static List<SupportedPlatform> _supportedPlatforms = new List<SupportedPlatform>(Enum.GetValues<SupportedPlatform>());
        private static Dictionary<SupportedPlatform, IList<Version>>? _versions;
        #endregion

        #region methods
        public static IList<string> GetCompatibleTemplateVersions(SupportedPlatform platform)
            => GetVersionCompatibilityData().Versions
                .Select(v => v.Platforms)
                .Where(p => p.SingleOrDefault(x => x.Key == platform) is not null)
                .SelectMany(x => x.SelectMany(c => c.Compatibility))
                .Distinct()
                .OrderBy(v => v)
                .ToList();

        public static Dictionary<SupportedPlatform, IList<Version>> GetPlatformCompatibility()
        { 
            if (_versions is not null)
                return _versions;

            _versions = new Dictionary<SupportedPlatform, IList<Version>>();

            var versions = GetVersionCompatibilityData();

            foreach (var supportedPlatform in _supportedPlatforms)
            {
                var w = versions!.Versions.Single(x => x.Version == PackageVersion.VersionIdentifier);
                var x = w.Platforms.Single(x => x.Key == supportedPlatform);
                var y = x.Compatibility.Select(x => new Version(x)).ToList();

                if (!_versions.TryAdd(
                        supportedPlatform,
                        versions!.Versions.Single(x => x.Version == PackageVersion.VersionIdentifier)
                            .Platforms.Single(x => x.Key == supportedPlatform)
                            .Compatibility.Select(x => new Version(x)).ToList()
                        )
                ) throw new NotImplementedException($"The supported platform '{supportedPlatform}' or the current tool version '{thisVersion}' does not have an entry in the compatibility matrix (HatTrick.DbEx.Tools.Resources.VersionCompatibility.json).");
            }
            
            return _versions;
        }

        public static VersionCompatibilityData GetVersionCompatibilityData()
        {
            if (_data is not null)
                return _data;

            string? versionList = null;
            using Stream stream = thisAssembly.GetManifestResourceStream("HatTrick.DbEx.Tools.Resources.PackageCompatibility.json")!;
            using StreamReader reader = new(stream);
            versionList = reader.ReadToEnd();

            _data = JsonSerializer.Deserialize<VersionCompatibilityData>(
                        versionList,
                        new JsonSerializerOptions
                        {
                            ReadCommentHandling = JsonCommentHandling.Skip,
                            PropertyNameCaseInsensitive = true,
                            Converters = { new JsonStringEnumConverter() }
                        }
                    ) ?? new VersionCompatibilityData();

            return _data;
        }
        #endregion

        #region classes
        public class VersionCompatibilityData
        {
            public IList<VersionData> Versions { get; set; } = new List<VersionData>();

            public class VersionData
            {
                public string? Version { get; set; }
                public IList<SupportedPlatformsData> Platforms { get; set; } = new List<SupportedPlatformsData>();
            }

            public class SupportedPlatformsData
            {
                public SupportedPlatform Key { get; set; }
                public IList<string> Compatibility { get; set; } = new List<string>();
            }
        }
        #endregion
    }
}
