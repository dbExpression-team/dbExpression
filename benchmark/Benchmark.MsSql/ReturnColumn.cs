using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System;
using System.Linq;

namespace HatTrick.DbEx.MsSql.Benchmark
{
    /// <summary>
    /// Column specifying the ORM being tested.  This class was inspired from Dapper (https://github.com/DapperLib/Dapper/blob/main/benchmarks/Dapper.Tests.Performance/Helpers/ReturnColum.cs)
    /// </summary>
    public class ReturnColum : IColumn
    {
        public string Id => nameof(ReturnColum);
        public string ColumnName { get; } = "Return";
        public string Legend => "The return type of the method";

        public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;
        public string GetValue(Summary summary, BenchmarkCase benchmarkCase)
        {
            var type = benchmarkCase.Descriptor.WorkloadMethod.ReturnType;
            if (type == typeof(object)) 
                return "dynamic";
            if (type.Name.Contains("`"))
            {
                return GetDisplayName(type);
            }
            return type.Name;
        }

        public string GetValue(Summary summary, BenchmarkCase benchmarkCase, SummaryStyle style) => GetValue(summary, benchmarkCase);

        public bool IsAvailable(Summary summary) => true;
        public bool AlwaysShow => true;
        public ColumnCategory Category => ColumnCategory.Job;
        public int PriorityInCategory => 1;
        public bool IsNumeric => false;
        public UnitType UnitType => UnitType.Dimensionless;
        public override string ToString() => ColumnName;

        private static string GetDisplayName(Type t)
        {
            return GetDisplayName(t, string.Empty);
        }

        private static string GetDisplayName(Type t, string seed)
        {
            if (t.Name == "Object")
                return string.Concat(seed, "dynamic");
            var take = t.Name.IndexOf('`') > 0 ? t.Name.IndexOf('`') : t.Name.Length;
            seed = string.Concat(seed, t.Name.Substring(0, take));

            if (t.IsGenericType)
            {
                seed = string.Concat(seed, $"<");
                for (var i = 0; i < t.GetGenericArguments().Count(); i++)
                {
                    seed = string.Concat(seed, $"{GetDisplayName(t.GetGenericArguments()[i])}");
                    if (i < t.GetGenericArguments().Count() - 1)
                        seed = string.Concat(seed, ",");
                }
                seed = string.Concat(seed, $">");
            }

            return seed;
        }
    }
}