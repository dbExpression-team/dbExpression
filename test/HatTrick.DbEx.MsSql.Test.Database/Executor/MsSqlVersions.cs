using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public class MsSqlVersions
    {
        public class AllVersionsAttribute : ClassDataAttribute
        {
            private static readonly IEnumerable<object[]> allVersions = new List<object[]> { new object[] { 2012 }, new object[] { 2014 } };

            public AllVersionsAttribute() : base(typeof(MsSqlVersions))
            {
            }

            /// <inheritdoc/>
            public override IEnumerable<object[]> GetData(MethodInfo testMethod)
                => allVersions;
        }

        public class SpecificVersionsAttribute : ClassDataAttribute
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
