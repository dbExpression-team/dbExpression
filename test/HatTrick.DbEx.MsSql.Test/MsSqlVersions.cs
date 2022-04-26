using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test
{
    /// <summary>
    /// Attributes for xUnit tests to enable testing against specific versions of MS Sql Server.  The supplied set of versions is compared against
    /// the version provided through configuration, only the current configured version will be returned in the test data.  For example, if 2019 is
    /// configured, AllVersionsAttribute will return an array with 2019 as the only value.
    /// </summary>
    /// <remarks>xUnit will fail (and subsequently the target test will fail) if the implemented method in the attribute class returns an empty enumerable.  
    /// As such, an attribute that enables a test to be run against a specific version of MS Sql Server should not be implemented; if a configured version 
    /// is set and that is NOT the specific version requested, the returning enumerable would be empty.</remarks>
    public static class MsSqlVersions
    {
        [SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "Helper class to simplify specification of use of all Sql Server versions for tests.")]
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
        public sealed class AllVersionsAttribute : ClassDataAttribute
        {
            public AllVersionsAttribute() : base(typeof(MsSqlVersions))
            {
            }

            /// <inheritdoc/>
            public override IEnumerable<object[]> GetData(MethodInfo testMethod)
                => new List<object[]> { new object[] { new CurrentMsSqlVersion().Version } };
        }

        [SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "Helper class to simplify specification of target Sql Server version for tests.")]
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
        public sealed class AllVersionsExceptAttribute : ClassDataAttribute
        {
            private readonly IList<int> versions;

            public AllVersionsExceptAttribute(int version) : base(typeof(MsSqlVersions))
            {
                this.versions = new List<int>(version);
            }

            public AllVersionsExceptAttribute(params int[] versions) : base(typeof(MsSqlVersions))
            {
                this.versions = versions;
            }

            /// <inheritdoc/>
            public override IEnumerable<object[]> GetData(MethodInfo testMethod)
            {
                var config = ConfigurationProvider.MsSqlVersion;
                return config.HasValue && !versions.Contains(config.Value) ?
                    new List<object[]> { new object[] { config.Value } }
                    : Enumerable.Empty<object[]>();
            }
        }
    }
}
