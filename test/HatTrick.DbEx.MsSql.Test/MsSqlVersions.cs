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
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
        public sealed class AllVersionsAttribute : ClassDataAttribute
        {
            public AllVersionsAttribute() : base(typeof(MsSqlVersions))
            {
            }

            /// <inheritdoc/>
            public override IEnumerable<object[]> GetData(MethodInfo testMethod)
                => new List<object[]> { new object[] { ConfigurationProvider.MsSqlVersion ?? 2019 } };
        }

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
                var version = ConfigurationProvider.MsSqlVersion ?? 2019;
                return !versions.Contains(version) ?
                    new List<object[]> { new object[] { version } }
                    : Enumerable.Empty<object[]>();
            }
        }
    }
}
