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
            private static readonly IEnumerable<object[]> allVersions = new List<object[]> { new object[] { 2012 }, new object[] { 2014 } };

            public AllVersionsAttribute() : base(typeof(MsSqlVersions))
            {
            }

            /// <inheritdoc/>
            public override IEnumerable<object[]> GetData(MethodInfo testMethod)
                => allVersions;
        }

        [SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "Helper class to simplify specification of target Sql Server version for tests.")]
        public sealed class SpecificVersionsAttribute : ClassDataAttribute
        {
            private readonly IEnumerable<object[]> versions;

            public SpecificVersionsAttribute(params int[] versions) : base(typeof(MsSqlVersions))
            {
                this.versions = versions.Select(v => new object[] { v });
            }

            /// <inheritdoc/>
            public override IEnumerable<object[]> GetData(MethodInfo testMethod)
                => versions;
        }
    }
}
