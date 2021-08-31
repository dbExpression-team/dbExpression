using System.Collections.Generic;
using System.Linq;

namespace ServerSideBlazorApp.Models
{
    public class Page<T,U>
        where U : PagingParameters, new()
    {
        public U PagingParameters { get; set; }
        public IList<T> Data { get; set; } = new List<T>();
        public int? TotalCount { get; set; }

        public Page()
        { 
        }

        public Page(U parameters, IList<T> page, int totalCount)
        {
            PagingParameters = parameters;
            Data = page;
            TotalCount = totalCount;
        }

        public static Page<T,U> CreateDefault()
            => new(new U { Offset = 0, Limit = 10 }, new List<T>(), 0);
    }

    public class Page<T> : Page<T, PagingParameters>
    {
        public Page() { }

        public Page(PagingParameters parameters, IList<T> page, int totalCount) : base(parameters, page, totalCount)
        {
        }

        public new static Page<T> CreateDefault()
            => new Page<T> 
            { 
                PagingParameters = new PagingParameters { Offset = 0, Limit = 10 }, 
                Data = new List<T>(), 
                TotalCount = 0 
            };
    }
}
