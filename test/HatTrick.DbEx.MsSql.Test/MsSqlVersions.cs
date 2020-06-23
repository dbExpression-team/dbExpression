using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test
{
    public static class MsSqlVersions
    {
        [SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "Helper class to simplify specification of use of all Sql Server versions for tests.")]
        public sealed class AllVersionsAttribute : ClassDataAttribute
        {
            public AllVersionsAttribute() : base(typeof(MsSqlVersions))
            {
            }

            /// <inheritdoc/>
            public override IEnumerable<object[]> GetData(MethodInfo testMethod)
                => new List<object[]> { new object[] { ConfigurationProvider.MsSqlVersion ?? 2019 } };
        }

        [SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "Helper class to simplify specification of target Sql Server version for tests.")]
        public sealed class SpecificVersionsAttribute : ClassDataAttribute
        {
            private readonly IEnumerable<int> versions;

            public SpecificVersionsAttribute(params int[] versions) : base(typeof(MsSqlVersions))
            {
                this.versions = versions;
            }

            /// <inheritdoc/>
            public override IEnumerable<object[]> GetData(MethodInfo testMethod)
            {
                var version = ConfigurationProvider.MsSqlVersion;
                return version.HasValue && versions.Contains(version.Value) ? 
                    new List<object[]> { new object[] { version.Value } }
                    : Enumerable.Empty<object[]>();
            }
        }
    }
}
