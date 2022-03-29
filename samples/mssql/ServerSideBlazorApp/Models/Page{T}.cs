using System;
using System.Collections.Generic;

namespace ServerSideBlazorApp.Models
{
    public class Page<T> : Page<T, PagingParameters>
    {
        public Page() : base(new PagingParameters(), new List<T>(), 0)
        {
        }

        public Page(PagingParameters parameters, IList<T> page, int totalCount) : base(parameters, page, totalCount)
        {
        }

        public new static Page<T> CreateDefault()
            => new(new PagingParameters { Offset = 0, Limit = 10 }, new List<T>(), 0);
    }
}
