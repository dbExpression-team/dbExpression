using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class MsSqlVersionWithDataAttribute : ClassDataAttribute
    {
        private readonly CurrentMsSqlVersion my;
        private readonly object[] data;

        public MsSqlVersionWithDataAttribute(Type a, params object[] data) : base(typeof(MsSqlVersionWithDataAttribute))
        {
            my = (a.GetConstructor(Array.Empty<Type>())!.Invoke(Array.Empty<object>()) as CurrentMsSqlVersion)!;
            this.data = data;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            return new List<object[]> { new List<object> { my.Version }.Concat(data).ToArray() };
        }
    }
}
