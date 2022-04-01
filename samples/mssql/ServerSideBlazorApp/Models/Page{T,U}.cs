using System.Collections.Generic;
using System;

namespace ServerSideBlazorApp.Models
{
    public class Page<T,U>
        where U : PagingParameters, new()
    {
        public U PagingParameters { get; set; }
        public IList<T> Data { get; set; } = new List<T>();
        public int? TotalCount { get; set; }

        public Page(U parameters, IList<T> page, int totalCount)
        {
            PagingParameters = parameters;
            Data = page;
            TotalCount = totalCount;
        }

        public static Page<T,U> CreateDefault()
            => new(new U { Offset = 0, Limit = 10 }, new List<T>(), 0);
    }
}
